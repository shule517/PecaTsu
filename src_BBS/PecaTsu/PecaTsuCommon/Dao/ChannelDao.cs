using PecaTsuCommon.Entity;
using PecaTsuCommon.Util;
using System.Collections.Generic;
using System.Text;

namespace PecaTsuCommon.Dao
{
    /// <summary>
    /// 配信者マスターDao
    /// </summary>
    public class ChannelDao
    {
        /// <summary>
        /// 配信者一覧を取得
        /// </summary>
        /// <returns>配信者一覧</returns>
        public static List<Channel> Select()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("  `ChannelId`");
            sb.AppendLine("  , `ChannelName`");
            sb.AppendLine("  , `ChannelType`");
            sb.AppendLine("  , `UpdateTime` ");
            sb.AppendLine("FROM");
            sb.AppendLine("  `PecaTsuBBS`.`Channel` ");
            sb.AppendLine("ORDER BY");
            sb.AppendLine("  `ChannelId`");

            return DBUtil.Select<Channel>(sb.ToString());
        }

        /// <summary>
        /// 配信者を新規登録
        /// </summary>
        /// <param name="detail">チャンネル詳細</param>
        public static void Insert(Dto.ChannelDetail detail)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT ");
            sb.AppendLine("INTO `PecaTsuBBS`.`Channel` ( ");
            sb.AppendLine("  `ChannelName`");
            sb.AppendLine("  , `ChannelType`");
            sb.AppendLine(") ");
            sb.AppendLine("VALUES ( ");
            sb.AppendLine("  @ChannelName");
            sb.AppendLine("  , @ChannelType");
            sb.AppendLine(") ");

            Dictionary<string, string> paramDic = new Dictionary<string, string>();
            paramDic["ChannelName"] = detail.ChannelName;
            if (detail.IsYPInfo)
            {
                // YP
                paramDic["ChannelType"] = "1";
            }
            else
            {
                // 配信者
                paramDic["ChannelType"] = "0";
            }

            DBUtil.Update(sb.ToString(), paramDic);
        }
    }
}
