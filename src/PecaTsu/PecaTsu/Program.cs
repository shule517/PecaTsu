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

			// YPデータ取り込み
			YPLoader loader = new YPLoader();
			loader.load();
		}
	}
}
