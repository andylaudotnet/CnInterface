using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System .IO;
using HtmlAgilityPack;
using CnDataAcess.Entity;
using CnBusinessLogic;
using System.Text.RegularExpressions;

namespace CnBusinessLogic
{
    public class VideoHtmlCreate
    {
        public void ParseVideosToHTML(object source, System.Timers.ElapsedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "抓取日志如下：");
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("17173"), "", "", "src","","", "17173Videos"); sb.Append("17173=ok"); }
            catch (Exception ex) { sb.Append("17173=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("56"), "", "alt", "src", "", "", "56Videos"); sb.Append("56=ok"); }
            catch (Exception ex) { sb.Append("56=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("6cn"), "", "alt", "src", "", "", "6cnVideos"); sb.Append("6cn=ok"); }
            catch (Exception ex) { sb.Append("6cn=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("baidu"), "", "", "src", "", "", "BaiduVideos"); sb.Append("baidu=ok"); }
            catch (Exception ex) { sb.Append("baidu=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("cntv"), "", "", "src", "", "", "CntvVideos"); sb.Append("cntv=ok"); }
            catch (Exception ex) { sb.Append("cntv=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("hunantv"), "title", "", "src", "http://tv.hunantv.com/", "", "HunantvVideos"); sb.Append("hunantv=ok"); }
            catch (Exception ex) { sb.Append("hunantv=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("ifeng"), "", "", "src", "", "../img/cninterface.jpg", "IfengVideos"); sb.Append("ifeng=ok"); }
            catch (Exception ex) { sb.Append("ifeng=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("ku6"), "", "", "src", "", "", "Ku6Videos"); sb.Append("ku6=ok"); }
            catch (Exception ex) { sb.Append("ku6=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("news"), "", "", "src", "", "http://www.news.cn/video/", "NewsVideos"); sb.Append("news=ok"); }
            catch (Exception ex) { sb.Append("news=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("openv"), "", "alt", "src", "http://hd.openv.com/", "", "OpenvVideos"); sb.Append("openv=ok"); }
            catch (Exception ex) { sb.Append("openv=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("qq"), "", "", "src", "", "", "QQVideos"); sb.Append("qq=ok"); }
            catch (Exception ex) { sb.Append("qq=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("sina"), "", "alt", "src", "", "", "SinaVideos"); sb.Append("sina=ok"); }
            catch (Exception ex) { sb.Append("sina=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("sohu"), "", "alt", "src", "", "../img/cninterface.jpg", "SohuVideos"); sb.Append("sohu=ok"); }
            catch (Exception ex) { sb.Append("sohu=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("tencent"), "", "alt", "src", "", "", "TencentVideos"); sb.Append("tencent=ok"); }
            catch (Exception ex) { sb.Append("tencent=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("tudou"), "title", "", "src", "", "", "TudouVideos"); sb.Append("tudou=ok"); }
            catch (Exception ex) { sb.Append("tudou=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("xunlei"), "", "alt", "src", "", "", "XunleiVideos"); sb.Append("xunlei=ok"); }
            catch (Exception ex) { sb.Append("xunlei=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("youku"), "", "", "src", "", "", "YoukuVideos"); sb.Append("youku=ok"); }
            catch (Exception ex) { sb.Append("youku=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("pps"), "", "", "src", "", "", "PPSVideos"); sb.Append("pps=ok"); }
            catch (Exception ex) { sb.Append("pps=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("pplive"), "", "alt", "src2", "", "", "PPLiveVideos"); sb.Append("pplive=ok"); }
            catch (Exception ex) { sb.Append("pplive=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("uusee"), "", "", "src", "", "", "UUseeVideos"); sb.Append("uusee=ok"); }
            catch (Exception ex) { sb.Append("uusee=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("m1905"), "", "", "src", "http://www.m1905.com/", "", "M1905Videos"); sb.Append("m1905=ok"); }
            catch (Exception ex) { sb.Append("m1905=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("funshion"), "", "", "src", "", "", "FunshionVideos"); sb.Append("funshion=ok"); }
            catch (Exception ex) { sb.Append("funshion=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("pomoho"), "", "", "src", "", "", "PomohoVideos"); sb.Append("pomoho=ok"); }
            catch (Exception ex) { sb.Append("pomoho=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("letv"), "", "", "src", "", "", "LetvVideos"); sb.Append("letv=ok"); }
            catch (Exception ex) { sb.Append("letv=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("aeeboo"), "", "", "src", "", "", "AeebooVideos"); sb.Append("aeeboo=ok"); }
            catch (Exception ex) { sb.Append("aeeboo=" + ex.Message + ""); }
            try { GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("google"), "", "", "src", "", "", "GoogleVideos"); sb.Append("google=ok"); }
            catch (Exception ex) { sb.Append("google=" + ex.Message + ""); }
            try {GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("joy"), "", "", "src", "", "", "joyVideos"); sb.Append("joy=ok"); }
            catch (Exception ex) { sb.Append("joy=" + ex.Message); }
            
            if (!System.IO.File.Exists(System.Configuration.ConfigurationSettings.AppSettings["CreateHtmlPath"].ToString() + "BuildHTMLLog.txt"))
            {
                System.IO.File.Create(System.Configuration.ConfigurationSettings.AppSettings["CreateHtmlPath"].ToString() + "BuildHTMLLog.txt");
            }
            string logfile = System.Configuration.ConfigurationSettings.AppSettings["CreateHtmlPath"].ToString() + "BuildHTMLLog.txt";
            using (StreamWriter SW = File.AppendText(logfile))
            {
                SW.WriteLine(sb.ToString());
                SW.Close();
            }
        }

        public void GetWebVideoHtml(CnDataAcess.Entity.CnInterfaceVideoXpath cnXpath,string title,string alt,string src,string hrefpath,string srcpath,string htmlname)
        {
            WebClient wc = new WebClient
            {
                Encoding = Encoding.GetEncoding(cnXpath.CnWebEncode)
            };
            string html = wc.DownloadString(cnXpath.CnWebUrl);

            //string html = "";
            //System.IO.StreamReader sr = new System.IO.StreamReader("D:\\CnInterface\\CnWeb\\html\\buildhtml.txt", Encoding.GetEncoding("gb2312"));
            //lock (sr)
            //{
            //    html = sr.ReadToEnd();
            //    sr.Close();
            //}
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            string title001 = "";
            string title002 = "";
            string title003 = "";
            string title004 = "";
            string title005 = "";
            string title006 = "";
            if (!title.Equals("") && alt.Equals(""))
            {
                title001 = doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoTitle001).Attributes["title"].Value;
                title002 = doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoTitle002).Attributes["title"].Value;
                title003 = doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoTitle003).Attributes["title"].Value;
                title004 = doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoTitle004).Attributes["title"].Value;
                title005 = doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoTitle005).Attributes["title"].Value;
                title006 = cnXpath.CnVideoTitle006.Equals("") ? cnXpath.CnVideoTitle006 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoTitle006).Attributes["title"].Value;
            }
            else if (title.Equals("") && !alt.Equals(""))
            {
                title001 = doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoTitle001).Attributes["alt"].Value;
                title002 = doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoTitle002).Attributes["alt"].Value;
                title003 = doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoTitle003).Attributes["alt"].Value;
                title004 = doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoTitle004).Attributes["alt"].Value;
                title005 = doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoTitle005).Attributes["alt"].Value;
                title006 =cnXpath.CnVideoTitle006.Equals("")?cnXpath.CnVideoTitle006:doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoTitle006).Attributes["alt"].Value;
            }
            else
            {
                title001 = doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoTitle001).InnerText;
                title002 = doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoTitle002).InnerText;
                title003 = doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoTitle003).InnerText;
                title004 = doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoTitle004).InnerText;
                title005 = doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoTitle005).InnerText;
                title006 = cnXpath.CnVideoTitle006.Equals("") ? cnXpath.CnVideoTitle006 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoTitle006).InnerText;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"> <html xmlns=\"http://www.w3.org/1999/xhtml\"><head><title>www.CnInterface.com接口天下</title><meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\" /> <meta name=\"keywords\" content=\"接口,接口天下,价值接口,程序接口,网络接口,webservice接口,http接口,ActiveX dll接口,普通dll接口,数据库接口,短信,短信发送,短信在线发送,手机短信,手机短信发送,手机短信在线发送\" /><style type=\"text/css\">a:link {text-decoration:none;color:#666699;}a:visited {text-decoration:none;color:#666699}a:hover {text-decoration:underline; color:#666699; cursor:hand;}a:active {text-decoration:none;color:#666699}</style><link href=\"../css/base.css\" type=\"text/css\" rel=\"Stylesheet\" /></head>");
            sb.Append("<body>");
            sb.Append("<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" >");
            sb.Append("<tr>");
            sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref001.Equals("") ? cnXpath.CnVideoHref001 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref001).Attributes["href"].Value) + "\" target=\"_blank\"><img border=\"0\"  src=\"" + srcpath + (cnXpath.CnVideoSrc001.Equals("")?cnXpath.CnVideoSrc001:doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoSrc001).Attributes[src].Value) + "\" width=\"130px\" height=\"88px\" alt=\"" + title001 + "\"/></a></td>");
            sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref002.Equals("") ? cnXpath.CnVideoHref002 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref002).Attributes["href"].Value) + "\" target=\"_blank\"><img border=\"0\"  src=\"" + srcpath + (cnXpath.CnVideoSrc002.Equals("") ? cnXpath.CnVideoSrc002 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoSrc002).Attributes[src].Value) + "\" width=\"130px\" height=\"88px\" alt=\"" + title002 + "\"/></a></td>");
            sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref003.Equals("") ? cnXpath.CnVideoHref003 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref003).Attributes["href"].Value) + "\" target=\"_blank\"><img border=\"0\"  src=\"" + srcpath + (cnXpath.CnVideoSrc003.Equals("") ? cnXpath.CnVideoSrc003 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoSrc003).Attributes[src].Value) + "\" width=\"130px\" height=\"88px\" alt=\"" + title003 + "\"/></a></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref001.Equals("") ? cnXpath.CnVideoHref001 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref001).Attributes["href"].Value) + "\" target=\"_blank\"><font size='2'  color='#003399'>" + title001 + "</font></a></td>");
            sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref002.Equals("") ? cnXpath.CnVideoHref002 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref002).Attributes["href"].Value) + "\" target=\"_blank\"><font size='2'  color='#003399'>" + title002 + "</font></a></td>");
            sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref003.Equals("") ? cnXpath.CnVideoHref003 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref003).Attributes["href"].Value) + "\" target=\"_blank\"><font size='2'  color='#003399'>" + title003 + "</font></a></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref004.Equals("") ? cnXpath.CnVideoHref004 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref004).Attributes["href"].Value) + "\" target=\"_blank\"><img border=\"0\"  src=\"" + srcpath + (cnXpath.CnVideoSrc004.Equals("") ? cnXpath.CnVideoSrc004 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoSrc004).Attributes[src].Value) + "\" width=\"130px\" height=\"88px\" alt=\"" + title004 + "\"/></a></td>");
            sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref005.Equals("") ? cnXpath.CnVideoHref005 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref005).Attributes["href"].Value) + "\" target=\"_blank\"><img border=\"0\"  src=\"" + srcpath + (cnXpath.CnVideoSrc005.Equals("") ? cnXpath.CnVideoSrc005 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoSrc005).Attributes[src].Value) + "\" width=\"130px\" height=\"88px\" alt=\"" + title005 + "\"/></a></td>");
            if (cnXpath.CnVideoHref006.Equals(""))
            {
                sb.Append("<td>&nbsp;</td>");
            }
            else
            {
                sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref006.Equals("") ? cnXpath.CnVideoHref006 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref006).Attributes["href"].Value) + "\" target=\"_blank\"><img border=\"0\"  src=\"" + srcpath + (cnXpath.CnVideoSrc006.Equals("") ? cnXpath.CnVideoSrc006 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoSrc006).Attributes[src].Value) + "\" width=\"130px\" height=\"88px\" alt=\"" + title006 + "\"/></a></td>");

            }
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref004.Equals("") ? cnXpath.CnVideoHref004 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref004).Attributes["href"].Value) + "\" target=\"_blank\"><font size='2'  color='#003399'>" + title004 + "</font></a></td>");
            sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref005.Equals("") ? cnXpath.CnVideoHref005 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref005).Attributes["href"].Value) + "\" target=\"_blank\"><font size='2'  color='#003399'>" + title005 + "</font></a></td>");
            if (cnXpath.CnVideoHref006.Equals(""))
            {
                sb.Append("<td>&nbsp;</td>");
            }
            else
            {
                sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref006.Equals("") ? cnXpath.CnVideoHref006 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref006).Attributes["href"].Value) + "\" target=\"_blank\"><font size='2'  color='#003399'>" + title006 + "</font></a></td>");
            }
            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("</body></html>");

            if (!System.IO.File.Exists(System.Configuration.ConfigurationSettings.AppSettings["CreateHtmlPath"].ToString() + htmlname + ".html"))
            {
                System.IO.File.Create(System.Configuration.ConfigurationSettings.AppSettings["CreateHtmlPath"].ToString() + htmlname + ".html");
            }
            StreamWriter sw = new StreamWriter(System.Configuration.ConfigurationSettings.AppSettings["CreateHtmlPath"].ToString() + htmlname + ".html");
            sw.Write(sb.ToString());
            sw.Close();
            System.Threading.Thread.Sleep(1000);
        }

        public void GetJoyVideoHtml()
        {
            WebClient wc = new WebClient
            {
                Encoding = Encoding.GetEncoding(936)
            };
            string html = wc.DownloadString("http://www.joy.cn/");
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            html = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[3]/div[1]/script[1]").InnerHtml;

            string name1 = html.Substring(html.IndexOf("Switcher[1]['title']") + 24, html.IndexOf("Switcher[1]['link']") - (html.IndexOf("Switcher[1]['title']") + 24) - 2);
            string href1 = html.Substring(html.IndexOf("Switcher[1]['link']") + 23, html.IndexOf("Switcher[1]['pic']") - (html.IndexOf("Switcher[1]['link']") + 23) - 2);
            string src1 = html.Substring(html.IndexOf("Switcher[1]['pic']") + 22, html.IndexOf("Switcher[1]['icon']") - (html.IndexOf("Switcher[1]['pic']") + 22) - 2);

            string name2 = html.Substring(html.IndexOf("Switcher[2]['title']") + 24, html.IndexOf("Switcher[2]['link']") - (html.IndexOf("Switcher[2]['title']") + 24) - 2);
            string href2 = html.Substring(html.IndexOf("Switcher[2]['link']") + 23, html.IndexOf("Switcher[2]['pic']") - (html.IndexOf("Switcher[2]['link']") + 23) - 2);
            string src2 = html.Substring(html.IndexOf("Switcher[2]['pic']") + 22, html.IndexOf("Switcher[2]['icon']") - (html.IndexOf("Switcher[2]['pic']") + 22) - 2);

            string name3 = html.Substring(html.IndexOf("Switcher[3]['title']") + 24, html.IndexOf("Switcher[3]['link']") - (html.IndexOf("Switcher[3]['title']") + 24) - 2);
            string href3 = html.Substring(html.IndexOf("Switcher[3]['link']") + 23, html.IndexOf("Switcher[3]['pic']") - (html.IndexOf("Switcher[3]['link']") + 23) - 2);
            string src3 = html.Substring(html.IndexOf("Switcher[3]['pic']") + 22, html.IndexOf("Switcher[3]['icon']") - (html.IndexOf("Switcher[3]['pic']") + 22) - 2);

            string name4 = html.Substring(html.IndexOf("Switcher[4]['title']") + 24, html.IndexOf("Switcher[4]['link']") - (html.IndexOf("Switcher[4]['title']") + 24) - 2);
            string href4 = html.Substring(html.IndexOf("Switcher[4]['link']") + 23, html.IndexOf("Switcher[4]['pic']") - (html.IndexOf("Switcher[4]['link']") + 23) - 2);
            string src4 = html.Substring(html.IndexOf("Switcher[4]['pic']") + 22, html.IndexOf("Switcher[4]['icon']") - (html.IndexOf("Switcher[4]['pic']") + 22) - 2);

            string name5 = html.Substring(html.IndexOf("Switcher[5]['title']") + 24, html.IndexOf("Switcher[5]['link']") - (html.IndexOf("Switcher[5]['title']") + 24) - 2);
            string href5 = html.Substring(html.IndexOf("Switcher[5]['link']") + 23, html.IndexOf("Switcher[5]['pic']") - (html.IndexOf("Switcher[5]['link']") + 23) - 2);
            string src5 = html.Substring(html.IndexOf("Switcher[5]['pic']") + 22, html.IndexOf("Switcher[5]['icon']") - (html.IndexOf("Switcher[5]['pic']") + 22) - 2);

            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"> <html xmlns=\"http://www.w3.org/1999/xhtml\"><head><title>www.CnInterface.com接口天下</title><meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\" /> <meta name=\"keywords\" content=\"接口,接口天下,价值接口,程序接口,网络接口,webservice接口,http接口,ActiveX dll接口,普通dll接口,数据库接口,短信,短信发送,短信在线发送,手机短信,手机短信发送,手机短信在线发送\" /><style type=\"text/css\">a:link {text-decoration:none;color:#666699;}a:visited {text-decoration:none;color:#666699}a:hover {text-decoration:underline; color:#666699; cursor:hand;}a:active {text-decoration:none;color:#666699}</style></head>");
            sb.Append("<body>");
            sb.Append("<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" >");
            sb.Append("<tr>");
            sb.Append(" <td><a href=\"" + href1 + "\" target=\"_blank\"><img border=\"0\"  src=\"" + src1 + "\" width=\"130px\" height=\"88px\" alt=\"" + name1 + "\"/></a></td>");
            sb.Append(" <td><a href=\"" + href2 + "\" target=\"_blank\"><img border=\"0\"  src=\"" + src2 + "\" width=\"130px\" height=\"88px\" alt=\"" + name2 + "\"/></a></td>");
            sb.Append(" <td><a href=\"" + href3 + "\" target=\"_blank\"><img border=\"0\"  src=\"" + src3 + "\" width=\"130px\" height=\"88px\" alt=\"" + name3 + "\"/></a></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append(" <td><a href=\"" + href1 + "\" target=\"_blank\"><font size='2'  color='#003399'>" + name1 + "</font></a></td>");
            sb.Append(" <td><a href=\"" + href2 + "\" target=\"_blank\"><font size='2'  color='#003399'>" + name2 + "</font></a></td>");
            sb.Append(" <td><a href=\"" + href3 + "\" target=\"_blank\"><font size='2'  color='#003399'>" + name3 + "</font></a></td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append(" <td><a href=\"" + href4 + "\" target=\"_blank\"><img border=\"0\"  src=\"" + src4 + "\" width=\"130px\" height=\"88px\" alt=\"" + name4 + "\"/></a></td>");
            sb.Append(" <td ><a href=\"" + href5 + "\" target=\"_blank\"><img border=\"0\"  src=\"" + src5 + "\" width=\"130px\" height=\"88px\" alt=\"" + name5 + "\"/></a></td>");
            sb.Append(" <td>&nbsp;</td></tr>");
            sb.Append("<tr>");
            sb.Append(" <td><a href=\"" + href4 + "\" target=\"_blank\"><font size='2'  color='#003399'>" + name4 + "</font></a></td>");
            sb.Append(" <td><a href=\"" + href5 + "\" target=\"_blank\"><font size='2'  color='#003399'>" + name5 + "</font></a></td>");
            sb.Append("<td>&nbsp;</td></tr>");
            sb.Append("</table>");
            sb.Append("</body></html>");

            if (!System.IO.File.Exists(System.Configuration.ConfigurationSettings.AppSettings["CreateHtmlPath"].ToString() + "JoyVideos.html"))
            {
                System.IO.File.Create(System.Configuration.ConfigurationSettings.AppSettings["CreateHtmlPath"].ToString() + "JoyVideos.html");
            }
            StreamWriter sw = new StreamWriter(System.Configuration.ConfigurationSettings.AppSettings["CreateHtmlPath"].ToString() + "JoyVideos.html");
            sw.Write(sb.ToString());
            sw.Close();
            System.Threading.Thread.Sleep(2000);
        }

    }
}
