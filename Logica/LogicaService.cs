using System;
using System.Collections.Generic;
using System.Text;

using EntidadesCompartidas;
using Datos;

namespace Logica
{
    public class LogicaService
    {
        public static List<Service> ListarServicesEnCurso(int Ci_Cliente)
        {
            return DatosService.ListarServicesEnCurso(Ci_Cliente);
        }

        public static List<Trabajo> ListarTrabajosDeService(int num)
        {
            return DatosService.ListarTrabajosDeService(num);
        }

        public static int AgregarService(string oMatricula, int oCodTrab, Service oService)
        {
            return DatosService.AgregarService(oMatricula, oCodTrab, oService);
        }

        public static int EliminarService(int oNumero)
        {
            return DatosService.EliminarService(oNumero);
        }

        public static int ModificarService(Service oService, string oMatricula, int oCodTrab)
        {
            return DatosService.ModificarService(oService, oMatricula, oCodTrab);
        }
        public static Service BuscarService(int oNum)
        {
            return DatosService.BuscarService(oNum);
        }

        public static List<Service> ListarServicesDeClientes(int oCedCliente)
        {
            return DatosService.ListarServiciosDeCliente(oCedCliente);
        }

        public static List<Service> ListarServiciosDeClienteporRangoDeFechas(string oFecha1, string oFecha2, int oCi)
        {
            return DatosService.ListarServiciosDeClienteporRangoDeFechas(oFecha1, oFecha2, oCi);
        }
    }
}
