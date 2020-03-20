using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPersona
{
    public class Estado
    {
        private int estado;

        enum situacion { soltero=0,casado=1,divorciado=2,viudo=3}

        public Estado(int estado)
        {
            this.estado = estado;
        }

        public int getEstado()
        {
            return estado;
        }
    }
}
