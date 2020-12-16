using MySql.Data.MySqlClient;
using PlaceMyBetOficial.Models.objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;


namespace PlaceMyBetOficial.Models
{
    public class MercadoRepository
    {
       
        public List<Mercado> GetMercados()
        {

            List<Mercado> mercados = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                // mercados = context.Mercados.Include(p => p.eventos).ToList();
                mercados = context.Mercados.ToList();
            }


            return mercados;

        }
        public List<Mercado> GetMercadosEvento()
        {

            List<Mercado> mercados = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Mercados.Include(p => p.eventos).ToList();
                mercados = context.Mercados.ToList();
            }


            return mercados;

        }
        public List<MercadoDTO> GetMercadosDTO()
        {

            List<Mercado> mercados = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Mercados.Include(p => p.eventos).ToList();
            }

            List<MercadoDTO> mercadosDTO = new List<MercadoDTO>();

            foreach(Mercado m in mercados)
            {
                MercadoDTO mercadoDto = new MercadoDTO(m.OverUnder,m.CuotaOver,m.CuotaUnder);
                mercadosDTO.Add(mercadoDto);
            }

            return mercadosDTO;

        }

        internal List<Mercado2DTO> GetMercadoId(int id)
        {
            Mercado mercado;
            Usuario usuario;
            List<Mercado2DTO> mercado2DTO = new List<Mercado2DTO>();

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.Mercados.Include(p => p.Apuestas).Where(s => s.MercadoId == id).FirstOrDefault();


                foreach (Apuesta a in mercado.Apuestas)
                {

                    usuario = context.Usuarios
                    .Where(s => s.UsuarioId == a.UsuarioId)
                    .FirstOrDefault();

                    Mercado2DTO mercado2Dto = new Mercado2DTO(a.Dinero, a.TipoApuesta, usuario.Nombre);
                    mercado2DTO.Add(mercado2Dto);
                }
            }

            return mercado2DTO;
        }
        internal Mercado GetMercadoTipo(string tipoMercado)
        {
            Mercado mercado;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.Mercados
                    .Where(s => s.OverUnder == tipoMercado)
                    .FirstOrDefault();
            }


            return mercado;
        }
        public void insert(Mercado mercado)
        {
            PlaceMyBetContext db = new PlaceMyBetContext();

           

            db.Mercados.Add(mercado);
            
            db.SaveChanges();

           
        }


        static Mercado2DTO ToDTO(Mercado m)
        {
            return null ;
        }

        public List<Mercado2DTO> GetMercado2DTO()
        {
            List<Mercado> mercados = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Mercados.Include(p => p.Apuestas).ToList();
            }

            List<Mercado2DTO> mercadoDTO = new List<Mercado2DTO>();

            foreach (Mercado m in mercados)
            {
                Mercado2DTO mercado2Dto = ToDTO(m);
                mercadoDTO.Add(mercado2Dto);
            }

            return mercadoDTO;
        }
    }

   


}

    
