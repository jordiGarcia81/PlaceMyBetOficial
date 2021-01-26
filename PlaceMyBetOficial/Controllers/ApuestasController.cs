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
        [Route("api/GetApuestas")]
        [HttpGet]
        public List<Apuesta> GetApuestas()
        {
            ApuestaRepository apuestaRepository = new ApuestaRepository();
            List<Apuesta> listapuestas = apuestaRepository.GetApuestas();
            return listapuestas;
        }
        //[Authorize]
        [Route("api/GetApuestaDTO")]
        [HttpPost]
        public List<ApuestaDTO> GetApuestaDTO()
        {
            ApuestaRepository apuestaRepository = new ApuestaRepository();
            List<ApuestaDTO> listApuesta = apuestaRepository.GetApuestaDTO();
            return listApuesta;
        }

        [HttpPut]
        [Route("api/InsertarApuestas")]
        public bool InsertarApuestas(Apuesta apuesta)
        {
            ApuestaRepository apuestaRepository = new ApuestaRepository();
            if (!apuestaRepository.Insertar(apuesta)) return false;

            return true;
        }
        [HttpPost]
        [Route("api/getApuestaUsuario")]
        public List<ResponseApuestasUsuario> getApuestaUsuario(string usuariosEmail, int mercadosIdMercado)
        {
            ApuestaRepository apuestaRepository = new ApuestaRepository();
            List<ResponseApuestasUsuario> apuestas = apuestaRepository.getApuestaUsuario(usuariosEmail, mercadosIdMercado);
            return apuestas;
        }

        [Route("api/getApuestaMercado")]
        [HttpPost]
        public List<ResponseApuestasMercado> getApuestaMercado(string usuariosEmail, double tipoMercado)
        {
            ApuestaRepository apuestaRepository = new ApuestaRepository();
            List<ResponseApuestasMercado> apuestas = apuestaRepository.getApuestaMercado(usuariosEmail, tipoMercado);
            return apuestas;
        }
        [Route("api/getApuestaCuota")]
        [HttpPost]
        public List<ResponseApuestasCuota> getApuestaCuotas(double cuotaOver, double cuotaUnder, string email)
        {
            ApuestaRepository apuestaRepository = new ApuestaRepository();
            List<ResponseApuestasCuota> apuestas = apuestaRepository.getApuestaCuotas(cuotaOver, cuotaUnder, email);
            return apuestas;
        }
    }
}
