using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCompartidas
{
    public class Administrativo: Funcionario
    {
       
            private string nivelDeInstruccion;
           

           
            public string NivelDeInstruccion
            {
                get { return nivelDeInstruccion; }
                set { nivelDeInstruccion=value; }
            }

            public Administrativo()
                : base()
                
            {
                nivelDeInstruccion = "ninguno";
                
            }

        public Administrativo(int ced, string contras,string nom, string ape, int sue, string dir,string nivel,int tel)
            : base(ced,contras, nom, ape, sue, dir,tel)

        {
            
            nivelDeInstruccion = nivel;
        }

        public override string ToString()
        {
            return base.ToString() + "NivelDeInstruccion: " + NivelDeInstruccion;
        }
        
    }
}
