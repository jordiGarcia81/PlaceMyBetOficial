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
        DataBase database = null;

        public UsuarioRepository()
        {
            database = new DataBase();
        }

        public List<Usuario> GetUsuarios()
        {

            database.connect();
            MySqlDataReader res = database.query("SELECT * FROM usuarios");

            Usuario usuario = null;
            List<Usuario> usuarios = new List<Usuario>();

            while (res.Read())
            {
                usuario = new Usuario( res.GetString(0), res.GetString(1), res.GetString(2), res.GetInt32(3) );
                usuarios.Add(usuario);
            }
            database.disconnect();
            return usuarios;
        }

    }
}