using PecaTsuCommon.Entity;
using PecaTsuCommon.Util;
using System.Collections.Generic;
using System.Text;

namespace PecaTsuCommon.Dao
{
    public class YPDao
    {
        public static List<YP> Select()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("  `YPUrl`");
            sb.AppendLine("  , `YPName`");
            sb.AppendLine("  , `UpdateTime` ");
            sb.AppendLine("FROM");
            sb.AppendLine("  `PecaTsuBBS`.`YP` ");
            sb.AppendLine("WHERE");
            sb.AppendLine("  `YPUrl` = :YPUrl ");
            sb.AppendLine("ORDER BY");
            sb.AppendLine("  `YPUrl`");

            return DBUtil.Select<YP>(sb.ToString());
        }
    }
}
