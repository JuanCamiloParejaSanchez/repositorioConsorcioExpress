using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsorcioExpress.Models
{
    public class AsignarRutas
    {
        public string IdConductor { get; set; }
        public string NumeroBus { get; set; }
        public string IdAdministrador { get; set; }
        public string Ruta { get; set; }
        public DateTime Fecha { get; set; }
}
}