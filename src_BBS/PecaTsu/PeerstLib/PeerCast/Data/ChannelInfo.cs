﻿using System.Collections.Generic;

namespace PeerstLib.PeerCast.Data
{
	//-------------------------------------------------------------
	// 概要：チャンネル情報クラス
	//-------------------------------------------------------------
	public class ChannelInfo
	{
		//-------------------------------------------------------------
		// 公開プロパティ
		//-------------------------------------------------------------

		// チャンネル情報
		public string Name { get; set; }
		public string Id { get; set; }
		public string Bitrate { get; set; }
		public string Type { get; set; }
		public string Genre { get; set; }
		public string Desc { get; set; }
		public string Url { get; set; }
		public string Uptime { get; set; }
		public string Comment { get; set; }
		public string Skips { get; set; }
		public string Age { get; set; }
		public string Bcflags { get; set; }

		// リレー情報
		public string Listeners { get; set; }
		public string Relays { get; set; }
		public string Hosts { get; set; }
		public string Status { get; set; }
		public string Firewalled { get; set; }
		public RelayColor RelayColor { get; set; }

		// トラック情報
		public string TrackTitle { get; set; }
		public string TrackArtist { get; set; }
		public string TrackAlbum { get; set; }
		public string TrackGenre { get; set; }
		public string TrackContact { get; set; }

		// ホスト情報一覧
		public List<HostInfo> HostList { get; set; }

		//-------------------------------------------------------------
		// 概要：コンストラクタ
		//-------------------------------------------------------------
		public ChannelInfo()
		{
			Name = string.Empty;
			Id = string.Empty;
			Bitrate = string.Empty;
			Type = string.Empty;
			Genre = string.Empty;
			Desc = string.Empty;
			Url = string.Empty;
			Uptime = string.Empty;
			Comment = string.Empty;
			Skips = string.Empty;
			Age = string.Empty;
			Bcflags = string.Empty;
			
			Listeners = string.Empty;
			Relays = string.Empty;
			Hosts = string.Empty;
			Status = string.Empty;
			Firewalled = string.Empty;
			RelayColor = Data.RelayColor.None;
			
			TrackTitle = string.Empty;
			TrackArtist = string.Empty;
			TrackAlbum = string.Empty;
			TrackGenre = string.Empty;
			TrackContact = string.Empty;

			HostList = new List<HostInfo>();
		}
	}
}
