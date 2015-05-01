using PecaTsuCommon.Entity;
using PecaTsuCommon.Util;
using PeerstLib.Bbs.Data;
using System.Collections.Generic;
using System.Text;

namespace PecaTsuCommon.Dao
{
    public class ImageLinkDao
    {
        public static List<ImageLink> Select()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("  `ThreadUrl`");
            sb.AppendLine("  , `ResNo`");
            sb.AppendLine("  , `ImageNo`");
            sb.AppendLine("  , `ImageUrl`");
            sb.AppendLine("  , `WriteTime`");
            sb.AppendLine("  , `UpdateTime` ");
            sb.AppendLine("FROM");
            sb.AppendLine("  `PecaTsuBBS`.`ImageLink` ");
            sb.AppendLine("ORDER BY");
            sb.AppendLine("  `ThreadUrl`");
            sb.AppendLine("  , `ResNo`");
            sb.AppendLine("  , `ImageNo`");
            sb.AppendLine("");

            return DBUtil.Select<ImageLink>(sb.ToString());
        }

        public static void Insert(string threadUrl, string channelName, string imageUrl, ResInfo res)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT ");
            sb.AppendLine("INTO `PecaTsuBBS`.`ImageLink` ( ");
            sb.AppendLine("  `ThreadUrl`");
            sb.AppendLine("  , `ResNo`");
            sb.AppendLine("  , `ImageUrl`");
            sb.AppendLine("  , `ChannelName`");
            sb.AppendLine("  , `WriterName`");
            sb.AppendLine("  , `WriterMail`");
            sb.AppendLine("  , `WriteTime`");
            sb.AppendLine("  , `WriterId`");
            sb.AppendLine("  , `Message`");
            sb.AppendLine(") ");
            sb.AppendLine("VALUES ( ");
            sb.AppendLine("  @ThreadUrl");
            sb.AppendLine("  , @ResNo");
            sb.AppendLine("  , @ImageUrl");
            sb.AppendLine("  , @ChannelName");
            sb.AppendLine("  , @WriterName");
            sb.AppendLine("  , @WriterMail");
            sb.AppendLine("  , @WriteTime");
            sb.AppendLine("  , @WriterId");
            sb.AppendLine("  , @Message");
            sb.AppendLine(") ");
            sb.AppendLine("ON DUPLICATE KEY UPDATE ImageUrl = @ImageUrl");

            Dictionary<string, string> paramDic = new Dictionary<string, string>();
            paramDic["ThreadUrl"] = threadUrl;
            paramDic["ResNo"] = res.ResNo;
            paramDic["ImageUrl"] = imageUrl;
            paramDic["ChannelName"] = channelName;
            paramDic["WriterName"] = res.Name;
            paramDic["WriterMail"] = res.Mail;
            paramDic["WriteTime"] = res.Date;
            paramDic["WriterId"] = res.Id;
            paramDic["Message"] = res.Message;

            DBUtil.Update(sb.ToString(), paramDic);
        }
    }
}
