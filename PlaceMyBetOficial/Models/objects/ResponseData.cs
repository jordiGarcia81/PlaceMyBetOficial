using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models.objects
{
    public class ResponseData
    {
        public class ResponseApuestasUsuario
        {

            public int idEvento { get; set; }
            public string tipoApuesta { get; set; }

            public double cuotaOver { get; set; }

            public double cuotaUnder { get; set; }

            public double dinero { get; set; }


            public ResponseApuestasUsuario(int idEvento, string tipoApuesta, double cuotaOver, double cuotaUnder, double dinero)
            {
                this.idEvento = idEvento;
                this.tipoApuesta = tipoApuesta;
                this.cuotaOver = cuotaOver;
                this.cuotaUnder = cuotaUnder;
                this.dinero = dinero;
            }

            
          

            public ResponseApuestasUsuario( string tipoApuesta, double cuotaOver, double cuotaUnder, double dinero)
            {
              
                this.tipoApuesta = tipoApuesta;
                this.cuotaOver = cuotaOver;
                this.cuotaUnder = cuotaUnder;
                this.dinero = dinero;
            }

        }
    }
}