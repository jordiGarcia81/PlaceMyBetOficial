using MySql.Data.MySqlClient;
using PlaceMyBetOficial.Models.objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using static PlaceMyBetOficial.Models.objects.Evento;

namespace PlaceMyBetOficial.Models
{
    public class EventoRepository
    {
        DataBase database = null;

        public EventoRepository()
        {
            database = new DataBase();
        }

       internal List<Evento> GetEvento()
        {
            database.connect();
            MySqlDataReader res = database.query("SELECT * FROM eventos");

            Evento eventos = null;
            List<Evento> evento = new List<Evento>();

            while (res.Read())
            {
                eventos = new Evento(res.GetInt32(0), res.GetString(1), res.GetString(2),  res.GetDateTime(3));
                evento.Add(eventos);
            }
            database.disconnect();
            return evento;
        }

         public List<EventoDTO> GetEventoDTO()
        {
            database.connect();
            MySqlDataReader res = database.query("SELECT visitante,local,fecha FROM eventos");

            EventoDTO eventos = null;
            List<EventoDTO> evento = new List<EventoDTO>();

            while (res.Read())
            {
                eventos = new EventoDTO(res.GetString(0), res.GetString(1), res.GetDateTime(2));
                evento.Add(eventos);
            }
            database.disconnect();
            return evento;
        }

       

    }
}