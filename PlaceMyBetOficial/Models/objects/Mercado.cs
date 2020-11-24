using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models.objects
{
    public class Mercado
    {
        public int idMercado { get; set; }
        public string overUnder { get; set; }
        public double cuotaOver { get; set; }
        public double cuotaUnder { get; set; }
        public double dineroOver { get; set; }
        public double dineroUnder { get; set; }
        public int eventosIdEvento { get; set; }

        public Mercado()
        {
        }

        public Mercado(int idMercado, string overUnder, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder, int eventosIdEvento)
        {
            this.idMercado = idMercado;
            this.overUnder = overUnder;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.dineroOver = dineroOver;
            this.dineroUnder = dineroUnder;
            this.eventosIdEvento = eventosIdEvento;
        }

        
    }
}