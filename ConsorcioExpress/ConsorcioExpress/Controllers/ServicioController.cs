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
    public class ServicioController : ApiController
    {
        // GET api/<controller>
        public List<Servicio> Get()
        {
            return ServicioData.Listar();
        }
        // GET api/<controller>/5
        public List<Servicio> Get(string id)
        {
            return ServicioData.Obtener(id);
        }
        // POST api/<controller>
        public bool Post([FromBody] Servicio id)
        {
            return ServicioData.RegistrarUsuario(id);
        }
        // PUT api/<controller>/5
        public bool Put([FromBody] Servicio id)
        {
            return ServicioData.ActualizarUsuario(id);
        }
        // DELETE api/<controller>/5
        public bool Delete(string id)
        {
            return ServicioData.EliminarUsuario(id);
        }
    }
}