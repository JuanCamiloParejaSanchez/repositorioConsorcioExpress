using ConsorcioExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConsorcioExpress.Data
{
    public class InventarioData
    {
        public static bool RegistrarUsuario(Inventario producto)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "REGISTRAR_PRODUCTO'" + producto.ReferenciaProducto + "','" + producto.NombreProducto + "','"
                + producto.Precio + "','" + producto.Cantidad + "'";
            if (!objEst.EjecutarSentencia(sentencia, false))
            {
                objEst = null;
                return false;
            }
            else
            {
                objEst = null;
                return true;
            }

        }

        public static bool ActualizarUsuario(Inventario producto)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "ACTUALIZAR_PRODUCTO'" + producto.ReferenciaProducto + "','" + producto.NombreProducto + "','"
                + producto.Precio + "','" + producto.Cantidad + "'";
            if (!objEst.EjecutarSentencia(sentencia, false))
            {
                objEst = null;
                return false;
            }
            else
            {
                objEst = null;
                return true;
            }
        }

        public static bool EliminarUsuario(string id)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "ELIMINAR_PRODUCTO'" + id + "'";
            if (!objEst.EjecutarSentencia(sentencia, false))
            {
                objEst = null;
                return false;
            }
            else
            {
                objEst = null;
                return true;
            }
        }

        public static List<Inventario> Listar()
        {
            List<Inventario> listar = new List<Inventario>();
            ConexionBD conexion = new ConexionBD();
            string sentencia = "LISTAR_PRODUCTO";
            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                while (dr.Read())
                {
                    listar.Add(new Inventario()
                    {
                        ReferenciaProducto = dr["ReferenciaProducto"].ToString(),
                        NombreProducto = dr["NombreProducto"].ToString(),
                        Precio = dr["Precio"].ToString(),
                        Cantidad = Convert.ToInt32(dr["Cantidad"].ToString())
                    });
                }
                return listar;
            }
            else
            {
                return listar;
            }
        }

        public static List<Inventario> Obtener(string id)
        {
            List<Inventario> listar = new List<Inventario>();
            ConexionBD conexion = new ConexionBD();
            string sentencia;
            sentencia = "CONSULTAR_PRODUCTO'" + id + "'";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                while (dr.Read())
                {
                    listar.Add(new Inventario()
                    {
                        ReferenciaProducto = dr["ReferenciaProducto"].ToString(),
                        NombreProducto = dr["NombreProducto"].ToString(),
                        Precio = dr["Precio"].ToString(),
                        Cantidad = Convert.ToInt32(dr["Cantidad"].ToString())
                    });
                }
                return listar;
            }
            else
            {
                return listar;
            }
        }
    }
}