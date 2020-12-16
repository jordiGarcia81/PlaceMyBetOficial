using PlaceMyBetOficial.Models;
using PlaceMyBetOficial.Models.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static PlaceMyBetOficial.Models.objects.Apuesta;
using static PlaceMyBetOficial.Models.objects.ResponseData;

namespace PlaceMyBetOficial.Controllers
{
    public class ApuestasController : ApiController
    {
        private PlaceMyBetContext db = new PlaceMyBetContext();
        [Route("api/GetApuestas")]
        [HttpGet]
        public List<Apuesta> GetApuestas()// recuperar todas las apuestas AE5
        {
            ApuestaRepository apuestaRepository = new ApuestaRepository();
            List<Apuesta> listApuesta = apuestaRepository.GetApuestas();
            return listApuesta;
        }
        [Route("api/GetApuestasMercado")]
        [HttpGet]
        public List<Apuesta> GetApuestasMercado()
        {
            ApuestaRepository apuestaRepository = new ApuestaRepository();
            List<Apuesta> listApuesta = apuestaRepository.GetApuestasMercado();
            return listApuesta;
        }
        [Route("api/GetApuestaId")]
        [HttpPost]
        public Apuesta GetApuestaId(int id)// recuperar todas las apuestas  partir de un Id AE5
        {
            ApuestaRepository apuestaRepository = new ApuestaRepository();
            Apuesta apuesta = apuestaRepository.GetApuestaId(id);
            return apuesta;
        }

        [HttpPost]
        [Route("api/InsertarApuestas")]
        public bool Insertar(Apuesta apuesta)
        {
            ApuestaRepository apuestaRepository = new ApuestaRepository();
            if (!apuestaRepository.Insertar(apuesta)) return false;

            return true;
        }
        [Route("api/GetApuestaDTO")]
        //[HttpPost]
        //public List<ApuestaDTO> GetApuestaDTO()
        //{
        //    ApuestaRepository apuestaRepository = new ApuestaRepository();
        //    List<ApuestaDTO> listApuesta = apuestaRepository.GetApuestaDTO();
        //    return listApuesta;
        //}

        [Route("api/GetApuesta2")]
        [HttpGet]
        public List<Apuesta2DTO> GetApuesta2(int dinero)
        {
            ApuestaRepository apuestaRepository = new ApuestaRepository();
            List<Apuesta2DTO> listApuesta = apuestaRepository.GetApuesta2DTO(dinero);
            return listApuesta;
        }

    }
}
