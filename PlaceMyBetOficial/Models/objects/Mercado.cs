using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models.objects
{
    public class Mercado
    {
        public int MercadoId { get; set; }
        public string OverUnder { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }
        public double DineroOver { get; set; }
        public double DineroUnder { get; set; }
        public int EventoId { get; set; }
        public Evento eventos { get; set; }
        public List<Apuesta> Apuestas { get; set; }
        public Mercado()
        {
        }

        public Mercado(int mercadoId, string overUnder, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder, int eventoId)
        {
            this.MercadoId = mercadoId;
            this.OverUnder = overUnder;
            this.CuotaOver = cuotaOver;
            this.CuotaUnder = cuotaUnder;
            this.DineroOver = dineroOver;
            this.DineroUnder = dineroUnder;
            this.EventoId = eventoId;
        }
    }

    public class MercadoDTO
    {
        public string OverUnder { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }
 

        public MercadoDTO()
        {
        }

        public MercadoDTO(string overUnder, double cuotaOver, double cuotaUnder)
        {
            this.OverUnder = overUnder;
            this.CuotaOver = cuotaOver;
            this.CuotaUnder = cuotaUnder;
        }
    }

    public class Mercado2DTO
    {
        public double Dinero { get; set; }
        public string TipoApuesta { get; set; }
        public string Nombre { get; set; }
       


        public Mercado2DTO()
        {
        }

        public Mercado2DTO( double dinero, string tipoApuesta,string nombre)
        {
            this.Dinero = dinero;
            this.TipoApuesta = tipoApuesta;
            this.Nombre = nombre;
        }
    }

}