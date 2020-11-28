using MySql.Data.MySqlClient;
using PlaceMyBetOficial.Models.objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models
{
    public class MercadoRepository
    {
        DataBase database = null;

        public MercadoRepository()
        {
            database = new DataBase();
        }
        public List<Mercado> GetMercados()
        {

            database.connect();
            MySqlDataReader res = database.query("SELECT * FROM mercados");

            Mercado mercado = null;
            List<Mercado> mercados = new List<Mercado>();

            while (res.Read())
            {

                mercado = new Mercado(res.GetInt32(0), res.GetString(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6));
                mercados.Add(mercado);
            }
            database.disconnect();
            return mercados;

        }
        public List<Mercado> GetMercadosDTO(string overUnder)
        {
          
            database.connect();
            MySqlDataReader res = database.query("SELECT * FROM mercados WHERE over_under='"+ overUnder+"'");

            Mercado mercado = null;
            List<Mercado> mercados = new List<Mercado>();

            while (res.Read())
            {
               
                mercado = new Mercado(res.GetInt32(0), res.GetString(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6));
                mercados.Add(mercado);
            }
            database.disconnect();
            return mercados;

        }
        public List<Mercado> getMercadosEvent(int idEvento,string overUnder)
        {
            database.connect();

            Dictionary<string, string> dicParameters = new Dictionary<string, string>();
            dicParameters.Add("@OU", overUnder);
            dicParameters.Add("@OI", Convert.ToString(idEvento));


            MySqlDataReader res = database.query_parameters("SELECT m.* FROM eventos e INNER JOIN mercados m ON e.id_evento = @OI WHERE m.over_under = @OU;", dicParameters);

            Mercado mercado = null;
            List<Mercado> mercados = new List<Mercado>();

            while (res.Read())
            {

                mercado = new Mercado(res.GetInt32(0), res.GetString(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6));
                mercados.Add(mercado);
            }
            database.disconnect();
            return mercados;


        }



        /*
        
        public List<Mercado> GetEventos(Mercado m)
        {
            database.connect();

            MySqlDataReader res = database.query("insert into mercados(over_under,cuota_over,cuota_under,dinero_over,dinero_under) values(@IE,@OU, SELECT `mercados`.`Eventos_id_evento`, `mercados`.`over_under`FROM `mercados`WHERE((`mercados`.`Eventos_id_evento`= @IE) AND(`mercados`.`over_under`= @OU)))");
            database.query.AddWithValue("@IE", m.eventosIdEvento); //Diccionario o array
            database.query.AddWithValue("@OU", m.overUnder);

           
        }
        */
        //public double calcularCuotaOver(Mercado m)
        //{
        //    double probabilidadOver = m.dineroOver / (m.dineroOver + m.dineroUnder);
        //    double cuotaOver = (1 / probabilidadOver) * 0.95;
        //    return cuotaOver;
        //}

        //public double calcularCuotaUnder(Mercado m)
        //{
        //    double probabilidadUnder = m.dineroUnder / (m.dineroOver + m.dineroUnder);
        //    double cuotaUnder = (1 / probabilidadUnder) * 0.95;
        //    return cuotaUnder;
        //}

        //public void probabilidad(Mercado m, Apuesta a)
        //{
        //    database.connect();
        //    MySqlDataReader res = database.query("UPDATE mercados SET cuota_over=" + calcularCuotaOver(m) + "," + " cuota_under= " + calcularCuotaUnder(m) + " WHERE id_mercado= " + a.mercadosIdMercado + ";");

        //    try
        //    {
        //        database.connect();
        //        database.disconnect();

        //    }
        //    catch
        //    {
        //        
        //    }
        //}
    }
}