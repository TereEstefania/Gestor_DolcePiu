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
            }
        }
    }
}