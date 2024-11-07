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
    public class AdministradorController : ApiController
    {
        // GET api/<controller>
        public List<Administrador> Get()
        {
            return AdministradorData.Listar();
        }
        // GET api/<controller>/5
        public List<Administrador> Get(string id)
        {
            return AdministradorData.Obtener(id);
        }
        // POST api/<controller>
        public bool Post([FromBody] Administrador id)
        {
            return AdministradorData.RegistrarUsuario(id);
        }
        // PUT api/<controller>/5
        public bool Put([FromBody] Administrador id)
        {
            return AdministradorData.ActualizarUsuario(id);
        }
        // DELETE api/<controller>/5
        public bool Delete(string id)
        {
            return AdministradorData.EliminarUsuario(id);
        }
    }
}