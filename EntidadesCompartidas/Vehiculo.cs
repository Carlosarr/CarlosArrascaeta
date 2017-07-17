using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCompartidas
{
    public class Vehiculo
    {
        private string _matricula;
        private string _marca;
        private string _modelo;
        private int _ano;
        private List<Foto> _fotos;

        public string Matricula
        {
            get { return _matricula; }
            set { _matricula=value; }
        }

        public string Marca
        {
            get { return _marca; }
            set { _marca=value; }
        }

        public string Modelo
        {
            get { return _modelo; }
            set { _modelo=value;}
        }

        public int Ano
        {
            get { return _ano; }
            set { _ano=value; }
        }

        public List<Foto> Fotos
        {
            get { return _fotos; }
            set { _fotos=value; }
        }

        public Vehiculo()
        {
            _matricula = "";
            _marca = "";
            _modelo = "";
            _ano = 0;
            _fotos = new List<Foto>();
        }

        public Vehiculo(string mat, string marc,string modelo,int ano, List<Foto> fotos)
        {
            _matricula = mat;
            _marca = marc;
            _modelo = modelo;
            _ano = ano;
            _fotos = fotos;
        }

        public override string ToString()
        {
            return "Matricula: " + Matricula + "Marca: " + Marca + "Modelo: " + Modelo + "Ano: " + Ano;
        }
    }
}
