using PecaTsu.Entity;
using PecaTsu.Logic;
using System;
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
			List<ChannelHistory> channelList = loader.load();

			// 配信中情報作成
			HatenaKeywordAPI hatena = new HatenaKeywordAPI();


			//DateTime date = DateTime.Now;
			List<Tuple<ChannelHistory, List<HatenaKeyword>>> list = new List<Tuple<ChannelHistory, List<HatenaKeyword>>>();

			string text = string.Empty;
			foreach (ChannelHistory channel in channelList)
			{
				text += channel.detail + " " + channel.genre + " " + channel.comment + Environment.NewLine;
				/*
				List<HatenaKeywordResult> result = setKeywordLink(text, 0, "game");

				Tuple<ChannelHistory, List<HatenaKeywordResult>> item = new Tuple<ChannelHistory, List<HatenaKeywordResult>>(channel, result);
				list.Add(item);
				Console.WriteLine("time : " + (date - DateTime.Now));
				 */
			}
			/*
			Console.WriteLine("time : " + (date - DateTime.Now));
			List<HatenaKeywordResult> result = setKeywordLink(text, 0, "game");
			Console.WriteLine("time : " + (date - DateTime.Now));
			 */

			// string result = hatena.setKeywordLink(text, 0, "game");

			// 配信中ゲームを初期化
			LiveGame.DeleteAll();

			text = Microsoft.VisualBasic.Strings.StrConv(text, Microsoft.VisualBasic.VbStrConv.Wide | Microsoft.VisualBasic.VbStrConv.Hiragana | Microsoft.VisualBasic.VbStrConv.Uppercase, 0x411);

			// ゲーム一覧から抽出
			List<Game> gameList = Game.Select();
			foreach (Game game in gameList)
			{
				string title = Microsoft.VisualBasic.Strings.StrConv(game.game_title, Microsoft.VisualBasic.VbStrConv.Wide | Microsoft.VisualBasic.VbStrConv.Hiragana | Microsoft.VisualBasic.VbStrConv.Uppercase, 0x411);
				int index = text.IndexOf(title);
				if (index != -1)
				{
					LiveGame liveGame = new LiveGame();
					liveGame.game_title = "HARD:" + game.game_hard + " GENRE:" + game.game_genre + " TITLE:" + game.game_title;
					liveGame.Insert();
				}
			}

			// はてなキーワードから抽出
			List<HatenaKeyword> keyword = hatena.extractHatenaKeyword(text, 30, "game");
			foreach (HatenaKeyword word in keyword)
			{
				LiveGame liveGame = new LiveGame();
				liveGame.game_title = word.Word;
				liveGame.Insert();
			}
		}
	}
}
