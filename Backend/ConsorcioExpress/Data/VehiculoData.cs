using ConsorcioExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConsorcioExpress.Data
{
    public class VehiculoData
    {
        public static bool RegistrarUsuario(Vehiculo regVehiculo)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "REGISTRAR_VEHICULO'" + regVehiculo.NumeroBus + "','" + regVehiculo.IdAdministrador + "','"
                + regVehiculo.ModeloBus + "','" + regVehiculo.NumeroPasajeros + "','" + regVehiculo.Placa + "'";
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


        public static bool ActualizarUsuario(Vehiculo regVehiculo)
        {
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "ACTUALIZAR_VEHICULO'" + regVehiculo.NumeroBus + "','" + regVehiculo.IdAdministrador + "','"
                + regVehiculo.ModeloBus + "','" + regVehiculo.NumeroPasajeros + "','" + regVehiculo.Placa + "'";
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
            sentencia = "ELIMINAR_VEHICULO'" + id + "'";
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



        public static List<Vehiculo> Listar()
        {
            List<Vehiculo> regVehiculo = new List<Vehiculo>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "LISTAR_VEHICULO";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    regVehiculo.Add(new Vehiculo()
                    {
                        NumeroBus = dr["NumeroBus"].ToString(),
                        IdAdministrador = dr["IdAdministrador"].ToString(),
                        ModeloBus = dr["ModeloBus"].ToString(),
                        NumeroPasajeros = dr["NumeroPasajeros"].ToString(),
                        Placa = dr["Placa"].ToString()                        
                    });
                }
                return regVehiculo;
            }
            else
            {
                return regVehiculo;
            }
        }


        public static List<Vehiculo> Obtener(string id)
        {
            List<Vehiculo> regVehiculo = new List<Vehiculo>();
            ConexionBD objEst = new ConexionBD();
            string sentencia;
            sentencia = "CONSULTAR_VEHICULO '" + id + "'";
            if (objEst.Consultar(sentencia, false))
            {
                SqlDataReader dr = objEst.Reader;
                while (dr.Read())
                {
                    regVehiculo.Add(new Vehiculo()
                    {
                        NumeroBus = dr["NumeroBus"].ToString(),
                        IdAdministrador = dr["IdAdministrador"].ToString(),
                        ModeloBus = dr["ModeloBus"].ToString(),
                        NumeroPasajeros = dr["NumeroPasajeros"].ToString(),
                        Placa = dr["Placa"].ToString()
                    });
                }
                return regVehiculo;
            }
            else
            {
                return regVehiculo;
            }
        }
    }
}