﻿using PlaceMyBetOficial.Models;
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
        [Route("api/GetEvento")]
        [HttpGet]
        public List<Evento> GetEvento()
        {
            EventoRepository eventoRepository = new EventoRepository();
            List<Evento> listevento = eventoRepository.GetEvento();
            return listevento;
        }
        [Route("api/GetEventoDTO")]
        [HttpPost]
        public List<EventoDTO> GetEventoDTO()
        {
            EventoRepository eventoRepository = new EventoRepository();
            List<EventoDTO> listEvento = eventoRepository.GetEventoDTO();
            return listEvento;
        }
        
    }
}
