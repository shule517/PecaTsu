using System;

namespace PecaTsuCommon.Entity
{
    /// <summary>
    /// 画像リンク情報
    /// </summary>
    public class ImageLink
    {
        /// <summary>
        /// スレッドURL
        /// </summary>
        public string ThreadUrl { get; set; }

        /// <summary>
        /// レス番号
        /// </summary>
        public int ResNo { get; set; }

        /// <summary>
        /// 連番
        /// </summary>
        public int ImageNo { get; set; }

        /// <summary>
        /// 画像URL
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 配信者名
        /// </summary>
        public string ChannelName { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        public string WriterName { get; set; }

        /// <summary>
        /// メール
        /// </summary>
        public string WriterMail { get; set; }

        /// <summary>
        /// 投稿日時
        /// </summary>
        public string WriteTime { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public string WriterId { get; set; }

        /// <summary>
        /// 本文
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 更新日時
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
