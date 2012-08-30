using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using HtmlAgilityPack;
using System.Net;
using System.Text.RegularExpressions;

namespace CnWeb.Parse
{
    public partial class WebNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["webname"] != null)
            {
                string responeStr = "";
                switch (Request["webname"].ToString().Trim())
                {
                    case "sina":
                        responeStr = GetSinaNews("http://www.sina.com.cn/");
                        break;
                    case "sohu":
                        responeStr = GetSohuNews("http://www.sohu.com/");
                        break;
                    case "tom":
                        responeStr = GetTomNews("http://www.tom.com/");
                        break;
                    case "yahoo":
                        responeStr = GetYahooNews("http://news.cn.yahoo.com/");
                        break;
                    case "baidu":
                        responeStr = GetBaiduNews("http://news.baidu.com/");
                        break;
                    case "163":
                        responeStr = Get163News("http://www.163.com/");
                        break;
                    default:
                        break;
                }
                Response.Write(responeStr);
                Response.Flush();
                Response.End();
            }
        }

        #region 新浪
        private String GetSinaNews(string url)
        { 
            StringBuilder sb = new StringBuilder();
            try
            {
                WebClient wc = new WebClient
                {
                    Encoding = Encoding.GetEncoding("gb2312")
                };
                string html = wc.DownloadString(url.Trim());

                //string html = "";
                //System.IO.StreamReader sr = new System.IO.StreamReader("D:\\CnInterface\\CnWeb\\html\\sinanews.txt", Encoding.GetEncoding("utf-8"));
                //lock (sr)
                //{
                //    html = sr.ReadToEnd();
                //    sr.Close();
                //}

                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                string newXpath = "/html[1]/body[1]/div[2]/div[4]/div[2]/div[4]/div[1]/div[1]/span[1]/div[1]/ul[1]/li";
                int newscount = doc.DocumentNode.SelectNodes(newXpath).Count;
               
                sb.Append("<b><a href=\"" + url + "\" target=\"_blank\"><font color=green>新浪</font></a>新闻：</b><br/>");
                for (int i = 1; i <= newscount; i++)
                {
                    string aXpath = "/html[1]/body[1]/div[2]/div[4]/div[2]/div[4]/div[1]/div[1]/span[1]/div[1]/ul[1]/li[" + i.ToString() + "]/a";
                    var anodes = doc.DocumentNode.SelectNodes(aXpath);
                    sb.Append("<div style=\"margin-top:6px; margin-bottom: 6px;\">");
                    foreach (var node in anodes)
                    {
                        string newValue = node.InnerText;
                        string urlValue = node.Attributes["href"].Value;
                        if (i == 1)
                        {
                            sb.Append("<a href=\"" + urlValue + "\" target=\"_blank\"><font color=red>" + newValue + "</font></a>&nbsp;&nbsp;");
                        }
                        else
                        {
                            sb.Append("<a href=\"" + urlValue + "\" target=\"_blank\">" + newValue + "</a>&nbsp;&nbsp;");
                        }
                    }
                    sb.Append("</div>");
                }
            }
            catch (Exception ex)
            {
                sb.Append("<font color=#666699>匹配异常:" + ex.Message + "</font>&nbsp;&nbsp;<a href='#' onclick='GetSinaData();'>重新读取</a>");
            }
            return sb.ToString();
        }
#endregion

        #region 搜狐
        private String GetSohuNews(string url)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                WebClient wc = new WebClient
                {
                    Encoding = Encoding.GetEncoding("gb2312")
                };
                string html = wc.DownloadString(url.Trim());

                //string html = "";
                //System.IO.StreamReader sr = new System.IO.StreamReader("D:\\CnInterface\\CnWeb\\html\\sohunews.txt", Encoding.GetEncoding("utf-8"));
                //lock (sr)
                //{
                //    html = sr.ReadToEnd();
                //    sr.Close();
                //}

                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                string newXpath = "/html[1]/body[1]/div[1]/div[10]/div[1]/div[1]/div[1]/div[1]/ul[1]/li";
                int newscount = doc.DocumentNode.SelectNodes(newXpath).Count;

                sb.Append("<b><a href=\"" + url + "\" target=\"_blank\"><font color=green>搜狐</font></a>新闻：</b><br/>");
                for (int i = 1; i <= 16; i++)
                {
                    string aXpath = "/html[1]/body[1]/div[1]/div[10]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[" + i.ToString() + "]/a";
                    var anodes = doc.DocumentNode.SelectNodes(aXpath);
                    sb.Append("<div style=\"margin-top:6px; margin-bottom: 6px;\">");
                    foreach (var node in anodes)
                    {
                        string newValue = node.InnerText;
                        string urlValue = node.Attributes["href"].Value;
                        if (i == 1)
                        {
                            sb.Append("<a href=\"" + urlValue + "\" target=\"_blank\"><font color=red>" + newValue + "</font></a>&nbsp;&nbsp;");
                        }
                        else
                        {
                            sb.Append("<a href=\"" + urlValue + "\" target=\"_blank\">" + newValue + "</a>&nbsp;&nbsp;");
                        }
                    }
                    sb.Append("</div>");
                }
            }
            catch (Exception ex)
            {
                sb.Append("<font color=#666699>匹配异常:" + ex.Message + "</font>&nbsp;&nbsp;<a href='#' onclick='GetSohuData();'>重新读取</a>");
            }
            return sb.ToString();
        }
#endregion

        #region 百度
        private String GetBaiduNews(string url)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                WebClient wc = new WebClient
                {
                    Encoding = Encoding.GetEncoding("gb2312")
                };
                string html = wc.DownloadString(url.Trim());

                //string html = "";
                //System.IO.StreamReader sr = new System.IO.StreamReader("D:\\CnInterface\\CnWeb\\html\\baidunews.txt", Encoding.GetEncoding("utf-8"));
                //lock (sr)
                //{
                //    html = sr.ReadToEnd();
                //    sr.Close();
                //}

                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                string newXpath = "/html[1]/body[1]/div[3]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li";
                int newscount = doc.DocumentNode.SelectNodes(newXpath).Count;

                sb.Append("<b><a href=\"" + url + "\" target=\"_blank\"><font color=green>百度</font></a>新闻：</b><br/>");
                for (int i = 1; i <= newscount; i++)
                {
                    string aXpath = "/html[1]/body[1]/div[3]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[1]/li[" + i.ToString() + "]/a";
                    var anodes = doc.DocumentNode.SelectNodes(aXpath);
                    sb.Append("<div style=\"margin-top:6px; margin-bottom: 6px;\">");
                    foreach (var node in anodes)
                    {
                        string newValue = node.InnerText;
                        string urlValue = node.Attributes["href"].Value;
                        if (i == 1)
                        {
                            sb.Append("<a href=\"" + urlValue + "\" target=\"_blank\"><font color=red>" + newValue + "</font></a>&nbsp;&nbsp;");
                        }
                        else
                        {
                            sb.Append("<a href=\"" + urlValue + "\" target=\"_blank\">" + newValue + "</a>&nbsp;&nbsp;");
                        }
                    }
                    sb.Append("</div>");
                }

                string newXpath2 = "/html[1]/body[1]/div[3]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[2]/li";
                int newscount2 = doc.DocumentNode.SelectNodes(newXpath2).Count;
                for (int i = 1; i <= newscount2; i++)
                {
                    string aXpath2 = "/html[1]/body[1]/div[3]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[2]/li[" + i.ToString() + "]/a[1]";
                    var urlXpath2 = "/html[1]/body[1]/div[3]/div[2]/div[1]/dl[1]/dd[1]/div[1]/ul[2]/li[" + i.ToString() + "]/a[1]/@href[1]";
                    string newValue2 = doc.DocumentNode.SelectSingleNode(aXpath2).InnerText;
                    string urlValue2 = url + doc.DocumentNode.SelectSingleNode(urlXpath2).Attributes["href"].Value;

                    sb.Append("<div style=\"margin-top:6px; margin-bottom: 6px;\">");
                    sb.Append("<a href=\"" + urlValue2 + "\" target=\"_blank\">" + newValue2 + "</a>&nbsp;&nbsp;");
                    sb.Append("</div>");
                }
            }
            catch (Exception ex)
            {
                sb.Append("<font color=#666699>匹配异常:" + ex.Message + "</font>&nbsp;&nbsp;<a href='#' onclick='GetBaiduData();'>重新读取</a>");
            }
            return sb.ToString();
        }
#endregion

        #region 网易
        private String Get163News(string url)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                WebClient wc = new WebClient
                {
                    Encoding = Encoding.GetEncoding("gb2312")
                };
                string html = wc.DownloadString(url.Trim());

                //string html = "";
                //System.IO.StreamReader sr = new System.IO.StreamReader("D:\\CnInterface\\CnWeb\\html\\163news.txt", Encoding.GetEncoding("utf-8"));
                //lock (sr)
                //{
                //    html = sr.ReadToEnd();
                //    sr.Close();
                //}

                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                string newXpath = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[2]/div[1]/div[2]/ul[1]/li";
                int newscount = doc.DocumentNode.SelectNodes(newXpath).Count;

                sb.Append("<b><a href=\"" + url + "\" target=\"_blank\"><font color=green>网易</font></a>新闻：</b><br/>");
                sb.Append("<div style=\"margin-top:6px; margin-bottom: 6px;\">");
                sb.Append("<a href=\"" + doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[4]/div[1]/div[1]/div[2]/div[1]/div[2]/h3[1]/a[1]/@href[1]").Attributes["href"].Value + "\" target=\"_blank\"><font color=red>" + doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[4]/div[1]/div[1]/div[2]/div[1]/div[2]/h3[1]/a[1]").InnerText + "</font></a>");
                sb.Append("</div>");
                for (int i = 1; i <= newscount; i++)
                {
                    string aXpath = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[2]/div[1]/div[2]/ul[1]/li["+i.ToString()+"]/a";
                    var anodes = doc.DocumentNode.SelectNodes(aXpath);
                    sb.Append("<div style=\"margin-top:6px; margin-bottom: 6px;\">");
                    foreach (var node in anodes)
                    {
                        string newValue = node.InnerText;
                        string urlValue = node.Attributes["href"].Value;
                        sb.Append("<a href=\"" + urlValue + "\" target=\"_blank\">" + newValue + "</a>&nbsp;&nbsp;");
                    }
                    sb.Append("</div>");
                }

                string newXpath2 = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[2]/div[1]/div[2]/ul[2]/li";
                int newscount2 = doc.DocumentNode.SelectNodes(newXpath2).Count;
                for (int i = 1; i <= newscount2; i++)
                {
                    string aXpath2 = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[2]/div[1]/div[2]/ul[2]/li["+i.ToString()+"]/a";
                    var anodes2 = doc.DocumentNode.SelectNodes(aXpath2);
                    sb.Append("<div style=\"margin-top:6px; margin-bottom: 6px;\">");
                    foreach (var node in anodes2)
                    {
                        string newValue2 = node.InnerText;
                        string urlValue2 = node.Attributes["href"].Value;
                        sb.Append("<a href=\"" + urlValue2 + "\" target=\"_blank\">" + newValue2 + "</a>&nbsp;&nbsp;");
                    }
                    sb.Append("</div>");
                }

                string newXpath3 = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[2]/div[1]/div[2]/ul[3]/li";
                int newscount3 = doc.DocumentNode.SelectNodes(newXpath3).Count;
                for (int i = 1; i <= 2; i++)
                {
                    string aXpath3 = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[2]/div[1]/div[2]/ul[3]/li[" + i.ToString() + "]/a";
                    var anodes3 = doc.DocumentNode.SelectNodes(aXpath3);
                    sb.Append("<div style=\"margin-top:6px; margin-bottom: 6px;\">");
                    foreach (var node in anodes3)
                    {
                        string newValue3 = node.InnerText;
                        string urlValue3 = node.Attributes["href"].Value;
                        sb.Append("<a href=\"" + urlValue3 + "\" target=\"_blank\">" + newValue3 + "</a>&nbsp;&nbsp;");
                    }
                    sb.Append("</div>");
                }
            }
            catch (Exception ex)
            {
                sb.Append("<font color=#666699>匹配异常:" + ex.Message + "</font>&nbsp;&nbsp;<a href='#' onclick='Get163Data();'>重新读取</a>");
            }
            return sb.ToString();
        }
#endregion

        #region 雅虎
        private String GetYahooNews(string url)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                WebClient wc = new WebClient
                {
                    Encoding = Encoding.GetEncoding("gb2312")
                };
                string html = wc.DownloadString(url.Trim());

                //string html = "";
                //System.IO.StreamReader sr = new System.IO.StreamReader("D:\\CnInterface\\CnWeb\\html\\yahoonews.txt", Encoding.GetEncoding("utf-8"));
                //lock (sr)
                //{
                //    html = sr.ReadToEnd();
                //    sr.Close();
                //}

                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                string newXpath = "/html/body/div[2]/div[2]/h4";
                int newscount = doc.DocumentNode.SelectNodes(newXpath).Count;

                sb.Append("<b><a href=\"" + url + "\" target=\"_blank\"><font color=green>雅虎</font></a>新闻：</b><br/>");
                sb.Append("<div style=\"margin-top:6px; margin-bottom: 6px;\">");
                sb.Append("<a href=\"" + doc.DocumentNode.SelectSingleNode("/html/body/div[2]/div[2]/h4/a[1]/@href[1]").Attributes["href"].Value + "\" target=\"_blank\"><font color=red>" + doc.DocumentNode.SelectSingleNode("/html/body/div[2]/div[2]/h4/a[1]").InnerText + "</font></a>&nbsp;&nbsp;");
                sb.Append("</div>");
                for (int i = 1; i <= newscount; i++)
                {
                    string aXpath1 = "/html/body/div[2]/div[2]/h4[" + i.ToString() + "]/a[1]";
                    string urlXpath1 = "/html/body/div[2]/div[2]/h4[" + i.ToString() + "]/a[1]/@href[1]";
                    if (i == 1)
                    {
                        try
                        {
                            aXpath1 = "/html/body/div[2]/div[2]/h4[" + i.ToString() + "]/a[2]";
                            urlXpath1 = "/html/body/div[2]/div[2]/h4[" + i.ToString() + "]/a[2]/@href[1]";
                        }
                        catch { }
                    }
                    string newValue1 = doc.DocumentNode.SelectSingleNode(aXpath1).InnerText;
                    string urlValue1 = doc.DocumentNode.SelectSingleNode(urlXpath1).Attributes["href"].Value;
                    sb.Append("<div style=\"margin-top:6px; margin-bottom: 6px;\">");
                    sb.Append("<a href=\"" + urlValue1 + "\" target=\"_blank\">" + newValue1 + "</a>");
                    sb.Append("</div>");
                }
            }
            catch (Exception ex)
            {
                sb.Append("<font color=#666699>匹配异常:" + ex.Message + "</font>&nbsp;&nbsp;<a href='#' onclick='GetYahooData();'>重新读取</a>");
            }
            return sb.ToString();
        }
#endregion

        #region Tom
        private String GetTomNews(string url)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                WebClient wc = new WebClient
                {
                    Encoding = Encoding.GetEncoding("utf-8")
                };
                string html = wc.DownloadString(url.Trim());

                //string html = "";
                //System.IO.StreamReader sr = new System.IO.StreamReader("D:\\CnInterface\\CnWeb\\html\\tomnews.txt", Encoding.GetEncoding("utf-8"));
                //lock (sr)
                //{
                //    html = sr.ReadToEnd();
                //    sr.Close();
                //}

                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                string newXpath = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[3]/ul[1]/li";
                int newscount = doc.DocumentNode.SelectNodes(newXpath).Count;

                sb.Append("<b><a href=\"" + url + "\" target=\"_blank\"><font color=green>TOM</font></a>新闻：</b><br/>");
                sb.Append("<div style=\"margin-top:6px; margin-bottom: 6px;\">");
                sb.Append("<a href=\"" + doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[4]/div[1]/div[1]/div[3]/h2[1]/a[1]/@href[1]").Attributes["href"].Value + "\" target=\"_blank\"><font color=red>" + doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[4]/div[1]/div[1]/div[3]/h2[1]/a[1]").InnerText + "</font></a>&nbsp;&nbsp;");
                sb.Append("</div>");
                for (int i = 1; i <= newscount; i++)
                {
                    string aXpath = "/html[1]/body[1]/div[4]/div[1]/div[1]/div[3]/ul[1]/li[" + i.ToString() + "]/a";
                    var anodes = doc.DocumentNode.SelectNodes(aXpath);
                    sb.Append("<div style=\"margin-top:6px; margin-bottom: 6px;\">");
                    foreach (var node in anodes)
                    {
                        string newValue = node.InnerText;
                        string urlValue = node.Attributes["href"].Value;
                        sb.Append("<a href=\"" + urlValue + "\" target=\"_blank\">" + newValue + "</a>&nbsp;&nbsp;");
                    }
                    sb.Append("</div>");
                }
            }
            catch (Exception ex)
            {
                sb.Append("<b><a href=\"http://www.tom.com/\" target=\"_blank\"><font color=green>TOM</font></a>新闻：</b><br/><font color=#666699>匹配异常:" + ex.Message + "</font>&nbsp;&nbsp;<a href='#' onclick='GetTomData();'>重新读取</a>");
            }
            return sb.ToString();
        }
        #endregion
    }
}
