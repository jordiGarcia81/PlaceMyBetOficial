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
        public List<EventoDTO> GetEventoDTO()
        {
            EventoRepository eventoRepository = new EventoRepository();
            List<EventoDTO> listEvento = eventoRepository.GetEventoDTO();
            return listEvento;
        }
        
    }
}
