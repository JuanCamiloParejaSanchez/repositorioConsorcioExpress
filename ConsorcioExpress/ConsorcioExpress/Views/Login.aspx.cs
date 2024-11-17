using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsorcioExpress.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            // Obtener los valores del formulario
            string documento = txtDocumento.Text;
            string contrasena = txtContrasena.Text;

            // Validar credenciales
            string resultado = ValidarCredenciales(documento, contrasena);

            if (resultado == "Bienvenido")
            {
                // Redirigir si las credenciales son correctas
                Response.Redirect("http:/127.0.0.1:5500/Menu_Principal/menu_principal.html");
            }
            else
            {
                // Mostrar mensaje de error
                lblMensaje.InnerText = "Credenciales incorrectas.";
            }
        }

        private string ValidarCredenciales(string documento, string contrasena)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=CAMILO;Initial Catalog=BD_CONSORCIO_EXPRESS;Integrated Security=True"))
            {
                string query = "SELECT COUNT(*) FROM USUARIO_NUEVO WHERE Documento = @Documento AND Contrasena = @Contrasena";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Documento", documento);
                cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();

                return count > 0 ? "Bienvenido" : "Credenciales incorrectas";
            }
        }
    }

}
