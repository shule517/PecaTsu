using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace PecaTsu.Logic
{
	/// <summary>
	/// はてなキーワード自動リンクAPI
	/// </summary>
	class HatenaKeywordAPI
	{
		// はてなキーワードAPIのURL
		const string RequestUrl = "http://d.hatena.ne.jp/xmlrpc";

		/// <summary>
		/// 文章に対してハイパーリンクを付与する
		/// </summary>
		/// <param name="text">対象の文章</param>
		/// <param name="score">閾値</param>
		/// <param name="category">book,music,movie,web,elec,animal,anime,food,sports,game,comic,hatena,club</param>
		/// <returns></returns>
		public string setKeywordLink(string text, int score, string category)
		{
			// POST送信するXMLを作成
			string postData = String.Format(@"<?xml version=""1.0"" encoding=""UTF-8""?>
<methodCall>
   <methodName>hatena.setKeywordLink</methodName>
   <params>
     <param>
        <value>
          <struct>
             <member>
               <name>body</name>
               <value>{0}</value>
             </member>
             <member>
               <name>score</name>
               <value><i4>{1}</i4></value>
             </member>
             <member>
               <name>cname</name>
               <value>
                 <array>
                   <data>
                     <value><string>{2}</string></value>
                   </data>
                 </array>
               </value>
             </member>
             <member>
               <name>a_target</name>
               <value>_blank</value>
             </member>
             <member>
               <name>a_class</name>
               <value>keyword</value>
             </member>
          </struct>
        </value>
     </param>
   </params>
</methodCall>", text, score, category);

			XmlDocument doc = post(RequestUrl, postData);

			// 結果を解析する
			XmlNode node = doc.SelectSingleNode("/methodResponse/params/param/value");
			return node.InnerText;
		}

		/// <summary>
		/// 文章からはてなキーワードを抽出する
		/// </summary>
		/// <param name="text">対象の文章</param>
		/// <param name="score">閾値</param>
		/// <param name="category">book,music,movie,web,elec,animal,anime,food,sports,game,comic,hatena,club</param>
		/// <returns></returns>
		public List<HatenaKeyword> extractHatenaKeyword(string text, int score, string category)
		{
			// POST送信するXMLを作成
			string postData = String.Format(@"<?xml version=""1.0"" encoding=""UTF-8""?>
<methodCall>
   <methodName>hatena.setKeywordLink</methodName>
   <params>
     <param>
        <value>
          <struct>
             <member>
               <name>body</name>
               <value>{0}</value>
             </member>
             <member>
               <name>score</name>
               <value><i4>{1}</i4></value>
             </member>
             <member>
               <name>mode</name>
               <value><string>lite<string></value>
             </member>
             <member>
               <name>cname</name>
               <value>
                 <array>
                   <data>
                     <value><string>{2}</string></value>
                   </data>
                 </array>
               </value>
             </member>
             <member>
               <name>a_target</name>
               <value>_blank</value>
             </member>
             <member>
               <name>a_class</name>
               <value>keyword</value>
             </member>
          </struct>
        </value>
     </param>
   </params>
</methodCall>", text, score, category);

			XmlDocument doc = post(RequestUrl, postData);

			// 結果を解析する
			XmlNodeList paramsNode = doc.SelectNodes("/methodResponse/params/param/value/struct/member/value/array/data/value/struct");

			List<HatenaKeyword> wordList = new List<HatenaKeyword>();
			foreach (XmlNode node in paramsNode)
			{
				HatenaKeyword result = new HatenaKeyword();
				result.Word = node.SelectSingleNode("member[1]/value").InnerText;
				result.Score = node.SelectSingleNode("member[2]/value").InnerText;
				result.Refcount = node.SelectSingleNode("member[3]/value").InnerText;
				result.Category = node.SelectSingleNode("member[4]/value").InnerText;

				wordList.Add(result);
			}

			return wordList;
		}

		/// <summary>
		/// データをPOSTする
		/// </summary>
		private XmlDocument post(string requestUrl, string postData)
		{
			byte[] postDataBytes = Encoding.UTF8.GetBytes(postData);

			// HttpWebRequestの作成
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);

			// POST
			request.Method = "POST";
			request.ContentType = "text/xml";
			request.ContentLength = postDataBytes.Length;
			Stream reqStream = request.GetRequestStream();
			reqStream.Write(postDataBytes, 0, postDataBytes.Length);
			reqStream.Close();

			HttpWebResponse response = null;
			XmlDocument doc = new XmlDocument();
			try
			{
				// レスポンスの取得
				response = (HttpWebResponse)request.GetResponse();
				Stream strm = response.GetResponseStream();
				StreamReader reader = new StreamReader(strm);
				doc.Load(strm);
			}
			catch
			{
				// レスポンス取得失敗
				return new XmlDocument();
			}
			finally
			{
				if (response != null)
				{
					response.Close();
				}
			}

			return doc;
		}
	}

	/// <summary>
	/// はてなキーワード情報
	/// </summary>
	class HatenaKeyword
	{
		public string Word { get; set; }
		public string Score { get; set; }
		public string Refcount { get; set; }
		public string Category { get; set; }
	}
}
