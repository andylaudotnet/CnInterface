using System;
using System.Collections.Generic;
using System.Text;
using System .Data;
using CnDataAcess.Entity;

namespace CnDataAcess.IList
{
    public  interface ICnInterfaceVideoXpath
    {
        CnInterfaceVideoXpath GetVideoXpathByWebName(string webname);
        int UpdateCnInterfaceVideo(CnInterfaceVideoXpath cnxpath);
    }
}
