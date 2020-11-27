using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models.objects
{
    public class Apuesta
    {
        public int ApuestaId { get; set; }
        public string tipoApuesta { get; set; }
        public string tipoMercado { get; set; }
        public int dinero { get; set; }
        public DateTime fecha { get; set; }
        public int mercadoId{ get; set; }
        public string usuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public Mercado Mercado { get; set; }

        public Apuesta()
        {
        }

        public Apuesta(int ApuestaId, string tipoApuesta, string tipoMercado, int cuota, int dinero, DateTime fecha, int mercadosIdMercado, string usuariosEmail)
        {
            this.ApuestaId = ApuestaId;
            this.tipoApuesta = tipoApuesta;
            this.tipoMercado = tipoMercado;
            this.dinero = dinero;
            this.fecha = fecha;
            this.mercadoId = mercadoId;
            this.usuarioId = usuarioId;
        }

        
       
    }
}