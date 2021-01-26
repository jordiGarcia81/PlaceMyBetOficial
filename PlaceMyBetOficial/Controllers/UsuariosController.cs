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

    public class UsuariosController : ApiController
    {
        // GET: api/Usuarios
        /// <summary>
        /// metodo que devuelve lista de usuarios
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        [Route("api/Usuarios")]
        [HttpGet]
        
        public List<Usuario> GetUsuarios()
        {
            UsuarioRepository userrepo = new UsuarioRepository();
            List<Usuario> usuarios = userrepo.GetUsuarios();
            return usuarios;
        }
        [Route("api/DeleteUsuarios")]
        [HttpDelete]
        public void Delete(string usuario)
        {
            UsuarioRepository rep = new UsuarioRepository();
            rep.Delete(usuario);
        }

        [Route("api/GetUsuarioDTO")]
        [HttpPost]
        public List<UsuarioDTO> GetUsuarioDTO()
        {
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            List<UsuarioDTO> usuarios = usuarioRepository.GetUsuarioDTO();
            return usuarios;
        }
        //    [Route("api/FilterUsuarios")]
        //    [HttpPost]
        //    public List<Usuario> Filter(string searchString)
        //    {
        //        UsuarioRepository usuarioRepository = new UsuarioRepository();
        //        List<Usuario> usuarios = usuarioRepository.Filter(searchString);
        //        return usuarios;
        //    }
    }
}
