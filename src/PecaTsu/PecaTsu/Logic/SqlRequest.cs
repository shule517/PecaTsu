using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PecaTsu.Logic
{
	class SqlRequest
	{
		private static string connectionData;
		private static MySqlConnection myConnection;
		private static MySqlDataReader myReader;

		public static void init()
		{
			StreamReader sr = new StreamReader(@"Settings/DBAccess.txt", Encoding.GetEncoding("Shift_JIS"));
			connectionData = sr.ReadToEnd();
		}

		public static List<List<string>> requestSql(string sql)
		{
			access(sql);

			List<List<string>> list = new List<List<string>>();
			while (myReader.Read())
			{

				List<string> data = new List<string>();
				for (int i = 0; i < myReader.FieldCount; i++)
				{
					data.Add(myReader.GetString(i));
				}
				list.Add(data);
			}
			myReader.Close();
			myConnection.Close();

			return list;
		}

		private static void access(string sql)
		{
			myConnection = new MySqlConnection(connectionData);
			MySqlCommand myCommand = new MySqlCommand(sql, myConnection);
			myConnection.Open();
			myReader = myCommand.ExecuteReader();
		}
	}
}
