using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBetOficial.Models
{
    public class DataBase
    {
        MySqlConnection con = null;

        public DataBase() {

            string conectString = "server=127.0.0.1;port=3306;database=placemybet;uid=root;pwd=;Convert Zero Datetime =True;SslMode=none;";
            con = new MySqlConnection(conectString);

        }

        public void connect() {
            con.Open();
        }
        public MySqlDataReader query(string query)
        {
            MySqlCommand command = con.CreateCommand();
            command.CommandText = query;
            return command.ExecuteReader();

        }
        public MySqlDataReader query_parameters(string query, Dictionary<string, string> dicParameters)
        {
            MySqlCommand command = con.CreateCommand();

            command.CommandText = query;
            foreach (var item in dicParameters)
            {
                command.Parameters.AddWithValue(item.Key, item.Value);
            }
            
            return command.ExecuteReader();
        }
        //metodo query con parametros


        public void disconnect()
        {
            con.Close();
        }
    }
}