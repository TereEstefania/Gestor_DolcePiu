using Gestor_DolcePiu.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Gestor_DolcePiu.DAL;

namespace Gestor_DolcePiu.BLL
{

    public class UsuarioServices
    {
        string patron = "PatronGestorPedidos";

        public bool Login(Usuario usuario)
        {
            
            AccesoDB acceso = new AccesoDB();

            try
            {
                acceso.setearSP("SP_ValidarCredencialUsuario");
                acceso.agregarParametro("@Mail", usuario.credencial.Email);
                
                acceso.agregarParametro("@Contrasenia", usuario.credencial.Pass);
                acceso.agregarParametro("@Patron", patron);
                acceso.ejecutarLector();

                if (acceso.Lector.Read())
                {
                    // Aquí puedes mapear los datos del usuario a un objeto Usuario si es necesario
                    usuario.Id = (int)acceso.Lector["id_usuario"];
                 
                    //if (!(datos.Lector["imagenPerfil"] is DBNull))
                    //   // trainee.ImagenPerfil = (string)datos.Lector["imagenPerfil"];
                    if (!(acceso.Lector["nombre"] is DBNull))
                        usuario.Nombre = (string)acceso.Lector["nombre"];
                    //if (!(acceso.Lector["apellido"] is DBNull))
                    //    usuario.Apellido = (string)acceso.Lector["apellido"];
                    if (!(acceso.Lector["direccion"] is DBNull))
                        usuario.Direccion = (string)acceso.Lector["direccion"];
                    //if (!(acceso.Lector["dni"] is DBNull))
                    //    usuario.Dni = (int)acceso.Lector["dni"];
                    //if (!(acceso.Lector["telefono"] is DBNull))
                    //    usuario.Telefono = (int)acceso.Lector["telefono"];
                    usuario.Zona = new Zonas();
                    if (!(acceso.Lector["id_zona"] is DBNull))
                        usuario.Zona.IdZona = (int)acceso.Lector["id_zona"];
                    //if (!(acceso.Lector["nombre"] is DBNull))
                    //    usuario.Zona.NombreZona = (string)acceso.Lector["nombre"];
                    //usuario.TipoRol = new Rol();
                    //if (!(acceso.Lector["id_rol"] is DBNull))
                    //    usuario.TipoRol.IdRol = (int)acceso.Lector["id_rol"];
                    //if (!(acceso.Lector["nombre"] is DBNull))
                    //    usuario.TipoRol.NombreRol = (string)acceso.Lector["nombre"];
                    if (!(acceso.Lector["Mail"] is DBNull))
                        usuario.credencial.Email = (string)acceso.Lector["Mail"];


                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

               acceso.cerrarConexion();
            }
           
        }
    }
}