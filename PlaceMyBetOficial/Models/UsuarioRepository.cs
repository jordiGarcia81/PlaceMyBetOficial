using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using PlaceMyBetOficial.Models.objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models
{
    public class UsuarioRepository
    {
        public List<Usuario> GetUsuarios()
        {

            List<Usuario> usuarios = new List<Usuario>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                // mercados = context.Mercados.Include(p => p.eventos).ToList();
                usuarios = context.Usuarios.ToList();
            }


            return usuarios;

        }

    }
}