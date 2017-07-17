using System;
using System.Collections.Generic;
using System.Text;

using Datos;
using EntidadesCompartidas;

namespace Logica
{
    public class LogicaAdministrativo
    {

        public static Administrativo LogueoAdministrativo(int Cedula, string Contraseña)
        {
            return DatosAdministrativo.LogueoAdministrativo(Cedula, Contraseña);
        }

        public static Administrativo BuscarAdministrativo(int Cedula)
        {
            return DatosAdministrativo.BuscarAdministrativo(Cedula);
        }

        //public static List<int> BuscarTelefonosAdministativo(int Cedula)
        //{
        //    return DatosAdministrativo.BucarTelefonosAdministativo(Cedula);
        //}

        //public static int AgregarTelefonoAdministrativo(int Cedula, int Numero)
        //{
        //    return DatosAdministrativo.AgregarTelefonoAdministrativo(Cedula, Numero);
        //}

        //public static int EliminarTelefonoAdministrativo(int Cedula, int Numero)
        //{
        //    return DatosAdministrativo.EliminarTelefonoAdministrativo(Cedula, Numero);
        //}

        public static int ComprobarRelacionAdministrativo(int Cedula)
        {
            return DatosAdministrativo.ComprobarRelacionAdministrativo(Cedula);
        }

        //public static int EliminarTelefonosAdministrativo(int Cedula)
        //{
        //    return DatosAdministrativo.EliminarTelefonosAdministrativo(Cedula);
        //}
    }
}
