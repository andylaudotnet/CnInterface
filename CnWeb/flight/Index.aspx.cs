using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace CnWeb.flight
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
		//http://59.151.1.234/Default.asmx
		//User=test;Password=techtest;Server=59.151.1.234;Port=350;MaxPages=99;

		//av h peksha/30may10/0700/ca
		/*
		命令1：av h peknrt/25may/ca/d  查国航北京到东京直达航班8月25号的税
		命令2：sd1q1     1表示上面的第一个航班，q表示仓位，选取有数字的仓位，如果没有，选取座位数为A的仓位；只能选取非共享航班（没有星号*）来预定查税.需要判断是否返回PEKLAX DK1？，没有就发送i命令返回 
		命令3：qte:/ca   需要判断是否返回FARE  CNY和TOTAL CNY？
		命令4：xs fsq1   需要判断是否返回FARE  CNY和TOTAL CNY？，没有就发送i命令返回 
		命令5：i
		*/
         /*
        •证件不区分类型；
        •一次散客只能预定不超过9人，儿童是在名字后面加CHD标识；
        •命令涉及到的是必须填写项：英文格式姓名（与证件号相同）、航段信息；
        •SSR DOCS 后的必须填写项格式：航空公司代码 Action-Code 1 证件类型/发证国家/证件号码/国籍/出生日期/性别/证件有效期限/SURNAME(姓)/FIRST-NAME(名)/MID-NAME(中间名)/持有人标识H/P1
        儿童票：一般情况，年龄2-12周岁，以航班去程和回程起飞日期为准。
        婴儿票：一般情况，年龄0-2周岁，以航班去程和回程起飞日期为准。
        发证国家/国籍/出生日期/性别/证件有效期限
        CHN/	/CN/	1JAN83/	M/	10OCT19
         
            1:单程1成人
            NM:1wang/xinhua
            SS:CA167/Y/30OCT09/PEKNRT/1
            TK:TL/1200/29OCT/bjs166
            CT:010-85867155-8
            @

            单程1成人带1儿童
            NM:1wang/ceshi1wang/ertongCHD
            SS:CA167/W/30OCT09/PEKNRT/2
            SSR DOCS CA HK1 P/CHN/G12345678/CN/1JAN83/M/10OCT19/Wang/CESHI/P1
            SSR DOCS CA HK1 P/CHN/G12345678/CN/1JAN83/M/10OCT19/Wang/ertong/P1
            TK:TL/1200/29OCT/XNN116   --出票时限和office号
            CT:010-85867155-8 --联系电话
            @


            2:单程多人
            NM:1wang/ceshu1wang/yi
            SS:CA167/W/30OCT09/PEKNRT/2
            SSR DOCS CA HK1 P/CHN/G12345678/CN/1JAN83/M/10OCT19/Wang/CESHI/P1
            SSR DOCS CA HK1 P/CHN/G12345678/CN/1JAN83/M/10OCT19/Wang/yi/P2
            TK:TL/1200/29MAY/XNN116
            CT:010-85867155-8
            @

            3:往返单人(多人与单程的类似)
            NM:1Wang/CESHI
            SS:CA167/W/30MAY09/PEKNRT/1
            SS:CA168/W/30JUN09/NRTPEK/1
            SSR DOCS CA HK1 P/CHN/G12345678/CN/1JAN83/M/10OCT19/Wang/CESHI/P1
            TK:TL/1200/29MAY/XNN116
            CT:010-85867155-8
            @

            */
	    /*P__SMS_InsertSendQueue
		203.81.21.56|3000|10060|8|这里是测试,message2,message3,message4,message5
            */
        }
    }
}
