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
       [Authorize(Roles = "Standard")]
        public List<Usuario> GetUsuarios()
        {
            UsuarioRepository userrepo = new UsuarioRepository();
            List<Usuario> usuarios = userrepo.GetUsuarios();
            return usuarios;
        }
    }
}
