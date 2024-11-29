using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;


namespace ConsorcioExpress.Models
{
    public class RegistroUsuario
    {            
        [Required]
        public string IdCodigoUsuario { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        [EmailAddress]
        public string Correo { get; set; }
        public string Cargo { get; set; }
        public string Contrasena { get; set; }

    }
}