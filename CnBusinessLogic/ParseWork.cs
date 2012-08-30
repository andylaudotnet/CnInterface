using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace CnBusinessLogic
{
    public  class ParseWork
    {
          public int State = 0;//0-没有开始,1-正在运行,2-成功结束,3-失败结束 
          public int finishcount= 0;//完成记录数量
          public int Percent = 0;//完成百分比 
          public DateTime StartTime;//开始时间
          public DateTime FinishTime;//结束时间
          public DateTime ErrorTime; //出错时间
          public string ParseLogicstr="";//抓取日志
          private string _parsetype = "";

          public ParseWork()
          { }

          public ParseWork(string parsetype)
          {
              this._parsetype = parsetype;
          }

          public void runwork() 
          { 
              switch(_parsetype)
              {
                  case "baidu":
                   lock (this)
                   {
                       if (State != 1)
                       {
                           State = 1;
                           StartTime = DateTime.Now;
                           System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(DoGetBaiduInterface));
                           thread.Start();
                       }
                   }
                   break;
                  case "google":
                   lock (this)
                   {
                       if (State != 1)
                       {
                           State = 1;
                           StartTime = DateTime.Now;
                           System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(DoGetGoogleInterface));
                           thread.Start();
                       }
                   }
                   break;
                  case "yahoo":
                   lock (this)
                   {
                       if (State != 1)
                       {
                           State = 1;
                           StartTime = DateTime.Now;
                           System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(DoGetYahooInterface));
                           thread.Start();
                       }
                   }
                   break;
                  case "bing":
                   lock (this)
                   {
                       if (State != 1)
                       {
                           State = 1;
                           StartTime = DateTime.Now;
                           System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(DoGetBingInterface));
                           thread.Start();
                       }
                   }
                   break;
                  case "sogou":
                   lock (this)
                   {
                       if (State != 1)
                       {
                           State = 1;
                           StartTime = DateTime.Now;
                           System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(DoGetSogouInterface));
                           thread.Start();
                       }
                   }
                   break;
                  case "soso":
                   lock (this)
                   {
                       if (State != 1)
                       {
                           State = 1;
                           StartTime = DateTime.Now;
                           System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(DoGetSosoInterface));
                           thread.Start();
                       }
                   }
                   break;
                  case "youdao":
                   lock (this)
                   {
                       if (State != 1)
                       {
                           State = 1;
                           StartTime = DateTime.Now;
                           System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(DoGetYoudaoInterface));
                           thread.Start();
                       }
                   }
                   break;
                  case "gougou":
                   lock (this)
                   {
                       if (State != 1)
                       {
                           State = 1;
                           StartTime = DateTime.Now;
                           System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(DoGetGougouInterface));
                           thread.Start();
                       }
                   }
                   break;
                  case "huasky":
                   lock (this)
                   {
                       if (State != 1)
                       {
                           State = 1;
                           StartTime = DateTime.Now;
                           System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(DoAutomatismParse));
                           thread.Start();
                       }
                   }
                   break;
                  case "videohtml":
                   lock (this)
                   {
                       if (State != 1)
                       {
                           State = 1;
                           StartTime = DateTime.Now;
                           System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(DoParseVideos));
                           thread.Start();
                       }
                   }
                   break;
                  default:
                   break;
             }
          }

          #region 抓取百度接口信息
          private void DoGetBaiduInterface()
          {
              try
              {
                  for (int i = 0; i <= 90; i = i + 10)
                  {
                      string url = "http://www.baidu.com/s?wd=%BD%D3%BF%DA&pn=" + i.ToString() + "&usm=1";
                      int insertCount = ParseLogic.GetCnInterfaceInfoFromBaidu(url);
                      System.Threading.Thread.Sleep(1000);

                      finishcount += insertCount;
                      Percent += 10;
                  }
                  State = 2;
              }
              catch
              {
                  ErrorTime = DateTime.Now;
                  Percent = 0;
                  State = 3;
              }
              finally
              {
                  FinishTime = DateTime.Now;
                  Percent = 0;
              }
          }
          #endregion

          #region 抓取Google接口信息
          private void DoGetGoogleInterface()
          {
              try
              {
                  for (int i = 0; i <= 90; i = i + 10)
                  {
                      string url = "http://www.google.com.hk/search?hl=zh-CN&newwindow=1&safe=strict&q=%E6%8E%A5%E5%8F%A3&start=" + i.ToString() + "&sa=N";
                      int insertCount = ParseLogic.GetCnInterfaceInfoFromGoogle(url);
                      System.Threading.Thread.Sleep(1000);

                      finishcount += insertCount;
                      Percent += 10;
                  }
                  State = 2;
              }
              catch
              {
                  ErrorTime = DateTime.Now;
                  Percent = 0;
                  State = 3;
              }
              finally
              {
                  FinishTime = DateTime.Now;
                  Percent = 0;
              }
          }
          #endregion

          #region 抓取Yahoo接口信息
          private void DoGetYahooInterface()
          {
              try
              {
                  for (int i = 0; i <= 90; i = i + 10)
                  {
                      string url = "http://one.cn.yahoo.com/s?p=%E6%8E%A5%E5%8F%A3&pid=hp&v=web&b=" + i.ToString();
                      int insertCount = ParseLogic.GetCnInterfaceInfoFromYahoo(url, i);
                      System.Threading.Thread.Sleep(1000);

                      finishcount += insertCount;
                      Percent += 10;
                  }
                  State = 2;
              }
              catch
              {
                  ErrorTime = DateTime.Now;
                  Percent = 0;
                  State = 3;
              }
              finally
              {
                  FinishTime = DateTime.Now;
                  Percent = 0;
              }
          }
          #endregion

          #region 抓取Bing接口信息
          private void DoGetBingInterface()
          {
              try
              {
                  for (int i = 1; i <= 90; i = i + 10)
                  {
                      string url = "http://cn.bing.com/search?q=%E6%8E%A5%E5%8F%A3&scope=web&filt=all&first=" + i.ToString() + "&FORM=PERE";
                      int insertCount = ParseLogic.GetCnInterfaceInfoFromBing(url, i);
                      System.Threading.Thread.Sleep(1000);

                      finishcount += insertCount;
                      Percent += 10;
                  }
                  State = 2;
              }
              catch
              {
                  ErrorTime = DateTime.Now;
                  Percent = 0;
                  State = 3;
              }
              finally
              {
                  FinishTime = DateTime.Now;
                  Percent = 0;
              }
          }
          #endregion

          #region 抓取Sogou接口信息
          private void DoGetSogouInterface()
          {
              try
              {
                  for (int i = 1; i <= 10; i++)
                 {
                      string url = "http://www.sogou.com/web?num=10&query=%BD%D3%BF%DA&page="+i.ToString()+"&w=01029901&dr=1&_asf=www.sogou.com&_ast=1270712320";
                      int insertCount = ParseLogic.GetCnInterfaceInfoFromSogou(url);
                      System.Threading.Thread.Sleep(1000);

                      finishcount += insertCount;
                      Percent += 10;
                  }
                  State = 2;
              }
              catch
              {
                  ErrorTime = DateTime.Now;
                  Percent = 0;
                  State = 3;
              }
              finally
              {
                  FinishTime = DateTime.Now;
                  Percent = 0;
              }
          }
          #endregion

          #region 抓取Soso接口信息
          private void DoGetSosoInterface()
          {
              try
              {
                  for (int i = 1; i <= 10; i++)
                  {
                      string url = "http://www.soso.com/q?w=%BD%D3%BF%DA&lr=&sc=web&ch=w.p&num=10&gid=&cin=&site=&sf=&sd=&pg=" + i.ToString();
                      int insertCount = ParseLogic.GetCnInterfaceInfoFromSoso(url);
                      System.Threading.Thread.Sleep(1000);

                      finishcount += insertCount;
                      Percent += 10;
                  }
                  State = 2;
              }
              catch
              {
                  ErrorTime = DateTime.Now;
                  Percent = 0;
                  State = 3;
              }
              finally
              {
                  FinishTime = DateTime.Now;
                  Percent = 0;
              }
          }
          #endregion

          #region 抓取Youdao接口信息
          private void DoGetYoudaoInterface()
          {
              try
              {
                  for (int i = 0; i < 10; i++)
                  {
                      string url = "http://www.youdao.com/search?q=%E6%8E%A5%E5%8F%A3&start=" + i.ToString() + "&ue=utf8&keyfrom=web.page1&lq=%E6%8E%A5%E5%8F%A3&timesort=0";
                      int insertCount = ParseLogic.GetCnInterfaceInfoFromYoudao(url);
                      System.Threading.Thread.Sleep(1000);

                      finishcount += insertCount;
                      Percent += 10;
                  }
                  State = 2;
              }
              catch
              {
                  ErrorTime = DateTime.Now;
                  Percent = 0;
                  State = 3;
              }
              finally
              {
                  FinishTime = DateTime.Now;
                  Percent = 0;
              }
          }
          #endregion

          #region 抓取Gougou接口信息
          private void DoGetGougouInterface()
          {
              try
              {
                  for (int i = 1; i <= 5; i++)
                  {
                      string url = "http://www.gougou.com/search?search=%e6%8e%a5%e5%8f%a3&restype=-1&sortby=8&suffix=1&page=" + i.ToString() + "&id=10000001&f=0&r=0&ty=0&b=0&pattern=0&al=&m=0&st=-1&imask=1&xmp=0&fl=0&w=0&z=0";
                      int insertCount = ParseLogic.GetCnInterfaceInfoFromGougou(url);
                      System.Threading.Thread.Sleep(1000);

                      finishcount += insertCount;
                      Percent += 20;
                  }
                  State = 2;
              }
              catch
              {
                  ErrorTime = DateTime.Now;
                  Percent = 0;
                  State = 3;
              }
              finally
              {
                  FinishTime = DateTime.Now;
                  Percent = 0;
              }
          }
          #endregion

          #region 抓取华军和天空接口信息
          private void DoAutomatismParse() 
          { 
               try 
               {
                   int insertcount = 0;
                   for (int i = 1; i <= 2; i++)
                   {
                           WebClient wc = new WebClient
                           {
                               Encoding = Encoding.GetEncoding(65001)
                           };
                           string url = "http://search.newhua.com/search_list.php?searchname=%E6%8E%A5%E5%8F%A3&t=yearip&page=" + i.ToString();
                           string cnurlxp = "/html[1]/body[1]/div[1]/div[1]/div[3]/div[5]/div[1]/div[1]/dl[1]/dd[1]/div[cnface]/strong[1]/a[1]/@href[1]";
                           string cnurlRgx = "";
                           string cnnamexp = "/html[1]/body[1]/div[1]/div[1]/div[3]/div[5]/div[1]/div[1]/dl[1]/dd[1]/div[cnface]/strong[1]/a[1]";
                           string cnnameRgx = "";
                           string cnbodyXp = "/html[1]/body[1]/div[1]/div[1]/div[3]/div[5]/div[1]/div[1]/dl[1]/dd[1]/p[cnface]";
                           string cnbodyRgx = "";
                           string cntimeXp = "/html[1]/body[1]/div[1]/div[1]/div[3]/div[5]/div[1]/div[1]/dl[1]/dd[1]/h4[cnface]";
                           string cntimeRgx = "";
                           string cntimeF = "";
                           string cnsource = "华军软件园";
                           string cnsourceurl = "http://www.newhua.com/";
                           int cntypeid = 2;
                           int sourceno = 1;
                           int pagesize = 20;
                           insertcount += ParseLogic.GetCnInterfaceInfoEntity(wc, url, cnurlxp, cnurlRgx, cnnamexp, cnnameRgx, cnbodyXp, cnbodyRgx, cntimeXp, cntimeRgx, cntimeF, cnsource, cnsourceurl, cntypeid, sourceno, pagesize);
                      
                           finishcount += insertcount;
                           Percent +=25;
                   }
                   System.Threading.Thread.Sleep(1000);
                   for (int i = 1; i <= 2; i++)
                   {
                       WebClient wc = new WebClient
                       {
                           Encoding = Encoding.GetEncoding(936)
                       };
                       string url = "http://www.skycn.com/search.php?ss_name=%BD%D3%BF%DA&get=down_times&sf=&page=" + i.ToString();
                       string cnurlxp = "/html[1]/body[1]/div[4]/div[3]/div[1]/div[1]/dl[1]/dt[cnface]/a[1]/@href[1]";
                       string cnurlRgx = "";
                       string cnnamexp = "/html[1]/body[1]/div[4]/div[3]/div[1]/div[1]/dl[1]/dt[cnface]/a[1]/@title[1]";
                       string cnnameRgx = "";
                       string cnbodyXp = "/html[1]/body[1]/div[4]/div[3]/div[1]/div[1]/dl[1]/dd[cnface]/p[1]";
                       string cnbodyRgx = "";
                       string cntimeXp = "/html[1]/body[1]/div[4]/div[3]/div[1]/div[1]/dl[1]/dd[cnface]";
                       string cntimeRgx = "更新时间：(.*?)<i>";
                       string cntimeF = "";
                       string cnsource = "天空软件站";
                       string cnsourceurl = "http://www.skycn.com/";
                       int cntypeid = 2;
                       int sourceno = 2;
                       int pagesize = 20;
                       insertcount += ParseLogic.GetCnInterfaceInfoEntity(wc, url, cnurlxp, cnurlRgx, cnnamexp, cnnameRgx, cnbodyXp, cnbodyRgx, cntimeXp, cntimeRgx, cntimeF, cnsource, cnsourceurl, cntypeid, sourceno, pagesize);

                       finishcount += insertcount;
                       Percent += 25;
                   } 
                    State=2; 
               } 
               catch 
               { 
                    ErrorTime=DateTime.Now; 
                    Percent=0; 
                    State=3; 
               } 
               finally 
               { 
                    FinishTime=DateTime.Now; 
                    Percent=0; 
               }
          }
          #endregion

          #region 抓取生成视频html
          private void DoParseVideos()
          {
              try
              {
                  StringBuilder sb = new StringBuilder();
                  VideoHtmlCreate vc = new VideoHtmlCreate();
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("17173"), "", "", "src", "", "", "17173Videos"); sb.Append("17173=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("17173=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 4; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("56"), "", "alt", "src", "", "", "56Videos"); sb.Append("<br>56=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>56=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 3; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("6cn"), "", "alt", "src", "", "", "6cnVideos"); sb.Append("<br>6cn=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>6cn=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 4; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("baidu"), "", "", "src", "", "", "BaiduVideos"); sb.Append("<br>baidu=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>baidu=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 4; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("cntv"), "", "", "src", "", "", "CntvVideos"); sb.Append("<br>cntv=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>cntv=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 4; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("hunantv"), "title", "", "src", "http://tv.hunantv.com/", "", "HunantvVideos"); sb.Append("<br>hunantv=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>hunantv=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 4; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("ifeng"), "", "", "src", "", "../img/cninterface.jpg", "IfengVideos"); sb.Append("<br>ifeng=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>ifeng=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 4; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("ku6"), "", "", "src", "", "", "Ku6Videos"); sb.Append("<br>ku6=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>ku6=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 4; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("news"), "", "", "src", "", "http://www.news.cn/video/", "NewsVideos"); sb.Append("<br>news=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>news=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 3; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("openv"), "", "alt", "src", "http://hd.openv.com/", "", "OpenvVideos"); sb.Append("<br>openv=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>openv=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 3; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("qq"), "", "", "src", "", "", "QQVideos"); sb.Append("<br>qq=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>qq=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 4; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("sina"), "", "alt", "src", "", "", "SinaVideos"); sb.Append("<br>sina=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>sina=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 4; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("sohu"), "", "alt", "src", "", "../img/cninterface.jpg", "SohuVideos"); sb.Append("<br>sohu=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>sohu=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 3; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("tencent"), "", "alt", "src", "", "", "TencentVideos"); sb.Append("<br>tencent=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>tencent=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 4; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("tudou"), "title", "", "src", "", "", "TudouVideos"); sb.Append("<br>tudou=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>tudou=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 4; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("xunlei"), "", "alt", "src", "", "", "XunleiVideos"); sb.Append("<br>xunlei=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>xunlei=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 4; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("youku"), "", "", "src", "", "", "YoukuVideos"); sb.Append("<br>youku=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>youku=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 4; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("pps"), "", "", "src", "", "", "PPSVideos"); sb.Append("<br>pps=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>pps=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 3; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("pplive"), "", "alt", "src2", "", "", "PPLiveVideos"); sb.Append("<br>pplive=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>pplive=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 3; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("uusee"), "", "", "src", "", "", "UUseeVideos"); sb.Append("<br>uusee=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>uusee=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 2; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("m1905"), "", "", "src", "http://www.m1905.com/", "", "M1905Videos"); sb.Append("<br>m1905=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>m1905=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 3; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("funshion"), "", "", "src", "", "", "FunshionVideos"); sb.Append("<br>funshion=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>funshion=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 4; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("joy"), "", "", "src", "", "", "joyVideos"); sb.Append("<br>joy=<font color='green'>ok</font>"); }
                  catch (Exception ex) { sb.Append("<br>joy=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 2; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("pomoho"), "", "", "src", "", "", "PomohoVideos"); sb.Append("<br>pomoho=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>pomoho=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 4; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("letv"), "", "", "src", "", "", "LetvVideos"); sb.Append("<br>letv=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>letv=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 3; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("aeeboo"), "", "", "src", "", "", "AeebooVideos"); sb.Append("<br>aeeboo=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>aeeboo=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 4; }
                  try { vc.GetWebVideoHtml(CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName("google"), "", "", "src", "", "", "GoogleVideos"); sb.Append("<br>google=<font color='green'>ok</font>"); finishcount += 1; }
                  catch (Exception ex) { sb.Append("<br>google=<font color='red'>" + ex.Message + "</font>"); }
                  finally { Percent += 4; }

                  ParseLogicstr = sb.ToString();
                  State = 2;
              }
              catch
              {
                  ErrorTime = DateTime.Now;
                  Percent = 0;
                  State = 3;
              }
              finally
              {
                  FinishTime = DateTime.Now;
                  Percent = 0;
              }
          }
          #endregion
    }
}
