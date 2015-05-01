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
            if (resList.Count == 0)
            {
                return;
            }

            StringBuilder sb = new StringBuilder();
            Dictionary<string, string> paramDic = new Dictionary<string, string>();

            // SQL文の生成
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
            sb.AppendLine("VALUES ");

            foreach (var res in resList.Select((value, i) => new { value, i }))
            {
                // SQL文の生成
                if (res.i == 0)
                {
                    sb.AppendLine("( ");
                }
                else
                {
                    sb.AppendLine(",( ");
                }
                sb.AppendLine("  @ThreadUrl" + res.i);
                sb.AppendLine("  , @ResNo" + res.i);
                sb.AppendLine("  , @WriterName" + res.i);
                sb.AppendLine("  , @WriterMail" + res.i);
                sb.AppendLine("  , @WriteTime" + res.i);
                sb.AppendLine("  , @WriterId" + res.i);
                sb.AppendLine("  , @Message" + res.i);
                sb.AppendLine(") ");

                // パラメータの設定
                paramDic["ThreadUrl" + res.i] = threadUrl;
                paramDic["ResNo" + res.i] = res.value.ResNo;
                paramDic["WriterName" + res.i] = res.value.Name;
                paramDic["WriterMail" + res.i] = res.value.Mail;
                paramDic["WriteTime" + res.i] = res.value.Date;
                paramDic["WriterId" + res.i] = res.value.Id;
                paramDic["Message" + res.i] = res.value.Message;
            }
            // sb.AppendLine("ON DUPLICATE KEY UPDATE Message = @Message");

            DBUtil.Update(sb.ToString(), paramDic);
        }

        /*
        public static void Insert(string threadUrl, List<ResInfo> resList)
        {
            foreach (ResInfo res in resList)
            {
                Insert(threadUrl, res);
            }
        }
         */

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
