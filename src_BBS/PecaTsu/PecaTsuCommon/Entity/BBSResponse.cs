using System;

namespace PecaTsuCommon.Entity
{
    /// <summary>
    /// レス情報
    /// </summary>
    class BBSResponse
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
        /// 名前
        /// </summary>
        public string WriterName { get; set; }

        /// <summary>
        /// メール
        /// </summary>
        public string WriterMail { get; set; }

        /// <summary>
        /// 書込日時
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
