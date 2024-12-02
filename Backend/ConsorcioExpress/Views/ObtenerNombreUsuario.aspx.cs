using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsorcioExpress.Views
{
    public partial class ObtenerNombreUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Obtener el nombre del usuario desde la sesión
            string nombreUsuario = Session["Nombres"] != null ? Session["Nombres"].ToString() : "Invitado";

            // Establecer el tipo de contenido como JSON
            Response.ContentType = "application/json";
            Response.Write("{\"Nombres\": \"" + nombreUsuario + "\"}");
            Response.End();
        }
    }
}