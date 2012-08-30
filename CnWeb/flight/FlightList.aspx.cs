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
using System.Text;
using HtmlAgilityPack;
using System.Xml;
using System.Net;

namespace CnWeb.flight
{
    public partial class FlightList :System.Web.UI.Page
    {
        protected string FlightHtml = "";
        protected string FlightInfo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FlightHtml = GetFlihtHtml(GetFlightList());
            }
        }

        private string GetFlihtHtml(string xml)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table border ='0' cellpadding ='4' cellspacing ='1' width ='737px' bgcolor='#9999ff'>");
            sb.Append("<tr>");
            sb.Append("<td width='60px' bgcolor='#ffffff'  style='background-image:url(../img/menuBackGround.jpg)'><font color='#666699'><b>航班号</b></font></td>");
            sb.Append("<td width='80px' bgcolor='#ffffff'  style='background-image:url(../img/menuBackGround.jpg)'><font color='#666699'><b>出发机场</b></font></td>");
            sb.Append("<td width='80px' bgcolor='#ffffff' style='background-image:url(../img/menuBackGround.jpg)'><font color='#666699'><b>到达机场</b></font></td>");
            sb.Append("<td width='80px' bgcolor='#ffffff' style='background-image:url(../img/menuBackGround.jpg)'><font color='#666699'><b>出发日期</b></font></td>");
            sb.Append("<td width='80px' bgcolor='#ffffff' style='background-image:url(../img/menuBackGround.jpg)'><font color='#666699'><b>出发时间</b></font></td>");
            sb.Append("<td width='80px' bgcolor='#ffffff' style='background-image:url(../img/menuBackGround.jpg)'><font color='#666699'><b>到达日期</b></font></td>");
            sb.Append("<td width='80px' bgcolor='#ffffff' style='background-image:url(../img/menuBackGround.jpg)'><font color='#666699'><b>到达时间</b></font></td>");
            sb.Append("<td bgcolor='#ffffff' style='background-image:url(../img/menuBackGround.jpg)'><font color='#666699'><b>机型</b></font></td>");
            sb.Append("<td bgcolor='#ffffff' style='background-image:url(../img/menuBackGround.jpg)'><font color='#666699'><b>仓位</b></font></td>");
            sb.Append("</tr>");
            if (xml.IndexOf("CRS.CommandSet.AV") > -1)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
               XmlNodeList xnl=doc.SelectNodes("CRS.CommandSet.AV/Item");
                int idcount=1;
               foreach (XmlNode xn in xnl)
               {
                   if (!xn.ChildNodes[3].InnerText.Trim().ToUpper().Equals(Request["ecity"].ToString().Trim().ToUpper()))
                   {
                       sb.Append("<tr id='tr"+idcount.ToString()+ "' onmouseover=\"onmouseovertr(this.id,2);\" onmouseout=\"onmouseouttr(this.id,2);\">");
                   }
                   else if (!xn.ChildNodes[2].InnerText.Trim().ToUpper().Equals(Request["bcity"].ToString().Trim().ToUpper()))
                   {
                       sb.Append("<tr id='tr" + idcount.ToString() + "' onmouseover=\"onmouseovertr(this.id,3);\" onmouseout=\"onmouseouttr(this.id,3);\">");
                   }
                   else
                   {
                       sb.Append("<tr id='tr"+idcount.ToString()+ "' onmouseover=\"onmouseovertr(this.id,1);\" onmouseout=\"onmouseouttr(this.id,1);\">");
                   }
                   sb.Append("<td bgcolor='#ffffff'>" + xn.Attributes["Carrier"].Value + xn.Attributes["FlightNo"].Value + "</td>");
                   sb.Append("<td bgcolor='#ffffff'>" + GetAirPortByCode(xn.ChildNodes[2].InnerText) + "</td>");
                   sb.Append("<td bgcolor='#ffffff'>" + GetAirPortByCode(xn.ChildNodes[3].InnerText) + "</td>");
                   sb.Append("<td bgcolor='#ffffff'>" + xn.ChildNodes[4].InnerText + "</td>");
                   sb.Append("<td bgcolor='#ffffff'>" + xn.ChildNodes[5].InnerText.Substring(0, 2) + ":" + xn.ChildNodes[5].InnerText.Substring(2) + "</td>");
                   sb.Append("<td bgcolor='#ffffff'>" + xn.ChildNodes[6].InnerText + "</td>");
                   sb.Append("<td bgcolor='#ffffff'>" + xn.ChildNodes[7].InnerText.Substring(0, 2) + ":" + xn.ChildNodes[7].InnerText.Substring(2) + "</td>");
                   sb.Append("<td bgcolor='#ffffff'>" + xn.Attributes["Carrier"].Value + xn.ChildNodes[8].InnerText + "</td>");
                   sb.Append("<td bgcolor='#ffffff' ><span title='查看所有仓位价格'  style='cursor:hand;;cursor:pointer;' onclick=\"openprice('ShowPrices.aspx?citycodes=" + Request["bcity"].ToString() + Request["ecity"].ToString() + "&date="+DateTime.Now.AddDays(1).ToString("dd")+"may&aircomcode=" + xn.Attributes["Carrier"].Value + "&bunks=" + xn.ChildNodes[14].InnerText + "');\">查看</td>");
                   sb.Append("</tr>");
                   idcount++;
               }
               FlightInfo = "共查询到"+xnl.Count.ToString()+"个航班。";
            }
            sb.Append("</table>");
            return sb.ToString();
        }

        private string GetFlightList()
        {
            //FlightList.aspx?bcity=PEK&ecity=CSX&bdate=20100510&btime=0900&airline=CZ
            FlightWebService.ABEService Av = new FlightWebService.ABEService();
            string xml = Av.GetAVXML(Request["bcity"].ToString(), Request["ecity"].ToString(), Request["bdate"].ToString(), Request["btime"].ToString(), Request["airline"].ToString(), "", "", "");
            return xml;
        }

        private string GetAirPortByCode(string code)
        {
            #region
            //string xpath = "/html/body/div/div[3]/div[3]/table/tbody/tr[2]/td[4]";
            //string url = "http://www.feeyo.com/airport_code.asp?search=" + code;
            //try
            //{
            //    WebClient wc = new WebClient
            //    {
            //        Encoding = Encoding.GetEncoding("gb2312")
            //    };
            //    string html = wc.DownloadString(url.Trim());
            //    var doc = new HtmlDocument();
            //    doc.LoadHtml(html);

            //    return doc.DocumentNode.SelectSingleNode(xpath).InnerText;
            //}
            //catch
            //{
            //    return code;
            //}    
            
            string aircodes = @"
                        AKU:阿克苏;
						AAT:阿勒泰;
						AKA:安康;
						AQG:安庆;
						AVA:安顺;
						AYN:安阳;
						AOG:鞍山;
						BFU:蚌埠;
						BAV:包头;
						BSD:保山;
						BHY:北海;
						PEK:北京首都;
						NAY:北京南苑;
						CGQ:长春;
						CNI:长海;
						CSX:长沙;
						CIH:长治;
						CGD:常德;
						CZX:常州;
						CHG:朝阳;
						CTU:成都;
						CIF:赤峰;
						CKG:重庆;
						DAX:达县;
						DLU:大理;
						DLC:大连;
						DAT:大同;
						DZU:大足;
						DDG:丹东;
						DIG:迪庆;
						DSN:东胜;
						DOY:东营;
						DNH:敦煌;
						ENH:恩施;
						FUO:佛山;
						FOC:福州;
						FUG:阜阳;
						FYN:富蕴;
						KOW:赣州;
						GOQ:格尔木;
						GHN:广汉;
						CAN:广州;
						KWE:贵阳;
						KWL:桂林;
						HRB:哈尔滨;
						HMI:哈密;
						HAK:海口;
						HLD:海拉尔;
						HZG:汉中;
						HGH:杭州;
						HFE:合肥;
						HTN:和田;
						HEK:黑河;
						HNY:衡阳;
						HET:呼和浩特;
						TXN:黄山;
						HYN:黄岩;
						HUZ:徽州;
						KNC:吉安;
						JIL:吉林;
						TNA:济南;
						JNG:济宁;
						JMU:佳木斯;
						JGN:嘉峪关;
						JNZ:锦州;
						SHS:荆沙;
						JGS:井冈山;
						JDZ:景德镇;
						JIU:九江;
						JZH:九寨沟;
						CHW:酒泉;
						KHG:喀什;
						KRY:克拉玛依;
						KCA:库车;
						KRL:库尔勒;
						KMG:昆明;
						LXA:拉萨;
						LHW:兰州;
						LJG:丽江;
						LYG:连云港;
						LIA:梁平;
						LXI:林西;
						LNJ:临沧;
						LYI:临沂;
						LZH:柳州;
						LUZ:庐山;
						LZO:泸州;
						LYA:洛阳;
						NZH:满洲里;
						LUM:芒市;
						MXZ:梅县;
						MIG:绵阳;
						MDG:牡丹江;
						KHN:南昌;
						NAO:南充;
						NKG:南京;
						NNG:南宁;
						NTG:南通;
						NNY:南阳;
						NGB:宁波;
						PZI:攀枝花;
						NDG:齐齐哈尔;
						IQM:且末;
						SHP:秦皇岛山海关;
						TAO:青岛;
						IQN:庆阳;
						JUZ:衢州;
						JJN:泉州晋江;
						SYX:三亚;
						SWA:汕头;
						SXJ:鄯善;
						SSS:上海;
						SHA:上海虹桥;
						PVG:上海浦东;
						SZX:深圳;
						SHE:沈阳;
						SJW:石家庄;
						SYM:思茅;
						SZV:苏州;
						TCG:塔城;
						TYN:太原;
						TSN:天津;
						TNH:通化;
						TGO:通辽;
						TEN:铜仁;
						WXN:万州;
						WEH:威海;
						WEF:潍坊;
						WNZ:温州;
						WUA:乌海;
						HLH:乌兰浩特;
						URC:乌鲁木齐;
						WUX:无锡;
						WHU:芜湖;
						WUZ:梧州;
						WUH:武汉;
						WUS:武夷山;
						XIY:西安;
						XIC:西昌;
						XNN:西宁;
						JHG:西双版纳;
						XIL:锡林浩特;
						XMN:厦门;
						XIG:香港;
						XFN:襄樊;
						XEN:兴城;
						XIN:兴宁;
						XNT:邢台;
						XUZ:徐州;
						YNT:烟台;
						ENY:延安;
						YNJ:延吉;
						YNZ:盐城;
						YIN:伊宁;
						YBP:宜宾;
						YIH:宜昌;
						YIW:义乌;
						INC:银川;
						UYN:榆林;
						YUA:元谋;
						YCU:运城;
						ZHA:湛江;
						DYG:张家界;
						ZAT:昭通;
						CGO:郑州;
						HSN:舟山;
						ZUH:珠海;
						ZYI:遵义;";
            try
            {
                return aircodes.Substring(aircodes.IndexOf(code) + 4, aircodes.Substring(aircodes.IndexOf(code) + 4).IndexOf(";"));
            }
            catch
            {
                return code;
            }
            #endregion
        }

        
    }
}
