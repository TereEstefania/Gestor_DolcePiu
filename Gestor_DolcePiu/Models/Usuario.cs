using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestor_DolcePiu.Models
{
    [Serializable]
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public int Dni { get; set; }
        public Credenciales credencial { get; set; }
        public Rol TipoRol { get; set; }
        public Zonas Zona { get; set; }
    }
}