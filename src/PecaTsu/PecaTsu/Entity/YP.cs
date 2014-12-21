using PecaTsu.Logic;
using System.Collections.Generic;

namespace PecaTsu.Entity
{
	class YP
	{
		public YP()
		{
		}

		// YPの一覧を取得
		public static List<YP> selectYPList()
		{
			string sql = "SELECT yp_id, yp_name, yp_url, update_time FROM yp ORDER BY yp_id";
			return SqlRequest.requestSql<YP>(sql);
		}

		public string yp_id { get; set; }
		public string yp_name { get; set; }
		public string yp_url { get; set; }
		public string update_time { get; set; }
	}
}
