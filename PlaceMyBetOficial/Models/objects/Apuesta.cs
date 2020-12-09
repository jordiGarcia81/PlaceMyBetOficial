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
        public ApuestaDTO(string usuarioId, int idEvento, string tipoApuesta, double cuotaOver, double cuotaUnder, double dinero, Mercado mercados)
        {
            UsuarioId = usuarioId;
            IdEvento = idEvento;
            TipoApuesta = tipoApuesta;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            Dinero = dinero;
            Mercados = mercados;
        }

        public string UsuarioId { get; }
        public int IdEvento { get; }
        public string TipoApuesta { get; }
        public double CuotaOver { get; }
        public double CuotaUnder { get; }
        public double Dinero { get; }
        public Mercado Mercados { get; }
    }
}