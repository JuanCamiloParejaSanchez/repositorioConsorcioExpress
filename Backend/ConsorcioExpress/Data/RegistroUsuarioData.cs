using ConsorcioExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConsorcioExpress.Data
{
    public class RegistroUsuarioData
    {
        public static bool RegistrarUsuario(RegistroUsuario usuario)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "REGISTRAR_USUARIO'" + usuario.IdCodigoUsuario + "','" + usuario.Documento + "','"
                + usuario.Nombres + "','" + usuario.Apellidos + "','" + usuario.Telefono + "','"
                + usuario.Correo + "','" + usuario.Cargo + "','" + usuario.Contrasena + "'";
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

        public static bool ActualizarUsuario(RegistroUsuario usuario)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "ACTUALIZAR_USUARIO'" + usuario.IdCodigoUsuario + "','" + usuario.Documento + "','"
                + usuario.Nombres + "','" + usuario.Apellidos + "','" + usuario.Telefono + "','"
                + usuario.Correo + "','" + usuario.Cargo + "','" + usuario.Contrasena + "'";
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
            sentencia = "ELIMINAR_USUARIO'" + id + "'";
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

        public static List<RegistroUsuario> Listar()
        {
            List<RegistroUsuario> listar = new List<RegistroUsuario>();
            ConexionBD conexion = new ConexionBD();
            string sentencia = "LISTAR_USUARIOS";
            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                while (dr.Read())
                {
                    listar.Add(new RegistroUsuario()
                    {
                        IdCodigoUsuario = dr["IdCodigoUsuario"].ToString(),
                        Documento = dr["Documento"].ToString(),
                        Nombres = dr["Nombres"].ToString(),
                        Apellidos = dr["Apellidos"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        Cargo = dr["Cargo"].ToString(),
                        Contrasena = dr["Contrasena"].ToString()
                    });
                }
                return listar;
            }
            else
            {
                return listar;
            }
        }

        public static List<RegistroUsuario> Obtener(string id)
        {
            List<RegistroUsuario> listar = new List<RegistroUsuario>();
            ConexionBD conexion = new ConexionBD();
            string sentencia;
            sentencia = "CONSULTAR_USUARIO'" + id + "'";

            if (conexion.Consultar(sentencia, false))
            {
                SqlDataReader dr = conexion.Reader;
                while (dr.Read())
                {
                    listar.Add(new RegistroUsuario()
                    {
                        IdCodigoUsuario = dr["IdCodigoUsuario"].ToString(),
                        Documento = dr["Documento"].ToString(),
                        Nombres = dr["Nombres"].ToString(),
                        Apellidos = dr["Apellidos"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Correo = dr["Correo"].ToString(),
                        Cargo = dr["Cargo"].ToString(),
                        Contrasena = dr["Contrasena"].ToString()
                    });
                }
                return listar;
            }
            else
            {
                return listar;
            }
        }
    }
}