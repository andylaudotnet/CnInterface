using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using CnDataAcess.Entity;
using CnBusinessLogic;

namespace CnWeb.Parse
{
    public partial class ParseXPathManage : System.Web.UI.Page
    {
        protected string WebName = "youku";
        protected string WebUrl = "http://www.youku.com";
        protected string WebEncode = "utf-8";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || CnInterfaceUser.GetUserLevel(Session["username"].ToString().Trim())!=1)
            {
                Response.Redirect("~/Index.aspx");
            }
            if (!IsPostBack)
            {
                if (Request["web"] != null)
                {
                    SetWebNameAndUrl(Request["web"].ToString().Trim());
                    GetWebXpath(Request["web"].ToString().Trim());
                }
                else
                {
                    Response.Redirect("ParseWebList.aspx");
                }
            }
        }

        #region 设置网站名称和地址及编码
        private void SetWebNameAndUrl(string web)
        {
            switch (web)
            {
                case "aeeboo":
                    WebName = "爱播网";
                    WebUrl = "http://www.aeeboo.com/";
                    WebEncode = "utf-8";
                    break;
                case "letv":
                    WebName = "乐视网";
                    WebUrl = "http://www.letv.com/";
                    WebEncode = "utf-8";
                    break;
                case "pomoho":
                    WebName = "爆米花";
                    WebUrl = "http://www.pomoho.com/";
                    WebEncode = "utf-8";
                    break;
                case "google":
                    WebName = "Google视频搜索";
                    WebUrl = "http://video.google.cn/";
                    WebEncode = "UTF-8";
                    break;
                case "youku":
                    WebName = "优酷网";
                    WebUrl = "http://www.youku.com/";
                    WebEncode = "utf-8";
                    break;
                case "tudou":
                    WebName = "土豆网";
                    WebUrl = "http://www.tudou.com/";
                    WebEncode = "gbk";
                    break;
                case "baidu":
                    WebName = "百度视频搜索";
                    WebUrl = "http://video.baidu.com/";
                    WebEncode = "gb2312";
                    break;
                case "xunlei":
                    WebName = "迅雷看看";
                    WebUrl = "http://www.xunlei.com/";
                    WebEncode = "utf-8";
                    break;
                case "joy":
                    WebName = "激动网";
                    WebUrl = "http://www.joy.cn/";
                    WebEncode = "gb2312";
                    break;
                case "sina":
                    WebName = "新浪视频";
                    WebUrl = "http://video.sina.com.cn/";
                    WebEncode = "gb2312";
                    break;
                case "ku6":
                    WebName = "酷6视频";
                    WebUrl = "http://www.ku6.com/";
                    WebEncode = "gb2312";
                    break;
                case "sohu":
                    WebName = "搜狐视频";
                    WebUrl = "http://tv.sohu.com/";
                    WebEncode = "GBK";
                    break;
                case "qq":
                    WebName = "QQ播客";
                    WebUrl = "http://video.qq.com/";
                    WebEncode = "utf-8";
                    break;
                case "hunantv":
                    WebName = "芒果TV";
                    WebUrl = "http://tv.hunantv.com/";
                    WebEncode = "utf-8";
                    break;
                case "tencent":
                    WebName = "腾讯宽频";
                    WebUrl = "http://bb.news.qq.com/";
                    WebEncode = "gb2312";
                    break;
                case "6cn":
                    WebName = "六间房";
                    WebUrl = "http://6.cn/";
                    WebEncode = "utf-8";
                    break;
                case "ifeng":
                    WebName = "凤凰宽频";
                    WebUrl = "http://v.ifeng.com/";
                    WebEncode = "utf-8";
                    break;
                case "news":
                    WebName = "新华网";
                    WebUrl = "http://www.news.cn/video/index.htm";
                    WebEncode = "utf-8";
                    break;
                case "56":
                    WebName = "56网";
                    WebUrl = "http://www.56.com/";
                    WebEncode = "GB2312";
                    break;
                case "pps":
                    WebName = "PPS";
                    WebUrl = "http://www.pps.tv/";
                    WebEncode = "gb2312";
                    break;
                case "pplive":
                    WebName = "PPLive";
                    WebUrl = "http://www.pptv.com/";
                    WebEncode = "utf-8";
                    break;
                case "funshion":
                    WebName = "风行";
                    WebUrl = "http://www.funshion.com/";
                    WebEncode = "utf-8";
                    break;
                case "uusee":
                    WebName = "UUsee";
                    WebUrl = "http://www.uusee.com/";
                    WebEncode = "utf-8";
                    break;
                case "m1905":
                    WebName = "m1905电影网";
                    WebUrl = "http://www.m1905.com/";
                    WebEncode = "utf-8";
                    break;
                case "openv":
                    WebName = "天线高清";
                    WebUrl = "http://hd.openv.com/";
                    WebEncode = "utf-8";
                    break;
                case "17173":
                    WebName = "17173游戏视频";
                    WebUrl = "http://media.17173.com/";
                    WebEncode = "gb2312";
                    break;
                case "cntv":
                    WebName = "中国网络电视台";
                    WebUrl = "http://www.cntv.cn/";
                    WebEncode = "gbk";
                    break;
                default:
                    WebName = "youku";
                    WebUrl = "http://www.youku.com";
                    WebEncode = "utf-8";
                    break;
            }
        }
        #endregion

        private void GetWebXpath(string web)
        {
            CnDataAcess.Entity.CnInterfaceVideoXpath cnXpath= CnBusinessLogic.CnInterfaceVideoXpath.GetVideoXpathByWebName(web);
            if (cnXpath != null)
            {
                WebClient wc = new WebClient
                {
                    Encoding = Encoding.GetEncoding(WebEncode)
                };
                string html = "";
                txtWebAddress.Text = cnXpath.CnWebUrl;
                txtWebEncode.Text = cnXpath.CnWebEncode;
                try
                {
                    html=wc.DownloadString(WebUrl);
                }
                catch { 
                    txtWebAddress.ForeColor = System.Drawing.Color.Red;
                    txtWebEncode.ForeColor = System.Drawing.Color.Red; 
                }
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);

                string title001 = cnXpath.CnVideoTitle001;
                txtTitle001.Text = title001;
                try {
                    if (title001.IndexOf("@alt") > -1)
                    {
                        string strTemp = doc.DocumentNode.SelectSingleNode(title001).Attributes["alt"].Value;
                    }
                    else if (title001.IndexOf("@title") > -1)
                    {
                        string strTemp = doc.DocumentNode.SelectSingleNode(title001).Attributes["title"].Value;
                    }
                    else
                    {
                        string strTemp = doc.DocumentNode.SelectSingleNode(title001).InnerText;
                    }
                }
                catch { txtTitle001.ForeColor = System.Drawing.Color.Red; }
                string href001 = cnXpath.CnVideoHref001;
                txtHref001.Text = href001;
                try { string strTemp = doc.DocumentNode.SelectSingleNode(href001).Attributes["href"].Value; }
                catch { txtHref001.ForeColor = System.Drawing.Color.Red; }
                string src001 = cnXpath.CnVideoSrc001;
                txtSrc001.Text = src001;
                try { string strTemp = doc.DocumentNode.SelectSingleNode(src001).Attributes["src"].Value; }
                catch { txtSrc001.ForeColor = System.Drawing.Color.Red; }

                string title002 = cnXpath.CnVideoTitle002; 
                txtTitle002.Text = title002;
                try
                {
                    if (title002.IndexOf("@alt") > -1)
                    {
                        string strTemp = doc.DocumentNode.SelectSingleNode(title002).Attributes["alt"].Value;
                    }
                    else if (title002.IndexOf("@title") > -1)
                    {
                        string strTemp = doc.DocumentNode.SelectSingleNode(title002).Attributes["title"].Value;
                    }
                    else
                    {
                        string strTemp = doc.DocumentNode.SelectSingleNode(title002).InnerText;
                    }
                }
                catch { txtTitle002.ForeColor = System.Drawing.Color.Red; }
                string href002 =  cnXpath.CnVideoHref002;
                txtHref002.Text = href002;
                try { string strTemp = doc.DocumentNode.SelectSingleNode(href002).Attributes["href"].Value; }
                catch { txtHref002.ForeColor = System.Drawing.Color.Red; }
                string src002 = cnXpath.CnVideoSrc002; 
                txtSrc002.Text = src002;
                try { string strTemp = doc.DocumentNode.SelectSingleNode(src002).Attributes["src"].Value; }
                catch { txtSrc002.ForeColor = System.Drawing.Color.Red; }

                string title003 = cnXpath.CnVideoTitle003; 
                txtTitle003.Text = title003;
                try
                {
                    if (title003.IndexOf("@alt") > -1)
                    {
                        string strTemp = doc.DocumentNode.SelectSingleNode(title003).Attributes["alt"].Value;
                    }
                    else if (title003.IndexOf("@title") > -1)
                    {
                        string strTemp = doc.DocumentNode.SelectSingleNode(title003).Attributes["title"].Value;
                    }
                    else
                    {
                        string strTemp = doc.DocumentNode.SelectSingleNode(title003).InnerText;
                    }
                }
                catch { txtTitle003.ForeColor = System.Drawing.Color.Red; }
                string href003 = cnXpath.CnVideoHref003; 
                txtHref003.Text = href003;
                try { string strTemp = doc.DocumentNode.SelectSingleNode(href003).Attributes["href"].Value; }
                catch { txtHref003.ForeColor = System.Drawing.Color.Red; }
                string src003 = cnXpath.CnVideoSrc003; 
                txtSrc003.Text = src003;
                try { string strTemp = doc.DocumentNode.SelectSingleNode(src003).Attributes["src"].Value; }
                catch { txtSrc003.ForeColor = System.Drawing.Color.Red; }

                string title004 = cnXpath.CnVideoTitle004; 
                txtTitle004.Text = title004;
                try
                {
                    if (title004.IndexOf("@alt") > -1)
                    {
                        string strTemp = doc.DocumentNode.SelectSingleNode(title004).Attributes["alt"].Value;
                    }
                    else if (title004.IndexOf("@title") > -1)
                    {
                        string strTemp = doc.DocumentNode.SelectSingleNode(title004).Attributes["title"].Value;
                    }
                    else
                    {
                        string strTemp = doc.DocumentNode.SelectSingleNode(title004).InnerText;
                    }
                }
                catch { txtTitle004.ForeColor = System.Drawing.Color.Red; }
                string href004 =cnXpath.CnVideoHref004; 
                txtHref004.Text = href004;
                try { string strTemp = doc.DocumentNode.SelectSingleNode(href004).Attributes["href"].Value; }
                catch { txtHref004.ForeColor = System.Drawing.Color.Red; }
                string src004 = cnXpath.CnVideoSrc004; 
                txtSrc004.Text = src004;
                try { string strTemp = doc.DocumentNode.SelectSingleNode(src004).Attributes["src"].Value; }
                catch { txtSrc004.ForeColor = System.Drawing.Color.Red; }

                string title005 =  cnXpath.CnVideoTitle005;
                txtTitle005.Text = title005;
                try
                {
                    if (title005.IndexOf("@alt") > -1)
                    {
                        string strTemp = doc.DocumentNode.SelectSingleNode(title005).Attributes["alt"].Value;
                    }
                    else if (title005.IndexOf("@title") > -1)
                    {
                        string strTemp = doc.DocumentNode.SelectSingleNode(title005).Attributes["title"].Value;
                    }
                    else
                    {
                        string strTemp = doc.DocumentNode.SelectSingleNode(title005).InnerText;
                    }
                }
                catch { txtTitle005.ForeColor = System.Drawing.Color.Red; }
                string href005 = cnXpath.CnVideoHref005; 
                txtHref005.Text = href005;
                try { string strTemp = doc.DocumentNode.SelectSingleNode(href005).Attributes["href"].Value; }
                catch { txtHref005.ForeColor = System.Drawing.Color.Red; }
                string src005 = cnXpath.CnVideoSrc005; 
                txtSrc005.Text = src005;
                try { string strTemp = doc.DocumentNode.SelectSingleNode(src005).Attributes["src"].Value; }
                catch { txtSrc005.ForeColor = System.Drawing.Color.Red; }

                string title006 = cnXpath.CnVideoTitle006; 
                txtTitle006.Text = title006;
                try
                {
                    if (title006.IndexOf("@alt") > -1)
                    {
                        string strTemp = doc.DocumentNode.SelectSingleNode(title006).Attributes["alt"].Value;
                    }
                    else if (title006.IndexOf("@title") > -1)
                    {
                        string strTemp = doc.DocumentNode.SelectSingleNode(title006).Attributes["title"].Value;
                    }
                    else
                    {
                        string strTemp = doc.DocumentNode.SelectSingleNode(title006).InnerText;
                    }
                }
                catch { txtTitle006.ForeColor = System.Drawing.Color.Red; }
                string href006 =  cnXpath.CnVideoHref006;
                txtHref006.Text = href006;
                try { string strTemp = doc.DocumentNode.SelectSingleNode(href006).Attributes["href"].Value; }
                catch { txtHref006.ForeColor = System.Drawing.Color.Red; }
                string src006 = cnXpath.CnVideoSrc006; 
                txtSrc006.Text = src006;
                try { string strTemp = doc.DocumentNode.SelectSingleNode(src006).Attributes["src"].Value; }
                catch { txtSrc006.ForeColor = System.Drawing.Color.Red; }
            }
            if (Request["update"] != null && Request["update"].ToString().Equals("ok"))
            {
                labUpdateResult.Text = "<font color='green'><b>数据库更新成功！</b></font>";
            }
        }

        protected void btnXpathUpdae_Click(object sender, EventArgs e)
        {
            try
            {
                CnDataAcess.Entity.CnInterfaceVideoXpath cnXpath = new CnDataAcess.Entity.CnInterfaceVideoXpath();
                cnXpath.CnWebName = Request["web"].ToString().Trim();
                cnXpath.CnWebUrl = txtWebAddress.Text.Trim();
                cnXpath.CnWebEncode = txtWebEncode.Text.Trim();
                cnXpath.CnVideoTitle001 = txtTitle001.Text.Trim();
                cnXpath.CnVideoHref001 = txtHref001.Text.Trim();
                cnXpath.CnVideoSrc001 = txtSrc001.Text.Trim();
                cnXpath.CnVideoTitle002 = txtTitle002.Text.Trim();
                cnXpath.CnVideoHref002 = txtHref002.Text.Trim();
                cnXpath.CnVideoSrc002 = txtSrc002.Text.Trim();
                cnXpath.CnVideoTitle003 = txtTitle003.Text.Trim();
                cnXpath.CnVideoHref003 = txtHref003.Text.Trim();
                cnXpath.CnVideoSrc003 = txtSrc003.Text.Trim();
                cnXpath.CnVideoTitle004 = txtTitle004.Text.Trim();
                cnXpath.CnVideoHref004 = txtHref004.Text.Trim();
                cnXpath.CnVideoSrc004 = txtSrc004.Text.Trim();
                cnXpath.CnVideoTitle005 = txtTitle005.Text.Trim();
                cnXpath.CnVideoHref005 = txtHref005.Text.Trim();
                cnXpath.CnVideoSrc005 = txtSrc005.Text.Trim();
                cnXpath.CnVideoTitle006 = txtTitle006.Text.Trim();
                cnXpath.CnVideoHref006 = txtHref006.Text.Trim();
                cnXpath.CnVideoSrc006 = txtSrc006.Text.Trim();
                int resultCount = 0;
                resultCount = CnBusinessLogic.CnInterfaceVideoXpath.UpdateCnInterfaceVideo(cnXpath);
                if (resultCount > 0)
                {
                    Response.Redirect("ParseXPathManage.aspx?update=ok&web="+Request["web"].ToString().Trim());
                }
                else
                {
                    labUpdateResult.Text = "<font color='red'><b>数据库更新失败！</b></font>";
                }
            }
            catch (Exception ex)
            {
                labUpdateResult.Text = "<font color='red'><b>数据库更新失败！</b></font><font color='#666699'>" + ex.Message + "</font>";
            }
        }
    }
}
