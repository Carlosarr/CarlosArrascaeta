using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCompartidas
{
    public class Funcionario
    {
        //atributos

        private int cedula;
        private string contrase�a;
        private string nombre;
        private string apellido;
        private int sueldo;
        private string direccion;
        private int telefono;


        //propiedades

        public int Cedula
        {
            get { return cedula; }
            set { cedula=value; }
        }

        public string Contrase�a
        {
            get { return contrase�a; }
            set { contrase�a=value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre=value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido=value; }
        }

        public int Sueldo
        {
            get { return sueldo; }
            set { sueldo=value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion=value; }
        }

        public int Telefono
        {
            get { return telefono; }
            set { telefono=value; }
        }

       

        //constructores

        public Funcionario()
        {
            cedula = 0;
            contrase�a = "";
            nombre = "sin nombre";
            apellido = "sin apellido";
            sueldo = 0;
            direccion = "sin direccion";
            telefono = 000;
        }
        
        //constructor que recibe solo la cedula cuando no necesito los dmas datos del objeto
        public Funcionario(int ced)
        {
            cedula = ced;
            contrase�a = "";
            nombre = "sin nombre";
            apellido = "sin apellido";
            sueldo = 0;
            direccion = "sin direccion";
            telefono = 000;
        }

        public Funcionario(int ced,string con ,string nom, string ape, int sue, string dir, int tel)
        {
            cedula = ced;
            contrase�a = con;    
            nombre = nom;
            apellido = ape;
            sueldo = sue;
            direccion = dir;
            telefono = tel;
        }

        public override string ToString()
        {
            return "Cedula: " + Cedula  +", Nombre: " + Nombre + ", Apellido: " + Apellido + ", Sueldo: " + Sueldo + ", Direccion: " + Direccion + ", Telefono: " + Telefono;
        }
    }
}
