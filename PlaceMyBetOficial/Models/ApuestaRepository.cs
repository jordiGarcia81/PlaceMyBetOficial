using Antlr.Runtime.Tree;
using MySql.Data.MySqlClient;
using PlaceMyBetOficial.Controllers;
using PlaceMyBetOficial.Models.objects;
using System;
using System.Collections.Generic;
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
        
        DataBase database = null;

        public ApuestaRepository()
        {
            database = new DataBase();

            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;
        }

        public List<Apuesta> GetApuestas()
        {
            database.connect();
            MySqlDataReader res = database.query("SELECT * FROM puestas");

           Apuesta apuestas = null;
           List<Apuesta> apuesta = new List<Apuesta>();

            while (res.Read())
            {
                apuestas = new Apuesta(res.GetInt32(0),res.GetString(1), res.GetString(2), res.GetDouble(3),res.GetDateTime(4), res.GetInt32(5), res.GetString(6));
                apuesta.Add(apuestas);
            }
            database.disconnect();
            return apuesta;
        }

        internal List<ApuestaDTO> GetApuestaDTO()
        {
            database.connect();
            MySqlDataReader res = database.query("SELECT tipo_apuesta,tipo_mercado,dinero,fecha,Usuarios_email FROM apuestas");

            ApuestaDTO apuestas = null;
            List<ApuestaDTO> apuesta = new List<ApuestaDTO>();

            while (res.Read())
            {
                apuestas = new ApuestaDTO(res.GetString(0),res.GetString(1) , res.GetDouble(2) ,  res.GetDateTime(3),res.GetString(4) );
                apuesta.Add(apuestas);
            }
            database.disconnect();
            return apuesta;
        }

        public bool CheckData( Apuesta a)
        {

            //Nombre comprobar si esta en BBDD
            switch (a.tipoMercado)
            {
                case "1.5":
                case "2.5":
                case "3.5":
                    if ((a.tipoApuesta == "over" || a.tipoApuesta == "under") && a.dinero > 0) return true;
                    else return false;
                default:
                    return false;
            }
        }
        public bool Insertar(Apuesta a)
        {

            DateTime date = DateTime.Now;
            string fecha;
            fecha = date.ToString("yyyy-MM-dd HH:mm:ss");

            try
            {
                database.connect();

                if (!CheckData(a))
                    return false;

                MySqlDataReader res = database.query("INSERT INTO apuestas (tipo_apuesta,tipo_mercado,dinero,fecha,Mercados_id_mercado,Usuarios_email) values ('" + a.tipoApuesta + "','" + a.tipoMercado + "'," + a.dinero + ",'" + fecha + "','" + a.usuariosEmail + "');");

                database.disconnect();

                nuevaCuota(a.tipoMercado, a.tipoApuesta, a.dinero);
                aumentoDinero(a);
               
            }
            catch (MySqlException e)
            {
               database.disconnect();
               return false;

            }
            return true;
        }

        public double calcularCuotaOver(Mercado m, double dinero)
        {
            double probabilidadOver = dinero / (dinero + m.dineroUnder);
            double cuotaOver = (1 / probabilidadOver) * 0.95;
            return cuotaOver;
        }

        public double calcularCuotaUnder(Mercado m, double dinero)
        {
            double probabilidadUnder = dinero / (m.dineroOver + dinero);
            double cuotaUnder = (1 / probabilidadUnder) * 0.95;
            return cuotaUnder;
        }

        public void aumentoDinero(Apuesta a)
        {
            database.connect();
           
            if (a.tipoApuesta == "over")
            {
                MySqlDataReader res = database.query ("UPDATE mercados SET dinero_over=dinero_over+" + a.dinero + " WHERE over_under = " + a.tipoMercado + ";");
            }
            else if (a.tipoApuesta == "under")
            {
                MySqlDataReader res = database.query ("UPDATE mercados SET dinero_under= dinero_under +" + a.dinero + " WHERE over_under = " + a.tipoMercado + ";");
            }

            database.disconnect();
        }

        //NuevaCuota(tipo_mercado, over_under, dinero); 
        public void nuevaCuota(string tipo_mercado, string over_under, double dinero)
        {
            MercadoRepository mercadoRepository = new MercadoRepository();
            List<Mercado> listamercados = mercadoRepository.GetMercadosDTO(tipo_mercado);
            double cuota_over;
            double cuota_under;



            try
            {
                database.connect();
                Apuesta a = null;
                if (over_under == "over")
                {
                    cuota_over = calcularCuotaOver(listamercados[0], dinero);
                    Debug.WriteLine("UPDATE mercados SET cuota_over=" + cuota_over + " WHERE over_under= '" + tipo_mercado + "';");
                    MySqlDataReader res = database.query("UPDATE mercados SET cuota_over="+ cuota_over + " WHERE over_under= '" + tipo_mercado+"';");
                }
                else
                {
                    cuota_under = calcularCuotaUnder(listamercados[0], dinero);
                    MySqlDataReader res = database.query("UPDATE mercados SET cuota_under=" + cuota_under + " WHERE over_under= '" + tipo_mercado + "';");
                }
               
                
               database.disconnect();

            }
            catch (MySqlException e)
            {
                database.disconnect();
            }

           

        }

        public List<ResponseApuestasUsuario> getApuestaUsuario(string usuariosEmail,int mercadosIdMercado)
        {
            database.connect();

            Dictionary<string, string> dicParameters = new Dictionary<string, string>();

            dicParameters.Add("@UE", usuariosEmail);
            dicParameters.Add("@IM", Convert.ToString(mercadosIdMercado));
            MySqlDataReader res = database.query_parameters("SELECT  m.Eventos_id_evento,a.tipo_apuesta,m.cuota_over,m.cuota_under,a.dinero FROM mercados m INNER JOIN apuestas a ON m.id_mercado = a.Mercados_id_mercado INNER JOIN eventos e ON m.Eventos_id_evento = e.id_evento WHERE Usuarios_email= @UE AND id_mercado= @IM;", dicParameters);


            ResponseApuestasUsuario apuesta = null;
            List<ResponseApuestasUsuario> apuestas = new List<ResponseApuestasUsuario>();

            while (res.Read())
            {

                apuesta = new ResponseApuestasUsuario(res.GetInt32(0), res.GetString(1),res.GetDouble(2), res.GetDouble(3), res.GetDouble(4));
                apuestas.Add(apuesta);
            }
            database.disconnect();
            return apuestas;
        }

        public List<ResponseApuestasMercado> getApuestaMercado(string usuariosEmail,double tipoMercado)
        {
            database.connect();

            Dictionary<string, string> dicParameters = new Dictionary<string, string>();
            dicParameters.Add("@UE", usuariosEmail);
            dicParameters.Add("@TM", Convert.ToString(tipoMercado));
            MySqlDataReader res = database.query_parameters("SELECT a.tipo_mercado,a.tipo_apuesta,a.dinero,m.cuota_under,m.cuota_over,a.Usuarios_email FROM apuestas a INNER JOIN mercados m ON a.Mercados_id_mercado=m.id_mercado WHERE tipo_mercado=@TM AND Usuarios_email=@UE;" , dicParameters);


            ResponseApuestasMercado apuesta = null;
            List<ResponseApuestasMercado> apuestas = new List<ResponseApuestasMercado>();

            while (res.Read())
            {

                apuesta = new ResponseApuestasMercado( res.GetString(0), res.GetString(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetString(5));
                apuestas.Add(apuesta);
            }
            database.disconnect();
            return apuestas;
        }
        /**Ejercicio1 **/
        public List<ResponseApuestasCuota> getApuestaCuotas(double cuotaOver, double cuotaUnder, string email)
        {
            database.connect();
            Dictionary<string, string> dicParameters = new Dictionary<string, string>();
            dicParameters.Add("@CO", Convert.ToString(cuotaOver));
            dicParameters.Add("@CU", Convert.ToString(cuotaUnder));
            dicParameters.Add("@UE", email);
            MySqlDataReader res = database.query_parameters("SELECT SELECT a.Usuarios_email, m.cuota_over,m.cuota_under FROM apuestas a  INNER JOIN mercados m ON m.id_mercado=a.Mercados_id_mercado WHERE cuota_over=@CO AND cuota_under=@CU AND Usuarios_Email=@UE", dicParameters);

            ResponseApuestasCuota apuesta = null;
            List<ResponseApuestasCuota> apuestas = new List<ResponseApuestasCuota>();

            while (res.Read())
            {

                apuesta = new ResponseApuestasCuota( res.GetDouble(0), res.GetDouble(1), res.GetString(2) );
                apuestas.Add(apuesta);
            }
            database.disconnect();
            return apuestas;
        }


    }
    
}