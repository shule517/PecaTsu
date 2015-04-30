using System;

namespace PecaTsuCommon.Entity
{
    /// <summary>
    /// 配信者マスター
    /// </summary>
    public class Channel
    {
        /// <summary>
        /// 配信者ID
        /// </summary>
        public int ChannelId { get; set; }

        /// <summary>
        /// 配信者名
        /// </summary>
        public string ChannelName { get; set; }

        /// <summary>
        /// チャンネル種類
        /// </summary>
        public int ChannelType { get; set; }

        /// <summary>
        /// 更新日時
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
