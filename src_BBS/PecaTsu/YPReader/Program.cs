using PecaTsuCommon;
using PecaTsuCommon.Bbs;
using PecaTsuCommon.Dao;
using PecaTsuCommon.Entity;
using PecaTsuCommon.Util;
using PeerstLib.Bbs.Data;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace YPReaderBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            DBUtil.Connect();

            List<YP> ypList = YPDao.Select();

            /*
            List<string> urlList = new List<string>();
            urlList.AddRange(YPReader.Read("http://temp.orz.hm/yp/"));
            urlList.AddRange(YPReader.Read("http://bayonet.ddo.jp/sp/"));



            List<string> imgList = new List<string>();
            foreach (string contactUrl in urlList)
            {
                BbsReader reader = new BbsReader();
                List<ResInfo> resList = reader.ReadRes(contactUrl);
                foreach (ResInfo res in resList)
                {
                    Match match = Regex.Match(res.Message, @"ttp://.*\.(jpg|JPG|jpeg|JPEG|bmp|BMP|png|PNG)");

                    if (match.Success)
                    {
                        imgList.Add("h" + match.Value);
                    }
                }
            }

            int i = 0;
            foreach (string imageUrl in imgList)
            {
                try
                {
                    System.Net.WebClient wc = new System.Net.WebClient();
                    wc.DownloadFile(imageUrl, @"S:\MyDocument_201503\dev\github\PecaTsu_BBS\src_BBS\img\" + i++ + ".jpg");
                    wc.Dispose();
                }
                catch (Exception)
                {
                }
            }
             */
        }
    }
}
