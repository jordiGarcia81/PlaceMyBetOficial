using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models.objects
{
    public class Mercado
    {
        public int MercadoId { get; set; }
        public string overUnder { get; set; }
        public double cuotaOver { get; set; }
        public double cuotaUnder { get; set; }
        public double dineroOver { get; set; }
        public double dineroUnder { get; set; }
        public int eventoId { get; set; }
        public List<Apuesta> apuestas { get; set; }
        public List<Evento> eventos { get; set; }

        public Mercado()
        {
        }

        public Mercado(int MercadoId, string overUnder, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder, int eventoId)
        {
            this.MercadoId = MercadoId;
            this.overUnder = overUnder;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.dineroOver = dineroOver;
            this.dineroUnder = dineroUnder;
            this.eventoId = eventoId;
        }

        
    }
}