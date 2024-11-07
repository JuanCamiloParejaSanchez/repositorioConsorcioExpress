using ConsorcioExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConsorcioExpress.Data
{
    public class ComprasData
    {
        public static bool RegistrarUsuario(Compras regCompras)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "REGISTRAR_COMPRAS'" + regCompras.NumeroFactura + "','" + regCompras.IdAdministrador + "','"
                + regCompras.IdProveedor + "','" + regCompras.NombreProducto + "','" + regCompras.Total + "','"
                + regCompras.Fecha + "'";
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


        public static bool ActualizarUsuario(Compras regCompras)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "ACTUALIZAR_COMPRAS'" + regCompras.NumeroFactura + "','" + regCompras.IdAdministrador + "','"
                + regCompras.IdProveedor + "','" + regCompras.NombreProducto + "','" + regCompras.Total + "','"
                + regCompras.Fecha + "'";
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
            sentencia = "ELIMINAR_COMPRAS'" + id + "'";
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



        public static List<Compras> Listar()
        {
            List<Compras> regCompras = new List<Compras>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "LISTAR_COMPRAS";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    regCompras.Add(new Compras()
                    {
                        NumeroFactura = dr["NumeroFactura"].ToString(),
                        IdAdministrador = dr["IdAdministrador"].ToString(),
                        IdProveedor = dr["IdProveedor"].ToString(),
                        NombreProducto = dr["NombreProducto"].ToString(),
                        Total = Convert.ToInt32(dr["Total"].ToString()),
                        Fecha = Convert.ToDateTime(dr["Fecha"].ToString())
                    });
                }
                return regCompras;
            }
            else
            {
                return regCompras;
            }
        }


        public static List<Compras> Obtener(string id)
        {
            List<Compras> regCompras = new List<Compras>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "CONSULTAR_COMPRAS'" + id + "'";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    regCompras.Add(new Compras()
                    {
                        NumeroFactura = dr["NumeroFactura"].ToString(),
                        IdAdministrador = dr["IdAdministrador"].ToString(),
                        IdProveedor = dr["IdProveedor"].ToString(),
                        NombreProducto = dr["NombreProducto"].ToString(),
                        Total = Convert.ToInt32(dr["Total"].ToString()),
                        Fecha = Convert.ToDateTime(dr["Fecha"].ToString())
                    });
                }
                return regCompras;
            }
            else
            {
                return regCompras;
            }
        }
    }
}