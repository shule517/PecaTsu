using PecaTsuCommon.Dto;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace PecaTsuCommon
{
    /// <summary>
    /// YP情報読み込み
    /// </summary>
    public class YPReader
    {
        public YPReader(string url)
        {
        }

        /// <summary>
        /// YPからチャンネル情報を取得
        /// </summary>
        /// <param name="ypUrl">YPのアドレス</param>
        /// <returns>チャンネル詳細</returns>
        public static List<ChannelDetail> Read(string ypUrl)
        {
            // index.txtを取得
            string indexUrl = ypUrl + "index.txt";
            string source = GetHtmlSource(indexUrl);

            // チャンネル情報一覧を取得
            List<ChannelDetail> channelDetailList = new List<ChannelDetail>();
            var lines = source.Split("\n".ToCharArray()).Where(e => !string.IsNullOrEmpty(e));
            foreach (var line in lines)
            {
                string[] indexTextElem = line.Split(new string[] { "<>" }, System.StringSplitOptions.None);
                ChannelDetail detail = new ChannelDetail(indexTextElem);
                channelDetailList.Add(detail);
            }

            return channelDetailList;
        }

        /// <summary>
        /// 指定URLのソースの取得
        /// </summary>
        /// <param name="url">取得先のURL</param>
        /// <returns>ソース</returns>
        private static string GetHtmlSource(string url)
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
