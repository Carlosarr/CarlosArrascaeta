using System;
using System.Collections.Generic;
using System.Text;

using EntidadesCompartidas;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosService
    {
        public static int AgregarService(string oMatricula, int oCodTrab, Service oService)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarServicio", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oNumero = new SqlParameter("@numero", oService.Numero);
            SqlParameter oMatricula1 = new SqlParameter("@Matricula", oMatricula);
            SqlParameter oCodTrab1 = new SqlParameter("@codtrabajo", oCodTrab);
            SqlParameter oCi_Cliente = new SqlParameter("@ci_cliente", oService.Cliente.Cedula);
            SqlParameter oCi_Admin = new SqlParameter("@ci_adm", oService.Administrativo.Cedula);
            SqlParameter oEstado = new SqlParameter("@@estado", oService.Estado);
            SqlParameter oFecha = new SqlParameter("@fecha", oService.Fecha);

            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oNumero);
            oComando.Parameters.Add(oMatricula1);
            oComando.Parameters.Add(oCodTrab1);
            oComando.Parameters.Add(oCi_Cliente);
            oComando.Parameters.Add(oCi_Admin);
            oComando.Parameters.Add(oEstado);
            oComando.Parameters.Add(oFecha);

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

                throw new Exception("Error al agregar servicio a la base de datos" + oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }


        }

        public static int EliminarService(int oNumero)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarServicio", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;


            SqlParameter oNumero1 = new SqlParameter("@numero", oNumero);

            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oNumero1);

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

                throw new Exception("Error al Eliminar servicio a la base de datos" + oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static int ModificarService(Service oService,string oMatricula, int oCodTrab)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarServicio", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oNumero = new SqlParameter("@numero", oService.Numero);
            SqlParameter oMatricula1 = new SqlParameter("@Matricula",oMatricula);
            SqlParameter oCodTrab1 = new SqlParameter("@codtrabajo", oCodTrab);
            SqlParameter oCi_Cliente = new SqlParameter("@ci_cliente", oService.Cliente.Cedula);
            SqlParameter oCi_Admin = new SqlParameter("@ci_adm", oService.Administrativo.Cedula);
            SqlParameter oEstado = new SqlParameter("@@estado", oService.Estado);
            SqlParameter oFecha = new SqlParameter("@fecha", oService.Fecha);

            SqlParameter oRetorno = new SqlParameter("@Resp", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oNumero);
            oComando.Parameters.Add(oMatricula1);
            oComando.Parameters.Add(oCodTrab1);
            oComando.Parameters.Add(oCi_Cliente);
            oComando.Parameters.Add(oCi_Admin);
            oComando.Parameters.Add(oEstado);
            oComando.Parameters.Add(oFecha);

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

                throw new Exception("Error al MODIFICAR servicio a la base de datos" + oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }


        }

        public static Service BuscarService(int oNum)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarService", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oNUmero = new SqlParameter("@numero", oNum);

            oComando.Parameters.Add(oNum);

            Service oServ = null;
            Mecanico oMecanico = null;
            Administrativo oAdmin = null;
            Cliente oCliente = null;
            //Trabajo oTrabajo = null;
            int oNumero = 0;
            int oCI_CLiente = 0;
            int oCi_Admin = 0;
            string oMatricula = "";
            DateTime oFecha = DateTime.Now;
            string oEstado = "";
            List<Trabajo> oTrabajos = null;


            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    oNumero = (int)oReader["Numero"];
                    oCI_CLiente = (int)oReader["Ci_Cliente"];
                    oCi_Admin = (int)oReader["Ci_Adm"];
                    oMatricula = (string)oReader["Matricula_Auto"];
                    oFecha = (DateTime)oReader["Fecha"];
                    oEstado = (string)oReader["Estado"];
                    oTrabajos = BuscarTrabajoPorServicio(oNumero, oMecanico);
                    oAdmin = DatosAdministrativo.BuscarAdministrativo(oCi_Admin);
                    oCliente = DatosCliente.BuscarCliente(oCI_CLiente,oAdmin.Cedula);

                    oServ = new Service(oNum, oEstado, oFecha, oCliente, oAdmin, oTrabajos);

                }
                return oServ;
            }
            catch (Exception es)
            {
                throw new Exception("Error al BUSCAR ADMINISTRATIVO a la base de datos: " + es.Message);
            }


        }

        public static List<Service> ListarServicesEnCurso(int Ci_Cliente)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarServicesEnCurso", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter ocedula = new SqlParameter("@Ci_Cliente", Ci_Cliente);

            oComando.Parameters.Add(ocedula);

            Service oServ = null;
            
            Administrativo oAdmin = null;
            Cliente oCliente = null;
            //Trabajo oTrabajo = null;
            int oNumero = 0;
            int oCI_CLiente = 0;
            int oCi_Admin = 0;
            string oMatricula = "";
            DateTime oFecha = DateTime.Now;
            string oEstado = "";
            List<Trabajo> oTrabajos = null;
            List<Service> ListaDeServices = new List<Service>();

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    oNumero = (int)oReader["Numero"];
                    oCI_CLiente = (int)oReader["Ci_Cliente"];
                    oCi_Admin = (int)oReader["Ci_Adm"];
                    oMatricula = (string)oReader["Matricula_Auto"];
                    oFecha = (DateTime)oReader["Fecha"];
                    oEstado = (string)oReader["Estado"];
                    oTrabajos = ListarTrabajosDeService(oNumero);
                    oAdmin = DatosAdministrativo.BuscarAdministrativo(oCi_Admin);
                    oCliente = DatosCliente.BuscarCliente(oCI_CLiente, oAdmin.Cedula);

                    oServ = new Service(oNumero, oEstado, oFecha, oCliente, oAdmin, oTrabajos);
                    ListaDeServices.Add(oServ);
                }
                return ListaDeServices;
            }
            catch (Exception es)
            {
                throw new Exception("Error al BUSCAR ADMINISTRATIVO a la base de datos: " + es.Message);
            }
        }

        public static List<Trabajo> BuscarTrabajoPorServicio(int oNumserv, Mecanico oMeca) //PARA MECANICO
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarTrabajosPorServicio", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oNumero = new SqlParameter("@NumServicio", oNumserv);

            oComando.Parameters.Add(oNumserv);

            Trabajo oTRab = null;
            int oCodigo = 0;
            string oDescripcion = "";
            Mecanico oMecanico = new Mecanico();
            List<Trabajo> olista = new List<Trabajo>();

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    oCodigo = (int)oReader["Codigo"];
                    oDescripcion = (string)oReader["Descripcion"];
     
                    oTRab = new Trabajo(oCodigo,oDescripcion,oMeca);
                    olista.Add(oTRab);
            
                }
                return olista;
            }
            catch(Exception oEx)
            {
                throw new Exception("error al BUSCARTRABAJOPORSERVICIO en la base de datos" + oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }

        


    }

        public static List<Trabajo> ListarTrabajosDeService(int num)  // para cliente pero es igual que el de arriba (cambiar eso)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarTrabajosDeService", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oNumero = new SqlParameter("@Num", num);

            oComando.Parameters.Add(oNumero);

            Trabajo oTRab = null;
            int oCodigo = 0;
            string oDescripcion = "";
            Mecanico oMecanico = new Mecanico();
            List<Trabajo> olista = new List<Trabajo>();

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    oCodigo = (int)oReader["Codigo"];
                    oDescripcion = (string)oReader["Descripcion"];

                    oTRab = new Trabajo(oCodigo, oDescripcion, oMecanico);
                    olista.Add(oTRab);

                }
                return olista;
            }
            catch (Exception oEx)
            {
                throw new Exception("error al BUSCARTRABAJOPORSERVICIO en la base de datos" + oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static List<Service> ListarServiciosDeCliente(int oCed)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarServicesEnCurso", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oCiCliente = new SqlParameter("@Ci_Cliente", oCed);

            oComando.Parameters.Add(oCiCliente);

            //            Numero int PRIMARY KEY not null IDENTITY,
            //Matricula_Auto varchar(4) not null,
            //Ci_Cliente int not null,
            //Ci_Adm int not null,
            //Fecha datetime not null,
            //Estado varchar(20) not null,

            string oMatricula = "";
            int oCedCliente = 0;
            int oCiAdm = 0;
            DateTime oFecha = DateTime.Now;
            string oEstado = "";
            // Trabajo = oTRabajo = null;
            List<Trabajo> oListaTrabajos = null;
            Service oService = null;
            List<Service> oLista = new List<Service>();

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    oMatricula = (string)oReader["Matricula_Auto"];
                    oCedCliente = (int)oReader["Ci_Cliente"];
                    oCiAdm = (int)oReader["Ci_Adm"];
                    oFecha = (DateTime)oReader["Fecha"];
                    oEstado = (string)oReader["Estado"];
                    Cliente oCliente = DatosCliente.BuscarCliente(oCedCliente, oCiAdm);
                    Administrativo oAdmin = DatosAdministrativo.BuscarAdministrativo(oCiAdm);

                    oService = new Service(0, oEstado, oFecha, oCliente, oAdmin, oListaTrabajos);
                    oLista.Add(oService);

                }
                return oLista;
            }
            catch (Exception oEx)
            {
                throw new Exception("error al LISTAR SERVICIOS desde la base de datos" + oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        ////
        public static List<Service> ListarServiciosDeClienteporRangoDeFechas(string oFecha1, string oFecha2, int oCiCliente)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarServicesYTrabajosPorRangoDeFechas", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oFe1 = new SqlParameter("@Fecha1", oFecha1);
            SqlParameter oFe2 = new SqlParameter("@Fecha2", oFecha2);
            SqlParameter oCiCli = new SqlParameter("@CiCliente", oCiCliente);


            oComando.Parameters.Add(oFe1);
            oComando.Parameters.Add(oFe2);
            oComando.Parameters.Add(oCiCli);


            //            Numero int PRIMARY KEY not null IDENTITY,
            //Matricula_Auto varchar(4) not null,
            //Ci_Cliente int not null,
            //Ci_Adm int not null,
            //Fecha datetime not null,
            //Estado varchar(20) not null,

            string oMatricula = "";
            int oCedCliente = 0;
            int oCiAdm = 0;
            DateTime oFecha = DateTime.Now;
            string oEstado = "";
            // Trabajo = oTRabajo = null;
            List<Trabajo> oListaTrabajos = null;
            Service oService = null;
            List<Service> oLista = new List<Service>();

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    oMatricula = (string)oReader["Matricula"];
                    oCedCliente = (int)oReader["Ci_Cliente"];
                    oCiAdm = (int)oReader["Ci_Adm"];
                    oFecha = (DateTime)oReader["Fecha"];
                    oEstado = (string)oReader["Estado"];
                    Cliente oCliente = DatosCliente.BuscarCliente(oCedCliente, oCiAdm);
                    Administrativo oAdmin = DatosAdministrativo.BuscarAdministrativo(oCiAdm);

                    oService = new Service(0, oEstado, oFecha, oCliente, oAdmin, oListaTrabajos);
                    oLista.Add(oService);

                }
                return oLista;
            }
            catch (Exception oEx)
            {
                throw new Exception("error al LISTAR SERVICIOS POR RANGO DE FECHAS desde la base de datos" + oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }
    }
}
