using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models.objects
{
    public class Usuario
    {
        public string usuarioId { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int edad { get; set; }
        public List<Apuesta> apuestas { get; set; }
        public Cuenta Cuenta { get; set; }

        public Usuario(string usuarioId, string nombre, string apellidos, int edad)
        {
            this.usuarioId = usuarioId;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
        }

    }
}