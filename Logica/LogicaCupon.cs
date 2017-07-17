using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;
using Datos;

namespace Logica
{
    public class LogicaCupon
    {
        public static Cupon BuscarCupon(int Cedula)
        {
            return DatosCupon.BuscarCupon(Cedula);
        }
        public static int AgregarCupon(Cupon _Cupon)
        {
            return DatosCupon.AgregarCupon(_Cupon);
        }
        public static int EliminarCupon(Cupon _Cupon)
        {
            return DatosCupon.EliminarCupon(_Cupon);
        }
        public static int ModificarCupon(Cupon _Cupon)
        {
            return DatosCupon.ModificarCupon(_Cupon);
        }
    }
}
