using ConsorcioExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConsorcioExpress.Data
{
    public class ServicioData
    {
        public static bool RegistrarUsuario(Servicio regServicio)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "REGISTRAR_SERVICIO'" + regServicio.IdServicio + "','" + regServicio.Descripcion + "'";
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


        public static bool ActualizarUsuario(Servicio regServicio)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "ACTUALIZAR_SERVICIO'" + regServicio.IdServicio + "','" + regServicio.Descripcion + "'";
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
            sentencia = "ELIMINAR_SERVICIO'" + id + "'";
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



        public static List<Servicio> Listar()
        {
            List<Servicio> regServicio = new List<Servicio>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "LISTAR_SERVICIO";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    regServicio.Add(new Servicio()
                    {
                        IdServicio = dr["IdServicio"].ToString(),
                        Descripcion = dr["Descripcion"].ToString()
                    });
                }
                return regServicio;
            }
            else
            {
                return regServicio;
            }
        }


        public static List<Servicio> Obtener(string id)
        {
            List<Servicio> regServicio = new List<Servicio>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "CONSULTAR_SERVICIO'" + id + "'";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    regServicio.Add(new Servicio()
                    {
                        IdServicio = dr["IdServicio"].ToString(),
                        Descripcion = dr["Descripcion"].ToString()                       
                    });
                }
                return regServicio;
            }
            else
            {
                return regServicio;
            }
        }
    }
}