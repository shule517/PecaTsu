using System;

namespace PecaTsuCommon.Entity
{
    /// <summary>
    /// YPマスター
    /// </summary>
    class YP
    {
        /// <summary>
        /// YPID
        /// </summary>
        public int YPId { get; set; }

        /// <summary>
        /// YPアドレス
        /// </summary>
        public string YPUrl { get; set; }

        /// <summary>
        /// YP名
        /// </summary>
        public string YPName { get; set; }

        /// <summary>
        /// 更新日時
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
