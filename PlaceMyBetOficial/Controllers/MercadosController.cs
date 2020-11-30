using PlaceMyBetOficial.Models;
using PlaceMyBetOficial.Models.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBetOficial.Controllers
{
    public class MercadosController : ApiController
    {

        [Route("api/GetMercados")]
        [HttpGet]
        public List<Mercado> GetMercados()
        {
            MercadoRepository mercadoRepository = new MercadoRepository();
            List<Mercado> listmercado = mercadoRepository.GetMercados();
            return listmercado;
        }
        [Route("api/GetMercado")]
        [HttpPost]
        public Mercado GetMercado(int id)
        {
            MercadoRepository mercadoRepository = new MercadoRepository();
            Mercado mercado = mercadoRepository.GetMercado(id);
            return mercado;
        }
        //    // api/getMercadosEvent?idEvento=1&overUnder=1.5
        //    [Route("api/getMercadosEvent")]
        //    [HttpPost]
        //    public List<Mercado> getMercadosEvent(int idEvento, string overUnder)
        //    {
        //        MercadoRepository mercadoRepository = new MercadoRepository();
        //        List<Mercado> mercados = mercadoRepository.getMercadosEvent(idEvento,overUnder);
        //        return mercados;
        //    }

    }
}
