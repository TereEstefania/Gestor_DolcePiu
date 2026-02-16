using Gestor_DolcePiu.BLL;
using Gestor_DolcePiu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gestor_DolcePiu.Pages
{
    public partial class Perfil : System.Web.UI.Page
    {
        Usuario usuarioLogueado;
        UsuarioServices usuarioService = new UsuarioServices();

        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioLogueado = (Usuario)Session["UsuarioLogueado"];

            if (usuarioLogueado == null)
            {
                Response.Redirect("/Pages/Login.aspx", false);
                return;
            }
            else
            {
                verPerfil();
            }

        }
 
        protected void verPerfil()
        {
            Usuario perfil = new Usuario();
            perfil = usuarioService.VisualizarUsuario(usuarioLogueado.Id);

            lblNombre.Text = "Nombre: " + perfil.Nombre; 
            lblApellido.Text = "Apellido: " + perfil.Apellido;
            lblDireccion.Text = "Direccion: " + perfil.Direccion;
            lblZona.Text = "Zona: " + perfil.Zona.NombreZona;
            lblEmail.Text = "Email: " + usuarioLogueado.credencial.Email;
            lblTelefono.Text = "Telefono: " + perfil.Telefono.ToString();
            lblDni.Text = "Dni: " + perfil.Dni.ToString();
        }
    }
}