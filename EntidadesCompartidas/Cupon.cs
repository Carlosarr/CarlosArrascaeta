using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCompartidas
{
    public class Cupon
    {
        private int _numero;
        private DateTime _fecha;
        private int _valor;
        private Cliente _cliente;


        public int Numero
        {
            get { return _numero;}
            set { _numero = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha=value; }
        }

        public int Valor
        {
            get { return _valor; }
            set { _valor=value; }
        }

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; ; }
        }



        public Cupon()
        {
            _numero = 0;
            _fecha = DateTime.Now;
            _valor = 0;
            _cliente = new Cliente();
        }

        public Cupon(int num, DateTime fecha, int valor, Cliente cliente)
        {
            _numero = num;
            _fecha = fecha;
            _valor = valor;
            _cliente = cliente;
        }

        public override string ToString()
        {
            return "Numero: " + Numero + "Fecha: " + Fecha + "Valor: " + Valor + "Cliente: " + Cliente;
        }
    }
}
