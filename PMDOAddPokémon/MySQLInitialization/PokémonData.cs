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
            
            string result = Enum.GetName(typeof(PokéDex.Moves), index);

            return result;
        }

    }
}
