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
    public class AsignarRutasController : ApiController
    {
        // GET api/<controller>
        public List<AsignarRutas> Get()
        {
            return AsignarRutasData.Listar();
        }
        // GET api/<controller>/5
        public List<AsignarRutas> Get(string id)
        {
            return AsignarRutasData.Obtener(id);
        }
        // POST api/<controller>
        public bool Post([FromBody] AsignarRutas id)
        {
            return AsignarRutasData.RegistrarUsuario(id);
        }
        // PUT api/<controller>/5
        public bool Put([FromBody] AsignarRutas id)
        {
            return AsignarRutasData.ActualizarUsuario(id);
        }
        // DELETE api/<controller>/5
        public bool Delete(string id)
        {
            return AsignarRutasData.EliminarUsuario(id);
        }
    }
}