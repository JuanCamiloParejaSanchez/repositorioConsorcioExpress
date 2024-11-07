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
    public class VehiculoController : ApiController
    {
        // GET api/<controller>
        public List<Vehiculo> Get()
        {
            return VehiculoData.Listar();
        }
        // GET api/<controller>/5
        public List<Vehiculo> Get(string id)
        {
            return VehiculoData.Obtener(id);
        }
        // POST api/<controller>
        public bool Post([FromBody] Vehiculo id)
        {
            return VehiculoData.RegistrarUsuario(id);
        }
        // PUT api/<controller>/5
        public bool Put([FromBody] Vehiculo id)
        {
            return VehiculoData.ActualizarUsuario(id);
        }
        // DELETE api/<controller>/5
        public bool Delete(string id)
        {
            return VehiculoData.EliminarUsuario(id);
        }
    }
}