using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsorcioExpress.Models
{
    public class Proveedor
    {
        public string IdProveedor { get; set; }
        public string NitProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}