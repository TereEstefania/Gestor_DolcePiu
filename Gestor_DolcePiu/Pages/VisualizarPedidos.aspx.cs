using Gestor_DolcePiu.Models;
using Gestor_DolcePiu.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Gestor_DolcePiu.Pages
{
    public partial class VisualizarPedidos : System.Web.UI.Page
    {
        Usuario usuarioLogueado;
        private List<DetallePedido> destallePedidos = new List<DetallePedido>();
        PedidosService servicio = new PedidosService();

        public bool clickeado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioLogueado = (Usuario)Session["UsuarioLogueado"];
            clickeado = false;

            if (usuarioLogueado == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                Visualizar();
            }
        }

        private void Visualizar()
        {
            destallePedidos = servicio.ListarPedidos(usuarioLogueado.Id);
            gdvPedidos.DataSource = destallePedidos;
            gdvPedidos.DataBind();
        }

        private void VisualizarPedido()
        {
            
        }

        protected void gdvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            DetallePedido detalle = new DetallePedido();
            Factura factura = new Factura();
            int id = (int)gdvPedidos.SelectedDataKey.Value;
            clickeado = true;
            lblFactura.Text = id.ToString();
            factura = servicio.ObtenerFactura(id);

            lblCliente.Text = factura.NombreUsuario.Nombre;
            lblFecha.Text = factura.Fecha.ToShortDateString();
            lblPago.Text = factura.TipoPago.Tipo_Pago;
            lblTotal.Text = factura.TotalFactura.ToString();

            gdvDetallesPedido.DataSource = servicio.ListarProductosPedidos(id);
            gdvDetallesPedido.DataBind();

        }
    }
}