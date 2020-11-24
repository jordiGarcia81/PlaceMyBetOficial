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
        public float cuotaOver { get; set; }
        public float cuotaUnder { get; set; }
        public float dineroOver { get; set; }
        public float dineroUnder { get; set; }
        public int eventoId { get; set; }
        public List<Apuesta> apuestas { get; set; }
        public List<Evento> eventos { get; set; }

        public Mercado()
        {
        }

        public Mercado(int MercadoId, string overUnder, float cuotaOver, float cuotaUnder, float dineroOver, float dineroUnder, int eventoId)
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