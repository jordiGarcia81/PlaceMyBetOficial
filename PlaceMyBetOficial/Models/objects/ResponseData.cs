﻿using System;
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
            public string tipoMercado { get; set; }
            public string email { get; set; }


            public ResponseApuestasUsuario(int idEvento, string tipoApuesta, double cuotaOver, double cuotaUnder, double dinero)
            {
                this.idEvento = idEvento;
                this.tipoApuesta = tipoApuesta;
                this.cuotaOver = cuotaOver;
                this.cuotaUnder = cuotaUnder;
                this.dinero = dinero;
            }

            
          

            //public ResponseApuestasMercado( string tipoMercado,string tipoApuesta, double cuotaOver, double cuotaUnder, double dinero,string email)
            //{
            //    this.tipoMercado = tipoMercado;
            //    this.tipoApuesta = tipoApuesta;
            //    this.cuotaOver = cuotaOver;
            //    this.cuotaUnder = cuotaUnder;
            //    this.dinero = dinero;
            //    this.email = email;
            //}

        }
    }
}