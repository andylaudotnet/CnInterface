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
using CnBusinessLogic;
using System.Text;

namespace CnWeb.Parse
{
    public partial class ParseVideos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || CnInterfaceUser.GetUserLevel(Session["username"].ToString().Trim())!=1)
            {
                Response.Redirect("~/Index.aspx");
            }
            if (!IsPostBack)
            {
                ParseVideosToHTML(Request["webname"] as string);
            }
        }

        private void ParseVideosToHTML(string webname)
        {
            StringBuilder sb = new StringBuilder();
            VideoHtmlCreate vc = new VideoHtmlCreate();
            switch(webname)
            {
                case "17173":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("17173"), "", "", "src", "", "", "17173Videos"); sb.Append("17173=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/17173Videos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("17173=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "56":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("56"), "", "alt", "src", "", "", "56Videos"); sb.Append("<br>56=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/56Videos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>56=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "6cn":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("6cn"), "", "", "src", "", "", "6cnVideos"); sb.Append("<br>6cn=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/6cnVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>6cn=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "baidu":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("baidu"), "", "", "src", "", "", "BaiduVideos"); sb.Append("<br>baidu=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/baiduVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>baidu=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "cntv":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("cntv"), "", "", "src", "", "", "CntvVideos"); sb.Append("<br>cntv=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/cntvVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>cntv=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "hunantv":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("hunantv"), "title", "", "src", "http://tv.hunantv.com/", "", "HunantvVideos"); sb.Append("<br>hunantv=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/hunantvVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>hunantv=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "ifeng":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("ifeng"), "", "", "src", "", "../img/cninterface.jpg", "IfengVideos"); sb.Append("<br>ifeng=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/ifengVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>ifeng=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "ku6":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("ku6"), "", "", "src", "", "", "Ku6Videos"); sb.Append("<br>ku6=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/ku6Videos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>ku6=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "news":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("news"), "", "", "src", "", "http://www.news.cn/video/", "NewsVideos"); sb.Append("<br>news=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/newsVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>news=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "openv":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("openv"), "", "alt", "src", "http://hd.openv.com/", "", "OpenvVideos"); sb.Append("<br>openv=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/openvVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>openv=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "qq":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("qq"), "", "", "src", "", "", "QQVideos"); sb.Append("<br>qq=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/qqVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>qq=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "sina":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("sina"), "", "alt", "src", "", "", "SinaVideos"); sb.Append("<br>sina=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/sinaVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>sina=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "sohu":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("sohu"), "", "alt", "src", "", "../img/cninterface.jpg", "SohuVideos"); sb.Append("<br>sohu=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/sohuVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>sohu=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "tencent":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("tencent"), "", "alt", "src", "", "", "TencentVideos"); sb.Append("<br>tencent=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/tencentVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>tencent=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "tudou":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("tudou"), "title", "", "src", "", "", "TudouVideos"); sb.Append("<br>tudou=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/tudouVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>tudou=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "xunlei":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("xunlei"), "", "alt", "src", "", "", "XunleiVideos"); sb.Append("<br>xunlei=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/xunleiVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>xunlei=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "youku":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("youku"), "", "", "src", "", "", "YoukuVideos"); sb.Append("<br>youku=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/youkuVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>youku=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "pps":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("pps"), "", "", "src", "", "", "PPSVideos"); sb.Append("<br>pps=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/ppsVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>pps=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "pplive":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("pplive"), "", "alt", "src2", "", "", "PPLiveVideos"); sb.Append("<br>pplive=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/ppliveVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>pplive=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "uusee":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("uusee"), "", "", "src", "", "", "UUseeVideos"); sb.Append("<br>uusee=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/uuseeVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>uusee=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "m1905":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("m1905"), "", "", "src", "http://www.m1905.com/", "", "M1905Videos"); sb.Append("<br>m1905=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/m1905Videos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>m1905=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "funshion":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("funshion"), "", "", "src", "", "", "FunshionVideos"); sb.Append("<br>funshion=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/funshionVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>funshion=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "joy":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("joy"), "", "", "src", "", "", "joyVideos"); sb.Append("<br>joy=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/joyVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>joy=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "pomoho":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("pomoho"), "", "", "src", "", "", "PomohoVideos"); sb.Append("<br>pomoho=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/pomohoVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>pomoho=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "letv":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("letv"), "", "", "src", "", "", "LetvVideos"); sb.Append("<br>letv=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/letvVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>letv=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "aeeboo":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("aeeboo"), "", "", "src", "", "", "AeebooVideos"); sb.Append("<br>aeeboo=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/aeebooVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>aeeboo=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                case "google":
                    try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("google"), "", "", "src", "", "", "GoogleVideos"); sb.Append("<br>google=<font color='green'>ok</font>&nbsp;&nbsp;<a href=\"../html/googleVideos.html\" target=\"_blank\"><font color=blue>查看</font></a>&nbsp;&nbsp;&nbsp;<a href=\"Index.aspx\">返回</a>"); }
                    catch (Exception ex) { sb.Append("<br>google=<font color='red'>" + ex.Message + "</font>"); }
                    break;
                default:
                    break;
            }
            Response.Write(sb.ToString());
        }
    }
}
