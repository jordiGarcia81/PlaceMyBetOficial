using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models.objects
{
    public class PlaceMyBetContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Apuesta> Apuestas { get; set; } // tablas
        public Microsoft.EntityFrameworkCore.DbSet<Cuenta> Cuentas { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Evento> Eventos { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Mercado> Mercados { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Usuario> Usuarios { get; set; }

        public PlaceMyBetContext(DbContextOptions options) : base(options)
        { 

        }
        protected void onConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseMySql(@"server=127.0.0.1;port=3306;database=placemybet2;uid=root; pwd =;Convert Zero Datetime=True;SslMode=none;");
        }
    }
    

}