using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;

using System.Data;
using System.Data.SqlClient;



namespace Datos    
{
    public class DatosAdministrativo
    {
        public static Administrativo LogueoAdministrativo(int cedula, string Contraseña)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("LogueoAdministrativo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCedula = new SqlParameter("@cedula", cedula);
            SqlParameter oContraseña = new SqlParameter("@contraseña", Contraseña);

            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCedula);
            oComando.Parameters.Add(oContraseña); //contraseña=cedula

            int oCedula1 = 0;
            string oContraseña1 = "";
            string oNombre = "";
            string oApellido = "";
            string oDireccion = "";
            int oSueldo = 0;
            string oNivelDeInstruccion = "";
            int oTelefono = 000;
            Administrativo _Admin = null; ;

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    oCedula1 = (int)oReader["Ci"];
                    oContraseña1 = (string)oReader["Contraseña"];
                    oNombre = (string)oReader["Nombre"];
                    oApellido = (string)oReader["Apellido"];
                    oDireccion = (string)oReader["Direccion"];
                    oSueldo = (int)oReader["Sueldo"];
                    oNivelDeInstruccion = (string)oReader["Nivel_De_Instruccion"];
                    oTelefono = (int)oReader["Telefono"];


                    _Admin = new Administrativo(oCedula1, oContraseña1, oNombre, oApellido, oSueldo, oDireccion, oNivelDeInstruccion, oTelefono);
                }
                return _Admin;
            }
            catch (Exception es)
            {
                throw new Exception("Error al LOGUEAR ADMINISTRATIVO a la base de datos: " + es.Message);
            }
            finally
            {
                oConexion.Close();
            }

        }

        public static int AgregarAdministrativo(Administrativo _Admin)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarAdministrativo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCedula = new SqlParameter("@Cedula", _Admin.Cedula);
            SqlParameter oNombre = new SqlParameter("@Nombre", _Admin.Nombre);
            SqlParameter oContraseña = new SqlParameter("@Contraseña", _Admin.Contraseña);
            SqlParameter oApellido = new SqlParameter("@Apellido", _Admin.Apellido);
            SqlParameter oDireccion = new SqlParameter("@Direccion", _Admin.Direccion);
            SqlParameter oSueldo = new SqlParameter("@Sueldo", _Admin.Sueldo);
            SqlParameter oNivelDeInstruccion = new SqlParameter("@NivelDeInstruccion", _Admin.NivelDeInstruccion);
            SqlParameter oTelefono = new SqlParameter("@Telefono", _Admin.Telefono); 

            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCedula);
            oComando.Parameters.Add(oContraseña);
            oComando.Parameters.Add(oNombre);
            oComando.Parameters.Add(oApellido);
            oComando.Parameters.Add(oDireccion);
            oComando.Parameters.Add(oSueldo);
            oComando.Parameters.Add(oNivelDeInstruccion);
            oComando.Parameters.Add(oTelefono);

            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int resultado = (int)oRetorno.Value;
                return resultado;
            }
            catch (Exception es)
            {
                throw new Exception("Error al AGREGAR ADMINISTRATIVO a la base de datos: " + es.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static int EliminarAdministrativo(Administrativo _Admin)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarAdministrativo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCedula = new SqlParameter("@Cedula", _Admin.Cedula);

            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCedula);
            oComando.Parameters.Add(oRetorno);
            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int resultado = (int)oRetorno.Value;
                return resultado;
            }
            catch (Exception es)
            {
                throw new Exception("Error al ELIMIAR ADMINISTRATIVO a la base de datos: " + es.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static int ModificarAdministrativo(Administrativo _Admin)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarAdministrativo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCedula = new SqlParameter("@Cedula", _Admin.Cedula);
            SqlParameter oContraseña = new SqlParameter("@Contraseña", _Admin.Contraseña);
            SqlParameter oNombre = new SqlParameter("@Nombre", _Admin.Nombre);
            SqlParameter oApellido = new SqlParameter("@Apellido", _Admin.Apellido);
            SqlParameter oDireccion = new SqlParameter("@Direccion", _Admin.Direccion);
            SqlParameter oSueldo = new SqlParameter("@Sueldo", _Admin.Sueldo);
            SqlParameter oNivelDeInstruccion = new SqlParameter("@NivelDeInstruccion", _Admin.NivelDeInstruccion);
            SqlParameter oTelefono = new SqlParameter("@Telefono", _Admin.Telefono);
            

            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCedula);
            oComando.Parameters.Add(oNombre);
            oComando.Parameters.Add(oContraseña);
            oComando.Parameters.Add(oApellido);
            oComando.Parameters.Add(oDireccion);
            oComando.Parameters.Add(oSueldo);
            oComando.Parameters.Add(oNivelDeInstruccion);
            oComando.Parameters.Add(oTelefono);
            

            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int resultado = (int)oRetorno.Value;
                return resultado;
            }
            catch (Exception es)
            {
                throw new Exception("Error al MODIFICAR ADMINISTRATIVO a la base de datos: " + es.Message);
            }
            finally
            {
                oConexion.Close();
            }

        }

        //public static int AgregarTelefonoAdministrativo(int Cedula, int Numero)
        //{
        //    SqlConnection oConexion = new SqlConnection(Conexion.STR);
        //    SqlCommand oComando = new SqlCommand("AgregarTelefonoAdministrativo", oConexion);
        //    oComando.CommandType = CommandType.StoredProcedure;

        //    SqlParameter oCedula = new SqlParameter("@Cedula", Cedula);
        //    SqlParameter oNumero = new SqlParameter("@Numero", Numero);


        //    SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
        //    oRetorno.Direction = ParameterDirection.ReturnValue;

        //    oComando.Parameters.Add(oCedula);
        //    oComando.Parameters.Add(oNumero);

        //    oComando.Parameters.Add(oRetorno);

        //    try
        //    {
        //        oConexion.Open();
        //        oComando.ExecuteNonQuery();
        //        int resultado = (int)oRetorno.Value;
        //        return resultado;
        //    }
        //    catch (Exception es)
        //    {
        //        throw new Exception("Error al AGREGAR TELEFONO ADMINISTRATIVO a la base de datos: " + es.Message);
        //    }
        //}

        //public static List<int> BucarTelefonosAdministativo(int Cedula)
        //{

        //    SqlConnection oConexion = new SqlConnection(Conexion.STR);
        //    SqlCommand oComando = new SqlCommand("BuscarTelefonosAministrativo", oConexion);
        //    oComando.CommandType = CommandType.StoredProcedure;

        //    SqlParameter oCedula = new SqlParameter("@Cedula", Cedula);
            

        //    oComando.Parameters.Add(oCedula);
          

        //    SqlDataReader oReader;

        //    List<int> Telefonos = new List<int>(); ;

        //    try
        //    {
        //        oConexion.Open();
        //        oReader = oComando.ExecuteReader();

        //        while (oReader.Read())
        //        {
        //            int cedula1 = (int)oReader["Ci"];
        //            int numero = (int)oReader["Numero"];

                     
        //            Telefonos.Add(numero);
        //        }
        //        return Telefonos;
        //    }
        //    catch (Exception es)
        //    {
        //        throw new Exception("Error al BUSCAR TELEFONOS ADMIN.. a la base de datos: " + es.Message);
        //    }
        //}

        //public static int EliminarTelefonoAdministrativo(int Cedula, int Numero)
        //{
        //    SqlConnection oConexion = new SqlConnection(Conexion.STR);
        //    SqlCommand oComando = new SqlCommand("EliminarTelefonoAdministrativo", oConexion);
        //    oComando.CommandType = CommandType.StoredProcedure;

        //    SqlParameter oCedula = new SqlParameter("@Cedula", Cedula);
        //    SqlParameter oNumero = new SqlParameter("@Numero", Numero);

        //    SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
        //    oRetorno.Direction = ParameterDirection.ReturnValue;

        //    oComando.Parameters.Add(oCedula);
        //    oComando.Parameters.Add(oNumero);
        //    oComando.Parameters.Add(oRetorno);
        //    try
        //    {
        //        oConexion.Open();
        //        oComando.ExecuteNonQuery();
        //        int resultado = (int)oRetorno.Value;
        //        return resultado;
        //    }
        //    catch (Exception es)
        //    {
        //        throw new Exception("Error al ELIMINAR TELEFONO MECANICO a la base de datos" + es);
        //    }
        //}

        public static Administrativo BuscarAdministrativo(int cedula)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarAdministrativo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCedula = new SqlParameter("@cedula", cedula);

            oComando.Parameters.Add(oCedula);
           

            int oCedula1 = 0;
            string oContraseña1 = "";
            string oNombre = "";
            string oApellido = "";
            string oDireccion = "";
            int oSueldo = 0;
            string oNivelDeInstruccion = "";
            int oTelefono = 000;
            Administrativo _Admin = null; ;

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    oCedula1 = (int)oReader["Ci"];
                    oContraseña1 = (string)oReader["Contraseña"];
                    oNombre = (string)oReader["Nombre"];
                    oApellido = (string)oReader["Apellido"];
                    oDireccion = (string)oReader["Direccion"];
                    oSueldo = (int)oReader["Sueldo"];
                    oNivelDeInstruccion = (string)oReader["Nivel_De_Instruccion"];
                    oTelefono = (int)oReader["Telefono"];



                    _Admin = new Administrativo(oCedula1, oContraseña1, oNombre, oApellido, oSueldo, oDireccion, oNivelDeInstruccion, oTelefono);
                }
                return _Admin;
            }
            catch (Exception es)
            {
                throw new Exception("Error al BUSCAR ADMINISTRATIVO a la base de datos: " + es.Message);
            }
            finally
            {
                oConexion.Close();
            }

        }

        public static int ComprobarRelacionAdministrativo(int Cedula) //comprobar que no este relacionado antes de borrarlo
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ComprobarRelacionAdministrativo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCedula = new SqlParameter("@Cedula", Cedula);
            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCedula);
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int resultado = (int)oRetorno.Value;
                return resultado;
            }
            catch (Exception es)
            {
                throw new Exception("Error al COMPROBAR RELAC ADMINISTRATIVO en la base de datos: " + es.Message);
            }
        }

        //public static int EliminarTelefonosAdministrativo(int Cedula)
        //{
        //    SqlConnection oConexion = new SqlConnection(Conexion.STR);
        //    SqlCommand oComando = new SqlCommand("EliminarTelefonosAdministrativo", oConexion);
        //    oComando.CommandType = CommandType.StoredProcedure;

        //    SqlParameter oCedula = new SqlParameter("@Cedula", Cedula);

        //    SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
        //    oRetorno.Direction = ParameterDirection.ReturnValue;

        //    oComando.Parameters.Add(oCedula);
        //    oComando.Parameters.Add(oRetorno);
        //    try
        //    {
        //        oConexion.Open();
        //        oComando.ExecuteNonQuery();
        //        int resultado = (int)oRetorno.Value;
        //        return resultado;
        //    }
        //    catch (Exception es)
        //    {
        //        throw new Exception("Error al ELIMIAR TELEFONOS ADMINISTRATIVO  en la base de datos: " + es.Message);
        //    }

        //}
    }
}
