using ConsorcioExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConsorcioExpress.Data
{
    public class AsignarRutasData
    {
        public static bool RegistrarUsuario(AsignarRutas regAsignarRutas)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "REGISTRAR_RUTAS'" + regAsignarRutas.IdConductor + "','" + regAsignarRutas.NumeroBus + "','"
                + regAsignarRutas.IdAdministrador + "','" + regAsignarRutas.Ruta + "','" + regAsignarRutas.Fecha + "'";
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


        public static bool ActualizarUsuario(AsignarRutas regAsignarRutas)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "ACTUALIZAR_RUTAS'" + regAsignarRutas.IdConductor + "','" + regAsignarRutas.NumeroBus + "','"
                + regAsignarRutas.IdAdministrador + "','" + regAsignarRutas.Ruta + "','" + regAsignarRutas.Fecha + "'";
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
            sentencia = "ELIMINAR_RUTAS'" + id + "'";
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



        public static List<AsignarRutas> Listar()
        {
            List<AsignarRutas> regAsignarRutas = new List<AsignarRutas>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "LISTAR_RUTAS";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    regAsignarRutas.Add(new AsignarRutas()
                    {
                        IdConductor = dr["IdConductor"].ToString(),
                        NumeroBus = dr["NumeroBus"].ToString(),
                        IdAdministrador = dr["IdAdministrador"].ToString(),
                        Ruta = dr["Ruta"].ToString(),
                        Fecha = Convert.ToDateTime(dr["Fecha"].ToString())                     
                    });
                }
                return regAsignarRutas;
            }
            else
            {
                return regAsignarRutas;
            }
        }


        public static List<AsignarRutas> Obtener(string id)
        {
            List<AsignarRutas> regAsignarRutas = new List<AsignarRutas>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "CONSULTAR_RUTAS'" + id + "'";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    regAsignarRutas.Add(new AsignarRutas()
                    {
                        IdConductor = dr["IdConductor"].ToString(),
                        NumeroBus = dr["NumeroBus"].ToString(),
                        IdAdministrador = dr["IdAdministrador"].ToString(),
                        Ruta = dr["Ruta"].ToString(),
                        Fecha = Convert.ToDateTime(dr["Fecha"].ToString())
                    });
                }
                return regAsignarRutas;
            }
            else
            {
                return regAsignarRutas;
            }
        }
    }
}