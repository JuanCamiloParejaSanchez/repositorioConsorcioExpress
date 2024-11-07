using ConsorcioExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConsorcioExpress.Data
{
    public class AdministradorData
    {
        public static bool RegistrarUsuario(Administrador regAdministrador)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "REGISTRAR_ADMINISTRADOR'" + regAdministrador.IdAdministrador + "','" + regAdministrador.Documento + "','"
                + regAdministrador.Nombres + "','" + regAdministrador.Apellidos + "','" + regAdministrador.Telefono + "','"
                + regAdministrador.Correo + "'";
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


        public static bool ActualizarUsuario(Administrador regAdministrador)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "ACTUALIZAR_ADMINISTRADOR'" + regAdministrador.IdAdministrador + "','" + regAdministrador.Documento + "','"
                + regAdministrador.Nombres + "','" + regAdministrador.Apellidos + "','" + regAdministrador.Telefono + "','"
                + regAdministrador.Correo + "'";
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
            sentencia = "ELIMINAR_ADMINISTRADOR'" + id + "'";
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



        public static List<Administrador> Listar()
        {
            List<Administrador> regAdministrador = new List<Administrador>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "LISTAR_ADMINISTRADOR";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    regAdministrador.Add(new Administrador()
                    {
                        IdAdministrador = dr["IdAdministrador"].ToString(),
                        Documento = dr["Documento"].ToString(),
                        Nombres = dr["Nombres"].ToString(),
                        Apellidos = dr["Apellidos"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Correo = dr["Correo"].ToString()
                    });
                }
                return regAdministrador;
            }
            else
            {
                return regAdministrador;
            }
        }


        public static List<Administrador> Obtener(string id)
        {
            List<Administrador> regAdministrador = new List<Administrador>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "CONSULTAR_ADMINISTRADOR '" + id + "'";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    regAdministrador.Add(new Administrador()
                    {
                        IdAdministrador = dr["IdAdministrador"].ToString(),
                        Documento = dr["Documento"].ToString(),
                        Nombres = dr["Nombres"].ToString(),
                        Apellidos = dr["Apellidos"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Correo = dr["Correo"].ToString()
                    });
                }
                return regAdministrador;
            }
            else
            {
                return regAdministrador;
            }
        }
    }
}