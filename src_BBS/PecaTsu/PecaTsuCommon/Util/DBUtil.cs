using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PecaTsuCommon.Util
{
    public class DBUtil
    {
        static MySqlConnection connection;

        public static void Connect()
        {
            StreamReader sr = new StreamReader(@"Settings/DBAccess.txt", Encoding.GetEncoding("Shift_JIS"));
            string connectionData = sr.ReadToEnd();
            connection = new MySqlConnection(connectionData);
            connection.Open();
        }

        public static List<Type> Select<Type>(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();

            return new List<Type>();
        }
    }
}
