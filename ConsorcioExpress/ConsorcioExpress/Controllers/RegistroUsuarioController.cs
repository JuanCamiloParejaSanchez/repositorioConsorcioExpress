using ConsorcioExpress.Data;
using ConsorcioExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace ConsorcioExpress.Controllers
{
    public class RegistroUsuarioController : ApiController
    {
        // GET api/<controller>
        public List<RegistroUsuario> Get()
        {
            return RegistroUsuarioData.Listar();
        }
        // GET api/<controller>/5
        public List<RegistroUsuario> Get(string id)
        {
            return RegistroUsuarioData.Obtener(id);
        }
        // POST api/<controller>
        public bool Post([FromBody] RegistroUsuario id)
        {
            return RegistroUsuarioData.RegistrarUsuario(id);
        }
        // PUT api/<controller>/5
        public bool Put([FromBody] RegistroUsuario regUsuario)
        {
            return RegistroUsuarioData.ActualizarUsuario(regUsuario);
        }
        // DELETE api/<controller>/5
        public bool Delete(string id)
        {
            return RegistroUsuarioData.EliminarUsuario(id);
        }


        // POST api/<controller>

        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login([FromBody] InicioSesion inicioSesion)
        {
            string coneccion = "Data Source=CAMILO;Initial Catalog=DBCONSORCIO_EXPRESS;Integrated Security=True";
            bool autenticado = false;

            using (SqlConnection connection = new SqlConnection(coneccion))
            {
                connection.Open();
                string query = "SELECT COUNT(1) FROM USUARIO_NUEVO WHERE documento=@documento AND contrasena=@contrasena";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@documento", inicioSesion.Documento);
                    command.Parameters.AddWithValue("@contrasena", inicioSesion.Contrasena);
                    autenticado = Convert.ToInt32(command.ExecuteScalar()) == 1;
                }
            }

            if (autenticado)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new { success = false });
            }
        }
        public class InicioSesion
        {
            public string Documento { get; set; }
            public string Contrasena { get; set; }
        }        
    }
}