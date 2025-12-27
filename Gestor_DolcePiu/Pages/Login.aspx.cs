using Gestor_DolcePiu.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gestor_DolcePiu.BLL;

namespace Gestor_DolcePiu.Pages
{
    public partial class Login : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.credencial = new Credenciales();
            usuario.credencial.Email = txtEmail.Text;
            usuario.credencial.Pass = txtPass.Text;

            UsuarioServices usuarioService = new UsuarioServices();

            if (usuarioService.Login(usuario))
            {
                // Guardar el usuario en la sesión
                Session.Add("UsuarioLogueado", usuario);

                // Redirigir a la página principal o dashboard
                Response.Redirect("/Pages/Pedidos.aspx",false);
                lblMensaje.Visible = false;
            }
            else
            {
                // Mostrar mensaje de error
                lblMensaje.Text = "Email o contraseña incorrectos.";
                lblMensaje.Visible = true;
            }
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Page/Registro.aspx", false);
        }
    }
}