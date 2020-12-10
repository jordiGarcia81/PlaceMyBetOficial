using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models.objects
{
    public class ResponseApuesta
    {
        public string UsuarioId { get; set; }
        public int idEvento { get; set; }
        public string TipoApuesta { get; set; }
        public double cuotaOver { get; set; }

        public double cuotaUnder { get; set; }
        public double dinero { get; set; }
        public Mercado mercados { get; set; }
        public ResponseApuesta()
        {
                
        }
        public ResponseApuesta(string UsuarioId, int idEvento, string TipoApuesta, double cuotaOver, double cuotaUnder, double dinero,Mercado mercado)
        {
            this.UsuarioId = UsuarioId;
            this.idEvento = idEvento;
            this.TipoApuesta = TipoApuesta;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.dinero = dinero;
    }

    }
   

}