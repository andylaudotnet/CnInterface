using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using CnDataAcess.Entity;
using CnBusinessLogic;
using System.Text.RegularExpressions;

namespace CnBusinessLogic
{
    public class ImagesXmlCreate
    {
        public string GetWebImagesXml(CnDataAcess.Entity.CnInterfaceVideoXpath cnXpath, string title, string alt, string src, string hrefpath, string srcpath, string htmlname,int bid,out int id)
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
            HtmlToText ht = new HtmlToText();
            title001 = ht.ConvertHtml(title001).Trim();
            title002 = ht.ConvertHtml(title002).Trim();
            title003 = ht.ConvertHtml(title003).Trim();
            title004 = ht.ConvertHtml(title004).Trim();
            title005 = ht.ConvertHtml(title005).Trim();
            title006 = ht.ConvertHtml(title006).Trim();

            string code = htmlname.Replace("Videos", "");
            htmlname = GetWebInfoByCode(code, 0);
            string weburl = GetWebInfoByCode(code, 1);
            StringBuilder sb = new StringBuilder();
           // int id = 0;
            //第一条
            bid++;
            sb.Append("<img id=\"" + bid + "\">");
            sb.Append("<web>" + htmlname + "</web>");
            sb.Append("<title>" + title001 + "</title>");
            sb.Append("<url>" + hrefpath + (cnXpath.CnVideoHref001.Equals("") ? cnXpath.CnVideoHref001 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref001).Attributes["href"].Value).Replace("&", "$") + "</url>");
            sb.Append("<src>" + srcpath + (cnXpath.CnVideoSrc001.Equals("") ? cnXpath.CnVideoSrc001 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoSrc001).Attributes[src].Value).Replace("&", "$") + "</src>");
            sb.Append("<weburl>" + weburl + "</weburl>");
            sb.Append("</img>");
            //第二条
            bid++;
            sb.Append("<img id=\"" + bid + "\">");
            sb.Append("<web>" + htmlname + "</web>");
            sb.Append("<title>" + title002 + "</title>");
            sb.Append("<url>" + hrefpath + (cnXpath.CnVideoHref002.Equals("") ? cnXpath.CnVideoHref002 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref002).Attributes["href"].Value).Replace("&", "$") + "</url>");
            sb.Append("<src>" + srcpath + (cnXpath.CnVideoSrc002.Equals("") ? cnXpath.CnVideoSrc002 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoSrc002).Attributes[src].Value).Replace("&", "$") + "</src>");
            sb.Append("<weburl>" + weburl + "</weburl>");
            sb.Append("</img>");
            //第三条
            bid++;
            sb.Append("<img id=\"" + bid + "\">");
            sb.Append("<web>" + htmlname + "</web>");
            sb.Append("<title>" + title003 + "</title>");
            sb.Append("<url>" + hrefpath + (cnXpath.CnVideoHref003.Equals("") ? cnXpath.CnVideoHref003 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref003).Attributes["href"].Value).Replace("&", "$") + "</url>");
            sb.Append("<src>" + srcpath + (cnXpath.CnVideoSrc003.Equals("") ? cnXpath.CnVideoSrc003 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoSrc003).Attributes[src].Value).Replace("&", "$") + "</src>");
            sb.Append("<weburl>" + weburl + "</weburl>");
            sb.Append("</img>");
            //第四条
            bid++;
            sb.Append("<img id=\"" + bid + "\">");
            sb.Append("<web>" + htmlname + "</web>");
            sb.Append("<title>" + title004 + "</title>");
            sb.Append("<url>" + hrefpath + (cnXpath.CnVideoHref004.Equals("") ? cnXpath.CnVideoHref004 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref004).Attributes["href"].Value).Replace("&", "$") + "</url>");
            sb.Append("<src>" + srcpath + (cnXpath.CnVideoSrc004.Equals("") ? cnXpath.CnVideoSrc004 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoSrc004).Attributes[src].Value).Replace("&", "$") + "</src>");
            sb.Append("<weburl>" + weburl + "</weburl>");
            sb.Append("</img>");
            //第五条
            bid++;
            sb.Append("<img id=\"" + bid + "\">");
            sb.Append("<web>" + htmlname + "</web>");
            sb.Append("<title>" + title005 + "</title>");
            sb.Append("<url>" + hrefpath + (cnXpath.CnVideoHref005.Equals("") ? cnXpath.CnVideoHref005 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref005).Attributes["href"].Value).Replace("&", "$") + "</url>");
            sb.Append("<src>" + srcpath + (cnXpath.CnVideoSrc005.Equals("") ? cnXpath.CnVideoSrc005 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoSrc005).Attributes[src].Value).Replace("&", "$") + "</src>");
            sb.Append("<weburl>" + weburl + "</weburl>");
            sb.Append("</img>");
            //第六条
            if (!cnXpath.CnVideoHref006.Equals(""))
            {
                bid++;
                sb.Append("<img id=\"" + bid + "\">");
                sb.Append("<web>" + htmlname + "</web>");
                sb.Append("<title>" + title006 + "</title>");
                sb.Append("<url>" + hrefpath + (cnXpath.CnVideoHref006.Equals("") ? cnXpath.CnVideoHref006 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoHref006).Attributes["href"].Value).Replace("&", "$") + "</url>");
                sb.Append("<src>" + srcpath + (cnXpath.CnVideoSrc006.Equals("") ? cnXpath.CnVideoSrc006 : doc.DocumentNode.SelectSingleNode(cnXpath.CnVideoSrc006).Attributes[src].Value).Replace("&", "$") + "</src>");
                sb.Append("<weburl>" + weburl + "</weburl>");
                sb.Append("</img>");
            }
            id = bid;

            return sb.ToString();
        }

        public string GetJoyImageXml(int bid, out int id)
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
            // int id = 0;
            //第一条
            bid++;
            sb.Append("<img id=\"" + bid + "\">");
            sb.Append("<web>激动网</web>");
            sb.Append("<title>" + name1 + "</title>");
            sb.Append("<url>" + href1.Replace("&", "$") + "</url>");
            sb.Append("<src>" + src1.Replace("&", "$") + "</src>");
            sb.Append("<weburl>http://www.joy.cn/</weburl>");
            sb.Append("</img>");
            //第二条
            bid++;
            sb.Append("<img id=\"" + bid + "\">");
            sb.Append("<web>激动网</web>");
            sb.Append("<title>" + name2 + "</title>");
            sb.Append("<url>" + href2.Replace("&", "$") + "</url>");
            sb.Append("<src>" + src2.Replace("&", "$") + "</src>");
            sb.Append("<weburl>http://www.joy.cn/</weburl>");
            sb.Append("</img>");
            //第三条
            bid++;
            sb.Append("<img id=\"" + bid + "\">");
            sb.Append("<web>激动网</web>");
            sb.Append("<title>" + name3 + "</title>");
            sb.Append("<url>" + href3.Replace("&", "$") + "</url>");
            sb.Append("<src>" + src3.Replace("&", "$") + "</src>");
            sb.Append("<weburl>http://www.joy.cn/</weburl>");
            sb.Append("</img>");
            //第四条
            bid++;
            sb.Append("<img id=\"" + bid + "\">");
            sb.Append("<web>激动网</web>");
            sb.Append("<title>" + name4 + "</title>");
            sb.Append("<url>" + href4.Replace("&", "$") + "</url>");
            sb.Append("<src>" + src4.Replace("&", "$") + "</src>");
            sb.Append("<weburl>http://www.joy.cn/</weburl>");
            sb.Append("</img>");
            //第五条
            bid++;
            sb.Append("<img id=\"" + bid + "\">");
            sb.Append("<web>激动网</web>");
            sb.Append("<title>" + name5 + "</title>");
            sb.Append("<url>" + href5.Replace("&", "$") + "</url>");
            sb.Append("<src>" + src5.Replace("&", "$") + "</src>");
            sb.Append("<weburl>http://www.joy.cn/</weburl>");
            sb.Append("</img>");

            id = bid;
            return sb.ToString();
        }

        #region 获取网站名称和地址
        private string GetWebInfoByCode(string code,int type)
        {
            string WebName = "";
            string WebUrl = "";
            code=code.ToLower().Trim();
            switch (code)
            {
                case "aeeboo":
                    WebName = "爱播网";
                    WebUrl = "http://www.aeeboo.com/";
                    break;
                case "letv":
                    WebName = "乐视网";
                    WebUrl = "http://www.letv.com/";
                    break;
                case "pomoho":
                    WebName = "爆米花";
                    WebUrl = "http://www.pomoho.com/";
                    break;
                case "google":
                    WebName = "Google视频搜索";
                    WebUrl = "http://video.google.cn/";
                    break;
                case "youku":
                    WebName = "优酷网";
                    WebUrl = "http://www.youku.com/";
                    break;
                case "tudou":
                    WebName = "土豆网";
                    WebUrl = "http://www.tudou.com/";
                    break;
                case "baidu":
                    WebName = "百度视频搜索";
                    WebUrl = "http://video.baidu.com/";
                    break;
                case "xunlei":
                    WebName = "迅雷看看";
                    WebUrl = "http://www.xunlei.com/";
                    break;
                case "joy":
                    WebName = "激动网";
                    WebUrl = "http://www.joy.cn/";
                    break;
                case "sina":
                    WebName = "新浪视频";
                    WebUrl = "http://video.sina.com.cn/";
                    break;
                case "ku6":
                    WebName = "酷6视频";
                    WebUrl = "http://www.ku6.com/";
                    break;
                case "sohu":
                    WebName = "搜狐视频";
                    WebUrl = "http://tv.sohu.com/";
                    break;
                case "qq":
                    WebName = "QQ播客";
                    WebUrl = "http://video.qq.com/";
                    break;
                case "hunantv":
                    WebName = "芒果TV";
                    WebUrl = "http://tv.hunantv.com/";
                    break;
                case "tencent":
                    WebName = "腾讯宽频";
                    WebUrl = "http://bb.news.qq.com/";
                    break;
                case "6cn":
                    WebName = "六间房";
                    WebUrl = "http://6.cn/";
                    break;
                case "ifeng":
                    WebName = "凤凰宽频";
                    WebUrl = "http://v.ifeng.com/";
                    break;
                case "news":
                    WebName = "新华网";
                    WebUrl = "http://www.news.cn/video/index.htm";
                    break;
                case "56":
                    WebName = "56网";
                    WebUrl = "http://www.56.com/";
                    break;
                case "pps":
                    WebName = "PPS";
                    WebUrl = "http://www.pps.tv/";
                    break;
                case "pplive":
                    WebName = "PPLive";
                    WebUrl = "http://www.pptv.com/";
                    break;
                case "funshion":
                    WebName = "风行";
                    WebUrl = "http://www.funshion.com/";
                    break;
                case "uusee":
                    WebName = "UUsee";
                    WebUrl = "http://www.uusee.com/";
                    break;
                case "m1905":
                    WebName = "m1905电影网";
                    WebUrl = "http://www.m1905.com/";
                    break;
                case "openv":
                    WebName = "天线高清";
                    WebUrl = "http://hd.openv.com/";
                    break;
                case "17173":
                    WebName = "17173游戏视频";
                    WebUrl = "http://media.17173.com/";
                    break;
                case "cntv":
                    WebName = "中国网络电视台";
                    WebUrl = "http://www.cntv.cn/";
                    break;
                default:
                    break;
            }
            if (type == 0)
            {
                return WebName;
            }
            else
            {
                return WebUrl;
            }
        }
        #endregion
    }
}
