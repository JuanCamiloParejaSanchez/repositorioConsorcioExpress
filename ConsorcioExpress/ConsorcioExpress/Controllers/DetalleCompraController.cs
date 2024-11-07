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
    public class DetalleCompraController : ApiController
    {
        // GET api/<controller>
        public List<DetalleCompra> Get()
        {
            return DetalleCompraData.Listar();
        }
        // GET api/<controller>/5
        public List<DetalleCompra> Get(string id)
        {
            return DetalleCompraData.Obtener(id);
        }
        // POST api/<controller>
        public bool Post([FromBody] DetalleCompra id)
        {
            return DetalleCompraData.RegistrarUsuario(id);
        }
        // PUT api/<controller>/5
        public bool Put([FromBody] DetalleCompra id)
        {
            return DetalleCompraData.ActualizarUsuario(id);
        }
        // DELETE api/<controller>/5
        public bool Delete(string id)
        {
            return DetalleCompraData.EliminarUsuario(id);
        }
    }
}