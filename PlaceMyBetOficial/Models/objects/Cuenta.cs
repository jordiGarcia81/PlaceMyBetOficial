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
    public string usuariosEmail { get; set; }
    
    public Cuenta(Int64 numTarjeta, string nombreBanco, double saldo, string usuariosEmail)
        {
            this.numTarjeta = numTarjeta;
            this.nombreBanco = nombreBanco;
            this.saldo = saldo;
            this.usuariosEmail = usuariosEmail;
        }

        
    }
}