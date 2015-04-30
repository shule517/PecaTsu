using PecaTsuCommon.Entity;
using PecaTsuCommon.Util;
using System.Collections.Generic;
using System.Text;

namespace PecaTsuCommon.Dao
{
    /// <summary>
    /// YPDao
    /// </summary>
    public class YPDao
    {
        /// <summary>
        /// YP一覧を取得
        /// </summary>
        /// <returns>YP一覧</returns>
        public static List<YP> Select()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("  `YPId`");
            sb.AppendLine("  , `YPUrl`");
            sb.AppendLine("  , `YPName`");
            sb.AppendLine("  , `UpdateTime` ");
            sb.AppendLine("FROM");
            sb.AppendLine("  `PecaTsuBBS`.`YP` ");
            sb.AppendLine("ORDER BY");
            sb.AppendLine("  `YPUrl`");

            return DBUtil.Select<YP>(sb.ToString());
        }
    }
}
