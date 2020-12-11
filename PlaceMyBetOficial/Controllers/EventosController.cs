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
        [Route("api/GetEvento")]
        [HttpGet]
        public List<Evento> Get()// recuperar Todos los eventos AE5
        {
            EventoRepository eventoRepository = new EventoRepository();
            List<Evento> listEvento = eventoRepository.GetEvento();
            return listEvento;
        }
       [Route("api/GetEventoDTO")]
        [HttpPost]
        public EventoDTO ToDTO(Evento e )
        {
            EventoRepository eventoRepository = new EventoRepository();
            EventoDTO ToDTO = eventoRepository.ToDTO(e);
            return ToDTO;
        }

        [HttpPut]
        public void Put(int id, string local, string visitante)
        {
            EventoRepository rep = new EventoRepository();
            rep.Put(id, local, visitante);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            EventoRepository rep = new EventoRepository();
            rep.Delete(id);
        }

    }
   

}
    
