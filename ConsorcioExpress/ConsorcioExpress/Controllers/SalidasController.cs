using ConsorcioExpress.Data;
using ConsorcioExpress.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConsorcioExpress.Controllers
{
    public class SalidasController : ApiController
    {
        // GET api/<controller>
        public List<Salidas> Get()
        {
            return SalidasData.Listar();
        }
        // GET api/<controller>/5
        public List<Salidas> Get(string id)
        {
            return SalidasData.Obtener(id);
        }
        // POST api/<controller>
        public bool Post([FromBody] Salidas id)
        {
            return SalidasData.RegistrarUsuario(id);
        }
        // PUT api/<controller>/5
        public bool Put([FromBody] Salidas regUsuario)
        {
            return SalidasData.ActualizarUsuario(regUsuario);
        }
        // DELETE api/<controller>/5
        public bool Delete(string id)
        {
            return SalidasData.EliminarUsuario(id);
        }

        [HttpPost]
        [Route("api/salidas")]
        public IActionResult RegistrarSalida([FromBody] Salidas salida)
        {
            // Lógica para llamar al procedimiento almacenado "RegistrarSalida"
            var resultado = EjecutarProcedimiento("REGISTRAR_SALIDA", salida.ReferenciaProducto, salida.Cantidad);
            return (IActionResult)Ok(new { message = "Salida registrada correctamente." });
        }

        private object EjecutarProcedimiento(string v, string referenciaProducto, int cantidad)
        {
            throw new NotImplementedException();
        }
    }
}