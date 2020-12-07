using Antlr.Runtime.Tree;
using MySql.Data.MySqlClient;
using PlaceMyBetOficial.Models.objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using static PlaceMyBetOficial.Models.objects.Apuesta;
using static PlaceMyBetOficial.Models.objects.ResponseData;

namespace PlaceMyBetOficial.Models
{
    public class ApuestaRepository
    {

        //    DataBase database = null;

        //    public ApuestaRepository()
        //    {
        //        database = new DataBase();

        //        CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
        //        culInfo.NumberFormat.NumberDecimalSeparator = ".";
        //        culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
        //        culInfo.NumberFormat.PercentDecimalSeparator = ".";
        //        culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
        //        System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;
        //    }

        internal List<Apuesta> GetApuestas()

        {
            //database.connect();
            //MySqlDataReader res = database.query("SELECT * FROM apuestas ");

            //Apuesta apuestas = null;
            List<Apuesta> apuestas = new List<Apuesta>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas.ToList();
            }


            //while (res.Read())
            //{
            //    apuestas = new Apuesta(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetDouble(3), res.GetDouble(4), res.GetDateTime(5), res.GetInt32(6), res.GetString(7));
            //    apuesta.Add(apuestas);
            //}
            //// database.disconnect();
            return apuestas;
        }

        internal Apuesta GetApuestas(int id)
        {
            Apuesta apuesta;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuesta = context.Apuestas
                    .Where(s => s.ApuestaId == id)
                    .FirstOrDefault();
            }


            return apuesta;
        }

        public bool CheckApuestas(Apuesta a)
        {
            switch (a.TipoMercado)
            {
                case "1.5":
                case "2.5":
                case "3.5":
                    if ((a.TipoApuesta == "over" || a.TipoApuesta == "under") ) return true;
                    else return false;
                default:
                    return false;
            }
        }
    
        public bool Insertar (Apuesta apuesta)
        {
            PlaceMyBetContext db = new PlaceMyBetContext();
            if (!CheckApuestas(apuesta))
            {
                return false;
            }
            //Inserta Apuesta
            db.Apuestas.Add(apuesta);
            db.SaveChanges();

            //Recuperar el mercado
            MercadoRepository mercadoRepository = new MercadoRepository();
            Mercado mercado = mercadoRepository.GetMercadoTipo(apuesta.TipoMercado);
            double cuota_over;
            double cuota_under;

            try
            {
                //sumarle el dinero correspondiente
                if (apuesta.TipoApuesta == "over") mercado.DineroOver = mercado.DineroOver + apuesta.Dinero;
                else mercado.DineroUnder = mercado.DineroUnder + apuesta.Dinero;

                cuota_over = CalcularCuotaOver(mercado, apuesta.Dinero);
                cuota_under = calcularCuotaUnder(mercado, apuesta.Dinero);

                //modicar las cuotas over y under
                mercado.CuotaOver = cuota_over;
                mercado.CuotaUnder = cuota_under;

                //guardar el mercado con la funcion context.SaveChanges()
                db.Mercados.Update(mercado);
                db.SaveChanges();

            }
            catch (EntityException ex) { }

           
            return true;
        }

        public double CalcularCuotaOver(Mercado m, double dinero)
        {
            double probabilidadOver = dinero / (dinero + m.DineroUnder);
            double cuotaOver = (1 / probabilidadOver) * 0.95;
            return cuotaOver;
        }

        public double calcularCuotaUnder(Mercado m, double dinero)
        {
            double probabilidadUnder = dinero / (m.DineroOver + dinero);
            double cuotaUnder = (1 / probabilidadUnder) * 0.95;
            return cuotaUnder;
        }
    }
}