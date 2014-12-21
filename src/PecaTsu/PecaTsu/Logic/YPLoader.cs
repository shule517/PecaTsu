using PecaTsu.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace PecaTsu.Logic
{
	class YPLoader
	{
		/// <summary>
		/// YP情報の取り込み
		/// </summary>
		public void load()
		{
			// YP情報の取得
			List<ChannelHistory> channelList = loadYPInfo();

			// チャンネルの登録
			insertChannel(channelList);

			// チャンネル履歴の取得
			List<ChannelHistory> historyList = ChannelHistory.selectByToDay();

			// チャンネル名を使用して、配信情報登録
			foreach (ChannelHistory channel in channelList)
			{
				ChannelHistory history = ChannelHistory.selectByChannelName(channel.channel_name);

				if (history == null)
				{
					channel.insert();
				}
				else if (history.equal(channel))
				{
					channel.update(history);
				}
				else
				{
					channel.insert();
				}
			}
		}

		/// <summary>
		/// チャンネルの登録
		/// </summary>
		private void insertChannel(List<ChannelHistory> channelList)
		{
			List<Channel> channelNameList = Channel.selectAll();
			List<string> insertChannelList = new List<string>();
			foreach (ChannelHistory channel in channelList)
			{
				// YPは登録しない
				if (channel.IsYPInfo)
				{
					continue;
				}

				// チャンネルが登録済みかチェック
				if (!existsChannel(channelNameList, channel.channel_name))
				{
					insertChannelList.Add(channel.channel_name);
				}
			}
			Channel.Insert(insertChannelList.ToArray());
		}

		/// <summary>
		/// YP情報の読み込み
		/// </summary>
		private List<ChannelHistory> loadYPInfo()
		{
			List<ChannelHistory> channelList = new List<ChannelHistory>();

			// チャンネル情報取得
			List<YP> ypList = YP.selectYPList();
			foreach (YP yp in ypList)
			{
				string url = yp.yp_url + "index.txt";
				string html = getHtmlSource(url);
				List<ChannelHistory> list = analyzeYPText(yp, html);
				channelList.AddRange(list);
			}

			return channelList;
		}

		/// <summary>
		/// チャンネルが登録済みかチェック
		/// </summary>
		private bool existsChannel(List<Channel> channelNameList, string channel_name)
		{
			foreach (Channel channel in channelNameList)
			{
				if (channel.channel_name == channel_name)
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// YP情報を解析する
		/// </summary>
		private List<ChannelHistory> analyzeYPText(YP yp, string html)
		{
			string[] indexText = html.Split(new String[] { "\n" }, StringSplitOptions.None);
			List<ChannelHistory> channelList = new List<ChannelHistory>();

			foreach (string line in indexText)
			{
				string[] element = line.Split(new String[] { "<>" }, StringSplitOptions.None);
				if (element.Length != 19)
				{
					continue;
				}
				ChannelHistory channel = new ChannelHistory(yp, element);
				channelList.Add(channel);
			}

			return channelList;
		}

		/// <summary>
		/// 指定URLのHTMLソースを取得
		/// </summary>
		private static string getHtmlSource(string url)
		{
			WebClient wc = new WebClient();
			Stream st = wc.OpenRead(url);
			Encoding enc = Encoding.GetEncoding("UTF-8");
			StreamReader sr = new StreamReader(st, enc);
			string html = sr.ReadToEnd();
			return html;
		}
	}
}
