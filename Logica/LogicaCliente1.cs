using System;
using System.Collections.Generic;
using System.Text;

using EntidadesCompartidas;
using Datos;

namespace Logica
{
    public class LogicaCliente1
    {
        public static Cliente LogueoCliente(int Cedula,string Contrase�a)
        {
            return DatosCliente.LogueoCliente(Cedula,Contrase�a);
        }

        public static int AgregarCliente(Cliente oCLiente)
        {
            return DatosCliente.AgregarCliente(oCLiente);
        }

        public static int EliminarCliente(int oCedula)
        {
            return DatosCliente.EliminarCliente(oCedula);
        }

        public static int ModificarCliente(Cliente oCLiente)
        {
            return DatosCliente.ModificarCliente(oCLiente);
        }

        public static Cliente BuscarCliente(int ocedula, int oCedulaAdmin)
        {
            return DatosCliente.BuscarCliente(ocedula, oCedulaAdmin);
        }

        public static List<Cliente> ListarClientes()
        {
            return DatosCliente.ListarClientes();
        }
    }
}
