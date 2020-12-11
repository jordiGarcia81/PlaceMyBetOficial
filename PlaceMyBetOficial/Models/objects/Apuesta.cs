using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models.objects
{
    public class Apuesta
    {
        public int ApuestaId { get; set; }
        public string TipoApuesta { get; set; }
        public string TipoMercado { get; set; }
        public int Dinero { get; set; }
        public DateTime Fecha { get; set; }
        public int MercadoId{ get; set; }
        public string UsuarioId { get; set; }
        public Mercado mercados { get; set; }
        //objeto usuario
        public Apuesta()
        {
        }

        public Apuesta(int apuestaId, string tipoApuesta, string tipoMercado, int dinero, DateTime fecha, int mercadoId, string usuarioId)
        {
            this.ApuestaId = apuestaId;
            this.TipoApuesta = tipoApuesta;
            this.TipoMercado = tipoMercado;
            this.Dinero = dinero;
            this.Fecha = fecha;
            this.MercadoId = mercadoId;
            this.UsuarioId = usuarioId;
        }


    }

    public class ApuestaDTO

    {
        public string UsuarioId { get; set; }
        public int IdEvento { get; set; }
        public string TipoApuesta { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }
        public double Dinero { get; set; }
        public Mercado Mercados { get; set; }

        public ApuestaDTO()
        {

        }
        public ApuestaDTO(string usuarioId, int idEvento, string tipoApuesta, double cuotaOver, double cuotaUnder, double dinero, Mercado mercados)
        {
            this.UsuarioId = usuarioId;
            this.IdEvento = idEvento;
            this.TipoApuesta = tipoApuesta;
            this.CuotaOver = cuotaOver;
            this.CuotaUnder = cuotaUnder;
            this.Dinero = dinero;
            this.Mercados = mercados;
        }

       
    }
}