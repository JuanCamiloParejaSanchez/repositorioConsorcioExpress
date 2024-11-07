using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsorcioExpress.Models
{
    public class DetalleCompra
    {
        public string IdArticulo { get; set; }
        public string NumeroFactura { get; set; }
        public Int32 Cantidad { get; set; }
        public Int32 Total { get; set; }
        public DateTime Fecha { get; set; }
    }
}