using PecaTsuCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PecaTsuCommon.Dao
{
    public class ImageLinkDao
    {
        public static void Insert(string threadUrl, int resNo, string imageUrl, string writeTime)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT ");
            sb.AppendLine("INTO `PecaTsuBBS`.`ImageLink` ( ");
            sb.AppendLine("  `ThreadUrl`");
            sb.AppendLine("  , `ResNo`");
            sb.AppendLine("  , `ImageUrl`");
            sb.AppendLine("  , `WriteTime`");
            sb.AppendLine(") ");
            sb.AppendLine("VALUES ( ");
            sb.AppendLine("  @ThreadUrl");
            sb.AppendLine("  , @ResNo");
            sb.AppendLine("  , @ImageUrl");
            sb.AppendLine("  , @WriteTime");
            sb.AppendLine(") ");
            sb.AppendLine("ON DUPLICATE KEY UPDATE ImageUrl = @ImageUrl");

            Dictionary<string, string> paramDic = new Dictionary<string, string>();
            paramDic["ThreadUrl"] = threadUrl;
            paramDic["ResNo"] = resNo.ToString();
            paramDic["ImageUrl"] = imageUrl;
            paramDic["WriteTime"] = writeTime;

            DBUtil.Update(sb.ToString(), paramDic);
        }
    }
}
