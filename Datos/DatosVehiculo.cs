using System;
using System.Collections.Generic;
using System.Text;

using EntidadesCompartidas;

using System.Data;
using System.Data.SqlClient;


namespace Datos
{
    public class DatosVehiculo
    {
        public static int AgregarVehiculo(Vehiculo oVehiculo, int oCi_Cliente)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarVehiculo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oMatricula = new SqlParameter("@Matricula", oVehiculo.Matricula);
            SqlParameter oMarca = new SqlParameter("@Marca", oVehiculo.Marca);
            SqlParameter oModelo = new SqlParameter("@Modelo", oVehiculo.Modelo);
            SqlParameter oAno = new SqlParameter("@Ano", oVehiculo.Ano);
            SqlParameter oCiCliente = new SqlParameter("@Ci_Cliente", oCi_Cliente);

            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oMatricula);
            oComando.Parameters.Add(oMarca);
            oComando.Parameters.Add(oModelo);
            oComando.Parameters.Add(oAno);
            oComando.Parameters.Add(oCiCliente);

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

                throw new Exception("Error al agregar vehiculo a la base de datos" + oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }
      
        }

        public static int EliminarVehiculo(string oMatricula1)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarVehiculo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oMatricula = new SqlParameter("@Matricula",oMatricula1);

            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oMatricula);


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

                throw new Exception("Error al eliminar vehiculo a la base de datos" + oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static int ModificarVehiculo(Vehiculo oVehiculo, int oCi_Cliente)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarVehiculo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oMatricula = new SqlParameter("@Matricula", oVehiculo.Matricula);
            SqlParameter oMarca = new SqlParameter("@Marca", oVehiculo.Marca);
            SqlParameter oModelo = new SqlParameter("@Modelo", oVehiculo.Modelo);
            SqlParameter oAno = new SqlParameter("@Ano", oVehiculo.Ano);
           

            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oMatricula);
            oComando.Parameters.Add(oMarca);
            oComando.Parameters.Add(oModelo);
            oComando.Parameters.Add(oAno);
            

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

                throw new Exception("Error al MODIFICAR vehiculo a la base de datos" + oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }


        }

        public static Vehiculo BuscarVehiculo(string oMatr)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarVehiculo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oMatricula = new SqlParameter("@matricula", oMatr);

            oComando.Parameters.Add(oMatricula);

            Vehiculo oVehiculo = null;
            string _matricula = "";
            string _marca = "";
            string _modelo = "";
            int _ano = 0;
            List<Foto> _fotos = null;

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    _matricula = (string)oReader["Matricula"];
                    _marca = (string)oReader["Marca"];
                    _modelo = (string)oReader["Modelo"];
                    _ano = (int)oReader["Año"];
                    _fotos = DatosVehiculo.ListarFotos(_matricula);
                    oVehiculo = new Vehiculo(_matricula, _marca, _modelo, _ano, _fotos);

                }
                return oVehiculo;
            }
            catch (Exception es)
            {
                throw new Exception("Error al BUSCAR VEHICULO a la base de datos: " + es.Message);
            }
        }

        public static List<Vehiculo> ListarVehiculos(int cedula)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarVehiculos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter ocedula = new SqlParameter("@cedula", cedula);

            oComando.Parameters.Add(ocedula);

            Vehiculo oVehiculo = null;
            string _matricula = "";
            string _marca = "";
            string _modelo = "";
            int _ano = 0;
            List<Foto> _fotos = null;
            List<Vehiculo> ListaDeVehiculos = new List<Vehiculo>();
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    _matricula = (string)oReader["Matricula"];
                    _marca = (string)oReader["Marca"];
                    _modelo = (string)oReader["Modelo"];
                    _ano = (int)oReader["Año"];
                    _fotos = DatosVehiculo.ListarFotos(_matricula);
                    oVehiculo = new Vehiculo(_matricula, _marca, _modelo, _ano, _fotos);

                    ListaDeVehiculos.Add(oVehiculo);
                }
                return ListaDeVehiculos;
            }
            catch (Exception es)
            {
                throw new Exception("Error al LISTAR VEHICULOS a la base de datos: " + es.Message);
            }
        }

        public static List<Foto> ListarFotos(string oMatricula2)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarFotos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oMatricula = new SqlParameter("@matricula", oMatricula2);

            oComando.Parameters.Add(oMatricula);

            List<Foto> oFotos = new List<Foto>();
            string ofoto = "";
            int oid = 0;
            SqlDataReader oReader;
            
            
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    oid = (int)oReader["Id"];
                    ofoto = (string)oReader["Imagen"];
                    Foto _foto = new Foto(ofoto,oid);
                    
                    oFotos.Add(_foto);
                    
                }
                return oFotos;
            }
            catch (Exception es)
            {
                throw new Exception("Error al Listar fotos de vehiculo de la base de datos: " + es.Message);
            }
        }

        public static int AgregarFoto(string Matricula, string Imagen)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarFoto", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oMatricula = new SqlParameter("@Matricula",Matricula);
            SqlParameter oImagen = new SqlParameter("@Imagen", Imagen);
            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oMatricula);
            oComando.Parameters.Add(oImagen);
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

                throw new Exception("Error al AGREGAR FOTO a la base de datos" + oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void ModificarFoto(int id, Foto NuevaFoto)
        {
            
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarFoto", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oId = new SqlParameter("@Id",id);
            SqlParameter odir = new SqlParameter("@dir", NuevaFoto.DireccionFotos);
   
            oComando.Parameters.Add(oId);
            oComando.Parameters.Add(odir);
            

            

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                
            }
            catch (Exception oEx)
            {

                throw new Exception("Error al MODIFICAR FOTO a la base de datos" + oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void EliminarFoto(int id)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarFoto", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oId = new SqlParameter("@Id", id);
           

            oComando.Parameters.Add(oId);
            




            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

            }
            catch (Exception oEx)
            {

                throw new Exception("Error al ELIMINAR FOTO a la base de datos" + oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static List<Vehiculo> ListarVehiculos2()
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarVehiculos2", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;


            Vehiculo oVehiculo = null;
            string _matricula = "";
            string _marca = "";
            string _modelo = "";
            int _ano = 0;
            List<Foto> _fotos = null;
            List<Vehiculo> ListaDeVehiculos = new List<Vehiculo>();
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    _matricula = (string)oReader["Matricula"];
                    _marca = (string)oReader["Marca"];
                    _modelo = (string)oReader["Modelo"];
                    _ano = (int)oReader["Año"];
                    _fotos = DatosVehiculo.ListarFotos(_matricula);
                    oVehiculo = new Vehiculo(_matricula, _marca, _modelo, _ano, _fotos);

                    ListaDeVehiculos.Add(oVehiculo);
                }
                return ListaDeVehiculos;
            }
            catch (Exception es)
            {
                throw new Exception("Error al LISTAR VEHICULOS a la base de datos: " + es.Message);
            }
        }
      
    }
}
