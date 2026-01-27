using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestor_DolcePiu.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public Usuario NombreUsuario { get; set; }
        public TipoPago TipoPago { get; set; }
        public double TotalFactura { get; set; }
        public DateTime Fecha { get; set; }
    }
}