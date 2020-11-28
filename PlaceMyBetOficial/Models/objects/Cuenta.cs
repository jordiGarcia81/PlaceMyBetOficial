using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models.objects
{
    public class Cuenta
    {

    public long cuentaId { get; set; }
    public string nombreBanco { get; set; }
    public int saldo { get; set; }
    public string usuarioId { get; set; }
    public Usuario Usuario { get; set; }

        public Cuenta()
        {

        }

        public Cuenta(long cuentaId, string nombreBanco, int saldo, string usuarioId)
        {
            this.cuentaId = cuentaId;
            this.nombreBanco = nombreBanco;
            this.saldo = saldo;
            this.usuarioId = usuarioId;
        }

        
    }
}