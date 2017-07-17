using System;
using System.Collections.Generic;
using System.Text;


namespace EntidadesCompartidas
{
    public class Mecanico:Funcionario
    {
        
        private string especialidad;
        private Mecanico sustituto;
        

        public Mecanico Sustituto
        {
            get{return sustituto;}
            set { sustituto=value; }
        }

        public string Especialidad
        {
            get { return especialidad; }
            set { especialidad=value; }
        }

        public string Etiqueta
        {
            get { return "Cedula: " + Convert.ToString(Cedula) + "- Especialidad: " + Especialidad; }
        }

        public Mecanico()
            : base()
          
        {
            especialidad = "sin especialidad";
            sustituto = null;
        }

        //constructor mixto que recibe solo la cedula, cuando no necesito los demas datos
        public Mecanico(int ced)
            : base(ced)
        {
            Cedula = ced;
            especialidad = "sin especialidad";
            sustituto = null;
        }

        public Mecanico(int ced,string con, string nom, string ape, int sue, string dir,Mecanico sust, string espe,int tel)
            : base(ced,con, nom, ape, sue, dir, tel)
        {
            especialidad = espe;
            sustituto = sust;
        }

        public override string ToString()
        {
            return base.ToString() + "Especialidad: " + Especialidad;
        }

    }
}
