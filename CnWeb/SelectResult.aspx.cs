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
using System.Data.SqlClient;
using System.Text;
using CnBusinessLogic;
using CnDataAcess;
using CnDataAcess.Entity;
using System.Collections.Generic;
using System.Net;
using System.IO;

namespace CnWeb
{
    public partial class SelectResult : System.Web.UI.Page
    {
        protected string SearchResultCount = "0";
        protected string SearchTime= "0.000";
        private const int pagesize =10;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    int ttype = 0;
                    DateTime dt1 = DateTime.Now;
                    if (Request["t"] != null && !Request["t"].ToString().Equals(""))
                    {
                        ttype = SetInterfaceTypeShow(Request["t"].ToString());
                    }
                    string searchstr = Server.HtmlDecode(Request["s"]);
                    int pageindex;
                    try
                    {
                        pageindex = Convert.ToInt32(Request["p"]);
                    }
                    catch
                    {
                        pageindex = 1;
                    }
                    int totalcount;
                    int totalpage;
                    DivSearchResults.InnerHtml = SelectInterfaceListInfo(ttype,searchstr, pagesize, pageindex, out totalcount, out totalpage);
                    txtInterfaceName.Value = searchstr;

                    DateTime dt2 = DateTime.Now;
                    TimeSpan ts = dt2 - dt1;
                    double timeuse = Convert.ToInt32(ts.TotalMilliseconds) * 0.001;
                    SearchTime = timeuse.ToString();
                    if (timeuse == 0)
                        SearchTime = "0.001";
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("Index.aspx?e="+ex.Message);
            }
        }

        private int SetInterfaceTypeShow(string type)
        {
            int t = 0;
            string showname = "";
            switch (type)
            {
                case "aall":
                    t = 0;
                    showname = "全部";
                    aWebservice.InnerHtml  = "<font size=2  color='#666699'>Webservice</font>";
                    aHTTP.InnerHtml  = "<font size=2  color='#666699'>HTTP</font>";
                    aDLL.InnerHtml  = "<font size=2  color='#666699'>普通DLL</font>";
                    aADLL.InnerHtml  = "<font size=2  color='#666699'>ActiveXDLL</font>";
                    aData.InnerHtml  = "<font size=2  color='#666699'>数据库</font>";
                    break;
                case "aWebservice":
                    t = 1;
                    showname = "Webservice";
                    aall.InnerHtml  = "<font size=2  color='#666699'>全部</font>";
                    aHTTP.InnerHtml  = "<font size=2  color='#666699'>HTTP</font>";
                    aDLL.InnerHtml  = "<font size=2  color='#666699'>普通DLL</font>";
                    aADLL.InnerHtml  = "<font size=2  color='#666699'>ActiveXDLL</font>";
                    aData.InnerHtml  = "<font size=2  color='#666699'>数据库</font>";
                    break;
                case "aHTTP":
                    t = 2;
                    showname = "HTTP";
                    aall.InnerHtml  = "<font size=2  color='#666699'>全部</font>";
                    aWebservice.InnerHtml  = "<font size=2  color='#666699'>Webservice</font>";
                    aDLL.InnerHtml  = "<font size=2  color='#666699'>普通DLL</font>";
                    aADLL.InnerHtml  = "<font size=2  color='#666699'>ActiveXDLL</font>";
                    aData.InnerHtml  = "<font size=2  color='#666699'>数据库</font>";
                    break;
                case "aDLL":
                    t = 3;
                    showname = "普通DLL";
                    aall.InnerHtml  = "<font size=2  color='#666699'>全部</font>";
                    aHTTP.InnerHtml  = "<font size=2  color='#666699'>HTTP</font>";
                    aWebservice.InnerHtml  = "<font size=2  color='#666699'>Webservice</font>";
                    aADLL.InnerHtml  = "<font size=2  color='#666699'>ActiveXDLL</font>";
                    aData.InnerHtml  = "<font size=2  color='#666699'>数据库</font>";
                    break;
                case "aADLL":
                    t = 4;
                    showname = "ActiveXDLL";
                    aall.InnerHtml  = "<font size=2  color='#666699'>全部</font>";
                    aHTTP.InnerHtml  = "<font size=2  color='#666699'>HTTP</font>";
                    aDLL.InnerHtml  = "<font size=2  color='#666699'>普通DLL</font>";
                    aWebservice.InnerHtml  = "<font size=2  color='#666699'>Webservice</font>";
                    aData.InnerHtml  = "<font size=2  color='#666699'>数据库</font>";
                    break;
                case "aData":
                    t = 5;
                    showname = "数据库";
                    aall.InnerHtml  = "<font size=2  color='#666699'>全部</font>";
                    aHTTP.InnerHtml  = "<font size=2  color='#666699'>HTTP</font>";
                    aDLL.InnerHtml  = "<font size=2  color='#666699'>普通DLL</font>";
                    aADLL.InnerHtml  = "<font size=2  color='#666699'>ActiveXDLL</font>";
                    aWebservice.InnerHtml  = "<font size=2  color='#666699'>Webservice</font>";
                    break;
                default:
                    t = 0;
                    showname = "Webservice";
                    aall.InnerHtml  = "<font size=2  color='#666699'>全部</font>";
                    aHTTP.InnerHtml  = "<font size=2  color='#666699'>HTTP</font>";
                    aDLL.InnerHtml  = "<font size=2  color='#666699'>普通DLL</font>";
                    aADLL.InnerHtml  = "<font size=2  color='#666699'>ActiveXDLL</font>";
                    aData.InnerHtml  = "<font size=2  color='#666699'>数据库</font>";
                    break;
            }
            System.Web.UI.HtmlControls.HtmlAnchor aname = (System.Web.UI.HtmlControls.HtmlAnchor)FindControl(type);
            aname.InnerHtml = "<font size=2 color=\"#003399\"><b>" + showname + "</b></font>";
            hiddenInterfaceName.Value = type;
            txtInterfaceName.Focus();
            return t;
        }
        private string GetTypaNameByNum(int ttype)
        {
            string typename = "";
            switch (ttype)
            { 
                case 1:
                    typename = "aWebservice";
                    break;
                case 2:
                    typename = "aHTTP";
                    break;
                case 3:
                    typename = "aDLL";
                    break;
                case 4:
                    typename = "aADLL";
                    break;
                case 5:
                    typename = "aData";
                    break;
                default:
                    typename = "aall";
                    break;
            }
            return typename;
        }
        private string SelectInterfaceListInfo(int ttype,string searchStr, int pagesize, int pageindex,out int totalcount,out int totalpage)
        {
             string returnString = "";
             try
             {
                 InterfaceInfo IFI = new InterfaceInfo();
                 IList<CnInterfaceInfo> ICII = IFI.GetCnInterfaceInfoByName(ttype,searchStr, pagesize, pageindex, out totalcount, out totalpage);
                 if (ICII != null)
                 {
                     SearchResultCount = totalcount.ToString();
                     StringBuilder sb = new StringBuilder();
                     foreach (CnInterfaceInfo icii in ICII)
                     {
                         sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px;\">");
                         sb.Append(" <div>");
                         sb.Append(" <a target=\"_blank\"  href=\"" + icii.CnInterfaceUrl + "\"><font color=blue>" + WordFiter(icii.CnInterfaceName.Replace(searchStr, "<font color=red>" + searchStr + "</font>")) + "</font></a>");
                         sb.Append(" </div>");
                         sb.Append(" <div style=\"font-size: 13px;\">");
                         sb.Append(" <font size=2 >" + WordFiter(icii.CnInterfacebody.Replace(searchStr, "<font color=red>" + searchStr + "</font>")) + "</font>");
                         sb.Append(" </div>");
                         sb.Append(" <div>");
                         sb.Append(" <font color=#006600>" + (icii.CnInterfaceUrl.Length > 66 ? icii.CnInterfaceUrl.Substring(0, 66) : icii.CnInterfaceUrl) + "</font>&nbsp;&nbsp;<font size=2 color=#006600>" + icii.CnInterfaceAppearTime.ToString("yyyy-MM-dd") + "</font>&nbsp;&nbsp;<a target=\"_blank\" href=\"" + icii.CnInterfaceSourceUrl + "\"><font size=2  color=#666699>" + icii.CnInterfaceSource + "</font></a>");
                         sb.Append("  </div>");
                         sb.Append(" </div>");
                     }
                     if (totalpage > 1)
                     {
                         string parame = "";
                         sb.Append("<table  border=\"0\" cellpadding =\"4\" cellspacing =\"0\" width=\"888px\">");
                         sb.Append("<tr >");
                         sb.Append("<td>");
                         if (pageindex > 1)
                         {
                             parame = "SelectResult.aspx?t=" + GetTypaNameByNum(ttype) + "&p=" + (pageindex - 1).ToString() + "&s=" + Server.HtmlEncode(searchStr);
                             sb.Append("<a  href=\"" + parame + "\"><font color=\"blue\">上一页</font></a><img border=\"0\"  src=\"img/blank001.jpg\" width=\"8px\"   style=\"FILTER: alpha(opacity=0);opacity:0;\"/>");
                         }
                         int beginindex = 1;//循环开始index
                         int endindex = totalpage;//循环结束index
                         if (totalpage > 20 && pageindex > 11 && totalpage - pageindex > 8)
                         {
                             beginindex = pageindex - 10;
                         }
                         if (totalpage > 20 && pageindex > 11 && totalpage - pageindex < 9)
                         {
                             beginindex = pageindex - (20 - (totalpage - pageindex) - 1);
                         }
                         if (endindex > 10)
                         {
                             endindex = pageindex + 9;
                             if (endindex > totalpage)
                             {
                                 endindex = totalpage;
                             }
                         }
                         for (int i = beginindex; i <= endindex; i++)
                         {
                             if ((i) == pageindex)
                             {
                                 sb.Append("<img border=\"0\"  src=\"img/blank001.jpg\" width=\"3px\"   style=\"FILTER: alpha(opacity=0);opacity:0;\"/>" + pageindex);
                             }
                             else
                             {
                                 parame = "SelectResult.aspx?t=" + GetTypaNameByNum(ttype) + "&p=" + (i).ToString() + "&s=" + Server.HtmlEncode(searchStr);
                                 sb.Append("<img border=\"0\"  src=\"img/blank001.jpg\" width=\"3px\"  style=\"FILTER: alpha(opacity=0);opacity:0;\"/><a href=\"" + parame + "\"><font color=\"blue\">[" + (i).ToString() + "]</font></a>");
                             }
                         }
                         if (pageindex < totalpage)
                         {
                             parame = "SelectResult.aspx?t=" + GetTypaNameByNum(ttype) + "&p=" + (pageindex + 1).ToString() + "&s=" + Server.HtmlEncode(searchStr);
                             sb.Append("<img border=\"0\"  src=\"img/blank001.jpg\" width=\"8px\"   style=\"FILTER: alpha(opacity=0);opacity:0;\"/><a   href=\"" + parame + "\"><font color=\"blue\">下一页</font></a>");
                         }
                         //&nbsp;&nbsp;<font size=2 color=#666699>共" + totalpage .ToString()+ "页</font>
                         sb.Append("</td>");
                         sb.Append("</tr>");
                         sb.Append("</table>");
                     }
                     returnString = sb.ToString();
                 }
                 else
                 {
                     returnString = "<br>抱歉，没有找到该类型“" + searchStr + "”相关的内容。<a href='GoogleResult.aspx?searchword=" + searchStr + "'>可去此处查询</a><br><br><b>建议您：</b> <br>1、看看输入的文字是否有误<br>2、去掉可能不必要的字词，如“的”、“什么”等<br>3、<a href='GoogleResult.aspx?searchword=" + searchStr + "'>去此处查询</a><br><br><br>";
                     DivTheSameResults.Attributes.Add("style","display:none");
                     divinterfaceAD.Attributes.Add("style", "display:none");
                 }
             }
             catch(Exception ex)
             {
                 totalcount = 0;
                 totalpage = 0;
                 returnString = "<br>抱歉，查询错误："+ex.Message+"。<a href='GoogleResult.aspx?searchword=" + searchStr + "'>可去此处查询</a><br><br><b>建议您：</b> <br>1、看看输入的文字是否有误<br>2、去掉可能不必要的字词，如“的”、“什么”等<br>3、<a href='GoogleResult.aspx?searchword=" + searchStr + "'>去此处查询</a><br><br><br>";
                 DivTheSameResults.Attributes.Add("style", "display:none");
                 divinterfaceAD.Attributes.Add("style", "display:none");
             }
            return returnString;
        }

        private string WordFiter(string word)
        {
            return word.Replace("口交", "嘴交").Replace("a片", "片片").Replace("裸体", "无衣").Replace("赌博","博彩");
        }

        protected void bntInterfaceSelect_Click(object sender, EventArgs e)
        {
            if (txtInterfaceName.Value.Trim() == "")
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                string searchStr = Server.HtmlEncode(txtInterfaceName.Value.Trim());
                Response.Redirect("SelectResult.aspx?t=" + hiddenInterfaceName.Value.Trim() + "&p=1&s=" + searchStr);
            }
        }
    }
}
