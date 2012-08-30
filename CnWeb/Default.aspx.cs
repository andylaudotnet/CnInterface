using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using CnDataAcess.Entity;
using CnBusinessLogic;
using System.Text.RegularExpressions;
using System.Xml;

namespace CnWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected string TagCloudCode = "";
        protected string PicGoingOk = "";
        protected string PicGoingError = "";
        protected string ImagesIndexsStr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ResponseIndexData"] != null)
            {
                Response.Write(GetImagesIndexData(Convert.ToInt32(Request["ResponseIndexData"])));
                Response.Flush();
                Response.End();
            }
            if(!IsPostBack)
            {
                //标签云参数初始化
                GetTagCloudCode();

                //滚动图片内容初始化
                try
                {
                    PicGoingOk = GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("56"), "", "alt", "src", "", "");
                    PicGoingError = "";
                }
                catch (Exception ex)
                {
                    PicGoingOk = "";
                    PicGoingError = ex.Message;
                }
            }
        }
        private string GetImagesIndexData(int pageindex)
        {
            string imgxml = "";
            System.IO.StreamReader sr = new System.IO.StreamReader(Server.MapPath("html/images.xml"), Encoding.UTF8);
            lock (sr)
            {
                imgxml = sr.ReadToEnd();
                sr.Close();
            }
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(imgxml);
            XmlNodeList xmlNodes = xd.SelectNodes("images/img");

            int begin = pageindex * 6;
            int end = begin + 6;
            if (end > xmlNodes.Count)
            {
                end = xmlNodes.Count;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" ?> ");
            sb.Append("<images>");
            XmlNode xmlNode;
            for (int i = begin; i < end; i++)
            {
                xmlNode = xmlNodes[i];
                sb.Append("<img id=\"" + xmlNode.Attributes["id"].Value.Trim() + "\">");
                sb.Append("<web>" + xmlNode.ChildNodes.Item(0).InnerText.Trim() + "</web>");
                sb.Append("<title>" + GetLenStr(xmlNode.ChildNodes.Item(1).InnerText.Trim(), 38) + "</title>");
                sb.Append("<url>" + xmlNode.ChildNodes.Item(2).InnerText.Trim() + "</url>");
                sb.Append("<src>" + xmlNode.ChildNodes.Item(3).InnerText.Trim() + "</src>");
                sb.Append("<weburl>" + xmlNode.ChildNodes.Item(4).InnerText.Trim() + "</weburl>");
                sb.Append("</img>");
            }
            sb.Append("<imgcount>" + xmlNodes.Count + "</imgcount>");
            sb.Append("</images>");

            return sb.ToString();
        }
        public string GetLenStr(string s, int len)
        {
            StringBuilder sb = new StringBuilder();
            int num = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char tt = s[i];
                if (IsChinese(tt.ToString()))
                {
                    num = num + 2;
                }
                else
                {
                    num = num + 1;
                }
                if (num > len)
                {
                    break;
                }
                sb.Append(tt.ToString());
            }
            return sb.ToString();
        }
        public string GetWebVideoHtml(CnDataAcess.Entity.CnInterfaceVideoXpath cnXpath, string title, string alt, string src, string hrefpath, string srcpath)
        {
            WebClient wc = new WebClient
            {
                Encoding = Encoding.GetEncoding(cnXpath.CnWebEncode)
            };
            string html = wc.DownloadString(cnXpath.CnWebUrl);

            //string html = "";
            //System.IO.StreamReader sr = new System.IO.StreamReader(System.Configuration.ConfigurationSettings.AppSettings["CreateHtmlPath"].ToString()+ "buildhtml.txt", Encoding.GetEncoding("gb2312"));
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
                title006 = cnXpath.CnVideoTitle006.Equals("") ? cnXpath.CnVideoTitle006 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoTitle006).Attributes["alt"].Value;
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
            sb.Append("<table border=\"0\" cellpadding =\"2\" cellspacing =\"4\"   width=\"100%\" >");
            sb.Append("<tr align=\"center\">");
            sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref001.Equals("") ? cnXpath.CnVideoHref001 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref001).Attributes["href"].Value) + "\" target=\"_blank\"><img border=\"0\"  src=\"" + srcpath + (cnXpath.CnVideoSrc001.Equals("") ? cnXpath.CnVideoSrc001 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoSrc001).Attributes[src].Value) + "\" width=\"130px\" height=\"88px\" alt=\"" + title001 + "\"/></a></td>");
            sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref002.Equals("") ? cnXpath.CnVideoHref002 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref002).Attributes["href"].Value) + "\" target=\"_blank\"><img border=\"0\"  src=\"" + srcpath + (cnXpath.CnVideoSrc002.Equals("") ? cnXpath.CnVideoSrc002 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoSrc002).Attributes[src].Value) + "\" width=\"130px\" height=\"88px\" alt=\"" + title002 + "\"/></a></td>");
            sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref003.Equals("") ? cnXpath.CnVideoHref003 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref003).Attributes["href"].Value) + "\" target=\"_blank\"><img border=\"0\"  src=\"" + srcpath + (cnXpath.CnVideoSrc003.Equals("") ? cnXpath.CnVideoSrc003 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoSrc003).Attributes[src].Value) + "\" width=\"130px\" height=\"88px\" alt=\"" + title003 + "\"/></a></td>");
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
            sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref001.Equals("") ? cnXpath.CnVideoHref001 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref001).Attributes["href"].Value) + "\" target=\"_blank\"  title=\""+title001+"\"><font size='2'  color='#003399'>" + getStr(title001,20) + "</font></a></td>");
            sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref002.Equals("") ? cnXpath.CnVideoHref002 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref002).Attributes["href"].Value) + "\" target=\"_blank\"  title=\"" + title002 + "\"><font size='2'  color='#003399'>" + getStr(title002,20) + "</font></a></td>");
            sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref003.Equals("") ? cnXpath.CnVideoHref003 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref003).Attributes["href"].Value) + "\" target=\"_blank\"  title=\"" + title003 + "\"><font size='2'  color='#003399'>" + getStr(title003, 20) + "</font></a></td>");
            sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref004.Equals("") ? cnXpath.CnVideoHref004 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref004).Attributes["href"].Value) + "\" target=\"_blank\"  title=\"" + title004 + "\"><font size='2'  color='#003399'>" + getStr(title004, 20) + "</font></a></td>");
            sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref005.Equals("") ? cnXpath.CnVideoHref005 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref005).Attributes["href"].Value) + "\" target=\"_blank\"  title=\"" + title005 + "\"><font size='2'  color='#003399'>" + getStr(title005, 20) + "</font></a></td>");
            if (cnXpath.CnVideoHref006.Equals(""))
            {
                sb.Append("<td>&nbsp;</td>");
            }
            else
            {
                sb.Append(" <td><a href=\"" + hrefpath + (cnXpath.CnVideoHref006.Equals("") ? cnXpath.CnVideoHref006 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref006).Attributes["href"].Value) + "\" target=\"_blank\"  title=\"" + title006 + "\"><font size='2'  color='#003399'>" + getStr(title006, 20) + "</font></a></td>");
            }
            sb.Append("</tr>");
            sb.Append("</table>");

            return sb.ToString();
        }

        public  string getStr(string s,int len)
        {
            StringBuilder sb = new StringBuilder();
            int num = 0;
            for (int i =0 ; i <s.Length; i++)
            {
                char tt= s[i];
                if (IsChinese(tt.ToString()))
                {
                    num = num + 2;
                }
                else
                {
                    num = num + 1;
                }
                if (num > len)
                {
                    break;
                }
                sb.Append(tt.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// 验证是否英文和数字
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private bool IsEnglish(string source)
        {
            return Regex.IsMatch(source, @"^[A-Za-z0-9]+$", RegexOptions.IgnoreCase);
        }
        /// <summary>
        /// 验证是否中文
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private  bool IsChinese(string source)
        {
            return Regex.IsMatch(source, @"^[\u4e00-\u9fa5]+$", RegexOptions.IgnoreCase);
        }


        private void GetTagCloudCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<tags>");
            sb.Append("<a href='http://www.cninterface.com/html/YoukuVideos.html' style='font-size: 12pt;'>优酷网</a>");
            sb.Append("<a href='http://www.cninterface.com/html/TudouVideos.html' style='font-size: 12pt;'>土豆网</a>");
            sb.Append("<a href='http://www.cninterface.com/html/BaiduVideos.html' style='font-size: 12pt;'>百度视频搜索</a>");
            sb.Append("<a href='http://www.cninterface.com/html/XunleiVideos.html' style='font-size: 12pt;'>迅雷看看</a>");
            sb.Append("<a href='http://www.cninterface.com/html/OpenvVideos.html' style='font-size: 12pt;'>天线高清</a>");
            sb.Append("<a href='http://www.cninterface.com/html/SinaVideos.html' style='font-size: 12pt;'>新浪播客</a>");
            sb.Append("<a href='http://www.cninterface.com/html/Ku6Videos.html' style='font-size: 12pt;'>酷6网</a>");
            sb.Append("<a href='http://www.cninterface.com/html/SohuVideos.html' style='font-size: 12pt;'>搜狐视频</a>");
            sb.Append("<a href='http://www.cninterface.com/html/QQVideos.html' style='font-size: 12pt;'>QQ播客</a>");
            sb.Append("<a href='http://www.cninterface.com/html/JoyVideos.html' style='font-size: 12pt;'>激动网</a>");
            sb.Append("<a href='http://www.cninterface.com/html/TencentVideos.html' style='font-size: 12pt;'>腾讯视频</a>");
            sb.Append("<a href='http://www.cninterface.com/html/6cnVideos.html' style='font-size: 12pt;'>六间房</a>");
            sb.Append("<a href='http://www.cninterface.com/html/IfengVideos.html' style='font-size: 12pt;'>凤凰宽频</a>");
            sb.Append("<a href='http://www.cninterface.com/html/NewsVideos.html' style='font-size: 12pt;'>新华视频</a>");
            sb.Append("<a href='http://www.cninterface.com/html/56Videos.html' style='font-size: 12pt;'>56网</a>");
            sb.Append("<a href='http://www.cninterface.com/html/HunantvVideos.html' style='font-size: 12pt;'>芒果tv</a>");
            sb.Append("<a href='http://www.cninterface.com/html/17173Videos.html' style='font-size: 12pt;'>17173游戏视频</a>");
            sb.Append("<a href='http://www.cninterface.com/html/CntvVideos.html' style='font-size: 12pt;'>中国网络电视台</a>");
            sb.Append("<a href='http://www.qiyi.com/' style='font-size: 12pt;'>奇艺</a>");
            sb.Append("<a href='http://www.umiwi.com/' style='font-size: 12pt;'>优米网</a>");
            sb.Append("<a href='http://www.cninterface.com/html/LetvVideos.html' style='font-size: 12pt;'>乐视网</a>");
            sb.Append("<a href='http://www.cninterface.com/html/PPSVideos.html' style='font-size: 12pt;'>PPS</a>");
            sb.Append("<a href='http://www.cninterface.com/html/PPLiveVideos.html' style='font-size: 12pt;'>PPLive</a>");
            sb.Append("<a href='http://www.cninterface.com/html/FunshionVideos.html' style='font-size: 12pt;'>风行</a>");
            sb.Append("<a href='http://www.cninterface.com/html/UUseeVideos.html' style='font-size: 12pt;'>UUsee</a>");
            sb.Append("</tags>");
            TagCloudCode = Server.UrlEncode(sb.ToString());
        }
    }
}
