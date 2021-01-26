using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using PlaceMyBetOficial.Models.objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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


        internal void Delete(string usuario)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            Usuario u;
            using (context)
            {
                u = context.Usuarios.Single(b => b.UsuarioId == usuario);
                context.Usuarios.Remove(u);
                context.SaveChanges();
            }
        }

        internal List<UsuarioDTO> GetUsuarioDTO()
        {

            List<UsuarioDTO> usuarios = new List<UsuarioDTO>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                usuarios = context.Usuarios.Select(p => ToDTO(p)).ToList();
                Debug.WriteLine("usuarios" + usuarios.Count);
            }

            return usuarios;
        }

        static UsuarioDTO ToDTO(Usuario u)
        {
            return new UsuarioDTO(u.Nombre, u.Apellidos, u.UsuarioId);
        }

        //public List<Usuario> Filter( string searchString)
        //{
        //    List<Usuario> usuarios = new List<Usuario>();

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        usuarios = (List<Usuario>)usuarios.Where(s => s.Nombre.Contains(searchString) || s.Apellidos.Contains(searchString) || s.UsuarioId.Contains(searchString));

        //    }


        //    return usuarios;
        //}

    }
}