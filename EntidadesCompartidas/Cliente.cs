using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCompartidas
{
    public class Cliente
    {
        private int cedula;
        private string contraseña;
        private string nombre;
        private string apellido;
        private string direccion;
        private int telefono;
        private Administrativo _administrativo;
        private List<Vehiculo> _vehiculo;


        public string Etiqueta
        {
            get { return "Nombre: " + Nombre + " " + "Ci: " + Cedula; }
        }
        public int Cedula
        {
            get{return cedula;}
            set{cedula=value;}
        }
        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña=value; }
        }
        public string Nombre
        {
            get{return nombre;}
            set{nombre=value;}
        }
        public string Apellido
        {
            get{return apellido;}
            set { apellido=value; }
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
        public Administrativo Administrativo
        {
            get { return _administrativo; }
            set { Administrativo=value; }
        }

        public List<Vehiculo> Vehiculo
        {
            get { return _vehiculo; }
            set { _vehiculo=value; }
        }

        public Cliente()
        {
            cedula = 123;
            contraseña = "";
            nombre = "";
            apellido = "";
            direccion = "";
            telefono = 000;
            _administrativo = new Administrativo();
            _vehiculo = new List<Vehiculo>();
        }

        public Cliente(int ced,string Contrasena, string nom, string ape,string dir, Administrativo admin, List<Vehiculo> vehiculos,int tel)
        {
            cedula = ced;
            Contraseña = Contrasena;
            nombre = nom;
            apellido = ape;
            _administrativo = admin;
            _vehiculo = vehiculos;
            direccion = dir;
            telefono = tel;
        }

        public override string ToString()
        {
            return "Cedula: " + Cedula + "Nombre: " + Nombre + "Apellido: " + Apellido + "Direccion" + Direccion +  "Administrativo: " + Administrativo + "Telefono: " + Telefono;
        }
    }
}
