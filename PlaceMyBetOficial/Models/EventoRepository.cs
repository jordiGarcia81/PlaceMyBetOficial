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

        public EventoDTO ToDTO(Evento e)
        {
           
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                List<EventoDTO> eventos = context.Eventos.Select(p => ToDTO(p)).ToList(); eventos = context.Eventos.Select(p => ToDTO(p)).ToList();
               
            }

           
            return  new EventoDTO(e.Local, e.Visitante);


        }
        internal void Save(Evento evento)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Eventos.Add(evento);
            context.SaveChanges();

        }

        internal void Put(int id, string local, string visitante)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            Evento e;
            using (context)
            {
                e = context.Eventos.Single(b => b.EventoId == id);
                e.Local = local;
                e.Visitante = visitante;
                context.SaveChanges();
            }

        }

        internal void Delete(int id)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            Evento e;
            using (context)
            {
                e = context.Eventos.Single(b => b.EventoId == id);
                context.Eventos.Remove(e);
                context.SaveChanges();
            }
        }




    }
}