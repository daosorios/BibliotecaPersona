using System;

//BIblioteca de cliente
namespace BeLife
{

    //creando clase de cliente 
    public class Cliente
    {
        //Atributos y get and set 
        public string rut { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public Sexo genero { get; set; }

        public Estado situacion { get; set; }

        //contructor de cliente 
        public Cliente()
        {
            this.Init();
        }

        //constructor con parametros
        private void Init()
        {
            rut = string.Empty;
            nombres = string.Empty;
            apellidos = string.Empty;
            fechaNacimiento = DateTime.Today;
            genero = Sexo.femenino;
            situacion = Estado.casado;
         
            
        }

    }   
}
