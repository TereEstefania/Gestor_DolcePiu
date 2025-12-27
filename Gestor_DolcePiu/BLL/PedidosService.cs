using Gestor_DolcePiu.DAL;
using Gestor_DolcePiu.Models;
using System;
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
        }
        
    }
}