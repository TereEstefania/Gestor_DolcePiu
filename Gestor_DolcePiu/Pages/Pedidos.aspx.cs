using Gestor_DolcePiu.BLL;
using Gestor_DolcePiu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace Gestor_DolcePiu.Pages
{
    public partial class Pedidos : System.Web.UI.Page
    {
        private string sabor;
        private int cantidad;
        
        TipoPago tipoPago = new TipoPago();
        Usuario usuarioLogueado = new Usuario();
        PedidosService pedidosService = new PedidosService();
        private List<ProductoSeleccionado> listaProductosSeleccionados = new List<ProductoSeleccionado>();

        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioLogueado = (Usuario)Session["UsuarioLogueado"];
            if (usuarioLogueado == null)
            {
                Response.Redirect("/Pages/Login.aspx", false);
            }
            else
            {
                lblBienvenida.Text = "Bienvenido, " + usuarioLogueado.Nombre;
            }
            if (!IsPostBack)
            {
                pedidosService.CargarZonas(lstZonas);
                pedidosService.CargarTipoPago(rblFormaPago);
                pedidosService.CargarSabor(lstSabores);
                // Inicializa la lista de productos en el estado de sesión si es la primera carga de la página
                Session["ListaProductosSeleccionados"] = new List<ProductoSeleccionado>();
            }
            else
            {
                // Recupera la lista de productos del estado de sesión en cada postback
                listaProductosSeleccionados = (List<ProductoSeleccionado>)Session["ListaProductosSeleccionados"];
            }
        }



        protected PedidosService GetPedidosService()
        {
            return pedidosService;
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            ProductoSeleccionado producto = new ProductoSeleccionado();

            lblRegistrado.Text = "";

            if (string.IsNullOrEmpty(lstSabores.SelectedItem?.Text))
            {
                lblRegistrado.Text = "Debe seleccionar un sabor.";
                return;
            }
            if (string.IsNullOrEmpty(txtCantidad.Text) || !int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
            {
                lblRegistrado.Text = "Debe ingresar una cantidad válida.";
                return;
            }

            sabor = lstSabores.SelectedItem.Text;
            cantidad = int.Parse(txtCantidad.Text);

            producto = pedidosService.AgregarProducto(sabor, cantidad);
            if (producto != null)
            {
                listaProductosSeleccionados.Add(producto);
                Session["ListaProductosSeleccionados"] = listaProductosSeleccionados;
                MostrarProductos();
            }
            else
            {
                lblRegistrado.Text = "No hay stock suficiente para el producto seleccionado.";
            }

        }

        private void MostrarProductos()
        {
            // Este método puede actualizar un control en la página, como un GridView o ListView, para mostrar los productos agregados
            gvMostrarProductos.DataSource = listaProductosSeleccionados;
            gvMostrarProductos.DataBind();

            decimal total = (decimal)listaProductosSeleccionados.Sum(p => p.Precio * p.Cantidad);
            lblTotal.Text = "Total: " + total.ToString("C");
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            string zona = lstZonas.SelectedItem.ToString();
            string formaPago = rblFormaPago.SelectedItem.ToString();
            string msj;

            if (string.IsNullOrEmpty(zona))
            {
                lblRegistrado.Text = "Debe seleccionar una zona.";
                return;
            }
            if (string.IsNullOrEmpty(formaPago))
            {
                lblRegistrado.Text = "Debe seleccionar un método de pago.";
                return;
            }
            if (listaProductosSeleccionados.Count == 0)
            {
                lblRegistrado.Text = "Debe agregar al menos un producto al pedido.";
                return;
            }
            listaProductosSeleccionados = (List<ProductoSeleccionado>)Session["ListaProductosSeleccionados"];

            msj = pedidosService.RegistrarPedido(usuarioLogueado, formaPago, listaProductosSeleccionados);

            if (string.IsNullOrEmpty(msj))
            {
                lblRegistrado.Text = "El pedido se registro correctamente! gracias!";//por algo no me escribe
                return;
            }
        }
    }
}