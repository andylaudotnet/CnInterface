using System;
using System.Data;
using CnDataAcess;
using CnDataAcess.Entity;

namespace CnBusinessLogic
{
    public class CnInterfaceVideoXpath
    {
        public static CnDataAcess.Entity.CnInterfaceVideoXpath GetVideoXpathByWebName(string webname)
        {
            return ObjectCreate.CreateInterfaceVideoXpath().GetVideoXpathByWebName(webname);
        }

        public static int UpdateCnInterfaceVideo(CnDataAcess.Entity.CnInterfaceVideoXpath cnXpath)
        {
            return ObjectCreate.CreateInterfaceVideoXpath().UpdateCnInterfaceVideo(cnXpath);
        }
    }
}
