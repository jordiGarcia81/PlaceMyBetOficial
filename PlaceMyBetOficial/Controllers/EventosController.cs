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
        //    //[HttpPost]
        //    //public List<EventoDTO> GetEventoDTO()
        //    //{
        //    //    EventoRepository eventoRepository = new EventoRepository();
        //    //    List<EventoDTO> listEvento = eventoRepository.GetEventoDTO();
        //    //    return listEvento;
        //    //}

    }
    //[HttpPost]
    //public void Post([FromBody] Evento evento)
    //{
    //    EventoRepository eventoRepository = new EventoRepository();
    //    eventoRepository.Save(evento);

    //}

}
    
