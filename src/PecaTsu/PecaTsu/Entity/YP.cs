using PecaTsu.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PecaTsu.Entity
{
	class YP
	{
		public YP(string[] data)
		{
			if (data.Length != 4) return;

			int i = 0;
			yp_id		= data[i++];
			yp_name		= data[i++]; 
			yp_url		= data[i++];
			update_time	= data[i++];
		}

		// YPの一覧を取得
		public static List<YP> selectYPList()
		{
			string sql = "SELECT yp_id, yp_name, yp_url, update_time FROM yp ORDER BY yp_id";
			List<List<string>> result = SqlRequest.requestSql(sql);
			if (result.Count == 0)
			{
				return null;
			}
			
			List<YP> list = new List<YP>();
			foreach (List<string> data in result)
			{
				YP yp = new YP(data.ToArray());
				list.Add(yp);
			}

			return list;
		}

		public string yp_id { get; set; }
		public string yp_name { get; set; }
		public string yp_url { get; set; }
		public string update_time { get; set; }
	}
}
