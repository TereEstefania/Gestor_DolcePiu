using Gestor_DolcePiu.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Gestor_DolcePiu.DAL;
using System.Drawing;
using static System.Collections.Specialized.BitVector32;

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

                  
                    if (!(acceso.Lector["nombre"] is DBNull))
                        usuario.Nombre = (string)acceso.Lector["nombre"];
                   
                    if (!(acceso.Lector["direccion"] is DBNull))
                        usuario.Direccion = (string)acceso.Lector["direccion"];
                 
                    usuario.Zona = new Zonas();
                    if (!(acceso.Lector["id_zona"] is DBNull))
                        usuario.Zona.IdZona = (int)acceso.Lector["id_zona"];
               
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

        public int RegistrarUsuario(Usuario nuevoUsuario)
        {
            AccesoDB acceso = new AccesoDB();
            int id_credencialUsuario = 0;

            try
            {
                acceso.setearSP("SP_CredencialUsuario");
                acceso.agregarParametro("@Mail", nuevoUsuario.credencial.Email);
                acceso.agregarParametro("@Contrasenia", nuevoUsuario.credencial.Pass);
                acceso.agregarParametro("@Patron", patron);
                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@id_credencialUsuario";
                outputParameter.SqlDbType = SqlDbType.Int;
                outputParameter.Direction = ParameterDirection.Output;
                acceso.Comando.Parameters.Add(outputParameter);
                acceso.ejecutarAccion();

                if (outputParameter.Value != DBNull.Value)
                {
                    id_credencialUsuario = Convert.ToInt32(outputParameter.Value);
                }

                return id_credencialUsuario;
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

        public void RegistrarPerfilUsuario(Usuario usuario)
        {
            AccesoDB acceso = new AccesoDB();
          
            int id_credencialUsuario = 0;
            try
            {
                acceso.setearSP("SP_CredencialUsuario");

                acceso.agregarParametro("@Mail", usuario.credencial.Email);
                acceso.agregarParametro("@Contrasenia", usuario.credencial.Pass);
                acceso.agregarParametro("@Patron", patron);
                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@id_credencialUsuario";
                outputParameter.SqlDbType = SqlDbType.Int;
                outputParameter.Direction = ParameterDirection.Output;
                acceso.Comando.Parameters.Add(outputParameter);
                acceso.ejecutarAccion();

                acceso.cerrarConexion();

                if (outputParameter.Value != DBNull.Value)
                {
                    id_credencialUsuario = Convert.ToInt32(outputParameter.Value);
                }
                acceso.Comando.Parameters.Clear();

                acceso.setearSP("SP_AgregarUsuario");

                acceso.agregarParametro("@Nombre", usuario.Nombre);
                acceso.agregarParametro("@Apellido", usuario.Apellido);
                acceso.agregarParametro("@Direccion", usuario.Direccion);
                acceso.agregarParametro("@Dni", usuario.Dni);
                acceso.agregarParametro("@Telefono", usuario.Telefono);
                acceso.agregarParametro("@id_zona", usuario.Zona.IdZona);
                acceso.agregarParametro("@id_rol", 3); // Rol predeterminado para nuevos usuarios
                acceso.agregarParametro("@id_credencialUsuario", id_credencialUsuario);

                acceso.ejecutarAccion();

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