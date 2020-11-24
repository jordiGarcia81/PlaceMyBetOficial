using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models.objects
{
    public class DataContext : Dbcontext
    {
        public Dbset<Apuesta> Apuestas { get; set; } // tablas
        public Dbset<Cuenta> Cuentas { get; set; }
        public Dbset<Evento> Eventos { get; set; }
        public Dbset<Mercado> Mercados { get; set; }
        public Dbset<Usuario> Usuarios { get; set; }

    }

    public DataContext()
    {

    }

    //metodo configuración

    protected override void onConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UserMysql("server = 127.0.0.1; port = 3306; database = placemybet2; uid = root; pwd =; Convert Zero Datetime = True; SslMode = none; ");
        }
    }
}