using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsorcioExpress.Views
{
    public partial class Index : System.Web.UI.Page
    {
        protected void BtnIniciarSesion(object sender, EventArgs e)
        {
            Response.Redirect("http:/127.0.0.1:5500/Inicio_Sesion/inicio_sesion.html");
        }
        protected void BtnRegistrarUsuario(object sender, EventArgs e)
        {
            Response.Redirect("http:/127.0.0.1:5500/Usuarios/registrar_usuario.html");
        }
    }
}