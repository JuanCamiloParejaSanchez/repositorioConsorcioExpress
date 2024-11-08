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
            sentencia = "REGISTRAR_COMPRAS'" + regCompras.NumeroFactura + "','" + regCompras.NombreProveedor + "','"
                + regCompras.NitProveedor + "','" + regCompras.Direccion + "','" + regCompras.Telefono + "','"
                + regCompras.Correo + "','" + regCompras.NombreArticulo + "','" + regCompras.Cantidad + "','"
                + regCompras.Total + "'";
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
            sentencia = "ACTUALIZAR_COMPRAS'" + regCompras.NumeroFactura + "','" + regCompras.NombreProveedor + "','"
                + regCompras.NitProveedor + "','" + regCompras.Direccion + "','" + regCompras.Telefono + "','"
                + regCompras.Correo + "','" + regCompras.NombreArticulo + "','" + regCompras.Cantidad + "','"
                + regCompras.Total + "'";
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
                        NombreProveedor = dr["NombreProveedor"].ToString(),
                        NitProveedor = dr["NitProveedor"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        NombreArticulo = dr["NombreArticulo"].ToString(),
                        Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                        Total = Convert.ToInt32(dr["Total"].ToString())

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
                        NombreProveedor = dr["NombreProveedor"].ToString(),
                        NitProveedor = dr["NitProveedor"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        NombreArticulo = dr["NombreArticulo"].ToString(),
                        Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                        Total = Convert.ToInt32(dr["Total"].ToString())

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