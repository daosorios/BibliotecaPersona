using System;

namespace Vista1
{
    internal class Persona
    {
        internal object sexo;
        internal string rut;
        internal string apellidos;
        internal DateTime? fechaNaci;
        internal string estadoCiv;

        public string nombres { get; internal set; }
    }
}