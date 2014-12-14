using PecaTsu.Entity;
using PecaTsu.Logic;

namespace PecaTsu
{
	class Program
	{
		static void Main(string[] args)
		{
			// SQL接続の初期化
			SqlRequest.init();

			string text = Channel.selectChannelID("あれくま");
		}
	}
}
