using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models.objects
{
    public class ResponseApuestasCuota
    {


    public double cuotaOver { get; set; }

    public double cuotaUnder { get; set; }

    public string email { get; set; }
    public ResponseApuestasCuota( double cuotaOver, double cuotaUnder, string email)
    {
        
        this.cuotaOver = cuotaOver;
        this.cuotaUnder = cuotaUnder;
        this.email = email;
    }

    }
}