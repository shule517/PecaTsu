using System;
using System.Collections.Generic;

namespace PecaTsu.Entity
{
	class ChannelHistory
	{
		public ChannelHistory()
		{
		}

		public ChannelHistory(string[] data)
		{
			int i = 0;
			//date = data[i++];
			//time_from = data[i++];
			//time_to = data[i++];
			//channel_id = data[i++];
			//yp_id = yp.yp_id;
			channel_name = data[i++];
			stream_id = data[i++];
			tip = data[i++];
			contact_url = data[i++];
			genre = data[i++];
			detail = data[i++];
			listener = data[i++];
			relay = data[i++];
			bitrate = data[i++];
			stream_type = data[i++];
			artist = data[i++];
			album = data[i++];
			title = data[i++];
			url = data[i++];
			encoded_name = data[i++];
			time = data[i++];
			alt = data[i++];
			comment = data[i++];
			direct = data[i++];
			//update_time = data[i++];
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

		/// <summary>
		/// YP情報の場合true
		/// </summary>
		public bool IsYPInfo { get { return listener == "-9"; } }
	}
}
