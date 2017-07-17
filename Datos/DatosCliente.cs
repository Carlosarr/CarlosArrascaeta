using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using EntidadesCompartidas;


namespace Datos
{
    public class DatosCliente
    {
        public static Cliente LogueoCliente(int Cedula, string Contraseña)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("LogueoCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCedula = new SqlParameter("@cedula", Cedula);
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
            List<Vehiculo> oVehiculos = null;
            int oTelefono = 0;
            Administrativo _Admin = new Administrativo(); ;
            Cliente Nuevo_Cliente = null;
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
                    oTelefono = (int)oReader["Telefono"];

                    
                    oVehiculos = DatosVehiculo.ListarVehiculos(oCedula1);


                    Nuevo_Cliente = new Cliente(oCedula1, oContraseña1, oNombre, oApellido, oDireccion, _Admin, oVehiculos, oTelefono);
                }
                return Nuevo_Cliente;
            }
            catch (Exception es)
            {
                throw new Exception("Error al LOGUEAR CLIENTE a la base de datos: " + es.Message);
            }
        }

        public static int AgregarCliente(Cliente oCLiente)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCi = new SqlParameter("@Ci", oCLiente.Cedula);
           
            SqlParameter oContraseña = new SqlParameter("@contraseña", oCLiente.Contraseña);
            SqlParameter oCiAdm = new SqlParameter("@CiAdm", oCLiente.Administrativo.Cedula);
            SqlParameter oNombre = new SqlParameter("@Nombre", oCLiente.Nombre);
            SqlParameter oApellido = new SqlParameter("@Apellido", oCLiente.Apellido);
            SqlParameter oDireccion = new SqlParameter("@Direccion", oCLiente.Direccion);
            SqlParameter oTel1 = new SqlParameter("@tel1", oCLiente.Telefono);
            


            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCi);
            oComando.Parameters.Add(oContraseña);
            oComando.Parameters.Add(oCiAdm);
            oComando.Parameters.Add(oNombre);
            oComando.Parameters.Add(oApellido);
            oComando.Parameters.Add(oDireccion);
            oComando.Parameters.Add(oTel1);
            

            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int oresultado = (int)oRetorno.Value;
                return oresultado;
            }
            catch (Exception oEx)
            {

                throw new Exception("Error al AGREGAR cliente a la base de datos" + oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static int EliminarCliente(int oCedula)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCi = new SqlParameter("@Ci", oCedula);


            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCi);


            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int oresultado = (int)oRetorno.Value;
                return oresultado;
            }
            catch (Exception oEx)
            {

                throw new Exception("Error al Eliminar cliente a la base de datos" + oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static int ModificarCliente(Cliente oCLiente)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCi = new SqlParameter("@Ci", oCLiente.Cedula);
            SqlParameter oContraseña = new SqlParameter("@contraseña", oCLiente.Contraseña);
            
            SqlParameter oNombre = new SqlParameter("@Nombre", oCLiente.Nombre);
            SqlParameter oApellido = new SqlParameter("@Apellido", oCLiente.Apellido);
            SqlParameter oDireccion = new SqlParameter("@Direccion", oCLiente.Direccion);
            SqlParameter oTel1 = new SqlParameter("@tel1", oCLiente.Telefono);
            


            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCi);
            oComando.Parameters.Add(oContraseña);
           
            oComando.Parameters.Add(oNombre);
            oComando.Parameters.Add(oApellido);
            oComando.Parameters.Add(oDireccion);
            oComando.Parameters.Add(oTel1);
           

            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                int oresultado = (int)oRetorno.Value;
                return oresultado;
            }
            catch (Exception oEx)
            {

                throw new Exception("Error al MODIFICAR cliente a la base de datos" + oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static Cliente BuscarCliente(int ocedula,int oCedulaAdmin)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCedula = new SqlParameter("@cedula", ocedula);

            oComando.Parameters.Add(oCedula);


            int oCedula1 = 0;
            string oContraseña1 = "";
            string oNombre = "";
            string oApellido = "";
            string oDireccion = "";
            int Ci_Administrativo = 0;
            int oTelefono = 0;
            List<Vehiculo> _Vehiculos = new List<Vehiculo>();
            Administrativo _Admin = null;
            Cliente oCliente = null; ;

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    oCedula1 = (int)oReader["Ci"];
                    Ci_Administrativo = (int)oReader["Ci_Adm"];
                    oContraseña1 = (string)oReader["Contraseña"];
                    oNombre = (string)oReader["Nombre"];
                    oApellido = (string)oReader["Apellido"];
                    oDireccion = (string)oReader["Direccion"];
                    _Admin = DatosAdministrativo.BuscarAdministrativo(Ci_Administrativo);
                    _Vehiculos = DatosVehiculo.ListarVehiculos(oCedula1);
                    oTelefono = (int)oReader["Telefono"];

                    oCliente = new Cliente(ocedula,oContraseña1, oNombre, oApellido, oDireccion, _Admin, _Vehiculos, oTelefono);

                }
                return oCliente;
            }
            catch (Exception es)
            {
                throw new Exception("Error al BUSCAR clientes a la base de datos: " + es.Message);
            }


        }


        public static List<Cliente> ListarClientes()
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarClientes", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            

            int oCedula1 = 0;
            string oContraseña1 = "";
            string oNombre = "";
            string oApellido = "";
            string oDireccion = "";
            int Ci_Administrativo = 0;
            int oTelefono = 0;
            List<Vehiculo> _Vehiculos = new List<Vehiculo>();
            Administrativo _Admin = null;
            Cliente oCliente = null; ;

            List<Cliente> ListaDeClientes = new List<Cliente>();

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    oCedula1 = (int)oReader["Ci"];
                    Ci_Administrativo = (int)oReader["Ci_Adm"];
                    oContraseña1 = (string)oReader["Contraseña"];
                    oNombre = (string)oReader["Nombre"];
                    oApellido = (string)oReader["Apellido"];
                    oDireccion = (string)oReader["Direccion"];
                    _Admin = DatosAdministrativo.BuscarAdministrativo(Ci_Administrativo);
                    _Vehiculos=DatosVehiculo.ListarVehiculos(oCedula1);
                    oTelefono = (int)oReader["Telefono"];

                    oCliente = new Cliente(oCedula1, oContraseña1, oNombre, oApellido, oDireccion, _Admin, _Vehiculos, oTelefono);
                    ListaDeClientes.Add(oCliente);
                }
                return ListaDeClientes;
            }
            catch (Exception es)
            {
                throw new Exception("Error al BUSCAR clientes a la base de datos: " + es.Message);
            }


        }
    }
}
