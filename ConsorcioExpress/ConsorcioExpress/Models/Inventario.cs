using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsorcioExpress.Models
{
    public class Inventario
    {
        public string ReferenciaProducto { get; set; }
        public string NombreProducto { get; set; }
        public Int32 Cantidad { get; set; }
    }
}