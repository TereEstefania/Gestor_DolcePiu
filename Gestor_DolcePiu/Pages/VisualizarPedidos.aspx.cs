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

        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioLogueado = (Usuario)Session["UsuarioLogueado"];

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
            CargarPedidosEnGrilla();
        }

        private void CargarPedidosEnGrilla()
        {
            gdvPedidos.DataSource = destallePedidos;
            gdvPedidos.DataBind();
        }

        protected void gdvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}