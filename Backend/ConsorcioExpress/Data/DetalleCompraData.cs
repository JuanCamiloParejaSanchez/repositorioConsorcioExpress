using ConsorcioExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConsorcioExpress.Data
{
    public class DetalleCompraData
    {
        public static bool RegistrarUsuario(DetalleCompra regDetalleCompra)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "REGISTRAR_PROVEEDOR'" + regDetalleCompra.IdArticulo + "','" + regDetalleCompra.NumeroFactura + "','"
                + regDetalleCompra.Cantidad + "','" + regDetalleCompra.Total + "','" + regDetalleCompra.Fecha + "'";
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


        public static bool ActualizarUsuario(DetalleCompra regDetalleCompra)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "REGISTRAR_PROVEEDOR'" + regDetalleCompra.IdArticulo + "','" + regDetalleCompra.NumeroFactura + "','"
                + regDetalleCompra.Cantidad + "','" + regDetalleCompra.Total + "','" + regDetalleCompra.Fecha + "'";
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
            sentencia = "ELIMINAR_PROVEEDOR'" + id + "'";
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



        public static List<DetalleCompra> Listar()
        {
            List<DetalleCompra> regDetalleCompra = new List<DetalleCompra>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "LISTAR_PROVEEDOR";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    regDetalleCompra.Add(new DetalleCompra()
                    {
                        IdArticulo = dr["IdArticulo"].ToString(),
                        NumeroFactura = dr["NumeroFactura"].ToString(),
                        Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                        Total = Convert.ToInt32(dr["Total"].ToString()),                       
                        Fecha = Convert.ToDateTime(dr["Fecha"].ToString())
                    });
                }
                return regDetalleCompra;
            }
            else
            {
                return regDetalleCompra;
            }
        }


        public static List<DetalleCompra> Obtener(string id)
        {
            List<DetalleCompra> regDetalleCompra = new List<DetalleCompra>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "CONSULTAR_PROVEEDOR'" + id + "'";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    regDetalleCompra.Add(new DetalleCompra()
                    {
                        IdArticulo = dr["IdArticulo"].ToString(),
                        NumeroFactura = dr["NumeroFactura"].ToString(),
                        Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                        Total = Convert.ToInt32(dr["Total"].ToString()),
                        Fecha = Convert.ToDateTime(dr["Fecha"].ToString())
                    });
                }
                return regDetalleCompra;
            }
            else
            {
                return regDetalleCompra;
            }
        }
    }
}