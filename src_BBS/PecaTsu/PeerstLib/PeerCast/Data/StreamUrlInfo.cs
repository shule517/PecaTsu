﻿
namespace PeerstLib.PeerCast.Data
{
	//-------------------------------------------------------------
	// 概要：ストリームURLから抽出した情報クラス
	//-------------------------------------------------------------
	public class StreamUrlInfo
	{
		//-------------------------------------------------------------
		// 公開プロパティ
		//-------------------------------------------------------------

		// PeerCastのアドレス
		public string Host { get; set; }

		// PeerCastのポート番号
		public string PortNo { get; set; }

		// ストリームID
		public string StreamId { get; set; }

		//-------------------------------------------------------------
		// 概要：コンストラクタ
		//-------------------------------------------------------------
		public StreamUrlInfo()
		{
			Host = "";
			PortNo = "";
			StreamId = "";
		}
	}
}
