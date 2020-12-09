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
                mercados = context.Mercados.Include(p => p.eventos).ToList();
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

        internal Mercado GetMercadoId(int id)
        {
            Mercado mercado;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.Mercados
                    .Where(s => s.MercadoId == id)
                    .FirstOrDefault();
            }


            return mercado;
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
        public bool insert(Mercado mercado)
        {
            PlaceMyBetContext db = new PlaceMyBetContext();

            if (!checkMercado(mercado)) {
                return false;
            }

            db.Mercados.Add(mercado);
            db.SaveChanges();

            return true;
        }

        private bool checkMercado(Mercado mercado)
        {
            if(mercado.OverUnder=="1.5"|| mercado.OverUnder == "2.5"||mercado.OverUnder == "3.5")
            {
                return true;
            }

            return false;
        }
        //public void create(Mercado mercado)
        //    {
        //        using (PlaceMyBetContext context = new PlaceMyBetContext())
        //        {
        //            string query = "INSERT mercados (OverUnder,CuotaOver,CuotaUnder,DineroOver,DineroUnder,EventoId)" +
        //                "VALUES(@OverUnder,@CuotaOver,@CuotaUnder,@DineroOver,@DineroUnder,@EventoId)";
        //            string parameters = new MySqlParameter[]
        //            {
        //            new MySqlParameter=("@OverUnder",mercado.OverUnder);
        //            new MySqlParameter= ("@CuotaOver", mercado.CuotaOver);
        //            new MySqlParameter= ("@CuotaUnder", mercado.CuotaUnder);
        //            new MySqlParameter= ("@DineroOver", mercado.DineroOver);
        //            new MySqlParameter= ("@DineroUnder", mercado.DineroUnder);
        //            new MySqlParameter= ("@EventoId", mercado.EventoId);

        //            }
        //        PlaceMyBetContext.Database.ExecuteSqlRaw(query, parameters);
        //        }
        //}
        //    public List<Mercado> GetMercadosDTO(string overUnder)
        //    {

        //        //database.connect();
        //        MySqlDataReader res = database.query("SELECT * FROM mercados WHERE over_under='"+ overUnder+"'");

        //        Mercado mercado = null;
        //        List<Mercado> mercados = new List<Mercado>();

        //        while (res.Read())
        //        {

        //            mercado = new Mercado(res.GetInt32(0), res.GetString(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6));
        //            mercados.Add(mercado);
        //        }
        //        //database.disconnect();
        //        return mercados;

        //    }
        //    public List<Mercado> getMercadosEvent(int idEvento,string overUnder)
        //    {
        //        //database.connect();

        //        Dictionary<string, string> dicParameters = new Dictionary<string, string>();
        //        dicParameters.Add("@OU", overUnder);
        //        dicParameters.Add("@OI", Convert.ToString(idEvento));


        //        MySqlDataReader res = database.query_parameters("SELECT m.* FROM eventos e INNER JOIN mercados m ON e.id_evento = @OI WHERE m.over_under = @OU;", dicParameters);

        //        Mercado mercado = null;
        //        List<Mercado> mercados = new List<Mercado>();

        //        while (res.Read())
        //        {

        //            mercado = new Mercado(res.GetInt32(0), res.GetString(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6));
        //            mercados.Add(mercado);
        //        }
        //        //database.disconnect();
        //        return mercados;


        //    }

    }

    }
