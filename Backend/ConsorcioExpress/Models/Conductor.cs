using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ConsorcioExpress.Models
{
    public class Conductor
    {
        public string IdConductor { get; set; }
        public string IdAdministrador { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
    }
}