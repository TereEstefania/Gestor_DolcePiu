using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestor_DolcePiu.Models
{
    public class DetallePedido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}