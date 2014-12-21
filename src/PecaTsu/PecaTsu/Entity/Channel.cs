using PecaTsu.Logic;
using System.Collections.Generic;

namespace PecaTsu.Entity
{
	class Channel
	{
		public Channel(string[] data)
		{
			int i = 0;
			channel_id = data[i++];
			channel_name =  data[i++];
		}

		/// <summary>
		/// チャンネル情報を登録
		/// </summary>
		public static void Insert(string[] name_list)
		{
			if (name_list.Length == 0)
			{
				return;
			}

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

		/// <summary>
		/// 登録されている全チャンネル名を取得
		/// </summary>
		public static List<Channel> selectAll()
		{
			string sql = string.Format("SELECT channel_id, channel_name FROM channel");
			List<List<string>> result = SqlRequest.requestSql(sql);

			List<Channel> list = new List<Channel>();
			foreach (List<string> data in result)
			{
				Channel channel = new Channel(data.ToArray());
				list.Add(channel);
			}

			return list;
		}

		public string channel_id { get; set; }
		public string channel_name { get; set; }
	}
}
