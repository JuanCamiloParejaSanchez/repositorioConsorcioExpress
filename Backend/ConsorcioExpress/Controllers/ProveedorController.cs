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
    public class ProveedorController : ApiController
    {
        // GET api/<controller>
        public List<Proveedor> Get()
        {
            return ProveedorData.Listar();
        }
        // GET api/<controller>/5
        public List<Proveedor> Get(string id)
        {
            return ProveedorData.Obtener(id);
        }
        // POST api/<controller>
        public bool Post([FromBody] Proveedor id)
        {
            return ProveedorData.RegistrarUsuario(id);
        }
        // PUT api/<controller>/5
        public bool Put([FromBody] Proveedor id)
        {
            return ProveedorData.ActualizarUsuario(id);
        }
        // DELETE api/<controller>/5
        public bool Delete(string id)
        {
            return ProveedorData.EliminarUsuario(id);
        }
    }
}