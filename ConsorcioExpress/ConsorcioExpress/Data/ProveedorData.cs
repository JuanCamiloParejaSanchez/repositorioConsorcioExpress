using ConsorcioExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConsorcioExpress.Data
{
    public class ProveedorData
    {
        public static bool RegistrarUsuario(Proveedor oProveedor)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "REGISTRAR_PROVEEDOR'" + oProveedor.NitProveedor + "','"
                + oProveedor.NombreProveedor + "','" + oProveedor.Direccion + "','" + oProveedor.Telefono + "','"
                + oProveedor.Correo + "'";
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


        public static bool ActualizarUsuario(Proveedor oProveedor)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "ACTUALIZAR_PROVEEDOR'" + oProveedor.NitProveedor + "','"
                + oProveedor.NombreProveedor + "','" + oProveedor.Direccion + "','" + oProveedor.Telefono + "','"
                + oProveedor.Correo + "'";
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



        public static List<Proveedor> Listar()
        {
            List<Proveedor> oProveedor = new List<Proveedor>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "LISTAR_PROVEEDOR";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    oProveedor.Add(new Proveedor()
                    {
                        NitProveedor = dr["NitProveedor"].ToString(),
                        NombreProveedor = dr["NombreProveedor"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Correo = dr["Correo"].ToString()
                    });
                }
                return oProveedor;
            }
            else
            {
                return oProveedor;
            }
        }


        public static List<Proveedor> Obtener(string id)
        {
            List<Proveedor> oProveedor = new List<Proveedor>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "CONSULTAR_PROVEEDOR'" + id + "'";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    oProveedor.Add(new Proveedor()
                    {
                        NitProveedor = dr["NitProveedor"].ToString(),
                        NombreProveedor = dr["NombreProveedor"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Correo = dr["Correo"].ToString()
                    });
                }
                return oProveedor;
            }
            else
            {
                return oProveedor;
            }
        }
    }
}