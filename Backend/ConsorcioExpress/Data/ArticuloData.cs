using ConsorcioExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConsorcioExpress.Data
{
    public class ArticuloData
    {
        public static bool RegistrarUsuario(Articulo regArticulo)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "REGISTRAR_ARTICULO'" + regArticulo.IdArticulo + "','" + regArticulo.NombreProducto + "','"
                + regArticulo.Total + "'";
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


        public static bool ActualizarUsuario(Articulo regArticulo)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "ACTUALIZAR_ARTICULO'" + regArticulo.IdArticulo + "','" + regArticulo.NombreProducto + "','"
                + regArticulo.Total + "'";
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
            sentencia = "ELIMINAR_ARTICULO'" + id + "'";
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



        public static List<Articulo> Listar()
        {
            List<Articulo> regArticulo = new List<Articulo>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "LISTAR_ARTICULO";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    regArticulo.Add(new Articulo()
                    {
                        IdArticulo = dr["IdArticulo"].ToString(),
                        NombreProducto = dr["NombreProducto"].ToString(),
                        Total = Convert.ToInt32(dr["Total"].ToString())
                    });
                }
                return regArticulo;
            }
            else
            {
                return regArticulo;
            }
        }


        public static List<Articulo> Obtener(string id)
        {
            List<Articulo> regArticulo = new List<Articulo>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "CONSULTAR_ARTICULO'" + id + "'";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    regArticulo.Add(new Articulo()
                    {
                        IdArticulo = dr["IdArticulo"].ToString(),
                        NombreProducto = dr["NombreProducto"].ToString(),
                        Total = Convert.ToInt32(dr["Total"].ToString())
                    });
                }
                return regArticulo;
            }
            else
            {
                return regArticulo;
            }
        }
    }
}