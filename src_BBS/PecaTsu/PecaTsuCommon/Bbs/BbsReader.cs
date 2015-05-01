using PeerstLib.Bbs.Data;
using PeerstLib.Bbs.Strategy;
using System.Collections.Generic;

namespace PecaTsuCommon.Bbs
{
    public class BbsReader
    {
        public string GetThreadUrl(string contactUrl)
        {
            BbsStrategy bbs = BbsStrategyFactory.Create(contactUrl);
            if (!bbs.ThreadSelected)
            {
                bbs.UpdateThreadList();

                if (bbs.ThreadList.Count > 0)
                {
                    bbs.ChangeThread(bbs.ThreadList[0].ThreadNo);
                }
            }

            return bbs.ThreadUrl;
        }

        public List<ResInfo> ReadRes(string contactUrl, out bool isThreadStop)
        {
            BbsStrategy bbs = BbsStrategyFactory.Create(contactUrl);
            if (!bbs.ThreadSelected)
            {
                bbs.UpdateThreadList();

                if (bbs.ThreadList.Count > 0)
                {
                    bbs.ChangeThread(bbs.ThreadList[0].ThreadNo);
                }
            }
            List<ResInfo> resList = bbs.ReadThread(true);

            // スレッドストップフラグを設定
            isThreadStop = (bbs.BbsInfo.ThreadStop <= resList.Count);

            return resList;
        }
    }
}
