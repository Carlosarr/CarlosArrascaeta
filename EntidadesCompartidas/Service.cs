using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCompartidas
{
   public  class Service
    {
        
        private int _numero;
        private string _estado;
        private DateTime _fecha;
        private Cliente _cliente;
        private Administrativo _administrativo;
        private List<Trabajo> _trabajos;


        public int Numero
        {
            get { return _numero; }
            set {_numero=value; }
        }

        public string Estado
        {
            get { return _estado; }
            set { _estado=value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha=value; }
        }

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente=value; }
        }

        public Administrativo Administrativo
        {
            get { return _administrativo; }
            set { _administrativo=value; }
        }

        public List<Trabajo> Trabajos
        {
            get { return _trabajos; }
            set { _trabajos=value; }
        }

        public Service()
        {
            _numero=0;
            _estado="";
            _fecha = DateTime.Now;
            _cliente = new Cliente();
            _administrativo = new Administrativo();
            _trabajos = new List<Trabajo>();

        }

        public Service(int num,string est,DateTime fec,Cliente cli,Administrativo adm,List<Trabajo> trab)
        {
            _numero = num;
            _estado = est;
            _fecha = fec;
            _cliente = cli;
            _administrativo = adm;
            _trabajos = trab;

        }

        public override string ToString()
        {
            return "Numero: " + Numero + "Estado: " + Estado + "Fecha: " + Fecha + "Cliente: " + Cliente + "Administrativo: " + Administrativo;
        }


    }
}
