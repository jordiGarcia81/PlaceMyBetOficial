using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models.objects
{
    public class PlaceMyBetContext : DbContext
    {
        public DbSet<Apuesta> Apuestas { get; set; } // tablas
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Mercado> Mercados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public PlaceMyBetContext() { }

        public PlaceMyBetContext(DbContextOptions options) : base(options)
        { 

        }
        protected void onConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=placemybet2;uid=root;pwd ='';SslMode=none;");
        }
    }
    

}