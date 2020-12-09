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
    
    internal List<Evento> GetEvento()
    {
        
        List<Evento> eventos = new List<Evento>();
        using (PlaceMyBetContext context = new PlaceMyBetContext())
        {
            eventos = context.Eventos.ToList();
                Debug.WriteLine("eventos" + eventos.Count);
        }

        
        return eventos;
    }

        public List<EventoDTO> ToDTO()
        {
            List<Evento> evento = new List<Evento>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                List<EventoDTO> eventos = context.Eventos.Select(p => ToDTO(p)).ToList(); eventos = context.Eventos.Select(p => ToDTO(p)).ToList();
            }

            List<EventoDTO> eventosDTO = new List<EventoDTO>();

            foreach (Evento e in evento)
            {
                EventoDTO eventoDTO = new EventoDTO(e.Local, e.Visitante);
                eventosDTO.Add(eventoDTO);
            }

            return eventosDTO;

            
        }
        internal void Save(Evento evento)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Eventos.Add(evento);
            context.SaveChanges();

        }

        

        // public List<EventoDTO> GetEventoDTO()
        //{
        //   // database.connect();
        //    MySqlDataReader res = database.query("SELECT visitante,local,fecha FROM eventos");

        //    EventoDTO eventos = null;
        //    List<EventoDTO> evento = new List<EventoDTO>();

        //    while (res.Read())
        //    {
        //        eventos = new EventoDTO(res.GetString(0), res.GetString(1), res.GetDateTime(2));
        //        evento.Add(eventos);
        //    }
        //    //database.disconnect();
        //    return evento;
        //}



    }
}