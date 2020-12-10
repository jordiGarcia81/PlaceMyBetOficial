using PlaceMyBetOficial.Models;
using PlaceMyBetOficial.Models.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static PlaceMyBetOficial.Models.objects.Evento;

namespace PlaceMyBetOficial.Controllers
{
    public class EventosController : ApiController
    {
        //[Route("api/GetEvento")]
        //[HttpGet]
        public List<Evento> Get()
        {
            EventoRepository eventoRepository = new EventoRepository();
            List<Evento> listEvento = eventoRepository.GetEvento();
            return listEvento;
        }
        //    //[Route("api/GetEventoDTO")]
        [HttpPost]
        public EventoDTO ToDTO(Evento e )
        {
            EventoRepository eventoRepository = new EventoRepository();
            EventoDTO ToDTO = eventoRepository.ToDTO(e);
            return ToDTO;
        }

    }
    //    [HttpPut]
    //public Evento Update( int id)
    //{
    //    EventoRepository eventoRepository = new EventoRepository();
    //    Evento evento = eventoRepository.update(id);
    //    return evento;

    //}

}
    
