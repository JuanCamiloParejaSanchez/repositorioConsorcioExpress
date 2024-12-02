using ConsorcioExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConsorcioExpress.Data
{
    public class SalidasData
    {
        public static bool RegistrarUsuario(Salidas regSalidas)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "REGISTRAR_SALIDA'" + regSalidas.IdSalida + "','" + regSalidas.ReferenciaProducto + "','" + regSalidas.Cantidad + "'";
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


        public static bool ActualizarUsuario(Salidas regSalidas)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "ACTUALIZAR_SALIDA'" + regSalidas.IdSalida + "','" + regSalidas.ReferenciaProducto + "','" + regSalidas.Cantidad + "'";
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
            sentencia = "ELIMINAR_SALIDA'" + id + "'";
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



        public static List<Salidas> Listar()
        {
            List<Salidas> listar = new List<Salidas>();
            ConexionBD conexion = new ConexionBD();
            string sentencia = "LISTAR_SALIDA";
            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                while (dr.Read())
                {
                    listar.Add(new Salidas()
                    {
                        IdSalida = Convert.ToInt32(dr["IdSalida"].ToString()),
                        ReferenciaProducto = dr["ReferenciaProducto"].ToString(),
                        Cantidad = Convert.ToInt32(dr["Total"].ToString())
                    });
                }
                return listar;
            }
            else
            {
                return listar;
            }
        }


        public static List<Salidas> Obtener(string id)
        {
            List<Salidas> listar = new List<Salidas>();
            ConexionBD conexion = new ConexionBD();
            string sentencia;
            sentencia = "CONSULTAR_SALIDA'" + id + "'";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                while (dr.Read())
                {
                    listar.Add(new Salidas()
                    {
                        IdSalida = Convert.ToInt32(dr["IdSalida"].ToString()),
                        ReferenciaProducto = dr["ReferenciaProducto"].ToString(),
                        Cantidad = Convert.ToInt32(dr["Total"].ToString())
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