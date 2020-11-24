using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models.objects
{
    public class Usuario
    {
        public string email { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int edad { get; set; }

        public Usuario(string email, string nombre, string apellidos, int edad)
        {
            this.email = email;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
        }

    }
}