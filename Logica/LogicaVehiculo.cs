using System;
using System.Collections.Generic;
using System.Text;

using Datos;
using EntidadesCompartidas;

namespace Logica
{
   public class LogicaVehiculo
    {
       public static int AgregarVehiculo(Vehiculo oVehiculo, int oCi_Cliente)
       {
           return DatosVehiculo.AgregarVehiculo(oVehiculo, oCi_Cliente);
       }

       public static int EliminarVehiculo(string oMatricula)
       {
           return DatosVehiculo.EliminarVehiculo(oMatricula);
       }

       public static int ModificarVehiculo(Vehiculo oVehiculo, int oCi_Cliente)
       {
           return DatosVehiculo.ModificarVehiculo(oVehiculo, oCi_Cliente);
       }

       public static Vehiculo BuscarVehiculo(string oMatr)
       {
           return DatosVehiculo.BuscarVehiculo(oMatr);
       }

       public static int AgregarFoto(string Matricula, string Imagen)
       {
           return DatosVehiculo.AgregarFoto(Matricula, Imagen);
       }

       public static List<Foto> ListarFotos(string Matricula)
       {
           return DatosVehiculo.ListarFotos(Matricula);
       }

       public static void ModificarFoto(int id,Foto NuevaFoto)
       {
            DatosVehiculo.ModificarFoto(id,NuevaFoto);
       }

       public static void EliminarFoto(int id)
       {
            DatosVehiculo.EliminarFoto(id);
       }

       public static List<Vehiculo> ListarVehiculos2()
       {
           return DatosVehiculo.ListarVehiculos2();
       }

      
    }
}
