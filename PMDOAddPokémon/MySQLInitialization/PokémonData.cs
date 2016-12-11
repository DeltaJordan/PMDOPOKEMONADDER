using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PMDOAddPokémon.MySQLInitialization
{
    class PokémonData
    {

        public static string GetMoveFromIndex(int index, MySqlConnection conn)
        {
            string query = "SELECT * FROM move WHERE num = '" + index + "'";
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                return reader.GetString("name");
            }

            return "";
        }

    }
}
