using PeerstLib.Bbs.Data;
using PeerstLib.Bbs.Strategy;
using System.Collections.Generic;

namespace PecaTsuCommon.Bbs
{
    public class BbsReader
    {
        public List<ResInfo> ReadRes(string contactUrl)
        {
            BbsStrategy bbs = BbsStrategyFactory.Create(contactUrl);
            if (bbs.ThreadSelected)
            {
                bbs.UpdateThreadList();

                if (bbs.ThreadList.Count > 0)
                {
                    bbs.ChangeThread(bbs.ThreadList[0].ThreadNo);
                }
            }
            List<ResInfo> resList = bbs.ReadThread(true);
            return resList;
        }
    }
}
