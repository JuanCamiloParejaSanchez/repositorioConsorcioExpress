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
    public class ArticuloController : ApiController
    {
        // GET api/<controller>
        public List<Articulo> Get()
        {
            return ArticuloData.Listar();
        }
        // GET api/<controller>/5
        public List<Articulo> Get(string id)
        {
            return ArticuloData.Obtener(id);
        }
        // POST api/<controller>
        public bool Post([FromBody] Articulo id)
        {
            return ArticuloData.RegistrarUsuario(id);
        }
        // PUT api/<controller>/5
        public bool Put([FromBody] Articulo id)
        {
            return ArticuloData.ActualizarUsuario(id);
        }
        // DELETE api/<controller>/5
        public bool Delete(string id)
        {
            return ArticuloData.EliminarUsuario(id);
        }
    }
}