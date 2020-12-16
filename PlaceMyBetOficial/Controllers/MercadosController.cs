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
        private PlaceMyBetContext db = new PlaceMyBetContext();

        [Route("api/GetMercados")]//recuperar todos los mercados
        [HttpGet]
        public List<Mercado> GetMercados()
        {
            MercadoRepository mercadoRepository = new MercadoRepository();
            List<Mercado> listmercado = mercadoRepository.GetMercados();
            return listmercado;
        }
        [Route("api/GetMercadosEvento")]//recuperar todos los mercados y eventos
        [HttpGet]
        public List<Mercado> GetMercadosEvento()
        {
            MercadoRepository mercadoRepository = new MercadoRepository();
            List<Mercado> listmercado = mercadoRepository.GetMercadosEvento();
            return listmercado;
        }

        [Route("api/GetMercadosDTO")]
        [HttpGet]
        public List<MercadoDTO> GetDTO()
        {
            MercadoRepository mercadoRepository = new MercadoRepository();
            List<MercadoDTO> listmercado = mercadoRepository.GetMercadosDTO();
            return listmercado;
        }
        [Route("api/GetMercadoId")]//recuperar todos los mercados a partir de un Id
        [HttpPost]
        public List<Mercado2DTO> GetMercadoId(int id)
        {
            MercadoRepository mercadoRepository = new MercadoRepository();
            List<Mercado2DTO> mercado = mercadoRepository.GetMercadoId(id);
            return mercado;
        }
        [Route("api/insert")]
        [HttpPost]
        public void insert(Mercado mercado)
        {
            MercadoRepository mercadoRepository = new MercadoRepository();

           mercadoRepository.insert(mercado);
            

        }
        [Route("api/GetMercado2DTO")]
        [HttpPost]
        public List<Mercado2DTO> GetMercado2DTO()
        {
            MercadoRepository mercadoRepository = new MercadoRepository();
            List<Mercado2DTO> listMercado = mercadoRepository.GetMercado2DTO();
            return listMercado;
        }






    }
}
