
using PecaTsu.Logic;
using System.Collections.Generic;
namespace PecaTsu.Entity
{
	class Game
	{
		public Game()
		{
		}

		/// <summary>
		/// 配信中ゲームを登録
		/// </summary>
		public static List<Game> Select()
		{
			string sql = string.Format("SELECT game_id, game_hard, game_genre, game_title, game_image_url, update_time FROM game");
			return SqlRequest.requestSql<Game>(sql);
		}

		public string game_id { get; set; }
		public string game_hard { get; set; }
		public string game_genre { get; set; }
		public string game_title { get; set; }
		public string game_image_url { get; set; }
		public string update_time { get; set; }
	}
}
