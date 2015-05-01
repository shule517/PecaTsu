
namespace PecaTsuCommon.Dto
{
    /// <summary>
    /// チャンネル詳細
    /// </summary>
    public class ChannelDetail
    {
        /// <summary>
        /// チャンネル情報初期化
        /// </summary>
        /// <param name="indexTextElem">index.txtの１行データ</param>
        public ChannelDetail(string[] indexTextElem)
		{
			int i = 0;
			ChannelName = indexTextElem[i++].Replace(" (要帯域チェック)", "");
            StreamId = indexTextElem[i++];
			Tip = indexTextElem[i++];
			ContactUrl = indexTextElem[i++];
			Genre = indexTextElem[i++];
			Detail = indexTextElem[i++];
			Listener = int.Parse(indexTextElem[i++]);
			Relay = int.Parse(indexTextElem[i++]);
			Bitrate = indexTextElem[i++];
			StreamType = indexTextElem[i++];
			Artist = indexTextElem[i++];
			Album = indexTextElem[i++];
			Title = indexTextElem[i++];
			Url = indexTextElem[i++];
			EncodedName = indexTextElem[i++];
			Time = indexTextElem[i++];
			Alt = indexTextElem[i++];
			Comment = indexTextElem[i++];
			Direct = indexTextElem[i++];
		}

        /// <summary>
        /// チャンネル名
        /// </summary>
		public string ChannelName { get; set; }

        /// <summary>
        /// ストリームID
        /// </summary>
		public string StreamId { get; set; }

        /// <summary>
        /// TIP
        /// </summary>
		public string Tip { get; set; }

        /// <summary>
        /// コンタクトURL
        /// </summary>
		public string ContactUrl { get; set; }

        /// <summary>
        /// ジャンル
        /// </summary>
		public string Genre { get; set; }

        /// <summary>
        /// 詳細
        /// </summary>
		public string Detail { get; set; }

        /// <summary>
        /// リスナー数
        /// </summary>
		public int Listener { get; set; }

        /// <summary>
        /// リレー数
        /// </summary>
		public int Relay { get; set; }

        /// <summary>
        /// ビットレート
        /// </summary>
		public string Bitrate { get; set; }

        /// <summary>
        /// ストリーム種類
        /// </summary>
		public string StreamType { get; set; }

        /// <summary>
        /// アーティスト
        /// </summary>
		public string Artist { get; set; }

        /// <summary>
        /// アルバム
        /// </summary>
		public string Album { get; set; }

        /// <summary>
        /// タイトル
        /// </summary>
		public string Title { get; set; }

        /// <summary>
        /// URL
        /// </summary>
		public string Url { get; set; }

        /// <summary>
        /// エンコード済みチャンネル名
        /// </summary>
		public string EncodedName { get; set; }

        /// <summary>
        /// 配信時間
        /// </summary>
		public string Time { get; set; }

        /// <summary>
        /// ALT
        /// </summary>
		public string Alt { get; set; }

        /// <summary>
        /// コメント
        /// </summary>
		public string Comment { get; set; }

        /// <summary>
        /// Direct
        /// </summary>
		public string Direct { get; set; }

		/// <summary>
		/// YP情報の場合true
		/// </summary>
		public bool IsYPInfo { get { return Listener < -1; } }
    }
}
