using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;
using Datos;

namespace Logica
{
    public class LogicaFuncionario
    {
        public static Administrativo LogueoFuncionario(int Cedula,string Contraseña)
        {
            return DatosAdministrativo.LogueoAdministrativo(Cedula, Contraseña);
        }

       
        public static int AgregarFuncionario(Funcionario _Funcionario)
        {
            if (_Funcionario is Administrativo)
            {
                return DatosAdministrativo.AgregarAdministrativo((Administrativo)_Funcionario);
            }
            else
            {
                return DatosMecanico.AgregarMecanico((Mecanico)_Funcionario);
            } 
        }

       
        public static int EliminarFuncioario(Funcionario _Funcionario)
        {
            if (_Funcionario is Administrativo)
            {
                return DatosAdministrativo.EliminarAdministrativo((Administrativo)_Funcionario);
            }
            else
            {
                return DatosMecanico.EliminarMecanico((Mecanico)_Funcionario);
            }
        }

        
        public static int ModificarFuncionario(Funcionario _Funcionario)
        {
            if (_Funcionario is Administrativo)
            {
                return DatosAdministrativo.ModificarAdministrativo((Administrativo)_Funcionario);
            }
            else
            {
                return DatosMecanico.ModificarMecanico((Mecanico)_Funcionario);
            }
        }

       
       

       
        public static Administrativo BuscarAdministrativo(int Cedula)
        {
            return DatosAdministrativo.BuscarAdministrativo(Cedula);
        }
    }
}
