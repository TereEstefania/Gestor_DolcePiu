using Gestor_DolcePiu.DAL;
using Gestor_DolcePiu.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Gestor_DolcePiu.BLL
{
    public class PedidosService
    {
        //public void VisualizarPedidos(int id)
        //{
        //    // Lógica para visualizar pedidos
        //    AccesoDB acceso = new AccesoDB();
            
            
        //    acceso.setearQuery("SELECT p.id_pedido, p.estado, f.fecha FROM dbo.pedido p JOIN dbo.factura f ON p.id_pedido = f.id_pedido WHERE f.id_usuario = @id_usuario;");
        //    acceso.agregarParametro("@id_usuario", id ); // Aquí deberías pasar el ID del usuario logueado
        //}

        public void CargarZonas(ListBox lista)
        {

           // Lógica para cargar zonas
            AccesoDB acceso = new AccesoDB();
            acceso.setearQuery("SELECT DISTINCT id_zona, nombre FROM dbo.zona;");

            acceso.ejecutarLector();
            while (acceso.Lector.Read())
            {
                Zonas zona = new Zonas();
                zona.IdZona = (int)acceso.Lector["id_zona"];
                zona.NombreZona = (string)acceso.Lector["nombre"];

                ListItem item = new ListItem(zona.NombreZona, zona.IdZona.ToString());
                lista.Items.Add(item);
            }
            acceso.cerrarConexion();
        }

        public void CargarTipoPago(RadioButtonList lista)
        {
            // Lógica para cargar tipos de pago
            AccesoDB acceso = new AccesoDB();
            acceso.setearQuery("SELECT DISTINCT id_pago, tipoPago FROM dbo.formaPago;");

            acceso.ejecutarLector();
            while (acceso.Lector.Read())
            {
                TipoPago tipoPago = new TipoPago();
                tipoPago.Id = (int)acceso.Lector["id_pago"];
                tipoPago.Tipo_Pago = (string)acceso.Lector["tipoPago"];

                ListItem item = new ListItem(tipoPago.Tipo_Pago, tipoPago.Id.ToString());
                lista.Items.Add(item);
            }
            acceso.cerrarConexion();
        }

        public void CargarSabor(ListBox lista)
        {
            AccesoDB acceso = new AccesoDB();
            acceso.setearQuery("SELECT nombre FROM dbo.producto WHERE stock > 0");
            acceso.ejecutarLector();

            while (acceso.Lector.Read())
            {
                string sabor = (string)acceso.Lector["nombre"];
                ListItem item = new ListItem(sabor);
                lista.Items.Add(item);
            }
            acceso.cerrarConexion();
        }

        public ProductoSeleccionado AgregarProducto(string sabor, int cantidad)
        {
            AccesoDB acceso = new AccesoDB();
            acceso.setearQuery("SELECT id_producto, precio, stock FROM dbo.producto WHERE nombre = @nombre");
            acceso.agregarParametro("@nombre", sabor);
            acceso.ejecutarLector();
            double precio = 0.0f;
            int stock = 0;
            int idProducto = 0;
            ProductoSeleccionado productosSeleccionados = null;

            if (acceso.Lector.Read())
            {
                precio = (double)acceso.Lector["precio"];
                stock = (int)acceso.Lector["stock"];
                idProducto = (int)acceso.Lector["id_producto"];

            }

            acceso.cerrarConexion();

            if (cantidad <= stock)
            {
   
                productosSeleccionados = new ProductoSeleccionado
                {
                    Id = idProducto,
                    Nombre = sabor,
                    Cantidad = cantidad,
                    Precio = precio
                };

                stock -= cantidad;
                ActualizarStock(sabor, stock);
                
                return productosSeleccionados;
            }
            else
            {
               
                return productosSeleccionados;
                throw new Exception("Cantidad solicitada excede el stock disponible.");
            }

            
        }

        public void ActualizarStock(string sabor, int stock)
        {
            AccesoDB acceso = new AccesoDB();
            acceso.setearQuery("UPDATE dbo.producto SET stock = @stock WHERE nombre = @nombre");
            acceso.agregarParametro("@stock", stock);
            acceso.agregarParametro("@nombre", sabor);
            acceso.ejecutarAccion();
            acceso.cerrarConexion();
        }

        public void ActualizarStockProducto(string id, int cantidad, string sabor)
        {
            AccesoDB acceso = new AccesoDB();
            acceso.setearQuery("Select stock from dbo.producto WHERE id_producto = @Id");
            acceso.agregarParametro("@Id", id);
            acceso.ejecutarLector();
            int stock = 0;

            if (acceso.Lector.Read())
            {
                stock = (int)acceso.Lector["stock"];
            }

            acceso.cerrarConexion();
            stock += cantidad;

            ActualizarStock(sabor, stock);
  
        }   

        public string RegistrarPedido(Usuario usuario, string pago, List<ProductoSeleccionado> productosElegidos)
        {
            AccesoDB acceso = new AccesoDB();
            int idPedido = 0;
            int idPago = 0;

            try
            {
                CrearPedido(usuario.Id);
                idPedido = ObtenerPedido(usuario.Id);
                idPago = ObtenerPago(pago);
                

                // Insertar en la tabla pedido_producto
                CargarPedido(productosElegidos,idPedido);

                // crear la factura
                CrearFactura(idPago, idPedido, usuario.Id, productosElegidos);

                return "Pedido registrado con éxito.";
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }

        public int ObtenerPedido(int idUsuario)
        {

            AccesoDB acceso = new AccesoDB();
            int idPedido = 0;
            try
            {
                acceso.setearQuery("SELECT TOP 1 id_pedido FROM dbo.pedido WHERE id_usuario = @idUsuario;");
                acceso.agregarParametro("@idUsuario", idUsuario);
                acceso.ejecutarLector();
                if (acceso.Lector.Read())
                {
                    idPedido = (int)acceso.Lector["id_pedido"];
                }
                
                acceso.cerrarConexion();

                return idPedido;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                acceso.cerrarConexion();
            }   
        }

        public int ObtenerPago(string nombrePago)
        {

            AccesoDB acceso = new AccesoDB();
            int idPago = 0;
            try
            {
                acceso.setearQuery("SELECT TOP 1 id_pago FROM dbo.formaPago WHERE tipoPago = @nombrePago;");
                acceso.agregarParametro("@nombrePago", nombrePago);
                acceso.ejecutarLector();
                if (acceso.Lector.Read())
                {
                    idPago = (int)acceso.Lector["id_pago"];
                }
                acceso.cerrarConexion();

                return idPago;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }

        public int ObtenerZona(string nombreZona)
        {

            AccesoDB acceso = new AccesoDB();
            int idZona = 0;
            try
            {
                acceso.setearQuery("SELECT TOP 1 id_zona FROM dbo.zona WHERE nombre = @nombreZona;");
                acceso.agregarParametro("@nombreZona", nombreZona);
                acceso.ejecutarLector();
                if (acceso.Lector.Read())
                {
                    idZona = (int)acceso.Lector["id_zona"];
                }
                acceso.cerrarConexion();
                return idZona;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }

        public void CrearPedido(int id)
        {
            AccesoDB acceso = new AccesoDB();
            try
            {
                acceso.setearQuery("INSERT INTO dbo.pedido (id_usuario, estado) VALUES (@id_usuario, 'Pendiente');");
                acceso.agregarParametro("@id_usuario", id); 
                acceso.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                 acceso.cerrarConexion();
            }
        }

        public void CargarPedido(List<ProductoSeleccionado> productosElegidos, int idPedido)
        {
            
            try
            {
                foreach (var producto in productosElegidos)
                {
                    AccesoDB acceso = new AccesoDB();
                    acceso.setearQuery("INSERT INTO dbo.pedido_producto (id_pedido, id_producto, cantidad) VALUES (@id_pedido, @id_producto, @cantidad);");
                    acceso.agregarParametro("@id_pedido", idPedido);
                    acceso.agregarParametro("@id_producto", producto.Id);
                    acceso.agregarParametro("@cantidad", producto.Cantidad);
                    acceso.ejecutarAccion();
                    acceso.cerrarConexion();
                }
            }
            catch (Exception)
            {

                throw;
            }
           

        }

        public void CrearFactura(int idPago, int idPedido, int idUsuario, List<ProductoSeleccionado> listaProductosSeleccionados)
        {
            AccesoDB acceso = new AccesoDB();

            try
            {
                acceso.setearQuery("INSERT INTO dbo.factura (id_pedido, id_usuario, id_pago, totalCompra, fecha) VALUES (@id_pedido, @id_usuario, @id_pago,@totalCompra, @fecha);");
                acceso.agregarParametro("@id_pedido", idPedido);
                acceso.agregarParametro("@id_usuario", idUsuario);
                acceso.agregarParametro("@id_pago", idPago);
                acceso.agregarParametro("@totalCompra", listaProductosSeleccionados.Sum(p => p.Precio * p.Cantidad));
                acceso.agregarParametro("@fecha", DateTime.Now);
                acceso.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }
    }
}