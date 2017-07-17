using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using EntidadesCompartidas;


namespace Datos
{
    public class DatosCupon
    {

        public static int AgregarCupon(Cupon _Cupon)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarCupon", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oNumero = new SqlParameter("@numero", _Cupon.Numero);
            SqlParameter oFecha = new SqlParameter("@fecha", _Cupon.Fecha);
            SqlParameter oValor = new SqlParameter("@valor", _Cupon.Valor);
            SqlParameter oCliente = new SqlParameter("@cliente", _Cupon.Cliente.Cedula);

            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oNumero);
            oComando.Parameters.Add(oFecha);
            oComando.Parameters.Add(oValor);
            oComando.Parameters.Add(oCliente);
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
                throw new Exception("Error al AGREGAR CUPON a la base de datos" + es);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static int EliminarCupon(Cupon _Cupon)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarCupon", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oNumero = new SqlParameter("@numero", _Cupon.Numero);

            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

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
                throw new Exception("Error al ELIMIAR CUPON a la base de datos" + es);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static int ModificarCupon(Cupon _Cupon)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarCupon", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oNumero = new SqlParameter("@Numero", _Cupon.Numero);
            SqlParameter oFecha = new SqlParameter("@Fecha", _Cupon.Fecha);
            SqlParameter oValor = new SqlParameter("@Valor", _Cupon.Valor);
            SqlParameter oCliente = new SqlParameter("@Ci_Cliente", _Cupon.Cliente.Cedula);
            
            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oNumero);
            oComando.Parameters.Add(oFecha);
            oComando.Parameters.Add(oValor);
            oComando.Parameters.Add(oCliente);
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
                throw new Exception("Error al MODIFICAR CUPON a la base de datos" + es);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static Cupon BuscarCupon(int numero)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarCupon", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oNumero = new SqlParameter("@Numero", numero);

            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oNumero);
            oComando.Parameters.Add(oRetorno);

            Cupon Nuevo_Cupon = null;
            Cliente Nuevo_Cliente = new Cliente();
            int oCi_Client=0;
            SqlDataReader oReader;

            DateTime oFecha = DateTime.Now;
            int oValor = 0;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    oFecha = (DateTime)oReader["Fecha"];
                    oValor = (int)oReader["Valor"];
                    oCi_Client = (int)oReader["Ci_Cliente"];

                    Nuevo_Cliente.Cedula = oCi_Client;

                    Nuevo_Cupon = new Cupon(numero, oFecha, oValor, Nuevo_Cliente);
                }
                return Nuevo_Cupon;
            }
            catch (Exception es)
            {
                throw new Exception("Error al BUSCAR CUPON a la base de datos: " + es.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }
    }
}
