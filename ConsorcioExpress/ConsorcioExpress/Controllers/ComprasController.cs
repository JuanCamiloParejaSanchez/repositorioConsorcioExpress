using ConsorcioExpress.Data;
using ConsorcioExpress.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ConsorcioExpress.Controllers
{
    public class ComprasController : ApiController
    {
        // GET api/compras
        public IHttpActionResult Get()
        {
            var compras = ComprasData.Listar();
            if (compras == null || compras.Count == 0)
            {
                return NotFound(); // Retorna 404 si no hay compras
            }
            return Ok(compras); // Retorna 200 con la lista de compras
        }

        // GET api/compras/{id}
        public IHttpActionResult Get(string id)
        {
            var compra = ComprasData.Obtener(id);
            if (compra == null)
            {
                return NotFound(); // Retorna 404 si la compra no existe
            }
            return Ok(compra); // Retorna 200 con los datos de la compra
        }

        // POST api/compras
        public IHttpActionResult Post([FromBody] Compras compra)
        {
            if (compra == null)
            {
                return BadRequest("Datos de compra inválidos."); // Retorna 400 si los datos son nulos o inválidos
            }

            bool resultado = ComprasData.RegistrarUsuario(compra);
            if (!resultado)
            {
                return BadRequest("No se pudo registrar la compra.");
            }
            return Ok("Compra registrada correctamente.");
        }

        // PUT api/compras/{id}
        public IHttpActionResult Put([FromBody] Compras compra)
        {
            if (compra == null)
            {
                return BadRequest("Datos de compra inválidos."); // Datos nulos
            }

            //compra.NumeroFactura = id; // Asegúrate de asignar el ID correcto

            bool resultado = ComprasData.ActualizarUsuario(compra);
            if (!resultado)
            {
                return BadRequest("No se pudo actualizar la compra.");
            }

            return Ok("Compra actualizada correctamente.");
        }


        // DELETE api/compras/{id}
        public IHttpActionResult Delete(string id)
        {
            bool resultado = ComprasData.EliminarUsuario(id);
            if (!resultado)
            {
                return BadRequest("No se pudo eliminar la compra.");
            }
            return Ok("Compra eliminada correctamente.");
        }
    }
}













//using ConsorcioExpress.Data;
//using ConsorcioExpress.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Routing;
//using Microsoft.AspNetCore.Mvc;

//namespace ConsorcioExpress.Controllers
//{
//    public class ComprasController : ApiController
//    {
//        // GET api/<controller>
//        public List<Compras> Get()
//        {
//            return ComprasData.Listar();
//        }
//        // GET api/<controller>/5
//        public List<Compras> Get(string id)
//        {
//            return ComprasData.Obtener(id);
//        }
//        // POST api/<controller>
//        public bool Post([FromBody] Compras id)
//        {
//            return ComprasData.RegistrarUsuario(id);
//        }
//        // PUT api/<controller>/5
//        public bool Put([FromBody] Compras id)
//        {
//            return ComprasData.ActualizarUsuario(id);
//        }
//        // DELETE api/<controller>/5
//        public bool Delete(string id)
//        {
//            return ComprasData.EliminarUsuario(id);
//        }

//        [HttpPost]
//        [Route("api/compras")]
//        public IActionResult RegistrarCompra([FromBody] Compras compra)
//        {
//            // Lógica para llamar al procedimiento almacenado "RegistrarCompra"
//            var resultado = EjecutarProcedimiento("REGISTRAR_COMPRAS", compra.ReferenciaProducto, compra.Cantidad);
//            return (IActionResult)Ok(new { message = "Compra registrada correctamente." });
//        }
//        private object EjecutarProcedimiento(string v, string referenciaProducto, int cantidad)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}