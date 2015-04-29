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

        public static List<string> Read(string url)
        {
            // index.txtを取得
            string indexUrl = url + "index.txt";
            string source = GetHtmlSource(indexUrl);

            // チャンネル情報一覧を取得
            var lines = source.Split("\n".ToCharArray()).Where(e => !string.IsNullOrEmpty(e));

            List<string> urlList = new List<string>();
            foreach (var line in lines)
            {
                string[] elem = line.Split("<>".ToCharArray());
                string contactUrl = elem[6];
                urlList.Add(contactUrl);
                /*
                ChannelHistory history = new ChannelHistory(elem);
                channelList.Add(history);
                 */
            }

            return urlList;
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
