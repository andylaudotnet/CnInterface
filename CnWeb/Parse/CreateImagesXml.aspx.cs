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
using System .IO;

namespace CnWeb.Parse
{
    public partial class CreateImagesXml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ParseVideosToHTML(Request["web"] as string);
            }
        }

        private void ParseVideosToHTML(string webname)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" ?>");
            sb.Append("<images>");
            ImagesXmlCreate vc = new ImagesXmlCreate();
            int bid = 0;
            int id;
            switch (webname)
            {
                case "17173":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("17173"), "", "", "src", "", "", "17173Videos",bid,out id));}
                    catch (Exception ex) { sb.Append("<error web=\"17173\">" + ex.Message + "</error>");}
                    break;
                case "56":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("56"), "", "alt", "src", "", "", "56Videos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"56\">" + ex.Message + "</error>"); }
                    break;
                case "6cn":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("6cn"), "", "", "src", "", "", "6cnVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"6cn\">" + ex.Message + "</error>"); }
                    break;
                case "baidu":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("baidu"), "", "", "src", "", "", "BaiduVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"baidu\">" + ex.Message + "</error>"); }
                    break;
                case "cntv":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("cntv"), "", "", "src", "", "", "CntvVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"cntv\">" + ex.Message + "</error>"); }
                    break;
                case "hunantv":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("hunantv"), "title", "", "src", "http://tv.hunantv.com/", "", "HunantvVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"hunantv\">" + ex.Message + "</error>"); }
                    break;
                case "ifeng":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("ifeng"), "", "", "src", "", "../img/cninterface.jpg", "IfengVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"ifeng\">" + ex.Message + "</error>"); }
                    break;
                case "ku6":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("ku6"), "", "", "src", "", "", "Ku6Videos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"ku6\">" + ex.Message + "</error>"); }
                    break;
                case "news":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("news"), "", "", "src", "", "http://www.news.cn/video/", "NewsVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"news\">" + ex.Message + "</error>"); }
                    break;
                case "openv":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("openv"), "", "alt", "src", "http://hd.openv.com/", "", "OpenvVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"openv\">" + ex.Message + "</error>"); }
                    break;
                case "qq":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("qq"), "", "", "src", "", "", "QQVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"qq\">" + ex.Message + "</error>"); }
                    break;
                case "sina":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("sina"), "", "alt", "src", "", "", "SinaVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"sina\">" + ex.Message + "</error>"); }
                    break;
                case "sohu":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("sohu"), "", "alt", "src", "", "../img/cninterface.jpg", "SohuVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"sohu\">" + ex.Message + "</error>"); }
                    break;
                case "tencent":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("tencent"), "", "alt", "src", "", "", "TencentVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"tencent\">" + ex.Message + "</error>"); }
                    break;
                case "tudou":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("tudou"), "title", "", "src", "", "", "TudouVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"tudou\">" + ex.Message + "</error>"); }
                    break;
                case "xunlei":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("xunlei"), "", "alt", "src", "", "", "XunleiVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"xunlei\">" + ex.Message + "</error>"); }
                    break;
                case "youku":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("youku"), "", "", "src", "", "", "YoukuVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"youku\">" + ex.Message + "</error>"); }
                    break;
                case "pps":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("pps"), "", "", "src", "", "", "PPSVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"pps\">" + ex.Message + "</error>"); }
                    break;
                case "pplive":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("pplive"), "", "alt", "src2", "", "", "PPLiveVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"pplive\">" + ex.Message + "</error>"); }
                    break;
                case "uusee":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("uusee"), "", "", "src", "", "", "UUseeVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"uusee\">" + ex.Message + "</error>"); }
                    break;
                case "m1905":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("m1905"), "", "", "src", "http://www.m1905.com/", "", "M1905Videos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"m1905\">" + ex.Message + "</error>"); }
                    break;
                case "funshion":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("funshion"), "", "", "src", "", "", "FunshionVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"funshion\">" + ex.Message + "</error>"); }
                    break;
                case "joy":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("joy"), "", "", "src", "", "", "joyVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"joy\">" + ex.Message + "</error>"); }
                    break;
                case "pomoho":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("pomoho"), "", "", "src", "", "", "PomohoVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"pomoho\">" + ex.Message + "</error>"); }
                    break;
                case "letv":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("letv"), "", "", "src", "", "", "LetvVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"letv\">" + ex.Message + "</error>"); }
                    break;
                case "aeeboo":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("aeeboo"), "", "", "src", "", "", "AeebooVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"aeeboo\">" + ex.Message + "</error>");}
                    break;
                case "google":
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("google"), "", "", "src", "", "", "GoogleVideos",bid,out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"google\">" + ex.Message + "</error>"); }
                    break;
                default:
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("56"), "", "alt", "src", "", "", "56Videos", bid, out id)); bid = id;}
                    catch (Exception ex) { sb.Append("<error web=\"56\">" + ex.Message + "</error>"); }
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("baidu"), "", "", "src", "", "", "BaiduVideos", bid, out id)); bid = id; }
                    catch (Exception ex) { sb.Append("<error web=\"baidu\">" + ex.Message + "</error>"); }
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("hunantv"), "title", "", "src", "http://tv.hunantv.com/", "", "HunantvVideos", bid, out id)); bid = id; }
                    catch (Exception ex) { sb.Append("<error web=\"hunantv\">" + ex.Message + "</error>"); }
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("ifeng"), "", "", "src", "", "../img/cninterface.jpg", "IfengVideos", bid, out id)); bid = id; }
                    catch (Exception ex) { sb.Append("<error web=\"ifeng\">" + ex.Message + "</error>"); }
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("openv"), "", "alt", "src", "http://hd.openv.com/", "", "OpenvVideos", bid, out id)); bid = id; }
                    catch (Exception ex) { sb.Append("<error web=\"openv\">" + ex.Message + "</error>"); }
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("qq"), "", "", "src", "", "", "QQVideos", bid, out id)); bid = id; }
                    catch (Exception ex) { sb.Append("<error web=\"qq\">" + ex.Message + "</error>"); }
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("tencent"), "", "alt", "src", "", "", "TencentVideos", bid, out id)); bid = id; }
                    catch (Exception ex) { sb.Append("<error web=\"tencent\">" + ex.Message + "</error>"); }
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("tudou"), "title", "", "src", "", "", "TudouVideos", bid, out id)); bid = id; }
                    catch (Exception ex) { sb.Append("<error web=\"tudou\">" + ex.Message + "</error>"); }
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("xunlei"), "", "alt", "src", "", "", "XunleiVideos", bid, out id)); bid = id; }
                    catch (Exception ex) { sb.Append("<error web=\"xunlei\">" + ex.Message + "</error>"); }
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("pps"), "", "", "src", "", "", "PPSVideos", bid, out id)); bid = id; }
                    catch (Exception ex) { sb.Append("<error web=\"pps\">" + ex.Message + "</error>"); }
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("pplive"), "", "alt", "src2", "", "", "PPLiveVideos", bid, out id)); bid = id; }
                    catch (Exception ex) { sb.Append("<error web=\"pplive\">" + ex.Message + "</error>"); }
                    try { sb.Append(vc.GetWebImagesXml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("aeeboo"), "", "", "src", "", "", "AeebooVideos", bid, out id)); bid = id; }
                    catch (Exception ex) { sb.Append("<error web=\"aeeboo\">" + ex.Message + "</error>"); }
                    try { sb.Append(vc.GetJoyImageXml(bid, out id)); }
                    catch (Exception ex) { sb.Append("<error web=\"joy\">" + ex.Message + "</error>"); }
                    break;
            }
            sb.Append("</images>");
            if (!System.IO.File.Exists(System.Configuration.ConfigurationSettings.AppSettings["CreateHtmlPath"].ToString() +"images.xml"))
            {
                System.IO.File.Create(System.Configuration.ConfigurationSettings.AppSettings["CreateHtmlPath"].ToString() +"images.xml");
            }
            StreamWriter sw = new StreamWriter(System.Configuration.ConfigurationSettings.AppSettings["CreateHtmlPath"].ToString() +"images.xml");
            sw.Write(sb.ToString());
            sw.Close();
            if (sb.ToString().IndexOf("<error") < 0)
            {
                Response.Write("<br/><br/><br/><center><font size=3 color=blue><b>创建成功！</b></font>&nbsp;&nbsp;<a href='#' onclick=\"window.showModalDialog('../html/images.xml','images','dialogWidth=836px;dialogHeight=500px');\"><font color=green>查看结果</font><a>&nbsp;&nbsp;<a href='Index.aspx'>返回</a></center>");
            }
            else if (sb.ToString().IndexOf("<img") > -1)
            {
                Response.Write("<br/><br/><br/><center><font size=3 color=blue><b>完成创建！</b></font><a href=\"../html/images.xml\" target=\"_blank\"><font size=2 color=#666699><b>个别Xml创建失败！</b></font></a>&nbsp;&nbsp;<a href='#' onclick=\"window.showModalDialog('../Default.aspx','images','dialogWidth=836px;dialogHeight=500px');\"><font color=green>查看结果</font><a>&nbsp;&nbsp;<a href='Index.aspx'>返回</a></center>");
            }
            else
            {
                Response.Write("<br/><br/><br/><center><font size=3 color=red><b>创建失败！</b></font>&nbsp;&nbsp;<a href='Index.aspx'>返回</a></center>");
            }
        }
    }
}
