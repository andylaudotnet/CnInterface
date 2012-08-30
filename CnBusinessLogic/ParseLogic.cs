using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;
using System.Data;
using CnDataAcess.Entity;
using HtmlAgilityPack;
using ParseParameter = CnDataAcess.Entity.ParseParameter;
using CnCommon;

namespace CnBusinessLogic
{
    public class ParseLogic
    {
        #region 网络信息解析方法
        /// <summary>
        ///网络信息解析方法
        /// </summary>
        public void ParseIndex()
        {
            for (; ; )
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    var dac = DataAccess.Create(
                        DataAccess.CreateConnection(
                            "server=www.beta-1.cn,1435;database=s446669db0;uid=s446669db0;pwd=B71E8A0397FC;persist security info=true;",
                            DataAccess.DataProvider.SqlServer));

                    const string sql = @"SELECT  * FROM    Cn_InterfaceParse WHERE   [ParseStatus] = 1  ORDER BY ID ASC";
                    var ParseParameterList = new List<ParseParameter>();

                    #region 获取需要解析的对象集合
                    using (IDataReader dr = dac.ExecuteReader(DataAccess.ConnManagementMode.Auto, sql))
                    {
                        while (dr.Read())
                        {
                            ParseParameterList.Add(new ParseParameter
                            {
                                ParseName = dr["ParseName"] as string,
                                ParseStatus = (int)dr["ParseStatus"],
                                SiteSoureName = dr["SiteSoureName"] as string,
                                SiteSoureEncodeNo = (int)dr["SiteSoureEncodeNo"],
                                SiteSoureUrl = dr["SiteSoureUrl"] as string,
                                CnTypeID = (int)dr["CnTypeID"],
                                CnListUrl = dr["CnListUrl"] as string,
                                CnListXPath = dr["CnListXPath"] as string,
                                CnListRegex = dr["CnListRegex"] as string,
                                CnInterfaceNameXPath = dr["CnInterfaceNameXPath"] as string,
                                CnInterfaceNameRegex = dr["CnInterfaceNameRegex"] as string,
                                CnInterfaceXPath = dr["CnInterfaceXPath"] as string,
                                CnInterfaceRegex = dr["CnInterfaceRegex"] as string,
                                CnInterfaceTimeXPath = dr["CnInterfaceTimeXPath"] as string,
                                CnInterfaceTimeRegex = dr["CnInterfaceTimeRegex"] as string,
                                CnInterfaceTimeFormat = dr["CnInterfaceTimeFormat"] as string  
                            });
                        }
                    }
                    #endregion

                    foreach (var ppl in ParseParameterList)
                    {
                        var CnInfoList = new List<CnInterfaceInfo>();

                        //获取接口列表
                        var wc = new WebClient { Encoding = Encoding.GetEncoding(ppl.SiteSoureEncodeNo) };
                        var html = wc.DownloadString(ppl.CnListUrl);

                        //HTML Parser
                        var doc = new HtmlDocument();
                        doc.LoadHtml(html);

                        if (ppl.CnListRegex == null || ppl.CnListRegex.Equals(""))
                        {
                            #region 如果Catalog Regex为空则XPath能准确定位, 那么使用SelectNodes取得URL集合
                            var nodes = doc.DocumentNode.SelectNodes(ppl.CnListXPath);
                            var counter = 0;
                            foreach (var node in nodes)
                            {
                                //Console.Write("解析_{2}: {0}/{1}...", ++counter, nodes.Count, ppl.ParseName);
                                try
                                {
                                    CnInfoList.Add(GetCnInterfaceInfoEntity(wc, 
                                                                                            node.Attributes["href"].Value, 
                                                                                            ppl.CnInterfaceNameXPath,
                                                                                            ppl.CnInterfaceNameRegex, 
                                                                                            ppl.CnInterfaceXPath, 
                                                                                            ppl.CnInterfaceRegex, 
                                                                                            ppl.CnInterfaceTimeXPath,
                                                                                            ppl.CnInterfaceTimeRegex,
                                                                                            ppl.CnInterfaceTimeFormat,
                                                                                            ppl.SiteSoureName,
                                                                                            ppl.SiteSoureUrl,
                                                                                            ppl.CnTypeID));
                                }
                                catch
                                {
                                    //Console.WriteLine("失败.");
                                    continue;
                                }
                                //Console.WriteLine("成功.");
                            }
                            #endregion
                        }
                        else
                        {
                            #region 若XPath无法准确定位, 使用Regex加以处理
                            var mc = new Regex(ppl.CnListRegex).Matches(doc.DocumentNode.SelectSingleNode(ppl.CnListXPath).InnerHtml);
                            var counter = 0;
                            foreach (Match m in mc)
                            {
                                //Console.Write("解析_{2}: {0}/{1}...", ++counter, mc.Count, ppl.ParseName);
                                if (!m.Success || m.Groups.Count < 2)
                                {
                                    //Console.WriteLine("失败.");
                                    continue;
                                }
                                try
                                {
                                    CnInfoList.Add(GetCnInterfaceInfoEntity(wc, 
                                                                                            m.Groups[1].Value,
                                                                                            ppl.CnInterfaceNameXPath,
                                                                                            ppl.CnInterfaceNameRegex,
                                                                                            ppl.CnInterfaceXPath,
                                                                                            ppl.CnInterfaceRegex,
                                                                                            ppl.CnInterfaceTimeXPath,
                                                                                            ppl.CnInterfaceTimeRegex,
                                                                                            ppl.CnInterfaceTimeFormat,
                                                                                            ppl.SiteSoureName,
                                                                                            ppl.SiteSoureUrl,
                                                                                            ppl.CnTypeID));
                                }
                                catch
                                {
                                    //Console.WriteLine("失败.");
                                    continue;
                                }
                                //Console.WriteLine("成功.");
                            }
                            #endregion
                        }

                       #region 往表Cn_InterfaceInfo插入数据
                        try
                        {
                            dac.Connection.Open();
                            var counter = 0;
                            foreach (var cnf in CnInfoList)
                            {
                                //Console.Write("入库_{2}: {0}/{1}...", ++counter, CnInfoList.Count, ppl.ParseName);
                                int insertCount=dac.ExecuteNonQuery(DataAccess.ConnManagementMode.Manual, false,
                                                    @"DECLARE @cnf_id INT
SELECT  @cnf_id = ID
FROM    Cn_InterfaceInfo
WHERE   CnInterfaceUrl = @cnfurl
        OR CnInterfaceName = @cnfname

IF @cnf_id IS NULL 
    BEGIN

        INSERT  INTO [Cn_InterfaceInfo]
                ( [CnInterfaceTypeID] ,
                  [CnInterfaceUrl] ,
                  [CnInterfaceName] ,
                  [CnInterfacebody] ,
                  [CnInterfaceSource] ,
                  [CnInterfaceSourceUrl] ,
                  [CnInterfaceDateTime]
                )
        VALUES  ( @cnftypeid ,
                  @cnfurl ,
                  @cnfname,
                  @cnfbody ,
                  @cnfsource,
                  @cnfsourceurl ,
                  @cncreatetime
                )  
    END
                 ",
                                                    dac.CreateParameter("@cnftypeid", cnf.CnInterfaceTypeID),
                                                    dac.CreateParameter("@cnfurl", cnf.CnInterfaceUrl),
                                                    dac.CreateParameter("@cnfname", cnf.CnInterfaceName),
                                                    dac.CreateParameter("@cnfbody", cnf.CnInterfacebody),
                                                    dac.CreateParameter("@cnfsource", cnf.CnInterfaceSource),
                                                    dac.CreateParameter("@cnfsourceurl", cnf.CnInterfaceSourceUrl),
                                                    dac.CreateParameter("@cncreatetime", cnf.CreateDateTime));

                               // Console.WriteLine("{0}条.", insertCount);
                            }
                        }
                        catch (Exception expAll)
                        {
                            //Console.WriteLine(expAll.Message + expAll.StackTrace);
                            continue;
                        }
                        finally
                        {
                            if (dac.Connection.State != ConnectionState.Closed)
                                dac.Connection.Close();
                        }
                       #endregion
                    }
                    //Console.WriteLine("休息3600秒...");
                    Thread.Sleep(3600 * 1000);
                }
                catch (Exception exp)
                {
                    //Console.WriteLine(exp.Message + exp.StackTrace);
                    continue;
                }
            }
        }
        #endregion

        #region 通过URL获取接口对象.
        /// <summary>
        /// 通过URL获取接口对象.
        /// </summary>
        /// <param name="wc">WebClient 对象.</param>
        /// <param name="url">接口URL.</param>
        /// <param name="cnnamexp">接口名称(XPath).</param>
        /// <param name="cnnameRgx">接口名称正则表达式(Regex)</param>
        /// <param name="cnbodyXp">接口内容(XPath).</param>
        /// <param name="cnbodyRgx">接口内容正则表达式(Regex).</param>
        /// <param name="cntimeXp">接口发布时间(XPath).</param>
        /// <param name="cntimeRgx">接口发布时间正则表达式(Regex).</param>
        /// <param name="cntimeF">接口发布时间Format.</param>
        /// <param name="cnsource">接口网络来源.</param>
        /// <param name="cnsourceurl">接口网络来源地址.</param>
        /// <returns>接口对象.</returns>
        public static CnInterfaceInfo GetCnInterfaceInfoEntity(WebClient wc, 
                                                                                              string url, 
                                                                                              string cnnamexp,
                                                                                              string cnnameRgx,
                                                                                              string cnbodyXp,
                                                                                              string cnbodyRgx, 
                                                                                              string cntimeXp,
                                                                                              string cntimeRgx,
                                                                                              string cntimeF,
                                                                                              string cnsource,
                                                                                              string cnsourceurl,
                                                                                              int      cntypeid)
        {
            var html = wc.DownloadString(url);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            //取接口名称
            var title = doc.DocumentNode.SelectSingleNode(cnnamexp).InnerHtml;
            if (cnnameRgx != null && !cnnameRgx.Equals(""))
                title = new Regex(cnnameRgx).Match(title).Groups[1].Value;
            //取接口发布时间
            var ptStr = doc.DocumentNode.SelectSingleNode(cntimeXp).InnerHtml;
            if (cntimeRgx != null && !cntimeRgx.Equals(""))
                ptStr = new Regex(cntimeRgx).Match(ptStr).Groups[1].Value;
            //避免与系统format定义冲突
            /*ptStr = ptStr.Replace("s", "S");
            var pt = DateTime.ParseExact(ptStr, cntimeF, CultureInfo.CurrentCulture);*/
            //取接口内容
            var body = doc.DocumentNode.SelectSingleNode(cnbodyXp).InnerHtml;
            if (cnbodyRgx !=null  &&  !cnbodyRgx.Equals(""))
                title = new Regex(cnbodyRgx).Match(body).Groups[1].Value;
            //去除html标记
            body = new HtmlToText().ConvertHtml(body).Trim();

            return new CnInterfaceInfo
            {
                CnInterfaceTypeID = cntypeid,
                CnInterfaceName = title,
                CnInterfacebody = body,
                CnInterfaceUrl = url,
                CnInterfaceSource = cnsource,
                CnInterfaceSourceUrl = cnsourceurl,
                CnInterfaceAppearTime = Convert.ToDateTime(ptStr)
            };
        }
        #endregion

        #region 获取华军和天空接口信息
        /// <summary>
        /// 通过URL获取接口对象.
        /// </summary>
        /// <param name="wc">WebClient 对象.</param>
        /// <param name="url">接口列表URL.</param>
        /// <param name="cnurlxp">接口地址(XPath).</param>
        /// <param name="cnurlRgx">接口地址正则表达式(Regex).</param>
        /// <param name="cnnamexp">接口名称(XPath).</param>
        /// <param name="cnnameRgx">接口名称正则表达式(Regex)</param>
        /// <param name="cnbodyXp">接口内容(XPath).</param>
        /// <param name="cnbodyRgx">接口内容正则表达式(Regex).</param>
        /// <param name="cntimeXp">接口发布时间(XPath).</param>
        /// <param name="cntimeRgx">接口发布时间正则表达式(Regex).</param>
        /// <param name="cntimeF">接口发布时间Format.</param>
        /// <param name="cnsource">接口网络来源.</param>
        /// <param name="cnsourceurl">接口网络来源地址.</param>
        /// <returns>接口对象.</returns>
        public static int GetCnInterfaceInfoEntity(WebClient wc,
                                                                                              string url,
                                                                                              string cnurlxp,
                                                                                              string cnurlRgx,
                                                                                              string cnnamexp,
                                                                                              string cnnameRgx,
                                                                                              string cnbodyXp,
                                                                                              string cnbodyRgx,
                                                                                              string cntimeXp,
                                                                                              string cntimeRgx,
                                                                                              string cntimeF,
                                                                                              string cnsource,
                                                                                              string cnsourceurl,
                                                                                              int cntypeid,
                                                                                              int sourceno,
                                                                                              int pagesize)
        {
            var html = wc.DownloadString(url);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            int insertcount = 0;
            for (int i = 1; i <=pagesize; i++)
            {
                try
                {
                    //xpath处理
                    string urlllog = "";
                    if (sourceno == 1)
                    {
                        cnurlxp = cnurlxp.Replace("cnface", (i * 2).ToString());
                        cnnamexp = cnnamexp.Replace("cnface", (i * 2).ToString());
                        cnbodyXp = cnbodyXp.Replace("cnface", i.ToString());
                        cntimeXp = cntimeXp.Replace("cnface", (i * 3).ToString());
                    }
                    if (sourceno == 2)
                    {
                        cnurlxp = cnurlxp.Replace("cnface", i.ToString());
                        cnnamexp = cnnamexp.Replace("cnface", i.ToString());
                        cnbodyXp = cnbodyXp.Replace("cnface", i.ToString());
                        cntimeXp = cntimeXp.Replace("cnface", i.ToString());
                        urlllog = "http://www.skycn.com/";
                    }
                    //取接口地址
                    var cnurl = urlllog + doc.DocumentNode.SelectSingleNode(cnurlxp).Attributes["href"].Value;
                    if (cnurlRgx != null && !cnurlRgx.Equals(""))
                        cnurl = new Regex(cnurlRgx).Match(cnurl).Groups[1].Value;
                    //取接口名称
                    var title = doc.DocumentNode.SelectSingleNode(cnnamexp).InnerHtml;
                    if (cnnameRgx != null && !cnnameRgx.Equals(""))
                        title = new Regex(cnnameRgx).Match(title).Groups[1].Value;
                    title = new HtmlToText().ConvertHtml(title).Trim();
                    //取接口内容
                    var body = doc.DocumentNode.SelectSingleNode(cnbodyXp).InnerHtml;
                    if (cnbodyRgx != null && !cnbodyRgx.Equals(""))
                        title = new Regex(cnbodyRgx).Match(body).Groups[1].Value;
                    body = new HtmlToText().ConvertHtml(body).Trim();

                    //取接口发布时间
                    var ptStr = doc.DocumentNode.SelectSingleNode(cntimeXp).InnerHtml;
                    if (cntimeRgx != null && !cntimeRgx.Equals(""))
                        ptStr = new Regex(cntimeRgx).Match(ptStr).Groups[1].Value;
               
                    CnInterfaceInfo cnf = new CnInterfaceInfo
                    {
                        CnInterfaceTypeID = cntypeid,
                        CnInterfaceName = title,
                        CnInterfacebody = body,
                        CnInterfaceUrl = cnurl,
                        CnInterfaceSource = cnsource,
                        CnInterfaceSourceUrl = cnsourceurl,
                        CnInterfaceAppearTime = Convert.ToDateTime(ptStr)
                    };
                    InterfaceInfo IFI = new InterfaceInfo();
                    int cont= IFI.InsertCnInterfaceInfo(cnf);
                    if (cont > 0)
                        insertcount += cont;
                }
                catch { continue; }
                System.Threading.Thread.Sleep(200);
            }
            return insertcount;
        }
        #endregion

        #region 获取百度接口查询结果
        /// <summary>
        /// 获取百度接口查询结果
        /// </summary>
        /// <param name="html">网络地址</param>
        /// <returns>百度查询结果</returns>
        public static int GetCnInterfaceInfoFromBaidu(string url)
        {
            int insertcount = 0;
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
            //StringBuilder sb = new StringBuilder();
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
                        //bodyValue = new HtmlToText().ConvertHtml(bodyValue).Trim(); 
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
                //sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px; width:678px\">");
                //sb.Append(" <div>");
                //sb.Append(" <a target=\"_blank\"  href=\"" + urlValue + "\"><font color=blue>" + nameValue.Replace("接口", "<font color=red>接口</font>") + "</font></a>");
                //sb.Append(" </div>");
                //sb.Append(" <div style=\"font-size: 13px;\">");
                //sb.Append(" <font size=2 >" + bodyValue.Replace("接口", "<font color=red>接口</font>") + "</font>");
                //sb.Append(" </div>");
                //sb.Append(" <div>");
                //sb.Append(" <font color=#006600>" + urlValue + "</font>&nbsp;&nbsp;<font size=2 color=#006600>" + timeValue + "</font>&nbsp;&nbsp;<a target=\"_blank\" href=\"" +url + "\"><font size=2  color=#666699>百度搜索</font></a>");
                //sb.Append("  </div>");
                //sb.Append(" </div>");

                CnInterfaceInfo cnf = new CnInterfaceInfo
                {
                    CnInterfaceTypeID = 2,
                    CnInterfaceName = nameValue,
                    CnInterfacebody = bodyValue,
                    CnInterfaceUrl = urlValue,
                    CnInterfaceSource = "百度搜索",
                    CnInterfaceSourceUrl = url,
                    CnInterfaceAppearTime = Convert.ToDateTime(timeValue)
                };
                InterfaceInfo IFI = new InterfaceInfo();
                int cont = IFI.InsertCnInterfaceInfo(cnf);
                if (cont > 0)
                    insertcount ++;

                System.Threading.Thread.Sleep(200);
            }
            return insertcount;
        }
        #endregion

        #region 获取Google接口查询结果
        /// <summary>
        /// 获取Google接口查询结果
        /// </summary>
        /// <param name="html">网络地址</param>
        /// <returns>Google查询结果</returns>
        public static int GetCnInterfaceInfoFromGoogle(string url)
        {
            int insertcount = 0;
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
            //StringBuilder sb = new StringBuilder();
            string listr = "/li[1]";
            for (int  i = 0; i <=10; i ++)
            {
                try
                {
                    string nameXpath = "/body[1]/div[5]/div[3]/div[1]/ol[1]" + listr + "/h3[1]/a[1]";
                    string urlXpath = "/body[1]/div[5]/div[3]/div[1]/ol[1]" + listr + "/h3[1]/a[1]/@href[1]";
                    string bodyXpath = "/body[1]/div[5]/div[3]/div[1]/ol[1]" + listr + "/div[1]";
                    
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
                        bodyValue = doc.DocumentNode.SelectSingleNode("/body[1]/div[5]/div[3]/div[1]/ol[1]" + listr + "/table[1]").InnerHtml;
                    }

                    //sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px; width:678px\">");
                    //sb.Append(" <div>");
                    //sb.Append(" <a target=\"_blank\"  href=\"" + urlValue + "\"><font color=blue>" + nameValue.Replace("接口", "<font color=red>接口</font>") + "</font></a>");
                    //sb.Append(" </div>");
                    //sb.Append(" <div style=\"font-size: 13px;\">");
                    //sb.Append(" <font size=2 >" + bodyValue.Replace("接口", "<font color=red>接口</font>") + "</font>");
                    //sb.Append(" </div>");
                    //sb.Append(" <div>");
                    //sb.Append(" <font color=#006600>" + urlValue + "</font>&nbsp;&nbsp;<font size=2 color=#006600>" + timeValue + "</font>&nbsp;&nbsp;<a target=\"_blank\" href=\"" + url + "\"><font size=2  color=#666699>Google搜索</font></a>");
                    //sb.Append("  </div>");
                    //sb.Append(" </div>");
                }
                catch
                {
                    listr += "/li[1]";
                    continue;
                }

                listr += "/li[1]";
            
                CnInterfaceInfo cnf = new CnInterfaceInfo
                {
                    CnInterfaceTypeID = 2,
                    CnInterfaceName = nameValue,
                    CnInterfacebody = bodyValue,
                    CnInterfaceUrl = urlValue,
                    CnInterfaceSource = "Google搜索",
                    CnInterfaceSourceUrl = url,
                    CnInterfaceAppearTime = Convert.ToDateTime(timeValue)
                };
                InterfaceInfo IFI = new InterfaceInfo();
                int cont = IFI.InsertCnInterfaceInfo(cnf);
                if (cont > 0)
                    insertcount++;

                System.Threading.Thread.Sleep(200);
            }

            return insertcount;
        }
        #endregion

        #region 获取Yahoo接口查询结果
        /// <summary>
        /// 获取Yahoo接口查询结果
        /// </summary>
        /// <param name="html">网络地址</param>
        /// <returns>Yahoo查询结果</returns>
        public static int GetCnInterfaceInfoFromYahoo(string url,int pageindex)
        {
            int insertcount = 0;
            WebClient wc = new WebClient
            {
                Encoding = Encoding.GetEncoding("gb2312")
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
            //StringBuilder sb = new StringBuilder();
            string divid = "1";
            if (pageindex == 0)
                divid = "2";
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    string nameXpath = "/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[" + divid + "]/ul[1]/li[" + i.ToString() + "]/h3[1]/a[1]";
                    string urlXpath = "/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[" + divid + "]/ul[1]/li[" + i.ToString() + "]/h3[1]/a[1]/@href[1]";
                    string bodyXpath = "/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[" + divid + "]/ul[1]/li[" + i.ToString() + "]/p[1]";
                    string timeXpath = "/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[" + divid + "]/ul[1]/li[" + i.ToString() + "]/em[1]/span[1]";

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
                        bodyValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[" + divid + "]/ul[1]/li[" + i.ToString() + "]/div[1]/div[2]/p[1]").InnerHtml;
                    }
                    try
                    {
                        timeValue = doc.DocumentNode.SelectSingleNode(timeXpath).InnerText;
                    }
                    catch
                    {
                        timeValue = doc.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[" + divid + "]/ul[1]/li[" + i.ToString() + "]/div[1]/div[2]/em[2]/span[1]").InnerText;
                    }

                    //sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px; width:678px\">");
                    //sb.Append(" <div>");
                    //sb.Append(" <a target=\"_blank\"  href=\"" + urlValue + "\"><font color=blue>" + nameValue.Replace("接口", "<font color=red>接口</font>") + "</font></a>");
                    //sb.Append(" </div>");
                    //sb.Append(" <div style=\"font-size: 13px;\">");
                    //sb.Append(" <font size=2 >" + bodyValue.Replace("接口", "<font color=red>接口</font>") + "</font>");
                    //sb.Append(" </div>");
                    //sb.Append(" <div>");
                    //sb.Append(" <font color=#006600>" + urlValue + "</font>&nbsp;&nbsp;<font size=2 color=#006600>" + timeValue + "</font>&nbsp;&nbsp;<a target=\"_blank\" href=\"" + url + "\"><font size=2  color=#666699>Yahoo搜索</font></a>");
                    //sb.Append("  </div>");
                    //sb.Append(" </div>");
                }
                catch
                {
                    continue;
                }
                try
                {
                    DateTime dt = Convert.ToDateTime(timeValue);
                }
                catch
                {
                    timeValue = DateTime.Now.ToString("yyyy-MM-dd");
                }
                CnInterfaceInfo cnf = new CnInterfaceInfo
                {
                    CnInterfaceTypeID = 2,
                    CnInterfaceName = nameValue,
                    CnInterfacebody = bodyValue,
                    CnInterfaceUrl = urlValue,
                    CnInterfaceSource = "Yahoo搜索",
                    CnInterfaceSourceUrl = url,
                    CnInterfaceAppearTime = Convert.ToDateTime(timeValue)
                };
                InterfaceInfo IFI = new InterfaceInfo();
                int cont = IFI.InsertCnInterfaceInfo(cnf);
                if (cont > 0)
                    insertcount++;

                System.Threading.Thread.Sleep(200);
            }

            return insertcount;
        }
        #endregion

        #region 获取Bing接口查询结果
        /// <summary>
        /// 获取Bing接口查询结果
        /// </summary>
        /// <param name="html">网络地址</param>
        /// <returns>Bing查询结果</returns>
        public static int GetCnInterfaceInfoFromBing(string url,int pageindex)
        {
            int insertcount = 0;

            WebClient wc = new WebClient
            {
                Encoding = Encoding.GetEncoding("gb2312")
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
            //StringBuilder sb = new StringBuilder();
            string divindex = "2";
            if(pageindex==1)
                divindex = "3";
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    string nameXpath = "/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[" + divindex + "]/ul[1]/li[" + i.ToString() + "]/div[1]/h3[1]/a[1]";
                    string urlXpath = "/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[" + divindex + "]/ul[1]/li[" + i.ToString() + "]/div[1]/h3[1]/a[1]/@href[1]";
                    string bodyXpath = "/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[" + divindex + "]/ul[1]/li[" + i.ToString() + "]/p[1]";

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
                        bodyValue ="";
                    }

                    //sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px; width:678px\">");
                    //sb.Append(" <div>");
                    //sb.Append(" <a target=\"_blank\"  href=\"" + urlValue + "\"><font color=blue>" + nameValue.Replace("接口", "<font color=red>接口</font>") + "</font></a>");
                    //sb.Append(" </div>");
                    //sb.Append(" <div style=\"font-size: 13px;\">");
                    //sb.Append(" <font size=2 >" + bodyValue.Replace("接口", "<font color=red>接口</font>") + "</font>");
                    //sb.Append(" </div>");
                    //sb.Append(" <div>");
                    //sb.Append(" <font color=#006600>" + urlValue + "</font>&nbsp;&nbsp;<font size=2 color=#006600>" + timeValue + "</font>&nbsp;&nbsp;<a target=\"_blank\" href=\"" + url + "\"><font size=2  color=#666699>Bing搜索</font></a>");
                    //sb.Append("  </div>");
                    //sb.Append(" </div>");
                }
                catch
                {
                    continue;
                }

                CnInterfaceInfo cnf = new CnInterfaceInfo
                {
                    CnInterfaceTypeID = 2,
                    CnInterfaceName = nameValue,
                    CnInterfacebody = bodyValue,
                    CnInterfaceUrl = urlValue,
                    CnInterfaceSource = "Bing搜索",
                    CnInterfaceSourceUrl = url,
                    CnInterfaceAppearTime = Convert.ToDateTime(timeValue)
                };
                InterfaceInfo IFI = new InterfaceInfo();
                int cont = IFI.InsertCnInterfaceInfo(cnf);
                if (cont > 0)
                    insertcount++;

                System.Threading.Thread.Sleep(200);
            }

            return insertcount;
        }
        #endregion

        #region 获取Soso接口查询结果
        /// <summary>
        /// 获取Soso接口查询结果
        /// </summary>
        /// <param name="html">网络地址</param>
        /// <returns>Soso查询结果</returns>
        public static int GetCnInterfaceInfoFromSoso(string url)
        {
            int insertcount = 0;

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
            string timeValue ="";
            //StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    string nameXpath = "/html[1]/body[1]/div[1]/div[2]/table[1]/tr[1]/td[2]/ol[1]/li["+i.ToString()+"]/h3[1]/a[1]";
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

                    //sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px; width:678px\">");
                    //sb.Append(" <div>");
                    //sb.Append(" <a target=\"_blank\"  href=\"" + urlValue + "\"><font color=blue>" + nameValue.Replace("接口", "<font color=red>接口</font>") + "</font></a>");
                    //sb.Append(" </div>");
                    //sb.Append(" <div style=\"font-size: 13px;\">");
                    //sb.Append(" <font size=2 >" + bodyValue.Replace("接口", "<font color=red>接口</font>") + "</font>");
                    //sb.Append(" </div>");
                    //sb.Append(" <div>");
                    //sb.Append(" <font color=#006600>" + urlValue + "</font>&nbsp;&nbsp;<font size=2 color=#006600>" + timeValue + "</font>&nbsp;&nbsp;<a target=\"_blank\" href=\"" + url + "\"><font size=2  color=#666699>Soso搜索</font></a>");
                    //sb.Append("  </div>");
                    //sb.Append(" </div>");
                }
                catch
                {
                    continue;
                }

                try
                {
                    DateTime dt = Convert.ToDateTime(timeValue);
                }
                catch
                {
                    timeValue = DateTime.Now.ToString("yyyy-MM-dd");
                }
                CnInterfaceInfo cnf = new CnInterfaceInfo
                {
                    CnInterfaceTypeID = 2,
                    CnInterfaceName = nameValue,
                    CnInterfacebody = bodyValue,
                    CnInterfaceUrl = urlValue,
                    CnInterfaceSource = "Soso搜索",
                    CnInterfaceSourceUrl = url,
                    CnInterfaceAppearTime = Convert.ToDateTime(timeValue)
                };
                InterfaceInfo IFI = new InterfaceInfo();
                int cont = IFI.InsertCnInterfaceInfo(cnf);
                if (cont > 0)
                    insertcount++;

                System.Threading.Thread.Sleep(200);
            }

            return insertcount;
        }
        #endregion

        #region 获取Sogou接口查询结果
        /// <summary>
        /// 获取Sogou接口查询结果
        /// </summary>
        /// <param name="html">网络地址</param>
        /// <returns>Sogou查询结果</returns>
        public static int GetCnInterfaceInfoFromSogou(string url)
        {
            int insertcount = 0;

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
            //StringBuilder sb = new StringBuilder();
            for (int i = 4; i <= 13; i++)
            {
                try
                {
                    string nameXpath = "/html[1]/body[1]/table[" + i .ToString()+ "]/tr[1]/td[1]/a[1]";
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
                        timeValue = timeValue.Substring(timeValue.LastIndexOf("20")).Replace("-->","");
                    }
                    catch
                    {
                        timeValue ="";
                    }

                    //sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px; width:678px\">");
                    //sb.Append(" <div>");
                    //sb.Append(" <a target=\"_blank\"  href=\"" + urlValue + "\"><font color=blue>" + nameValue.Replace("接口", "<font color=red>接口</font>") + "</font></a>");
                    //sb.Append(" </div>");
                    //sb.Append(" <div style=\"font-size: 13px;\">");
                    //sb.Append(" <font size=2 >" + bodyValue.Replace("接口", "<font color=red>接口</font>") + "</font>");
                    //sb.Append(" </div>");
                    //sb.Append(" <div>");
                    //sb.Append(" <font color=#006600>" + urlValue + "</font>&nbsp;&nbsp;<font size=2 color=#006600>" + timeValue + "</font>&nbsp;&nbsp;<a target=\"_blank\" href=\"" + url + "\"><font size=2  color=#666699>Sogou搜索</font></a>");
                    //sb.Append("  </div>");
                    //sb.Append(" </div>");
                }
                catch
                {
                    continue;
                }

                try
                {
                    DateTime dt = Convert.ToDateTime(timeValue);
                }
                catch
                {
                    timeValue = DateTime.Now.ToString("yyyy-MM-dd");
                }
                CnInterfaceInfo cnf = new CnInterfaceInfo
                {
                    CnInterfaceTypeID = 2,
                    CnInterfaceName = nameValue,
                    CnInterfacebody = bodyValue,
                    CnInterfaceUrl = urlValue,
                    CnInterfaceSource = "Sogou搜索",
                    CnInterfaceSourceUrl = url,
                    CnInterfaceAppearTime = Convert.ToDateTime(timeValue)
                };
                InterfaceInfo IFI = new InterfaceInfo();
                int cont = IFI.InsertCnInterfaceInfo(cnf);
                if (cont > 0)
                    insertcount++;

                System.Threading.Thread.Sleep(200);
            }

            return insertcount;
        }
        #endregion

        #region 获取有道接口查询结果
        /// <summary>
        /// 获取有道接口查询结果
        /// </summary>
        /// <param name="html">网络地址</param>
        /// <returns>有道查询结果</returns>
        public static int GetCnInterfaceInfoFromYoudao(string url)
        {
            int insertcount = 0;

            WebClient wc = new WebClient
            {
                Encoding = Encoding.GetEncoding("gb2312")
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
            //StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    string nameXpath = "/body[1]/div[6]/div[2]/ul[1]/li["+i.ToString()+"]/h3[1]/a[1]";
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

                    //sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px; width:678px\">");
                    //sb.Append(" <div>");
                    //sb.Append(" <a target=\"_blank\"  href=\"" + urlValue + "\"><font color=blue>" + nameValue.Replace("接口", "<font color=red>接口</font>") + "</font></a>");
                    //sb.Append(" </div>");
                    //sb.Append(" <div style=\"font-size: 13px;\">");
                    //sb.Append(" <font size=2 >" + bodyValue.Replace("接口", "<font color=red>接口</font>") + "</font>");
                    //sb.Append(" </div>");
                    //sb.Append(" <div>");
                    //sb.Append(" <font color=#006600>" + urlValue + "</font>&nbsp;&nbsp;<font size=2 color=#006600>" + timeValue + "</font>&nbsp;&nbsp;<a target=\"_blank\" href=\"" + url + "\"><font size=2  color=#666699>有道搜索</font></a>");
                    //sb.Append("  </div>");
                    //sb.Append(" </div>");
                }
                catch
                {
                    continue;
                }

                try
                {
                    DateTime dt = Convert.ToDateTime(timeValue);
                }
                catch
                {
                    timeValue = DateTime.Now.ToString("yyyy-MM-dd");
                }
                CnInterfaceInfo cnf = new CnInterfaceInfo
                {
                    CnInterfaceTypeID = 2,
                    CnInterfaceName = nameValue,
                    CnInterfacebody = bodyValue,
                    CnInterfaceUrl = urlValue,
                    CnInterfaceSource = "有道搜索",
                    CnInterfaceSourceUrl = url,
                    CnInterfaceAppearTime = Convert.ToDateTime(timeValue)
                };
                InterfaceInfo IFI = new InterfaceInfo();
                int cont = IFI.InsertCnInterfaceInfo(cnf);
                if (cont > 0)
                    insertcount++;

                System.Threading.Thread.Sleep(200);
            }

            return insertcount;
        }
        #endregion

        #region 获取狗狗接口查询结果
        /// <summary>
        /// 获取狗狗接口查询结果
        /// </summary>
        /// <param name="html">网络地址</param>
        /// <returns>狗狗查询结果</returns>
        public static int GetCnInterfaceInfoFromGougou(string url)
        {
            int insertcount = 0;

            WebClient wc = new WebClient
            {
                Encoding = Encoding.GetEncoding("gb2312")
            };
            string html = wc.DownloadString(url.Trim());

            //string html = "";
            //System.IO.StreamReader sr = new System.IO.StreamReader("D:\\CnInterface\\CnWeb\\html\\gougoucode.txt", Encoding.GetEncoding("gb2312"));
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
            //StringBuilder sb = new StringBuilder();
            for (int i = 2; i <= 27; i++)
            {
                try
                {
                    string nameXpath = "/html[1]/body[1]/div[10]/table[2]/tr[" + i .ToString()+ "]/td[2]/a[1]";
                    string urlXpath = "/html[1]/body[1]/div[10]/table[2]/tr[" + i.ToString() + "]/td[2]/a[1]/@href[1]";
                    string bodyXpath01 = "/html[1]/body[1]/div[10]/table[2]/tr[" + i.ToString() + "]/td[3]";
                    string bodyXpath02 = "/html[1]/body[1]/div[10]/table[2]/tr[" + i.ToString() + "]/td[4]";
                    string bodyXpath03 = "/html[1]/body[1]/div[10]/table[2]/tr[" + i.ToString() + "]/td[6]/a[1]";
                    string bodyXpath03href = "/html[1]/body[1]/div[10]/table[2]/tr[" + i.ToString() + "]/td[6]/a[1]/@href[1]";
                    string timeXpath = "/html[1]/body[1]/div[10]/table[2]/tr[" + i.ToString() + "]/td[5]";

                    nameValue = doc.DocumentNode.SelectSingleNode(nameXpath).InnerText;
                    nameValue = new HtmlToText().ConvertHtml(nameValue).Trim();
                    urlValue = doc.DocumentNode.SelectSingleNode(urlXpath).Attributes["href"].Value;
                    try
                    {
                        bodyValue = "此软件大小为"+doc.DocumentNode.SelectSingleNode(bodyXpath01).InnerText+"，";
                        bodyValue += "格式为" + doc.DocumentNode.SelectSingleNode(bodyXpath02).InnerText + "，";
                        bodyValue += "共收到评论<a href='" + doc.DocumentNode.SelectSingleNode(bodyXpath03href).Attributes["href"].Value + "' target='_blank'>" + doc.DocumentNode.SelectSingleNode(bodyXpath03).InnerText + "</a>";
                    }
                    catch
                    {
                        bodyValue = "";
                    }
                    try
                    {
                        timeValue = doc.DocumentNode.SelectSingleNode(timeXpath).InnerText;
                    }
                    catch
                    {
                        timeValue = "";
                    }

                    //sb.Append(" <div style=\"margin-top: 20px; margin-bottom: 20px; width:678px\">");
                    //sb.Append(" <div>");
                    //sb.Append(" <a target=\"_blank\"  href=\"" + urlValue + "\"><font color=blue>" + nameValue.Replace("接口", "<font color=red>接口</font>") + "</font></a>");
                    //sb.Append(" </div>");
                    //sb.Append(" <div style=\"font-size: 13px;\">");
                    //sb.Append(" <font size=2 >" + bodyValue.Replace("接口", "<font color=red>接口</font>") + "</font>");
                    //sb.Append(" </div>");
                    //sb.Append(" <div>");
                    //sb.Append(" <font color=#006600>" + urlValue + "</font>&nbsp;&nbsp;<font size=2 color=#006600>" + timeValue + "</font>&nbsp;&nbsp;<a target=\"_blank\" href=\"" + url + "\"><font size=2  color=#666699>狗狗搜索</font></a>");
                    //sb.Append("  </div>");
                    //sb.Append(" </div>");
                }
                catch
                {
                    continue;
                }

                try
                {
                    DateTime dt = Convert.ToDateTime(timeValue);
                }
                catch
                {
                    timeValue = DateTime.Now.ToString("yyyy-MM-dd");
                }
                CnInterfaceInfo cnf = new CnInterfaceInfo
                {
                    CnInterfaceTypeID = 2,
                    CnInterfaceName = nameValue,
                    CnInterfacebody = bodyValue,
                    CnInterfaceUrl = urlValue,
                    CnInterfaceSource = "狗狗搜索",
                    CnInterfaceSourceUrl = url,
                    CnInterfaceAppearTime = Convert.ToDateTime(timeValue)
                };
                InterfaceInfo IFI = new InterfaceInfo();
                int cont = IFI.InsertCnInterfaceInfo(cnf);
                if (cont > 0)
                    insertcount++;

                System.Threading.Thread.Sleep(200);
            }

            return insertcount;
        }
        #endregion
    }
}
