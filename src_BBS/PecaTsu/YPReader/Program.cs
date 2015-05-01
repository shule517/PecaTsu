using PecaTsuCommon;
using PecaTsuCommon.Bbs;
using PecaTsuCommon.Dao;
using PecaTsuCommon.Dto;
using PecaTsuCommon.Entity;
using PecaTsuCommon.Util;
using PeerstLib.Bbs.Data;
using PeerstLib.Util;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace YPReaderBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            DBUtil.Connect();

            Logger.Instance.Debug("aa");

            // YPからチャンネル情報を取得
            List<ChannelDetail> channelDetails = GetChannelDetails();

            // 配信者マスターの更新
            UpdateChannel(channelDetails);

            // スレッド情報の更新
            UpdateBBSThread(channelDetails);

            // レス情報の更新
            UpdateBBSResponse();

            List<string> imgList = new List<string>();

            // レス一覧の取得
            List<BBSResponse> resList = BBSResponseDao.Select();
            foreach (BBSResponse res in resList)
            {
                Match match = Regex.Match(res.Message, @"ttp://.*\.(jpg|JPG|jpeg|JPEG|bmp|BMP|png|PNG)");

                if (match.Success)
                {
                    string imageUrl = "h" + match.Value;
                    imgList.Add(imageUrl);
                    ImageLinkDao.Insert(res.ThreadUrl, res.ResNo, imageUrl, res.WriteTime);
                }
            }

            /*
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
            // TODO DEBUG END
             */

            DBUtil.Close();
        }

        private static void UpdateBBSResponse()
        {
            // レス読み込み
            List<BBSThread> threadList = BBSThreadDao.Select();
            foreach (BBSThread thread in threadList)
            {
                // スレッドストップしていたらスルー
                if (thread.IsThreadStop)
                {
                    continue;
                }

                BbsReader reader = new BbsReader();
                bool isThreadStop;
                List<ResInfo> resList = reader.ReadRes(thread.ThreadUrl, out isThreadStop);
                resList = resList.Where(res => int.Parse(res.ResNo) > thread.MaxResNo).ToList();

                // レスの追加
                BBSResponseDao.Insert(thread.ThreadUrl, resList);

                // 最大レス番号
                string maxResNo = (resList.Count() == 0) ? "0" : resList.Last().ResNo;

                // 掲示板の更新(スレッドストップを更新)
                BBSThreadDao.Update(thread.ChannelId, thread.ThreadUrl, maxResNo, isThreadStop);
            }
        }

        /// <summary>
        /// スレッド情報の更新
        /// </summary>
        /// <param name="channelDetails">チャンネル詳細</param>
        private static void UpdateBBSThread(List<ChannelDetail> channelDetails)
        {
            List<Channel> channelList = ChannelDao.Select();
            var channelDetailsJoin = channelDetails.Join(channelList, detail => detail.ChannelName, channel => channel.ChannelName, (detail, channel) => new { Detail = detail, Channel = channel });

            List<BBSThread> threadList = BBSThreadDao.Select();
            foreach (var detail in channelDetailsJoin)
            {
                // コンタクトURLからスレッドURLを取得
                BbsReader reader = new BbsReader();
                string threadUrl = reader.GetThreadUrl(detail.Detail.ContactUrl);

                // スレッド情報が登録されていなければ登録する
                bool isExist = threadList.Any(thread => (thread.ChannelId == detail.Channel.ChannelId) && (thread.ThreadUrl == threadUrl));
                if (!isExist)
                {
                    BBSThreadDao.Insert(detail.Channel.ChannelId, threadUrl, false);
                }
            }
        }

        /// <summary>
        /// チャンネル詳細を取得
        /// </summary>
        /// <returns>チャンネル詳細一覧</returns>
        private static List<ChannelDetail> GetChannelDetails()
        {
            List<ChannelDetail> channelDetails = new List<ChannelDetail>();

            // YP一覧の取得
            List<YP> ypList = YPDao.Select();

            // YPからチャンネル詳細を取得
            foreach (YP yp in ypList)
            {
                List<ChannelDetail> details = YPReader.Read(yp.YPUrl);
                channelDetails.AddRange(details);
            }

            return channelDetails;
        }

        /// <summary>
        /// チャンネル詳細を更新
        /// </summary>
        /// <param name="channelDetails">チャンネル詳細</param>
        private static void UpdateChannel(List<ChannelDetail> channelDetails)
        {
            List<Channel> channelList = ChannelDao.Select();
            foreach (ChannelDetail detail in channelDetails)
            {
                bool isExist = channelList.Any(elem => elem.ChannelName == detail.ChannelName);
                if (!isExist)
                {
                    ChannelDao.Insert(detail);
                }
            }
        }
    }
}
