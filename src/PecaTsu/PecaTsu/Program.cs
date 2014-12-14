using PecaTsu.Entity;
using PecaTsu.Logic;
using System.Collections.Generic;

namespace PecaTsu
{
	class Program
	{
		static void Main(string[] args)
		{
			// SQL接続の初期化
			SqlRequest.init();

			List<YP> list = YP.selectYPList();
			string text = Channel.selectChannelID("しっかりシュールｃｈ");
		}
	}
}
