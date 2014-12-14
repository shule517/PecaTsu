using PecaTsu.Logic;
using System.Collections.Generic;

namespace PecaTsu.Entity
{
	class Channel
	{
		public static void Insert(string[] name_list)
		{
			string values = string.Empty;
			foreach (string channel_name in name_list)
			{
				values += "('" + channel_name + "'), ";
			}

			string sql = string.Format("INSERT IGNORE INTO channel (channel_name) values {0} ('')", values);
			SqlRequest.requestSql(sql);
		}

		public static void Insert(string channel_name)
		{
			string sql = string.Format("INSERT IGNORE INTO channel (channel_name) values ('{0}')", channel_name);
			SqlRequest.requestSql(sql);
		}

		internal static string selectChannelID(string channel_name)
		{
			string sql = string.Format("SELECT channel_id FROM channel WHERE channel_name = '{0}'", channel_name);
			List<List<string>> result = SqlRequest.requestSql(sql);
			if (result.Count <= 0)
			{
				return string.Empty;
			}

			string channel_id = result[0][0];
			return channel_id;
		}
	}
}
