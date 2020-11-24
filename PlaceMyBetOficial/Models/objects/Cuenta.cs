using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models.objects
{
    public class Cuenta
    {

    public long numTarjeta { get; set; }
    public string nombreBanco { get; set; }
    public double saldo { get; set; }
    public string usuarioId { get; set; }
    public Usuario Usuario { get; set; }

        public Cuenta(Int64 numTarjeta, string nombreBanco, double saldo, string usuarioId)
        {
            this.numTarjeta = numTarjeta;
            this.nombreBanco = nombreBanco;
            this.saldo = saldo;
            this.usuarioId = usuarioId;
        }

        
    }
}