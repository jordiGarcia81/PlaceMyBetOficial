using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models.objects
{
    public class Evento
    {
        public int eventoId { get; set; }
        public string visitante { get; set; }
        public string local { get; set; }
        public DateTime fecha { get; set; }
        public Mercado Mercado { get; set; }

        public Evento(int eventoId, string visitante, string local, DateTime fecha)
        {
            this.eventoId = eventoId;
            this.visitante = visitante;
            this.local = local;
            this.fecha = fecha;

        }
        
        
    }
}