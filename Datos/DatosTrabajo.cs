using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosTrabajo
    {
        public static int AgregarTrabajo(Trabajo _trb)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarTrabajo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCodigo = new SqlParameter("@Codigo", _trb.Codigo);
            SqlParameter oDescripcion = new SqlParameter("@Descripcion", _trb.Descripcion);
            SqlParameter oCiMecanico = new SqlParameter("@Ci_Mecanico", _trb.Mecanico.Cedula);

            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCodigo);
            oComando.Parameters.Add(oDescripcion);
            oComando.Parameters.Add(oCiMecanico);
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int resultado = (int)oRetorno.Value;
                return resultado;
            }
            catch(Exception es)
            {
                throw new Exception("Error al AGREGAR TRABAJO a la base de datos" + es);
            }


        }

        public static int EliminarTrabajo(Trabajo _trb)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarTrabajo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCodigo = new SqlParameter("@Codigo", _trb.Codigo);

            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCodigo);
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
                throw new Exception("Error al ELIMIAR TRABAJO a la base de datos" + es);
            }

        }

        public static int ModificarTrabajo(Trabajo _trb)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarTrabajo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCodigo = new SqlParameter("@Codigo", _trb.Codigo);
            SqlParameter oDescripcion = new SqlParameter("@Descripcion", _trb.Descripcion);
            SqlParameter oCiMecanico = new SqlParameter("@Ci_Mecanico", _trb.Mecanico.Cedula);

            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCodigo);
            oComando.Parameters.Add(oDescripcion);
            oComando.Parameters.Add(oCiMecanico);
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
                throw new Exception("Error al MODIFICAR TRABAJO a la base de datos" + es);
            }
        }

        public static Trabajo BuscarTrabajo(int Codigo)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarTrabajo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCodigo = new SqlParameter("@Codigo", Codigo);


            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCodigo);
            oComando.Parameters.Add(oRetorno);

            int oCedulaMecanico = 0;

            string oDescripcion = "";
            Mecanico oMecanico = new Mecanico();
            Trabajo _Trabajo = null;

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    oDescripcion = (string)oReader["Descripcion"];
                    oCedulaMecanico = (int)oReader["Ci_Mecanico"];

                    oMecanico.Cedula = oCedulaMecanico;
                    _Trabajo = new Trabajo(Codigo,oDescripcion,oMecanico);
                }
                return _Trabajo;
            }
            catch (Exception es)
            {
                throw new Exception("Error al BUSCAR TRABAJO a la base de datos: " + es.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static List<Trabajo> BuscarTrabajosPorRangoDeFechas(DateTime Fecha1, DateTime Fecha2,int Ci_Mecanico)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarTrabajosPorRangoDeFechas", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oFecha1 = new SqlParameter("@Fecha1", Fecha1);
            SqlParameter oFecha2 = new SqlParameter("@Fecha2", Fecha2);
            SqlParameter oCiMecanico = new SqlParameter("@CiMecanico", Ci_Mecanico);

            oComando.Parameters.Add(oFecha1);
            oComando.Parameters.Add(oFecha2);
            oComando.Parameters.Add(oCiMecanico);

            int oCodigo = 0;
            string oDescripcion = "";
            int oCi_Mecanico = 0;

            Mecanico oMecanico = new Mecanico();
            Trabajo _Trabajo = null;
            List<Trabajo> ListaDeTrabajos = new List<Trabajo>();

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    oCodigo = (int)oReader["Codigo_Trabajo"];
                    oDescripcion = (string)oReader["Descripcion"];
                    oCi_Mecanico = (int)oReader["Ci_Mecanico"];

                    oMecanico.Cedula=oCi_Mecanico;

                    _Trabajo = new Trabajo(oCodigo, oDescripcion, oMecanico);
                    ListaDeTrabajos.Add(_Trabajo);
                }
                return ListaDeTrabajos;
            }
            catch (Exception es)
            {
                throw new Exception("Error al BUSCAR TRABAJOS POR RANGO a la base de datos: " + es.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static List<Trabajo> ListarTrabajosDisponibles()
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarTrabajosDisponibles", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;




            int oCodigo;
            string oDescripcion;
            int oCi_Mecanico;
            Mecanico oMecanico = new Mecanico();
            Trabajo _Trabajo = null;
            List<Trabajo> ListaDeTrabajos = new List<Trabajo>();

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    oCodigo = (int)oReader["Codigo"];
                    oDescripcion = (string)oReader["Descripcion"];
                    oCi_Mecanico = (int)oReader["Ci_Mecanico"];

                    oMecanico = DatosMecanico.BuscarMecanico(oCi_Mecanico);
                    _Trabajo = new Trabajo(oCodigo, oDescripcion, oMecanico);
                    ListaDeTrabajos.Add(_Trabajo);
                }
                return ListaDeTrabajos;
            }
            catch (Exception es)
            {
                throw new Exception("Error al LISTAR TRABAJOS DISPONIBLES " + es.Message);
            }
            finally
            {
                oConexion.Close();
            }

        }
    }
}
