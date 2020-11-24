using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models.objects
{
    public class Apuesta
    {

        public string tipoApuesta { get; set; }
        public string tipoMercado { get; set; }
        public double dinero { get; set; }
        public int idMercado { get; set; }
        public string usuariosEmail { get; set; }

        public Apuesta()
        {
        }

        public Apuesta(int idApuesta, string tipoApuesta, string tipoMercado, double cuota, double dinero, DateTime fecha, int mercadosIdMercado, string usuariosEmail)
        {
            this.tipoApuesta = tipoApuesta;
            this.tipoMercado = tipoMercado;
            this.dinero = dinero;
            this.idMercado = idMercado;
            this.usuariosEmail = usuariosEmail;
        }

        
        public class ApuestaDTO
        {
            public ApuestaDTO(string tipoApuesta, double tipoMercado, double cuota, double dinero, DateTime fecha, string usuariosEmail)
            {
                this.tipoApuesta = tipoApuesta;
                this.tipoMercado = tipoMercado;
                this.cuota = cuota;
                this.dinero = dinero;
                this.fecha = fecha;
                this.usuariosEmail = usuariosEmail;
            }

            public string tipoApuesta { get; set; }
            public double tipoMercado { get; set; }
            public double cuota { get; set; }
            public double dinero { get; set; }
            public DateTime fecha { get; set; }
            public string usuariosEmail { get; set; }
        }
    }
}