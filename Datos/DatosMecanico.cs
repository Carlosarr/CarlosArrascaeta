using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;

using System.Data;
using System.Data.SqlClient;



namespace Datos
{
    public class DatosMecanico
    {
        public static Mecanico LogueoMecanico(int cedula, string Contraseña)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("LogueoMecanico", oConexion);
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
            string oEspecialidad = "";
            Mecanico Nuevo_Mecanico = null;
            Mecanico Sustituto = null;
            int oTelefono = 000;


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
                    oEspecialidad = (string)oReader["Especialidad"];
                    oTelefono = (int)oReader["Telefono"];



                    Nuevo_Mecanico = new Mecanico(oCedula1, oContraseña1, oNombre, oApellido, oSueldo, oDireccion, Sustituto, oEspecialidad, oTelefono);
                }
                return Nuevo_Mecanico;
            }
            catch (Exception es)
            {
                throw new Exception("Error al LOGUEAR MECANICO a la base de datos: " + es.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static int AgregarMecanico(Mecanico _Meca)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarMecanico", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCedula = new SqlParameter("@cedula", _Meca.Cedula);
            SqlParameter oContraseña = new SqlParameter("@Contraseña", _Meca.Contraseña);
            SqlParameter oNombre = new SqlParameter("@Nombre", _Meca.Nombre);
            SqlParameter oApellido = new SqlParameter("@Apellido", _Meca.Apellido);
            SqlParameter oDireccion = new SqlParameter("@Direccion", _Meca.Direccion);
            SqlParameter oSueldo = new SqlParameter("@Sueldo", _Meca.Sueldo);
            SqlParameter oSustituto = new SqlParameter("@CedulaSustituto", _Meca.Sustituto.Cedula);
            SqlParameter oEspecialidad = new SqlParameter("@Especialidad", _Meca.Especialidad);
            SqlParameter oTelefono = new SqlParameter("@Telefono", _Meca.Telefono);

            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCedula);
            oComando.Parameters.Add(oContraseña);
            oComando.Parameters.Add(oNombre);
            oComando.Parameters.Add(oApellido);
            oComando.Parameters.Add(oDireccion);
            oComando.Parameters.Add(oSueldo);
            oComando.Parameters.Add(oSustituto);
            oComando.Parameters.Add(oEspecialidad);
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
                throw new Exception("Error al AGREGAR MECANICO a la base de datos" + es);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static int EliminarMecanico(Mecanico _Meca)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarMecanico", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCedula = new SqlParameter("@Cedula", _Meca.Cedula);

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
                throw new Exception("Error al ELIMIAR MECANICO a la base de datos" + es);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static int ModificarMecanico(Mecanico _Meca)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarMecanico", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCedula = new SqlParameter("@Cedula", _Meca.Cedula);
            SqlParameter oNombre = new SqlParameter("@Nombre", _Meca.Nombre);
            SqlParameter ocontraseña = new SqlParameter("@Contraseña", _Meca.Contraseña);
            SqlParameter oApellido = new SqlParameter("@Apellido", _Meca.Apellido);
            SqlParameter oDireccion = new SqlParameter("@Direccion", _Meca.Direccion);
            SqlParameter oSueldo = new SqlParameter("@Sueldo", _Meca.Sueldo);
            SqlParameter oSustituto = new SqlParameter("@CedulaSustituto", _Meca.Sustituto.Cedula);
            SqlParameter oEspecialidad = new SqlParameter("@Especialidad", _Meca.Especialidad);
            SqlParameter oTelefono = new SqlParameter("@Telefono", _Meca.Telefono);

            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCedula);
            oComando.Parameters.Add(oNombre);
            oComando.Parameters.Add(ocontraseña);
            oComando.Parameters.Add(oApellido);
            oComando.Parameters.Add(oDireccion);
            oComando.Parameters.Add(oSueldo);
            oComando.Parameters.Add(oSustituto);
            oComando.Parameters.Add(oEspecialidad);
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
                throw new Exception("Error al MODIFICAR MECANICO a la base de datos" + es);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static Mecanico BuscarMecanico(int cedula)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarMecanico", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCedula = new SqlParameter("@Cedula", cedula);


            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCedula);
            oComando.Parameters.Add(oRetorno);

            //Datos mecanico
            int oCedula1 = 0;
            string oContraseña = "";
            string oNombre = "";
            string oApellido = "";
            string oDireccion = "";
            int oSueldo = 0;
            string oEspecialidad = "";


            int oTelefono = 000;
            Mecanico _Meca = null; ;
            Mecanico _Sust;



            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    //Datos Mecanico

                    oCedula1 = (int)oReader["Ci"];
                    oContraseña = (string)oReader["Contraseña"];
                    oNombre = (string)oReader["Nombre"];
                    oApellido = (string)oReader["Apellido"];
                    oDireccion = (string)oReader["Direccion"];
                    oSueldo = (int)oReader["Sueldo"];
                    oEspecialidad = (string)oReader["Especialidad"];
                    int Ci_Sustituto = (int)oReader["Ci_Sustituto"];
                    oTelefono = (int)oReader["Telefono"];


                    //buscar telefonos

                   
                    _Sust = new Mecanico(Ci_Sustituto);
                    _Meca = new Mecanico(oCedula1, oContraseña, oNombre, oApellido, oSueldo, oDireccion, _Sust, oEspecialidad, oTelefono);

                }
                return _Meca;
            }
            catch (Exception es)
            {
                throw new Exception("Error al BUSCAR MECANICO a la base de datos" + es);
            }
            finally
            {
                oConexion.Close();
            }

        }

        public static int AgregarTelefonoMecanico(int Cedula, int Numero)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarTelefonoMecanico", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCedula = new SqlParameter("@Cedula", Cedula);
            SqlParameter oNumero = new SqlParameter("@Numero", Numero);


            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCedula);
            oComando.Parameters.Add(oNumero);

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
                throw new Exception("Error al AGREGAR TELEFONO MECANICO a la base de datos: " + es.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        //public static List<int> BuscarTelefonosMecanico(int Cedula)
        //{

        //    SqlConnection oConexion = new SqlConnection(Conexion.STR);
        //    SqlCommand oComando = new SqlCommand("BuscarTelefonosMecanico", oConexion);
        //    oComando.CommandType = CommandType.StoredProcedure;

        //    SqlParameter oCedula = new SqlParameter("@Cedula", Cedula);
        //    //SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);

        //    oComando.Parameters.Add(oCedula);
        //    //oComando.Parameters.Add(oRetorno);

        //    int numero1 = 0;
        //    int cedula1 = 0;
        //    SqlDataReader oReader;

        //    List<int> Telefonos = new List<int>();

        //    try
        //    {
        //        oConexion.Open();
        //        oReader = oComando.ExecuteReader();

        //        while (oReader.Read())
        //        {
        //            cedula1 = (int)oReader["Ci"];
        //            numero1 = (int)oReader["Numero"];
        //            Telefonos.Add(numero1);

        //        }

        //        return Telefonos;


        //    }
        //    catch (Exception es)
        //    {
        //        throw new Exception("Error al BUSCAR TELEFONOS MECANICO.. a la base de datos: " + es.Message);
        //    }


        //}

        //public static int EliminarTelefonoMecanico(int Cedula, int Numero)
        //{
        //    SqlConnection oConexion = new SqlConnection(Conexion.STR);
        //    SqlCommand oComando = new SqlCommand("EliminarTelefonoMecanico", oConexion);
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

        public static List<Mecanico> ListarMecanicos()
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarMecanicos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;


            //Datos mecanico
            int oCedula1 = 0;
            string oNombre = "";
            string oApellido = "";
            string oDireccion = "";
            int oSueldo = 0;
            string oEspecialidad = "";
            string oContraseña = "";



            int oTelefono = 000; //listas de tels ficticias, despues le asignamos los telefonos a cada uno

            Mecanico _Meca = null; ;
            Mecanico _Sust = new Mecanico();


            List<Mecanico> ListaDeMecanicos = new List<Mecanico>();

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    //Datos Mecanico

                    oCedula1 = (int)oReader["Ci"];
                    oContraseña = (string)oReader["Contraseña"];
                    oNombre = (string)oReader["Nombre"];
                    oApellido = (string)oReader["Apellido"];
                    oDireccion = (string)oReader["Direccion"];
                    oSueldo = (int)oReader["Sueldo"];
                    oEspecialidad = (string)oReader["Especialidad"];
                    int Ci_sust = (int)oReader["Ci_Sustituto"];
                    _Sust.Cedula = Ci_sust;
                    oTelefono = (int)oReader["Telefono"];

                    _Meca = new Mecanico(oCedula1, oContraseña, oNombre, oApellido, oSueldo, oDireccion, _Sust, oEspecialidad,oTelefono);

                   
                    ListaDeMecanicos.Add(_Meca);
                }
                return ListaDeMecanicos;
            }
            catch (Exception es)
            {
                throw new Exception("Error al LISTAR MECANICOS a la base de datos" + es);
            }
            finally
            {
                oConexion.Close();
            }
        }


        public static int ComprobarRelacionMecanico(int Cedula) //comprobar que no este relacionado antes de borrarlo
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ComprobarRelacionMecanico", oConexion);
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
                throw new Exception("Error al COMPROBAR RELAC MECANICO en la base de datos: " + es.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        //public static int EliminarTelefonosMecanico(int Cedula)
        //{
        //    SqlConnection oConexion = new SqlConnection(Conexion.STR);
        //    SqlCommand oComando = new SqlCommand("EliminarTelefonosMecanico", oConexion);
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
        //        throw new Exception("Error al ELIMINAR TELEFONOS MECANICO  en la base de datos: " + es.Message);
        //    }

        //}
    }
    }

       


