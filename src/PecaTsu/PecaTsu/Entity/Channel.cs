using PecaTsu.Logic;
using System.Collections.Generic;

namespace PecaTsu.Entity
{
	class Channel
	{
		public Channel()
		{
		}

		/// <summary>
		/// チャンネル情報を登録(複数)
		/// </summary>
		public static void Insert(string[] names)
		{
			if (names.Length == 0)
			{
				return;
			}

			string values = string.Empty;
			foreach (string channel_name in names)
			{
				values += "('" + channel_name + "'), ";
			}

			string sql = string.Format("INSERT IGNORE INTO channel (channel_name) values {0} ('')", values);
			SqlRequest.requestSql(sql);
		}

		/// <summary>
		/// チャンネル情報を登録
		/// </summary>
		public static void Insert(string channel_name)
		{
			string sql = string.Format("INSERT IGNORE INTO channel (channel_name) values ('{0}')", channel_name);
			SqlRequest.requestSql(sql);
		}

		/// <summary>
		/// チャンネルIDで検索
		/// </summary>
		internal static string selectByChannelID(string channel_name)
		{
			string sql = string.Format("SELECT channel_id FROM channel WHERE channel_name = '{0}'", channel_name);

			List<Channel> result = SqlRequest.requestSql<Channel>(sql);

			if (result.Count > 0)
			{
				return result[0].channel_id;
			}

			return string.Empty;
		}

		/// <summary>
		/// 登録されている全チャンネル名を取得
		/// </summary>
		public static List<Channel> selectAll()
		{
			string sql = string.Format("SELECT channel_id, channel_name FROM channel");

			List<Channel> result = SqlRequest.requestSql<Channel>(sql);
			return result;
		}

		public string channel_id { get; set; }
		public string channel_name { get; set; }
	}
}
