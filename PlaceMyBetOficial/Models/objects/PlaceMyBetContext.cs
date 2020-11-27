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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=PlaceMyBet2;Uid=root;Pwd=''; SslMode = none");
            }
                
        }
    }
    

}