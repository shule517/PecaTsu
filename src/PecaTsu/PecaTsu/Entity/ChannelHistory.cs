using PecaTsu.Logic;
using System;
using System.Collections.Generic;

namespace PecaTsu.Entity
{
	class ChannelHistory
	{
		public void update(ChannelHistory history)
		{
			string time_to = DateTime.Now.ToString("HHmmss");

			string sql = string.Format(@"
UPDATE
	channel_history
SET
	time_to = '{0}',
	time = '{1}',
	listener = '{2}',
	relay = '{3}'
WHERE
	date = '{4}'
	AND time_from = '{5}'
	AND channel_id = '{6}'
", time_to, time,
 ((int.Parse(history.listener) < int.Parse(listener)) ? listener : history.listener),
 ((int.Parse(history.relay) < int.Parse(relay)) ? relay : history.relay),
 history.date, history.time_from, history.channel_id);
			SqlRequest.requestSql(sql);
		}

		/// <summary>
		/// 指定チャンネル名の最新データを取得
		/// </summary>
		/// <param name="channelName"></param>
		/// <returns></returns>
		public static ChannelHistory selectByChannelName(string channelName)
		{
			string date = DateTime.Now.ToString("yyyyMMdd");
			string sql = string.Format(@"
SELECT
	date, time_from, time_to, channel_id, yp_id, channel_name, stream_id, tip, contact_url, genre, detail, listener, relay, bitrate, stream_type, artist, album, title, url, encoded_name, time, alt, comment, direct, update_time
FROM
	channel_history
WHERE
		date = '{0}'
	AND	channel_name = '{1}'
ORDER BY
	update_time DESC", date, channelName);
			List<List<string>> result = SqlRequest.requestSql(sql);
			if (result.Count == 0)
			{
				return null;
			}

			ChannelHistory history = new ChannelHistory(result[0].ToArray(), true);

			return history;
		}

		public static List<ChannelHistory> select()
		{
			string date = DateTime.Now.ToString("yyyyMMdd");
			string sql = string.Format("SELECT date, time_from, time_to, channel_id, yp_id, channel_name, stream_id, tip, contact_url, genre, detail, listener, relay, bitrate, stream_type, artist, album, title, url, encoded_name, time, alt, comment, direct, update_time FROM channel_history WHERE date = '{0}'", date);
			List<List<string>> result = SqlRequest.requestSql(sql);

			List<ChannelHistory> list = new List<ChannelHistory>();
			foreach (var data in result)
			{
				string[] element = data.ToArray();
				ChannelHistory history = new ChannelHistory(element);
				list.Add(history);
			}

			return list;
		}

		public void insert()
		{
			channel_id = Channel.selectChannelID(channel_name);
			date = DateTime.Now.ToString("yyyyMMdd");
			time_from = DateTime.Now.ToString("HHmmss");
			time_to = DateTime.Now.ToString("HHmmss");
			string sql = string.Format("INSERT IGNORE INTO channel_history (date,time_from,time_to,channel_id,yp_id,channel_name,stream_id,tip,contact_url,genre,detail,listener,relay,bitrate,stream_type,artist,album,title,url,encoded_name,time,alt,comment,direct) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}')", date, time_from, time_to, channel_id, yp_id, channel_name, stream_id, tip, contact_url, genre, detail, listener, relay, bitrate, stream_type, artist, album, title, url, encoded_name, time, alt, comment, direct);
			SqlRequest.requestSql(sql);
		}

		public ChannelHistory(string[] data, bool test)
		{
			int i = 0;
			date = data[i]; i++;
			time_from = data[i]; i++;
			time_to = data[i]; i++;
			channel_id = data[i]; i++;
			yp_id = data[i]; i++;
			channel_name = data[i]; i++;
			stream_id = data[i]; i++;
			tip = data[i]; i++;
			contact_url = data[i]; i++;
			genre = data[i]; i++;
			detail = data[i]; i++;
			listener = data[i]; i++;
			relay = data[i]; i++;
			bitrate = data[i]; i++;
			stream_type = data[i]; i++;
			artist = data[i]; i++;
			album = data[i]; i++;
			title = data[i]; i++;
			url = data[i]; i++;
			encoded_name = data[i]; i++;
			time = data[i]; i++;
			alt = data[i]; i++;
			comment = data[i]; i++;
			direct = data[i]; i++;
			update_time = data[i]; i++;
		}


		public ChannelHistory(string[] data)
		{
			int i = 0;
			//date = data[i]; i++;
			//time_from = data[i]; i++;
			//time_to = data[i]; i++;
			//channel_id = data[i]; i++;
			//yp_id = data[i]; i++;
			channel_name = data[i]; i++;
			stream_id = data[i]; i++;
			tip = data[i]; i++;
			contact_url = data[i]; i++;
			genre = data[i]; i++;
			detail = data[i]; i++;
			listener = data[i]; i++;
			relay = data[i]; i++;
			bitrate = data[i]; i++;
			stream_type = data[i]; i++;
			artist = data[i]; i++;
			album = data[i]; i++;
			title = data[i]; i++;
			url = data[i]; i++;
			encoded_name = data[i]; i++;
			time = data[i]; i++;
			alt = data[i]; i++;
			comment = data[i]; i++;
			direct = data[i]; i++;
			//update_time = data[i]; i++;
		}

		public ChannelHistory(string[] data, string date, string time_from, string time_to, string channel_id, string update_time)
		{
			int i = 0;
			date = "";
			time_from = "";
			time_to = "";
			channel_id = "";
			yp_id = "";
			update_time = "";

			/*
			date = data[i]; i++;
			time_from = data[i]; i++;
			time_to = data[i]; i++;
			channel_id = data[i]; i++;
			yp_id = data[i]; i++;
			 */
			channel_name = data[i]; i++;
			stream_id = data[i]; i++;
			tip = data[i]; i++;
			contact_url = data[i]; i++;
			genre = data[i]; i++;
			detail = data[i]; i++;
			listener = data[i]; i++;
			relay = data[i]; i++;
			bitrate = data[i]; i++;
			stream_type = data[i]; i++;
			artist = data[i]; i++;
			album = data[i]; i++;
			title = data[i]; i++;
			url = data[i]; i++;
			encoded_name = data[i]; i++;
			time = data[i]; i++;
			alt = data[i]; i++;
			comment = data[i]; i++;
			direct = data[i]; i++;
			//update_time = data[i]; i++;
		}
		public string date { get; set; }
		public string time_from { get; set; }
		public string time_to { get; set; }
		public string channel_id { get; set; }
		public string yp_id { get; set; }
		public string channel_name { get; set; }
		public string stream_id { get; set; }
		public string tip { get; set; }
		public string contact_url { get; set; }
		public string genre { get; set; }
		public string detail { get; set; }
		public string listener { get; set; }
		public string relay { get; set; }
		public string bitrate { get; set; }
		public string stream_type { get; set; }
		public string artist { get; set; }
		public string album { get; set; }
		public string title { get; set; }
		public string url { get; set; }
		public string encoded_name { get; set; }
		public string time { get; set; }
		public string alt { get; set; }
		public string comment { get; set; }
		public string direct { get; set; }
		public string update_time { get; set; }

		public bool equal(ChannelHistory channel)
		{
			return
				// (date == channel.date) &&
				// (time_from == channel.time_from) &&
				// (time_to == channel.time_to) &&
				// (channel_id == channel.channel_id) &&
				// (yp_id == channel.yp_id) &&
				// (channel_name == channel.channel_name) &&
				// (stream_id == channel.stream_id) &&
				// (tip == channel.tip) &&
				(contact_url == channel.contact_url) &&
				(genre == channel.genre) &&
				(detail == channel.detail) &&
				// (listener == channel.listener) &&
				// (relay == channel.relay) &&
				// (bitrate == channel.bitrate) &&
				// (stream_type == channel.stream_type) &&
				(artist == channel.artist) &&
				(album == channel.album) &&
				(title == channel.title) &&
				(url == channel.url) &&
				// (encoded_name == channel.encoded_name) &&
				// (time == channel.time) &&
				// (alt == channel.alt) &&
				(comment == channel.comment);
			// (direct == channel.direct);
			// (update_time == channel.update_time);
		}
	}
}
