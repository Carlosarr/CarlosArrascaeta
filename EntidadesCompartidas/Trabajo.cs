using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCompartidas
{
    public class Trabajo
    {
        private int _codigo;
        private string _descripcion;
        private Mecanico _mecanico;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo=value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion=value; }
        }

        public Mecanico Mecanico
        {
            get { return _mecanico; }
            set { _mecanico=value; }
        }


        public Trabajo()
        {
            _codigo = 0;
            _descripcion = "";
            _mecanico=new Mecanico();
        }

         public Trabajo(int cod, string desc, Mecanico meca)
        {
            _codigo = cod;
            _descripcion= desc;
            _mecanico = meca;
        }

        public override string ToString()
        {
            return "Codigo" + Codigo + "Descripcion" + Descripcion + "Mecanico" + Mecanico;
        }

    }
}
