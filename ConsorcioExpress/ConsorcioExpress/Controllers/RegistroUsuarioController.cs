using ConsorcioExpress.Data;
using ConsorcioExpress.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
    }
}