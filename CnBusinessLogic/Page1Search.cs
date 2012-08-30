using System;
using System .Web;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using System.Net;
using System.Text.RegularExpressions;

namespace CnBusinessLogic
{
    public class Page1Search
    {
        #region 获取百度查询结果
        /// <summary>
        /// 获取百度查询结果
        /// </summary>
        /// <param name="html">网络地址</param>
        /// <returns>百度查询结果</returns>
        public  string GetSearchResultFromBaidu(string searchword)
        {
            StringBuilder sb = new StringBuilder();
            string url = "http://www.baidu.com/s?wd=" + searchword;
            try
            {
                WebClient wc = new WebClient
                {
                    Encoding = Encoding.GetEncoding("gb2312")
                };
                string html = wc.DownloadString(url.Trim());

                //string html = "";
                //System.IO.StreamReader sr = new System.IO.StreamReader("D:\\CnInterface\\CnWeb\\html\\baiducode.txt", Encoding.GetEncoding("gb2312"));
                //lock (sr)
                //{
                //    html = sr.ReadToEnd();
                //    sr.Close();
                //}

                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                
                //sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px;width:678px\"><a href=\"" + url + "\" target=\"_blank\">百度</a><span id='spanbaidu' onclick='if(document.getElementById(\"divbaidu\").style.display == \"none\"){document.getElementById(\"divbaidu\").style.display = \"block\";document.getElementById(\"spanbaidu\").innerHTML =\"<font color=#666699><b>第一页数据</b></font>&nbsp;<font  color=red>收起</font>\";}else{document.getElementById(\"divbaidu\").style.display = \"none\";document.getElementById(\"spanbaidu\").innerHTML =\"<font color=#666699><b>第一页数据</b></font>&nbsp;<font  color=green>展开</font>\";}' style=\"cursor:hand\"><font color='#666699'><b>第一页数据</b></font>&nbsp;<font  color=red>收起</font></span>");
                //sb.Append(" <div id='divbaidu' style='display:none;'>");
                for (int i = 4; i <= 13; i++)
                {
                    string nameXpath = "/html[1]/body[1]/table[" + i.ToString() + "]/tr[1]/td[1]/a[1]";
                    string urlXpath = "/html[1]/body[1]/table[" + i.ToString() + "]/tr[1]/td[1]/a[1]/@href[1]";
                    string bodyXpath = "/html[1]/body[1]/table[" + i.ToString() + "]/tr[1]/td[1]/font[1]";
                    string timeXpath = "/html[1]/body[1]/table[" + i.ToString() + "]/tr[1]/td[1]/font[1]/font[2]";

                    string nameValue = "";
                    try
                    {
                        nameValue = doc.DocumentNode.SelectSingleNode(nameXpath).InnerHtml;
                        nameValue = new HtmlToText().ConvertHtml(nameValue).Trim();
                    }
                    catch
                    {
                        try
                        {
                            nameValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/table[" + i.ToString() + "]/tr[1]/td[1]/font[1]/a[1]").InnerHtml;
                            nameValue = new HtmlToText().ConvertHtml(nameValue).Trim();
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    string urlValue = "";
                    try
                    {
                        urlValue = doc.DocumentNode.SelectSingleNode(urlXpath).Attributes["href"].Value;
                    }
                    catch
                    {
                        try
                        {
                            urlValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/table[" + i.ToString() + "]/tr[1]/td[1]/font[1]/a[1]/@href[1]").Attributes["href"].Value;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    string bodyValue = "";
                    try
                    {
                        bodyValue = doc.DocumentNode.SelectSingleNode(bodyXpath).InnerHtml;
                        bodyValue = new HtmlToText().ConvertHtml(bodyValue).Trim();
                        if (bodyValue.Length < 20)
                        {
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        try
                        {
                            bodyValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/table[" + i.ToString() + "]/tr[2]/td[1]/p[1]").InnerHtml;
                        }
                        catch
                        {
                            bodyValue = "";
                        }
                    }
                    string timeValue = "";
                    try
                    {
                        timeValue = doc.DocumentNode.SelectSingleNode(timeXpath).InnerHtml;
                        timeValue = timeValue.Substring(timeValue.LastIndexOf("20"));
                    }
                    catch
                    {
                        try
                        {
                            timeValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/table[" + i.ToString() + "]/tr[1]/td[1]/font[1]/font[1]").InnerHtml;
                            timeValue = timeValue.Substring(timeValue.LastIndexOf("20"));
                        }
                        catch
                        {
                            timeValue = DateTime.Now.ToString("yyyy-MM-dd");
                        }
                    }
                    try
                    {
                        DateTime dt = Convert.ToDateTime(timeValue);
                    }
                    catch
                    {
                        timeValue = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                    sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px;\">");
                    sb.Append(" <div>");
                    sb.Append(" <a target=\"_blank\"  href=\"" + urlValue + "\"><font color=blue>" + nameValue.Replace(System.Web.HttpUtility.UrlDecode(searchword, Encoding.GetEncoding("gb2312")), "<font color=red>" + System.Web.HttpUtility.UrlDecode(searchword, Encoding.GetEncoding("gb2312")) + "</font>") + "</font></a>");
                    sb.Append(" </div>");
                    sb.Append(" <div style=\"font-size: 13px;\">");
                    sb.Append(" <font size=2 >" + bodyValue.Replace(System.Web.HttpUtility.UrlDecode(searchword, Encoding.GetEncoding("gb2312")), "<font color=red>" + System.Web.HttpUtility.UrlDecode(searchword, Encoding.GetEncoding("gb2312")) + "</font>") + "</font>");
                    sb.Append(" </div>");
                    sb.Append(" <div>");
                    sb.Append(" <font color=#006600>" + (urlValue.Length > 66 ? urlValue.Substring(0, 66)+"..." : urlValue) + "</font>&nbsp;&nbsp;<font size=2 color=#006600>" + timeValue + "</font>&nbsp;&nbsp;<a target=\"_blank\" href=\"" + url + "\"><font size=2  color=#666699>百度搜索</font></a>");
                    sb.Append("  </div>");
                    sb.Append(" </div>");
                    System.Threading.Thread.Sleep(200);
                }
                //sb.Append("  </div>");
                //sb.Append(" </div>");
            }
            catch (Exception ex)
            {
                sb.Append(ex.Message+"&nbsp;<a href=\""+url+"\" target=\"_blank\"><font color=blue>此处查看</font></a>");
            }
            if (sb.ToString().Trim().Equals(""))
                sb.Append("该网站相关Xpath出现改动，请根据改动及时修正匹配Xpath。" + "&nbsp;<a href=\"" + url + "\" target=\"_blank\"><font color=blue>此处查看</font></a>");
            return sb.ToString();
        }
        #endregion

        #region 获取Google查询结果
        /// <summary>
        /// 获取Google查询结果
        /// </summary>
        /// <param name="html">网络地址</param>
        /// <returns>Google查询结果</returns>
        public string GetSearchResultFromGoogle(string searchword)
        {
            StringBuilder sb = new StringBuilder();
            string url = "http://www.google.com.hk/search?hl=zh-CN&source=hp&q=" + searchword + "&meta=&aq=f&aqi=g10&aql=&oq=&gs_rfai=";
            try
            {
                WebClient wc = new WebClient
                {
                    Encoding = Encoding.GetEncoding("gb2312")
                };
                string html = wc.DownloadString(url.Trim());

                //string html = "";
                //System.IO.StreamReader sr = new System.IO.StreamReader("D:\\CnInterface\\CnWeb\\html\\googlecode.txt", Encoding.GetEncoding("utf-8"));
                //lock (sr)
                //{
                //    html = sr.ReadToEnd();
                //    sr.Close();
                //}

                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                string nameValue = "";
                string urlValue = "";
                string bodyValue = "";
                string timeValue = DateTime.Now.ToString("yyyy-MM-dd");

                //sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px;width:678px\"><a href=\"" + url + "\" target=\"_blank\">谷歌</a><span id='spangoogle' onclick='if(document.getElementById(\"divgoogle\").style.display == \"none\"){document.getElementById(\"divgoogle\").style.display = \"block\";document.getElementById(\"spangoogle\").innerHTML =\"<font color=#666699><b>第一页数据</b></font>&nbsp;<font  color=red>收起</font>\";}else{document.getElementById(\"divgoogle\").style.display = \"none\";document.getElementById(\"spangoogle\").innerHTML =\"<font color=#666699><b>第一页数据</b></font>&nbsp;<font  color=green>展开</font>\";}' style=\"cursor:hand\"><font color='#666699'><b>第一页数据</b></font>&nbsp;<font  color=green>展开</font></span>");
                //sb.Append(" <div id='divgoogle' style='display:none;'>");
                string listr = "/li[1]";
                for (int i = 0; i <= 10; i++)
                {
                    try
                    {
                        string nameXpath = "/body[1]/div[5]/div[3]/div[1]/ol[1]" + listr + "/h3[1]/a[1]";
                        string urlXpath = "/body[1]/div[5]/div[3]/div[1]/ol[1]" + listr + "/h3[1]/a[1]/@href[1]";
                        string bodyXpath = "/body[1]/div[5]/div[3]/div[1]/ol[1]" + listr + "/div[1]";

                        try
                        {
                            nameValue = doc.DocumentNode.SelectSingleNode(nameXpath).InnerText;
                        }
                        catch
                        {
                            nameValue = doc.DocumentNode.SelectSingleNode("/body[1]/div[5]/div[4]/div[1]/ol[1]" + listr + "/h3[1]/a[1]").InnerText;
                        }

                        try
                        {
                            urlValue = doc.DocumentNode.SelectSingleNode(urlXpath).Attributes["href"].Value;
                        }
                        catch
                        {
                            urlValue = doc.DocumentNode.SelectSingleNode("/body[1]/div[5]/div[4]/div[1]/ol[1]" + listr + "/h3[1]/a[1]/@href[1]").Attributes["href"].Value;
                        }
                        try
                        {
                            bodyValue = doc.DocumentNode.SelectSingleNode(bodyXpath).InnerHtml;
                            bodyValue = new HtmlToText().ConvertHtml(bodyValue).Trim();
                        }
                        catch
                        {
                            try
                            {
                                bodyValue = doc.DocumentNode.SelectSingleNode("/body[1]/div[5]/div[3]/div[1]/ol[1]"+ listr +"/table[1]").InnerHtml;
                            }
                            catch
                            {
                                try
                                {                                                                                 
                                    bodyValue = doc.DocumentNode.SelectSingleNode("/body[1]/div[5]/div[4]/div[1]/ol[1]" + listr + "/div[1]").InnerHtml;
                                }
                                catch
                                {
                                    bodyValue = "";
                                }
                            }
                        }

                        sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px;\">");
                        sb.Append(" <div>");
                        sb.Append(" <a target=\"_blank\"  href=\"" + urlValue + "\"><font color=blue>" + nameValue.Replace(System.Web.HttpUtility.UrlDecode(searchword, Encoding.UTF8), "<font color=red>" + System.Web.HttpUtility.UrlDecode(searchword, Encoding.UTF8) + "</font>") + "</font></a>");
                        sb.Append(" </div>");
                        sb.Append(" <div style=\"font-size: 13px;\">");
                        sb.Append(" <font size=2 >" + bodyValue.Replace(System.Web.HttpUtility.UrlDecode(searchword, Encoding.UTF8), "<font color=red>" + System.Web.HttpUtility.UrlDecode(searchword, Encoding.UTF8) + "</font>") + "</font>");
                        sb.Append(" </div>");
                        sb.Append(" <div>");
                        sb.Append(" <font color=#006600>" + (urlValue.Length > 66 ? urlValue.Substring(0, 66)+"..." : urlValue) + "</font>&nbsp;&nbsp;<font size=2 color=#006600>" + timeValue + "</font>&nbsp;&nbsp;<a target=\"_blank\" href=\"" + url + "\"><font size=2  color=#666699>Google搜索</font></a>");
                        sb.Append("  </div>");
                        sb.Append(" </div>");
                    }
                    catch
                    {
                        listr += "/li[1]";
                        continue;
                    }

                    listr += "/li[1]";

                    System.Threading.Thread.Sleep(200);
                }
                //sb.Append("  </div>");
                //sb.Append(" </div>");
            }
            catch (Exception ex)
            {
                sb.Append(ex.Message + "&nbsp;<a href=\"" + url + "\" target=\"_blank\"><font color=blue>此处查看</font></a>");
            }
            if (sb.ToString().Trim().Equals(""))
                sb.Append("该网站相关Xpath出现改动，请根据改动及时修正匹配Xpath。" + "&nbsp;<a href=\"" + url + "\" target=\"_blank\"><font color=blue>此处查看</font></a>");
            return sb.ToString();
        }
        #endregion

        #region 获取Yahoo查询结果
        /// <summary>
        /// 获取Yahoo查询结果
        /// </summary>
        /// <param name="html">网络地址</param>
        /// <returns>Yahoo查询结果</returns>
        public string GetSearchResultFromYahoo(string searchword)
        {
            StringBuilder sb = new StringBuilder(); 
            string url = "http://one.cn.yahoo.com/s?p=" + searchword + "&pid=hp&v=web";
            try
            {
                WebClient wc = new WebClient
                {
                    Encoding = Encoding.GetEncoding("utf-8")
                };
                string html = wc.DownloadString(url.Trim());

                //string html = "";
                //System.IO.StreamReader sr = new System.IO.StreamReader("D:\\CnInterface\\CnWeb\\html\\yahoocode.txt", Encoding.GetEncoding("utf-8"));
                //lock (sr)
                //{
                //    html = sr.ReadToEnd();
                //    sr.Close();
                //}

                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                string nameValue = "";
                string urlValue = "";
                string bodyValue = "";
                string timeValue = "";

                //sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px;width:678px\"><a href=\"" + url + "\" target=\"_blank\">雅虎</a><span id='spanyahoo' onclick='if(document.getElementById(\"divyahoo\").style.display == \"none\"){document.getElementById(\"divyahoo\").style.display = \"block\";document.getElementById(\"spanyahoo\").innerHTML =\"<font color=#666699><b>第一页数据</b></font>&nbsp;<font  color=red>收起</font>\";}else{document.getElementById(\"divyahoo\").style.display = \"none\";document.getElementById(\"spanyahoo\").innerHTML =\"<font color=#666699><b>第一页数据</b></font>&nbsp;<font  color=green>展开</font>\";}' style=\"cursor:hand\"><font color='#666699'><b>第一页数据</b></font>&nbsp;<font  color=green>展开</font></span>");
                //sb.Append(" <div id='divyahoo' style='display:none;'>");
                string divid = "1";
                for (int i = 1; i <= 10; i++)
                {
                    try
                    {
                        string nameXpath = "/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[" + i.ToString() + "]/h3[1]/a[1]";
                        string urlXpath = "/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[" + i.ToString() + "]/h3[1]/a[1]/@href[1]";
                        string bodyXpath = "/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[" + i.ToString() + "]/p[1]";
                        string timeXpath = "/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[" + i.ToString() + "]/em[1]/span[1]";

                        try
                        {
                            nameValue = doc.DocumentNode.SelectSingleNode(nameXpath).InnerText;
                        }
                        catch
                        {
                            try
                            {
                                nameValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[" + i.ToString() + "]/div[1]/h3[1]/a[1]").InnerText;
                            }
                            catch
                            {
                                try
                                {
                                    nameValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/ul[1]/li[" + i.ToString() + "]/h3[1]/a[1]").InnerText;
                                }
                                catch
                                {
                                    nameValue = doc.DocumentNode.SelectSingleNode(" /html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[3]/ul[1]/li[" + i.ToString() + "]/h3[1]/a[1]").InnerText;
                                }
                            }
                        }
                        try
                        {
                            urlValue = doc.DocumentNode.SelectSingleNode(urlXpath).Attributes["href"].Value;
                        }
                        catch
                        {
                            try
                            {
                                urlValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[" + i.ToString() + "]/div[1]/h3[1]/a[1]/@href[1]").Attributes["href"].Value;
                            }
                            catch
                            {
                                try
                                {
                                    urlValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/ul[1]/li[" + i.ToString() + "]/h3[1]/a[1]/@href[1]").Attributes["href"].Value;
                                }
                                catch
                                {
                                    urlValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[3]/ul[1]/li[" + i.ToString() + "]/h3[1]/a[1]/@href[1]").Attributes["href"].Value;
                                }
                            }
                        }
                        try
                        {
                            bodyValue = doc.DocumentNode.SelectSingleNode(bodyXpath).InnerHtml;
                            bodyValue = new HtmlToText().ConvertHtml(bodyValue).Trim();
                        }
                        catch
                        {
                            try
                            {
                                bodyValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[" + i.ToString() + "]/div[1]/div[1]").InnerText;
                            }
                            catch
                            {
                                try
                                {
                                    bodyValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/ul[1]/li[" + i.ToString() + "]/p[1]").InnerText;
                                }
                                catch
                                {
                                    bodyValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[3]/ul[1]/li[" + i.ToString() + "]/p[1]").InnerText;
                                }
                            }
                        }
                        try
                        {
                            timeValue = doc.DocumentNode.SelectSingleNode(timeXpath).InnerText;
                        }
                        catch
                        {
                            try
                            {
                                timeValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[" + i.ToString() + "]/div[1]/div[1]/ul[1]/li[1]/div[1]/em[2]/span[1]").InnerText;
                            }
                            catch
                            {
                                try
                                {
                                    timeValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/ul[1]/li[" + i.ToString() + "]/em[1]/span[1]").InnerText;
                                }
                                catch
                                {
                                    timeValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[3]/ul[1]/li[" + i.ToString() + "]/em[1]/span[1]").InnerText;
                                }
                            }
                        }

                        sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px;\">");
                        sb.Append(" <div>");
                        sb.Append(" <a target=\"_blank\"  href=\"" + urlValue + "\"><font color=blue>" + nameValue.Replace(System.Web.HttpUtility.UrlDecode(searchword, Encoding.UTF8), "<font color=red>" + System.Web.HttpUtility.UrlDecode(searchword, Encoding.UTF8) + "</font>") + "</font></a>");
                        sb.Append(" </div>");
                        sb.Append(" <div style=\"font-size: 13px;\">");
                        sb.Append(" <font size=2 >" + bodyValue.Replace(System.Web.HttpUtility.UrlDecode(searchword, Encoding.UTF8), "<font color=red>" + System.Web.HttpUtility.UrlDecode(searchword, Encoding.UTF8) + "</font>") + "</font>");
                        sb.Append(" </div>");
                        sb.Append(" <div>");
                        sb.Append(" <font color=#006600>" + (urlValue.Length > 66 ? urlValue.Substring(0, 66)+"..." : urlValue) + "</font>&nbsp;&nbsp;<font size=2 color=#006600>" + timeValue + "</font>&nbsp;&nbsp;<a target=\"_blank\" href=\"" + url + "\"><font size=2  color=#666699>Yahoo搜索</font></a>");
                        sb.Append("  </div>");
                        sb.Append(" </div>");
                    }
                    catch
                    {
                        continue;
                    }

                    System.Threading.Thread.Sleep(200);
                }
                //sb.Append("  </div>");
                //sb.Append(" </div>");
            }
            catch (Exception ex)
            {
                sb.Append(ex.Message + "&nbsp;<a href=\"" + url + "\" target=\"_blank\"><font color=blue>此处查看</font></a>");
            }
            if (sb.ToString().Trim().Equals(""))
                sb.Append("该网站相关Xpath出现改动，请根据改动及时修正匹配Xpath。" + "&nbsp;<a href=\"" + url + "\" target=\"_blank\"><font color=blue>此处查看</font></a>");
            return sb.ToString();
        }
        #endregion

        #region 获取Bing查询结果
        /// <summary>
        /// 获取Bing查询结果
        /// </summary>
        /// <param name="html">网络地址</param>
        /// <returns>Bing查询结果</returns>
        public string GetSearchResultFromBing(string searchword)
        {
            StringBuilder sb = new StringBuilder();
            string url = "http://cn.bing.com/search?q=" + searchword + "&form=QBLH&filt=all&qs=n&sk=";
            try
            { 
                WebClient wc = new WebClient
                {
                    Encoding = Encoding.GetEncoding("utf-8")
                };
                string html = wc.DownloadString(url.Trim());

                //string html = "";
                //System.IO.StreamReader sr = new System.IO.StreamReader("D:\\CnInterface\\CnWeb\\html\\bingcode.txt", Encoding.GetEncoding("utf-8"));
                //lock (sr)
                //{
                //    html = sr.ReadToEnd();
                //    sr.Close();
                //}

                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                string nameValue = "";
                string urlValue = "";
                string bodyValue = "";
                string timeValue = DateTime.Now.ToString("yyyy-MM-dd");

                //sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px;width:678px\"><a href=\"" + url + "\" target=\"_blank\">必应</a><span id='spanbing' onclick='if(document.getElementById(\"divbing\").style.display == \"none\"){document.getElementById(\"divbing\").style.display = \"block\";document.getElementById(\"spanbing\").innerHTML =\"<font color=#666699><b>第一页数据</b></font>&nbsp;<font  color=red>收起</font>\";}else{document.getElementById(\"divbing\").style.display = \"none\";document.getElementById(\"spanbing\").innerHTML =\"<font color=#666699><b>第一页数据</b></font>&nbsp;<font  color=green>展开</font>\";}' style=\"cursor:hand\"><font color='#666699'><b>第一页数据</b></font>&nbsp;<font  color=green>展开</font></span>");
                //sb.Append(" <div id='divbing' style='display:none;'>");
                string divindex = "3";
                for (int i = 1; i <= 10; i++)
                {
                    try
                    {                                     
                        string nameXpath = "/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[" + divindex + "]/ul[1]/li[" + i.ToString() + "]/div[1]/h3[1]/a[1]";
                        string urlXpath = "/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[" + divindex + "]/ul[1]/li[" + i.ToString() + "]/div[1]/h3[1]/a[1]/@href[1]";
                        string bodyXpath = "/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[" + divindex + "]/ul[1]/li[" + i.ToString() + "]/p[1]";

                        try
                        {
                            nameValue = doc.DocumentNode.SelectSingleNode(nameXpath).InnerText;
                        }
                        catch
                        {
                            try
                            {
                                nameValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[4]/ul[1]/li[" + i.ToString() + "]/div[1]/h3[1]/a[1]").InnerText;
                            }
                            catch
                            {
                                nameValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/ul[1]/li[" + i.ToString() + "]/div[1]/h3[1]/a[1]").InnerText;
                            }
                        }
                        try
                        {
                            urlValue = doc.DocumentNode.SelectSingleNode(urlXpath).Attributes["href"].Value;
                        }
                        catch
                        {
                            try
                            {
                                urlValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[4]/ul[1]/li[" + i.ToString() + "]/div[1]/h3[1]/a[1]/@href[1]").Attributes["href"].Value;
                            }
                            catch
                            {
                                urlValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/ul[1]/li[" + i.ToString() + "]/div[1]/h3[1]/a[1]/@href[1]").Attributes["href"].Value;
                            }
                        }
                        try
                        {
                            bodyValue = doc.DocumentNode.SelectSingleNode(bodyXpath).InnerHtml;
                            bodyValue = new HtmlToText().ConvertHtml(bodyValue).Trim();
                        }
                        catch
                        {
                            try
                            {
                                bodyValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[4]/ul[1]/li[" + i.ToString() + "]/p[1]").InnerHtml;
                            }
                            catch
                            {
                                bodyValue = doc.DocumentNode.SelectSingleNode(" /html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/ul[1]/li[" + i.ToString() + "]/p[1]").InnerText;
                            }
                        }

                        sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px; width:678px\">");
                        sb.Append(" <div>");
                        sb.Append(" <a target=\"_blank\"  href=\"" + urlValue + "\"><font color=blue>" + nameValue.Replace(System.Web.HttpUtility.UrlDecode(searchword, Encoding.UTF8), "<font color=red>" + System.Web.HttpUtility.UrlDecode(searchword, Encoding.UTF8) + "</font>") + "</font></a>");
                        sb.Append(" </div>");
                        sb.Append(" <div style=\"font-size: 13px;\">");
                        sb.Append(" <font size=2 >" + bodyValue.Replace(System.Web.HttpUtility.UrlDecode(searchword, Encoding.UTF8), "<font color=red>" + System.Web.HttpUtility.UrlDecode(searchword, Encoding.UTF8) + "</font>") + "</font>");
                        sb.Append(" </div>");
                        sb.Append(" <div>");
                        sb.Append(" <font color=#006600>" + (urlValue.Length > 66 ? urlValue.Substring(0, 66)+"..." : urlValue) + "</font>&nbsp;&nbsp;<font size=2 color=#006600>" + timeValue + "</font>&nbsp;&nbsp;<a target=\"_blank\" href=\"" + url + "\"><font size=2  color=#666699>Bing搜索</font></a>");
                        sb.Append("  </div>");
                        sb.Append(" </div>");
                    }
                    catch
                    {
                        continue;
                    }

                    System.Threading.Thread.Sleep(200);
                }
                //sb.Append("  </div>");
                //sb.Append(" </div>");
            }
            catch (Exception ex)
            {
                sb.Append(ex.Message + "&nbsp;<a href=\"" + url + "\" target=\"_blank\"><font color=blue>此处查看</font></a>");
            }
            if (sb.ToString().Trim().Equals(""))
                sb.Append("该网站相关Xpath出现改动，请根据改动及时修正匹配Xpath。" + "&nbsp;<a href=\"" + url + "\" target=\"_blank\"><font color=blue>此处查看</font></a>");
            return sb.ToString();
        }
        #endregion

        #region 获取Sogou查询结果
        /// <summary>
        /// 获取Sogou查询结果
        /// </summary>
        /// <param name="html">网络地址</param>
        /// <returns>Sogou查询结果</returns>
        public string GetSearchResultFromSogou(string searchword)
        {
            StringBuilder sb = new StringBuilder();
            string url = "http://www.sogou.com/web?query=" + searchword + "&_asf=www.sogou.com&_ast=1270793244&w=01019900&p=40040100";
            try
            {
                WebClient wc = new WebClient
                {
                    Encoding = Encoding.GetEncoding("gb2312")
                };
                string html = wc.DownloadString(url.Trim());

                //string html = "";
                //System.IO.StreamReader sr = new System.IO.StreamReader("D:\\CnInterface\\CnWeb\\html\\sogoucode.txt", Encoding.GetEncoding("gb2312"));
                //lock (sr)
                //{
                //    html = sr.ReadToEnd();
                //    sr.Close();
                //}

                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                string nameValue = "";
                string urlValue = "";
                string bodyValue = "";
                string timeValue = "";

                //sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px;width:678px\"><a href=\"" + url + "\" target=\"_blank\">搜狗</a><span id='spansogou' onclick='if(document.getElementById(\"divsogou\").style.display == \"none\"){document.getElementById(\"divsogou\").style.display = \"block\";document.getElementById(\"spansogou\").innerHTML =\"<font color=#666699><b>第一页数据</b></font>&nbsp;<font  color=red>收起</font>\";}else{document.getElementById(\"divsogou\").style.display = \"none\";document.getElementById(\"spansogou\").innerHTML =\"<font color=#666699><b>第一页数据</b></font>&nbsp;<font  color=green>展开</font>\";}' style=\"cursor:hand\"><font color='#666699'><b>第一页数据</b></font>&nbsp;<font  color=green>展开</font></span>");
                //sb.Append(" <div id='divsogou' style='display:none;'>");
                for (int i = 4; i <= 13; i++)
                {
                    try
                    {
                        string nameXpath = "/html[1]/body[1]/table[" + i.ToString() + "]/tr[1]/td[1]/a[1]";
                        string urlXpath = "/html[1]/body[1]/table[" + i.ToString() + "]/tr[1]/td[1]/a[1]/@href[1]";
                        string bodyXpath = "/html[1]/body[1]/table[" + i.ToString() + "]/tr[1]/td[1]/font[1]";
                        string timeXpath = "/html[1]/body[1]/table[" + i.ToString() + "]/tr[1]/td[1]/font[1]/font[4]";

                        nameValue = doc.DocumentNode.SelectSingleNode(nameXpath).InnerText;
                        nameValue = new HtmlToText().ConvertHtml(nameValue).Trim();
                        urlValue = doc.DocumentNode.SelectSingleNode(urlXpath).Attributes["href"].Value;
                        try
                        {
                            bodyValue = doc.DocumentNode.SelectSingleNode(bodyXpath).InnerHtml;
                            bodyValue = new HtmlToText().ConvertHtml(bodyValue).Trim();
                        }
                        catch
                        {
                            bodyValue = "";
                        }
                        try
                        {
                            timeValue = doc.DocumentNode.SelectSingleNode(timeXpath).InnerText;
                            timeValue = timeValue.Substring(timeValue.LastIndexOf("20")).Replace("-->", "");
                        }
                        catch
                        {
                            timeValue = "";
                        }

                        sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px;\">");
                        sb.Append(" <div>");
                        sb.Append(" <a target=\"_blank\"  href=\"" + urlValue + "\"><font color=blue>" + nameValue.Replace(System.Web.HttpUtility.UrlDecode(searchword, Encoding.GetEncoding("gb2312")), "<font color=red>" + System.Web.HttpUtility.UrlDecode(searchword, Encoding.GetEncoding("gb2312")) + "</font>") + "</font></a>");
                        sb.Append(" </div>");
                        sb.Append(" <div style=\"font-size: 13px;\">");
                        sb.Append(" <font size=2 >" + bodyValue.Replace(System.Web.HttpUtility.UrlDecode(searchword, Encoding.GetEncoding("gb2312")), "<font color=red>" + System.Web.HttpUtility.UrlDecode(searchword, Encoding.GetEncoding("gb2312")) + "</font>") + "</font>");
                        sb.Append(" </div>");
                        sb.Append(" <div>");
                        sb.Append(" <font color=#006600>" + (urlValue.Length > 66 ? urlValue.Substring(0, 66)+"..." : urlValue) + "</font>&nbsp;&nbsp;<font size=2 color=#006600>" + timeValue + "</font>&nbsp;&nbsp;<a target=\"_blank\" href=\"" + url + "\"><font size=2  color=#666699>Sogou搜索</font></a>");
                        sb.Append("  </div>");
                        sb.Append(" </div>");
                    }
                    catch
                    {
                        continue;
                    }

                    System.Threading.Thread.Sleep(200);
                }
                //sb.Append(" </div>");
                //sb.Append(" </div>");
            }
            catch (Exception ex)
            {
                sb.Append(ex.Message + "&nbsp;<a href=\"" + url + "\" target=\"_blank\"><font color=blue>此处查看</font></a>");
            }
            if (sb.ToString().Trim().Equals(""))
                sb.Append("该网站相关Xpath出现改动，请根据改动及时修正匹配Xpath。" + "&nbsp;<a href=\"" + url + "\" target=\"_blank\"><font color=blue>此处查看</font></a>");
            return sb.ToString();
        }
        #endregion

        #region 获取Soso接口查询结果
        /// <summary>
        /// 获取Soso接口查询结果
        /// </summary>
        /// <param name="html">网络地址</param>
        /// <returns>Soso查询结果</returns>
        public string GetSearchResultFromSoso(string searchword)
        {
            StringBuilder sb = new StringBuilder();
            string url = "http://www.soso.com/q?pid=s.idx&w=" + searchword;
            try
            {
                WebClient wc = new WebClient
                {
                    Encoding = Encoding.GetEncoding("gb2312")
                };
                string html = wc.DownloadString(url.Trim());

                //string html = "";
                //System.IO.StreamReader sr = new System.IO.StreamReader("D:\\CnInterface\\CnWeb\\html\\sosocode.txt", Encoding.GetEncoding("gb2312"));
                //lock (sr)
                //{
                //    html = sr.ReadToEnd();
                //    sr.Close();
                //}

                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                string nameValue = "";
                string urlValue = "";
                string bodyValue = "";
                string timeValue = "";

                //sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px;width:678px\"><a href=\"" + url + "\" target=\"_blank\">搜搜</a><span id='spansoso' onclick='if(document.getElementById(\"divsoso\").style.display == \"none\"){document.getElementById(\"divsoso\").style.display = \"block\";document.getElementById(\"spansoso\").innerHTML =\"<font color=#666699><b>第一页数据</b></font>&nbsp;<font  color=red>收起</font>\";}else{document.getElementById(\"divsoso\").style.display = \"none\";document.getElementById(\"spansoso\").innerHTML =\"<font color=#666699><b>第一页数据</b></font>&nbsp;<font  color=green>展开</font>\";}' style=\"cursor:hand\"><font color='#666699'><b>第一页数据</b></font>&nbsp;<font  color=green>展开</font></span>");
                //sb.Append(" <div id='divsoso' style='display:none;'>");
                for (int i = 1; i <= 10; i++)
                {
                    try
                    {
                        string nameXpath = "/html[1]/body[1]/div[1]/div[2]/table[1]/tr[1]/td[2]/ol[1]/li[" + i.ToString() + "]/h3[1]/a[1]";
                        string urlXpath = "/html[1]/body[1]/div[1]/div[2]/table[1]/tr[1]/td[2]/ol[1]/li[" + i.ToString() + "]/h3[1]/a[1]/@href[1]";
                        string bodyXpath = "/html[1]/body[1]/div[1]/div[2]/table[1]/tr[1]/td[2]/ol[1]/li[" + i.ToString() + "]/p[1]";
                        string timeXpath = "/html[1]/body[1]/div[1]/div[2]/table[1]/tr[1]/td[2]/ol[1]/li[" + i.ToString() + "]/div[1]/div[1]/cite[1]";

                        nameValue = doc.DocumentNode.SelectSingleNode(nameXpath).InnerText;
                        nameValue = new HtmlToText().ConvertHtml(nameValue).Trim();
                        urlValue = doc.DocumentNode.SelectSingleNode(urlXpath).Attributes["href"].Value;
                        try
                        {
                            bodyValue = doc.DocumentNode.SelectSingleNode(bodyXpath).InnerHtml;
                            bodyValue = new HtmlToText().ConvertHtml(bodyValue).Trim();
                        }
                        catch
                        {
                            bodyValue = "";
                        }
                        try
                        {
                            timeValue = doc.DocumentNode.SelectSingleNode(timeXpath).InnerText;
                            timeValue = timeValue.Substring(timeValue.LastIndexOf("20"));
                        }
                        catch
                        {
                            timeValue = "";
                        }

                        sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px;\">");
                        sb.Append(" <div>");
                        sb.Append(" <a target=\"_blank\"  href=\"" + urlValue + "\"><font color=blue>" + nameValue.Replace(System.Web.HttpUtility.UrlDecode(searchword, Encoding.GetEncoding("gb2312")), "<font color=red>" + System.Web.HttpUtility.UrlDecode(searchword, Encoding.GetEncoding("gb2312")) + "</font>") + "</font></a>");
                        sb.Append(" </div>");
                        sb.Append(" <div style=\"font-size: 13px;\">");
                        sb.Append(" <font size=2 >" + bodyValue.Replace(System.Web.HttpUtility.UrlDecode(searchword, Encoding.GetEncoding("gb2312")), "<font color=red>" + System.Web.HttpUtility.UrlDecode(searchword, Encoding.GetEncoding("gb2312")) + "</font>") + "</font>");
                        sb.Append(" </div>");
                        sb.Append(" <div>");
                        sb.Append(" <font color=#006600>" + (urlValue.Length > 66 ? urlValue.Substring(0, 66)+"..." : urlValue) + "</font>&nbsp;&nbsp;<font size=2 color=#006600>" + timeValue + "</font>&nbsp;&nbsp;<a target=\"_blank\" href=\"" + url + "\"><font size=2  color=#666699>Soso搜索</font></a>");
                        sb.Append("  </div>");
                        sb.Append(" </div>");
                    }
                    catch
                    {
                        continue;
                    }

                    System.Threading.Thread.Sleep(200);
                }
                //sb.Append("  </div>");
                //sb.Append(" </div>");
            }
            catch (Exception ex)
            {
                sb.Append(ex.Message + "&nbsp;<a href=\"" + url + "\" target=\"_blank\"><font color=blue>此处查看</font></a>");
            }
            if (sb.ToString().Trim().Equals(""))
                sb.Append("该网站相关Xpath出现改动，请根据改动及时修正匹配Xpath。" + "&nbsp;<a href=\"" + url + "\" target=\"_blank\"><font color=blue>此处查看</font></a>");
            return sb.ToString();
        }
        #endregion

        #region 获取有道查询结果
        /// <summary>
        /// 获取有道查询结果
        /// </summary>
        /// <param name="html">网络地址</param>
        /// <returns>有道查询结果</returns>
        public string GetSearchResultFromYoudao(string searchword)
        {
            StringBuilder sb = new StringBuilder();
            string url = "http://www.youdao.com/search?q=" + searchword + "&ue=utf8&keyfrom=web.index";
            try
            {
                WebClient wc = new WebClient
                {
                    Encoding = Encoding.GetEncoding("utf-8")
                };
                string html = wc.DownloadString(url.Trim());

                //string html = "";
                //System.IO.StreamReader sr = new System.IO.StreamReader("D:\\CnInterface\\CnWeb\\html\\youdaocode.txt", Encoding.GetEncoding("gb2312"));
                //lock (sr)
                //{
                //    html = sr.ReadToEnd();
                //    sr.Close();
                //}

                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                string nameValue = "";
                string urlValue = "";
                string bodyValue = "";
                string timeValue = "";

                //sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px;width:678px\"><a href=\"" + url + "\" target=\"_blank\">有道</a><span id='spanyoudao' onclick='if(document.getElementById(\"divyoudao\").style.display == \"none\"){document.getElementById(\"divyoudao\").style.display = \"block\";document.getElementById(\"spanyoudao\").innerHTML =\"<font color=#666699><b>第一页数据</b></font>&nbsp;<font  color=red>收起</font>\";}else{document.getElementById(\"divyoudao\").style.display = \"none\";document.getElementById(\"spanyoudao\").innerHTML =\"<font color=#666699><b>第一页数据</b></font>&nbsp;<font  color=green>展开</font>\";}' style=\"cursor:hand\"><font color='#666699'><b>第一页数据</b></font>&nbsp;<font  color=green>展开</font></span>");
                //sb.Append(" <div id='divyoudao' style='display:none;'>");
                for (int i = 1; i <= 10; i++)
                {
                    try
                    {
                        string nameXpath = "/body[1]/div[6]/div[2]/ul[1]/li[" + i.ToString() + "]/h3[1]/a[1]";
                        string urlXpath = "/body[1]/div[6]/div[2]/ul[1]/li[" + i.ToString() + "]/h3[1]/a[1]/@href[1]";
                        string bodyXpath = "/body[1]/div[6]/div[2]/ul[1]/li[" + i.ToString() + "]/div[1]";
                        string timeXpath = "/body[1]/div[6]/div[2]/ul[1]/li[" + i.ToString() + "]/p[1]/span[1]";

                        nameValue = doc.DocumentNode.SelectSingleNode(nameXpath).InnerText;
                        nameValue = new HtmlToText().ConvertHtml(nameValue).Trim();
                        urlValue = doc.DocumentNode.SelectSingleNode(urlXpath).Attributes["href"].Value;
                        try
                        {
                            bodyValue = doc.DocumentNode.SelectSingleNode(bodyXpath).InnerHtml;
                            bodyValue = new HtmlToText().ConvertHtml(bodyValue).Trim();
                        }
                        catch
                        {
                            bodyValue = "";
                        }
                        try
                        {
                            timeValue = doc.DocumentNode.SelectSingleNode(timeXpath).InnerText;
                            timeValue = timeValue.Substring(timeValue.LastIndexOf("20")).Replace("-->", "");
                        }
                        catch
                        {
                            timeValue = "";
                        }

                        sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px;\">");
                        sb.Append(" <div>");
                        sb.Append(" <a target=\"_blank\"  href=\"" + urlValue + "\"><font color=blue>" + nameValue.Replace(System.Web.HttpUtility.UrlDecode(searchword, Encoding.UTF8), "<font color=red>" + System.Web.HttpUtility.UrlDecode(searchword, Encoding.UTF8) + "</font>") + "</font></a>");
                        sb.Append(" </div>");
                        sb.Append(" <div style=\"font-size: 13px;\">");
                        sb.Append(" <font size=2 >" + bodyValue.Replace(System.Web.HttpUtility.UrlDecode(searchword, Encoding.UTF8), "<font color=red>" + System.Web.HttpUtility.UrlDecode(searchword, Encoding.UTF8) + "</font>") + "</font>");
                        sb.Append(" </div>");
                        sb.Append(" <div>");
                        sb.Append(" <font color=#006600>" + (urlValue.Length > 66 ? urlValue.Substring(0, 66)+"..." : urlValue) + "</font>&nbsp;&nbsp;<font size=2 color=#006600>" + timeValue + "</font>&nbsp;&nbsp;<a target=\"_blank\" href=\"" + url + "\"><font size=2  color=#666699>有道搜索</font></a>");
                        sb.Append("  </div>");
                        sb.Append(" </div>");
                    }
                    catch
                    {
                        continue;
                    }

                    System.Threading.Thread.Sleep(200);
                }
                //sb.Append("  </div>");
                //sb.Append(" </div>");
            }
            catch (Exception ex)
            {
                sb.Append(ex.Message + "&nbsp;<a href=\"" + url + "\" target=\"_blank\"><font color=blue>此处查看</font></a>");
            }
            if (sb.ToString().Trim().Equals(""))
                sb.Append("该网站相关Xpath出现改动，请根据改动及时修正匹配Xpath。" + "&nbsp;<a href=\"" + url + "\" target=\"_blank\"><font color=blue>此处查看</font></a>");
            return sb.ToString();
        }
        #endregion
    }
}
