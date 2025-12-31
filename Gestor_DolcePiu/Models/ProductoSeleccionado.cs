using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestor_DolcePiu.Models
{
    public class ProductoSeleccionado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        
    }
}