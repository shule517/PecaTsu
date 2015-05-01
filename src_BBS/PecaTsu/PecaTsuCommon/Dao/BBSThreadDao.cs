using PecaTsuCommon.Dto;
using PecaTsuCommon.Entity;
using PecaTsuCommon.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace PecaTsuCommon.Dao
{
    /// <summary>
    /// スレッド情報
    /// </summary>
    public class BBSThreadDao
    {
        /// <summary>
        /// スレッド情報の取得
        /// </summary>
        /// <returns>スレッド情報</returns>
        public static List<BBSThread> Select()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("  `ChannelId`");
            sb.AppendLine("  , `ThreadUrl`");
            sb.AppendLine("  , `MaxResNo`");
            sb.AppendLine("  , `IsThreadStop`");
            sb.AppendLine("  , `UpdateTime` ");
            sb.AppendLine("FROM");
            sb.AppendLine("  `PecaTsuBBS`.`BBSThread` ");
            sb.AppendLine("ORDER BY");
            sb.AppendLine("  `ChannelId`");
            sb.AppendLine("  , `ThreadUrl`");

            return DBUtil.Select<BBSThread>(sb.ToString());
        }

        /// <summary>
        /// スレッド情報の登録
        /// </summary>
        /// <param name="detail">チャンネル詳細</param>
        public static void Insert(int channelId, string threadUrl, bool isThreadStop)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT ");
            sb.AppendLine("INTO `PecaTsuBBS`.`BBSThread` ( ");
            sb.AppendLine("  `ChannelId`");
            sb.AppendLine("  , `ThreadUrl`");
            sb.AppendLine("  , `IsThreadStop`");
            sb.AppendLine(") ");
            sb.AppendLine("VALUES ( ");
            sb.AppendLine("  @ChannelId");
            sb.AppendLine("  , @ThreadUrl");
            sb.AppendLine("  , @IsThreadStop");
            sb.AppendLine(") ");
            sb.AppendLine("");

            Dictionary<string, string> paramDic = new Dictionary<string, string>();
            paramDic["ChannelId"] = channelId.ToString();
            paramDic["ThreadUrl"] = threadUrl;
            paramDic["IsThreadStop"] = isThreadStop ? "1" : "0";

            DBUtil.Update(sb.ToString(), paramDic);
        }

        /// <summary>
        /// スレッド情報の更新
        /// </summary>
        /// <param name="detail">チャンネル詳細</param>
        public static void Update(int channelId, string threadUrl, string maxResNo, bool isThreadStop)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE `PecaTsuBBS`.`BBSThread` ");
            sb.AppendLine("SET");
            sb.AppendLine("  `MaxResNo` = @MaxResNo");
            sb.AppendLine("  , `IsThreadStop` = @IsThreadStop");
            sb.AppendLine("  , `UpdateTime` = current_timestamp() ");
            sb.AppendLine("WHERE");
            sb.AppendLine("  `ChannelId` = @ChannelId ");
            sb.AppendLine("  and `ThreadUrl` = @ThreadUrl");

            Dictionary<string, string> paramDic = new Dictionary<string, string>();
            paramDic["ChannelId"] = channelId.ToString();
            paramDic["ThreadUrl"] = threadUrl;
            paramDic["MaxResNo"] = maxResNo;
            paramDic["IsThreadStop"] = isThreadStop ? "1" : "0";

            DBUtil.Update(sb.ToString(), paramDic);
        }
    }
}
