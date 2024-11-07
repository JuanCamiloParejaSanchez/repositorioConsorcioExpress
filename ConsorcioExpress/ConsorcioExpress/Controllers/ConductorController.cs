using ConsorcioExpress.Data;
using ConsorcioExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConsorcioExpress.Controllers
{
    public class ConductorController : ApiController
    {
        // GET api/<controller>
        public List<Conductor> Get()
        {
            return ConductorData.Listar();
        }
        // GET api/<controller>/5
        public List<Conductor> Get(string id)
        {
            return ConductorData.Obtener(id);
        }
        // POST api/<controller>
        public bool Post([FromBody] Conductor id)
        {
            return ConductorData.RegistrarUsuario(id);
        }
        // PUT api/<controller>/5
        public bool Put([FromBody] Conductor id)
        {
            return ConductorData.ActualizarUsuario(id);
        }
        // DELETE api/<controller>/5
        public bool Delete(string id)
        {
            return ConductorData.EliminarUsuario(id);
        }
    }
}