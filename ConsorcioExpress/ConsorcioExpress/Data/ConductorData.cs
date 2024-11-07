using ConsorcioExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConsorcioExpress.Data
{
    public class ConductorData
    {
        public static bool RegistrarUsuario(Conductor regConductor)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "REGISTRAR_CONDUCTOR'" + regConductor.IdConductor + "','" + regConductor.IdAdministrador + "','"
                + regConductor.Documento + "','" + regConductor.Nombres + "','" + regConductor.Apellidos + "'";
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


        public static bool ActualizarUsuario(Conductor regConductor)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "ACTUALIZAR_CONDUCTOR'" + regConductor.IdConductor + "','" + regConductor.IdAdministrador + "','"
                + regConductor.Documento + "','" + regConductor.Nombres + "','" + regConductor.Apellidos + "'";
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
            sentencia = "ELIMINAR_CONDUCTOR'" + id + "'";
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



        public static List<Conductor> Listar()
        {
            List<Conductor> regConductor = new List<Conductor>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "LISTAR_CONDUCTOR";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    regConductor.Add(new Conductor()
                    {
                        IdConductor = dr["IdProveedor"].ToString(),
                        IdAdministrador = dr["NitProveedor"].ToString(),
                        Documento = dr["NombreProveedor"].ToString(),
                        Nombres = dr["Direccion"].ToString(),
                        Apellidos = dr["Telefono"].ToString()                        
                    });
                }
                return regConductor;
            }
            else
            {
                return regConductor;
            }
        }


        public static List<Conductor> Obtener(string id)
        {
            List<Conductor> regConductor = new List<Conductor>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "CONSULTAR_CONDUCTOR'" + id + "'";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    regConductor.Add(new Conductor()
                    {
                        IdConductor = dr["IdProveedor"].ToString(),
                        IdAdministrador = dr["NitProveedor"].ToString(),
                        Documento = dr["NombreProveedor"].ToString(),
                        Nombres = dr["Direccion"].ToString(),
                        Apellidos = dr["Telefono"].ToString()
                    });
                }
                return regConductor;
            }
            else
            {
                return regConductor;
            }
        }
    }
}