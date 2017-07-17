using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCompartidas
{
    public class Foto
    {

        private string _direccionFoto;
        private int _idFoto;

        public string DireccionFotos
        {
            get { return _direccionFoto; }
            set { _direccionFoto = value; }
        }
        public int IdFoto
        {
            get { return _idFoto; }
            set { _idFoto = value; }
        }

        public Foto()
        {
            _direccionFoto = "";
            _idFoto = 0;
        }
        public Foto(string dir)
        {
            _direccionFoto = dir;
            
        }
        public Foto(string dir,int Id)
        {
            _direccionFoto = dir;
            _idFoto = Id;

        }
    }
}
