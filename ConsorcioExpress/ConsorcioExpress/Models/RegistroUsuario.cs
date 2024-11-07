using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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


        /*public string ConfirmarContrasena { get; set; }*/

    }
}