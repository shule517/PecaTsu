using PecaTsuCommon.Entity;
using PecaTsuCommon.Util;
using PeerstLib.Bbs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PecaTsuCommon.Dao
{
    public class BBSResponseDao
    {
        /// <summary>
        /// レス情報の取得
        /// </summary>
        /// <returns>レス情報</returns>
        public static List<BBSResponse> Select()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("  `ThreadUrl`");
            sb.AppendLine("  , `ResNo`");
            sb.AppendLine("  , `WriterName`");
            sb.AppendLine("  , `WriterMail`");
            sb.AppendLine("  , `WriteTime`");
            sb.AppendLine("  , `WriterId`");
            sb.AppendLine("  , `Message`");
            sb.AppendLine("  , `UpdateTime` ");
            sb.AppendLine("FROM");
            sb.AppendLine("  `PecaTsuBBS`.`BBSResponse` ");
            sb.AppendLine("ORDER BY");
            sb.AppendLine("  `ThreadUrl`");
            sb.AppendLine("  , `ResNo`");

            return DBUtil.Select<BBSResponse>(sb.ToString());
        }

        public static void Insert(string threadUrl, List<ResInfo> resList)
        {
            foreach (ResInfo res in resList)
            {
                Insert(threadUrl, res);
            }
        }

        public static void Insert(string threadUrl, ResInfo resList)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT ");
            sb.AppendLine("INTO `PecaTsuBBS`.`BBSResponse` ( ");
            sb.AppendLine("  `ThreadUrl`");
            sb.AppendLine("  , `ResNo`");
            sb.AppendLine("  , `WriterName`");
            sb.AppendLine("  , `WriterMail`");
            sb.AppendLine("  , `WriteTime`");
            sb.AppendLine("  , `WriterId`");
            sb.AppendLine("  , `Message`");
            sb.AppendLine(") ");
            sb.AppendLine("VALUES ( ");
            sb.AppendLine("  @ThreadUrl");
            sb.AppendLine("  , @ResNo");
            sb.AppendLine("  , @WriterName");
            sb.AppendLine("  , @WriterMail");
            sb.AppendLine("  , @WriteTime");
            sb.AppendLine("  , @WriterId");
            sb.AppendLine("  , @Message");
            sb.AppendLine(") ");
            sb.AppendLine("ON DUPLICATE KEY UPDATE Message = @Message");

            Dictionary<string, string> paramDic = new Dictionary<string, string>();
            paramDic["ThreadUrl"] = threadUrl;
            paramDic["ResNo"] = resList.ResNo;
            paramDic["WriterName"] = resList.Name;
            paramDic["WriterMail"] = resList.Mail;
            paramDic["WriteTime"] = resList.Date;
            paramDic["WriterId"] = resList.Id;
            paramDic["Message"] = resList.Message;

            DBUtil.Update(sb.ToString(), paramDic);
        }
    }
}
