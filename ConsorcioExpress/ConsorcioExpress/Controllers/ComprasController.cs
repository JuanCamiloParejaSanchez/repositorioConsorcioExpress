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
    public class ComprasController : ApiController
    {
        // GET api/<controller>
        public List<Compras> Get()
        {
            return ComprasData.Listar();
        }
        // GET api/<controller>/5
        public List<Compras> Get(string id)
        {
            return ComprasData.Obtener(id);
        }
        // POST api/<controller>
        public bool Post([FromBody] Compras id)
        {
            return ComprasData.RegistrarUsuario(id);
        }
        // PUT api/<controller>/5
        public bool Put([FromBody] Compras id)
        {
            return ComprasData.ActualizarUsuario(id);
        }
        // DELETE api/<controller>/5
        public bool Delete(string id)
        {
            return ComprasData.EliminarUsuario(id);
        }
    }
}