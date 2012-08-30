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

namespace CnWeb.flight
{
    public partial class ShowPrices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowBunks();
        }

        private void ShowBunks()
        {
            FlightWebService.ABEService FA = new FlightWebService.ABEService();
            string prices = FA.GetRawDataFromABE("FD:" + Request["citycodes"].ToString() + "/" + Request["date"].ToString() + "/" + Request["aircomcode"].ToString() + "/S", "");

            string[] bunk = Request["bunks"].ToString().Split(' ');
            StringBuilder sb = new StringBuilder();
            sb.Append("<table border ='0' cellpadding ='4' cellspacing ='1' width ='390px' bgcolor='#9999ff'>");
            sb.Append("<tr>");
            sb.Append("<td align='center'  bgcolor='#ffffff' style='background-image:url(../img/menuBackGround.jpg)'><font color='#666699'><b>舱  位</b></font></td>");
            sb.Append("<td align='center'  bgcolor='#ffffff' style='background-image:url(../img/menuBackGround.jpg)'><font color='#666699'><b>价  格(元)</b></font></td>");
            sb.Append("<td  align='center' bgcolor='#ffffff' style='background-image:url(../img/menuBackGround.jpg)'><font color='#666699'><b>剩余座位数</b></font></td>");
            sb.Append("</tr>");
            int idcount = 1;
            for (int i = 0; i < bunk.Length; i++)
            {
                   if (!"0.00".Equals(GetPriceByAirCompany(prices, bunk[i].Substring(0, 1))))
                   {
                       sb.Append("<tr id='tr" + idcount.ToString() + "' onmouseover=\"onmouseovertr(this.id);\" onmouseout=\"onmouseouttr(this.id);\">");
                       string cang = bunk[i].Substring(0, 1);
                       if (cang.Trim().ToUpper().Equals("C"))
                       {
                           cang += "<font color='#666699'>(商务舱)</font>";
                       }
                       else if (cang.Trim().ToUpper().Equals("F"))
                       {
                           cang += "<font color='#666699'>(头等舱)</font>";
                       }
                       else
                       {
                           cang += "<font color='#666699'>(经济舱)</font>";
                       }
                       sb.Append("<td align='center' bgcolor='#ffffff' onmouseover=\"this.style.backgroundColor='yellow';\" onmouseout=\"this.style.backgroundColor='#ffffff';\">" + cang + "</td>");
                       sb.Append("<td align='center' bgcolor='#ffffff' onmouseover=\"this.style.backgroundColor='yellow';\" onmouseout=\"this.style.backgroundColor='#ffffff';\">" + GetPriceByAirCompany(prices, bunk[i].Substring(0, 1)) + "</td>");
                       sb.Append("<td align='center' bgcolor='#ffffff' onmouseover=\"this.style.backgroundColor='yellow';\" onmouseout=\"this.style.backgroundColor='#ffffff';\">" + (bunk[i].Substring(1).ToUpper().Trim() == "A" ? "9个以上" : bunk[i].Substring(1) + "个") + "</td>");
                       sb.Append("</tr>");
                       idcount++;
                   }
            }
            if (idcount == 1)
            {
                sb.Append("<tr>");
                sb.Append("<td align='center' bgcolor='#ffffff' colspan='3'><font color=red><b>未找到该航班的仓位价格！</b></font></td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            Response.Write(sb.ToString());
        }

        private string GetPriceByAirCompany(string prices, string bunk)
        {
            string[] strtemp = prices.Split('\n');
            string price = "0.00";
            for (int i = 0; i < strtemp.Length; i++)
            {
                if (strtemp[i].IndexOf("FD:") > -1 || strtemp[i].IndexOf("PAGE") > -1 || strtemp[i].Equals("")) { }
                else
                {
                    if (strtemp[i].Length > 24)
                    {
                        if (bunk.ToUpper().Equals(strtemp[i].Substring(0, 24).Substring(strtemp[i].Substring(0, 24).IndexOf("/") + 1, 2).Trim().ToUpper()))
                            price = strtemp[i].Substring(0, 24).Substring(strtemp[i].Substring(0, 24).LastIndexOf("/") + 1).Trim();
                    }
                }
            }
            return price;
        }
    }
}
