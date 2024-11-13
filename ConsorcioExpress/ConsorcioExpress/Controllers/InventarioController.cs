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
    public class InventarioController : ApiController
    {
        // GET api/<controller>
        public List<Inventario> Get()
        {
            return InventarioData.Listar();
        }
        // GET api/<controller>/5
        public List<Inventario> Get(string id)
        {
            return InventarioData.Obtener(id);
        }
        // POST api/<controller>
        public bool Post([FromBody] Inventario id)
        {
            return InventarioData.RegistrarUsuario(id);
        }
        // PUT api/<controller>/5
        public bool Put([FromBody] Inventario regProducto)
        {
            return InventarioData.ActualizarUsuario(regProducto);
        }
        // DELETE api/<controller>/5
        public bool Delete(string id)
        {
            return InventarioData.EliminarUsuario(id);
        }
    }
}