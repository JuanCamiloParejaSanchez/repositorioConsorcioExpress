using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsorcioExpress.Models
{
    public class Compras
    {
        public string NumeroFactura { get; set; } 
		public string IdAdministrador { get; set; }
        public string IdProveedor { get; set; }
        public string NombreProducto { get; set; }
        public Int32 Total { get; set; }
        public DateTime Fecha { get; set; }
    }
}