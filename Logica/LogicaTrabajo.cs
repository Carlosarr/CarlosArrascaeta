using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;
using Datos;

namespace Logica
{
    public class LogicaTrabajo
    {
        public static int AgregarTrabajo(Trabajo _Trabajo)
        {
            return DatosTrabajo.AgregarTrabajo(_Trabajo);
        }

        public static int EliminarTrabajo(Trabajo _Trabajo)
        {
            return DatosTrabajo.EliminarTrabajo(_Trabajo);
        }

        public static int ModificarTrabajo(Trabajo _Trabajo)
        {
            return DatosTrabajo.ModificarTrabajo(_Trabajo);
        }

        public static Trabajo BuscarTrabajo(int Codigo)
        {
            return DatosTrabajo.BuscarTrabajo(Codigo);
        }

        public static List<Trabajo> BuscarTrabajosPorRangoDeFechas(DateTime Fecha1, DateTime Fecha2,int Cedula_Mecanico)
        {
            return DatosTrabajo.BuscarTrabajosPorRangoDeFechas(Fecha1, Fecha2,Cedula_Mecanico);
        }
        public static List<Trabajo> ListarTrabajosDisponibles()
        {
            return DatosTrabajo.ListarTrabajosDisponibles();
        }  
    }
}
