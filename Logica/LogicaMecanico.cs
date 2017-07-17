using System;
using System.Collections.Generic;
using System.Text;

using Datos;
using EntidadesCompartidas;

namespace Logica
{
    public class LogicaMecanico
    {
        public static Mecanico LogueoMecanico(int Cedula, string Contraseña)
        {
            return DatosMecanico.LogueoMecanico(Cedula, Contraseña);
        }

        public static Mecanico BuscarMecanico(int Cedula)
        {
            return DatosMecanico.BuscarMecanico(Cedula);
        }

        //public static List<int> BuscarTelefonosMecanico(int Cedula)
        //{
        //    return DatosMecanico.BuscarTelefonosMecanico(Cedula);
        //}

        //public static int AgregarTelefonoMecanico(int Cedula, int Numero)
        //{
        //    return DatosMecanico.AgregarTelefonoMecanico(Cedula, Numero);
        //}

        //public static int EliminarTelefonoMecanico(int Cedula, int Numero)
        //{
        //    return DatosMecanico.EliminarTelefonoMecanico(Cedula, Numero);
        //}

        public static List<Mecanico> ListarMecanicos()
        {
            return DatosMecanico.ListarMecanicos();
        }

        public static int ComprobarRelacionMecanico(int Cedula)
        {
            return DatosMecanico.ComprobarRelacionMecanico(Cedula);
        }

        //public static int EliminarTelefonosMecanico(int Cedula)
        //{
        //    return DatosMecanico.EliminarTelefonosMecanico(Cedula);
        //}
    }
}
