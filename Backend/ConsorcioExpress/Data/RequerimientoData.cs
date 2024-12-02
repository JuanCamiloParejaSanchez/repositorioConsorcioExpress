using ConsorcioExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConsorcioExpress.Data
{
    public class RequerimientoData
    {
        public static bool RegistrarUsuario(Requerimiento regRequerimiento)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "REGISTRAR_REQUERIMIENTO'" + regRequerimiento.NumeroBus + "','" + regRequerimiento.IdServicio + "'";
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


        public static bool ActualizarUsuario(Requerimiento regRequerimiento)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "ACTUALIZAR_REQUERIMIENTO'" + regRequerimiento.NumeroBus + "','" + regRequerimiento.IdServicio + "'";
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
            sentencia = "ELIMINAR_REQUERIMIENTO'" + id + "'";
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



        public static List<Requerimiento> Listar()
        {
            List<Requerimiento> regRequerimiento = new List<Requerimiento>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "LISTAR_REQUERIMIENTO";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    regRequerimiento.Add(new Requerimiento()
                    {
                        NumeroBus = dr["NumeroBus"].ToString(),
                        IdServicio = dr["IdServicio"].ToString()                        
                    });
                }
                return regRequerimiento;
            }
            else
            {
                return regRequerimiento;
            }
        }


        public static List<Requerimiento> Obtener(string id)
        {
            List<Requerimiento> regRequerimiento = new List<Requerimiento>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "CONSULTAR_REQUERIMIENTO'" + id + "'";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    regRequerimiento.Add(new Requerimiento()
                    {
                        NumeroBus = dr["NumeroBus"].ToString(),
                        IdServicio = dr["IdServicio"].ToString()
                    });
                }
                return regRequerimiento;
            }
            else
            {
                return regRequerimiento;
            }
        }
    }
}