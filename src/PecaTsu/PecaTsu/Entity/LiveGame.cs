
using PecaTsu.Logic;
namespace PecaTsu.Entity
{
	class LiveGame
	{
		public LiveGame()
		{
		}

		/// <summary>
		/// 配信中ゲームを登録
		/// </summary>
		public void Insert()
		{
			string sql = string.Format("INSERT IGNORE INTO live_game (game_title) values ('{0}')", game_title);
			SqlRequest.requestSql(sql);
		}

		/// <summary>
		/// 全レコードを削除
		/// </summary>
		public static void DeleteAll()
		{
			string sql = "DELETE FROM live_game";
			SqlRequest.requestSql(sql);
		}
	
		public string game_title { get; set; }
		public string update_time { get; set; }
	}
}
