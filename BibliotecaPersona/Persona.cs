using System;

namespace BibliotecaPersona
{
    public class Persona
    {
        public String rut { get; set; }
        public String nombres { get; set; }
        public String apellidos { get; set; }
        public DateTime fechaNaci { get; set; }

        public String sexo { get; set; }
        public String estadoCiv { get; set; }
        public Persona()
        {
            this.Init();
        }

        private void Init()
        {
            rut = string.Empty;
            nombres = string.Empty;
            apellidos = string.Empty;
            fechaNaci = DateTime.Today;
            sexo = string.Empty;
            estadoCiv = string.Empty;
        }

    }   
}
