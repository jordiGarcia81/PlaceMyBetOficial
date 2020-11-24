using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models.objects
{
    public class Evento
    {
        public int idEvento { get; set; }
        public string visitante { get; set; }
        public string local { get; set; }
        public DateTime fecha { get; set; }

        public Evento(int idEvento, string visitante, string local, DateTime fecha)
        {
            this.idEvento = idEvento;
            this.visitante = visitante;
            this.local = local;
            this.fecha = fecha;

        }
        public class EventoDTO
        {
            public string visitante { get; set; }
            public string local { get; set; }
            public DateTime fecha { get; set; }
            public EventoDTO(string visitante, string local, DateTime fecha)
            {
                this.visitante = visitante;
                this.local = local;
                this.fecha = fecha;

            }
        }
    }
}