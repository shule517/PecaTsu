using System;

namespace PecaTsuCommon.Entity
{
    /// <summary>
    /// スレッド情報
    /// </summary>
    public class BBSThread
    {
        /// <summary>
        /// 配信者ID
        /// </summary>
        public int ChannelId { get; set; }

        /// <summary>
        /// スレッドURL
        /// </summary>
        public string ThreadUrl { get; set; }

        /// <summary>
        /// スレッドストップフラグ
        /// </summary>
        public bool IsThreadStop { get; set; }

        /// <summary>
        /// 更新日時
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
