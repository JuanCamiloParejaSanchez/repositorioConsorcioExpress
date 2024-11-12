using ConsorcioExpress.Data;
using ConsorcioExpress.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
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
        public List<Inventario> Get(string producto)
        {
            return InventarioData.Obtener(producto);
        }
        // POST api/<controller>
        public bool Post([FromBody] Inventario producto)
        {
            return InventarioData.RegistrarUsuario(producto);
        }
        // PUT api/<controller>/5
        public bool Put([FromBody] Inventario producto)
        {
            return InventarioData.ActualizarUsuario(producto);
        }
        // DELETE api/<controller>/5
        public bool Delete(string id)
        {
            return InventarioData.EliminarUsuario(id);
        }

        [HttpPost]
        public IHttpActionResult ActualizarInventarioSalida(string nombreArticulo, int cantidad)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString))
            {
                var command = new SqlCommand("ACTUALIZAR_INVENTARIO_SALIDA", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NombreArticulo", nombreArticulo);
                command.Parameters.AddWithValue("@Cantidad", cantidad);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return Ok("Inventario actualizado exitosamente.");
        }
    }
}