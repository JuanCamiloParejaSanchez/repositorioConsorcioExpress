using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsorcioExpress.Models
{
    public class Compras
    {
        public string NumeroFactura { get; set; }
        public string ReferenciaProducto { get; set; } 
		public string NombreArticulo { get; set; }
        public Int32 Cantidad { get; set; }
        public string NombreProveedor { get; set; }
        public string NitProveedor { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public Int32 Total { get; set; }
        
    }
}