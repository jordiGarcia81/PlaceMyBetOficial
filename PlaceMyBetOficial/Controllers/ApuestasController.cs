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
    //    [Route("api/GetApuestas")]
    //    [HttpGet]
    //    public List<Apuesta> GetApuestas()
    //    {
    //        ApuestaRepository apuestaRepository = new ApuestaRepository();
    //        List<Apuesta> listApuesta = apuestaRepository.GetApuestas();
    //        return listApuesta;
    //    }

    //    //[Authorize]
    //    [Route("api/GetApuestaDTO")]
    //    [HttpPost]
    //    public List<ApuestaDTO> GetApuestaDTO()
    //    {
    //        ApuestaRepository apuestaRepository = new ApuestaRepository();
    //        List<ApuestaDTO> listApuesta = apuestaRepository.GetApuestaDTO();
    //        return listApuesta;
    //    }

    //    [HttpPut]
    //    [Route("api/InsertarApuestas")]
    //    public bool InsertarApuestas(Apuesta apuesta)
    //    {
    //        ApuestaRepository apuestaRepository = new ApuestaRepository();
    //        if (!apuestaRepository.Insertar(apuesta)) return false;

    //        return true;
    //    }
    //    // api/getApuestaUsuario?usuariosEmail=jordigarcia%40gmail.com&mercadosIdMercado=1
    //    [HttpPost]
    //    [Route("api/getApuestaUsuario")]
    //    public List<ResponseApuestasUsuario> getApuestaUsuario(string usuariosEmail, int mercadosIdMercado)
    //    {
    //        ApuestaRepository apuestaRepository = new ApuestaRepository();
    //        List<ResponseApuestasUsuario> apuestas = apuestaRepository.getApuestaUsuario(usuariosEmail, mercadosIdMercado);
    //        return apuestas;
    //    }
    //    // api/getApuestaMercado?usuariosEmail=jordigarcia%40gmail.com&tipoMercado=1.5
    //    [Route("api/getApuestaMercado")]
    //    [HttpPost]
    //    public List<ResponseApuestasMercado> getApuestaMercado(string usuariosEmail, double tipoMercado)
    //    {
    //        ApuestaRepository apuestaRepository = new ApuestaRepository();
    //        List<ResponseApuestasMercado> apuestas = apuestaRepository.getApuestaMercado(usuariosEmail, tipoMercado);
    //        return apuestas;
    //    }
    }
}
