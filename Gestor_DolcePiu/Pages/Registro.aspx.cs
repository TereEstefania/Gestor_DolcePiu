using Gestor_DolcePiu.BLL;
using Gestor_DolcePiu.DAL;
using Gestor_DolcePiu.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gestor_DolcePiu.Pages
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PedidosService pedidosService = new PedidosService();
                pedidosService.CargarZonas(lstZonas);

            }

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            
                Usuario nuevoUsuario = new Usuario();
                UsuarioServices usuarioService = new UsuarioServices();

                nuevoUsuario.Nombre = txtNombre.Text;
                nuevoUsuario.Apellido = txtApellido.Text;
                nuevoUsuario.Direccion = txtDireccion.Text;
                nuevoUsuario.Dni = txtDocumento.Text;
                nuevoUsuario.Telefono = txtTelefono.Text;
                nuevoUsuario.credencial = new Credenciales();
                nuevoUsuario.credencial.Email = txtEmail.Text;
                nuevoUsuario.credencial.Pass = txtContrasenia.Text;
                nuevoUsuario.Zona = new Zonas();
                nuevoUsuario.Zona.IdZona = int.Parse(lstZonas.SelectedValue);
                usuarioService.RegistrarPerfilUsuario(nuevoUsuario);
                
                Session.Add("NuevoUsuario", nuevoUsuario);

                Response.Redirect("/Pages/ok.html", false);

        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}