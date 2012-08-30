using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace CnWeb
{
    public partial class Page1Result : System.Web.UI.Page
    {
        protected int WebCount = 0;
        protected string SearchTime = "0.000";
        protected string gb2312Encode = "";
        protected string utf8Encode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["webname"] != null && Request["word"] != null)
            {
                ASYSearchResult(Request["webname"].ToString().Trim(), Request["word"].ToString().Trim());
            }
            if (!IsPostBack)
            {
                    txtSearchWord.Value = Server.UrlDecode(Request["searchword"].ToString());
                    string web = Request["web"].ToString();
                    DateTime dt1 = DateTime.Now;

                    SetWebShow(web);
                    DivSearchResults.InnerHtml = GetDataBySearchWord(txtSearchWord.Value.Trim(),web);

                    DateTime dt2 = DateTime.Now;
                    TimeSpan ts = dt2 - dt1;
                    double timeuse = Convert.ToInt32(ts.TotalMilliseconds) * 0.001;
                    SearchTime = timeuse.ToString();
                    if (timeuse == 0)
                        SearchTime = "0.003";
                }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!txtSearchWord.Value.Trim().Equals(""))
            {
                Response.Redirect("Page1Result.aspx?web=" + hiddenwebName .Value.Trim()+ "&searchword=" + Server.UrlEncode(txtSearchWord.Value));
            }
            else
            {
                txtSearchWord.Focus();
            }
        }

        private void ASYSearchResult(string webname,string word)
        {
            System.Threading.Thread.Sleep(300);
            CnBusinessLogic.Page1Search CP = new CnBusinessLogic.Page1Search();
            StringBuilder sb = new StringBuilder();
            switch (webname)
            {
                case "baidu":
                    sb.Append(CP.GetSearchResultFromBaidu(word));
                    break;
                case "google":
                    sb.Append(CP.GetSearchResultFromGoogle(word));
                    break;
                case "yahoo":
                    sb.Append(CP.GetSearchResultFromYahoo(word));
                    break;
                case "bing":
                    sb.Append(CP.GetSearchResultFromBing(word));
                    break;
                case "sogou":
                    sb.Append(CP.GetSearchResultFromSogou(word));
                    break;
                case "soso":
                    sb.Append(CP.GetSearchResultFromSoso(word));
                    break;
                case "youdao":
                    sb.Append(CP.GetSearchResultFromYoudao(word));
                    break;
                default:
                    sb.Append("未找到符合要求的数据。");
                    break;
            }
            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }

        #region 设置web显示
        private void SetWebShow(string web)
        {
            string showname="";
            switch (web) {
            case "aall":
                showname = "全部";
                abaidu.InnerHtml = "<font size=2  color='#666699'>百度</font>";
                agoogle.InnerHtml = "<font size=2  color='#666699'>Google</font>";
                ayahoo.InnerHtml = "<font size=2  color='#666699'>雅虎</font>";
                abing.InnerHtml = "<font size=2  color='#666699'>Bing</font>";
                asogou.InnerHtml = "<font size=2  color='#666699'>搜狗</font>";
                asoso.InnerHtml = "<font size=2  color='#666699'>搜搜</font>";
                ayoudao.InnerHtml = "<font size=2  color='#666699'>有道</font>";
                break;
            case "abaidu":
                showname = "百度";
                aall.InnerHtml = "<font size=2  color='#666699'>全部</font>";
                agoogle.InnerHtml = "<font size=2  color='#666699'>Google</font>";
                ayahoo.InnerHtml = "<font size=2  color='#666699'>雅虎</font>";
                abing.InnerHtml = "<font size=2  color='#666699'>Bing</font>";
                asogou.InnerHtml = "<font size=2  color='#666699'>搜狗</font>";
                asoso.InnerHtml = "<font size=2  color='#666699'>搜搜</font>";
                ayoudao.InnerHtml = "<font size=2  color='#666699'>有道</font>";
                break;
            case "agoogle":
                showname = "Google";
                abaidu.InnerHtml = "<font size=2  color='#666699'>百度</font>";
                aall.InnerHtml = "<font size=2  color='#666699'>全部</font>";
                ayahoo.InnerHtml = "<font size=2  color='#666699'>雅虎</font>";
                abing.InnerHtml = "<font size=2  color='#666699'>Bing</font>";
                asogou.InnerHtml = "<font size=2  color='#666699'>搜狗</font>";
                asoso.InnerHtml = "<font size=2  color='#666699'>搜搜</font>";
                ayoudao.InnerHtml = "<font size=2  color='#666699'>有道</font>";
                break;
            case "ayahoo":
                showname = "雅虎";
                abaidu.InnerHtml = "<font size=2  color='#666699'>百度</font>";
                agoogle.InnerHtml = "<font size=2  color='#666699'>Google</font>";
                aall.InnerHtml = "<font size=2  color='#666699'>全部</font>";
                abing.InnerHtml = "<font size=2  color='#666699'>Bing</font>";
                asogou.InnerHtml = "<font size=2  color='#666699'>搜狗</font>";
                asoso.InnerHtml = "<font size=2  color='#666699'>搜搜</font>";
                ayoudao.InnerHtml = "<font size=2  color='#666699'>有道</font>";
                break;
            case "abing":
                showname = "Bing";
                abaidu.InnerHtml = "<font size=2  color='#666699'>百度</font>";
                agoogle.InnerHtml = "<font size=2  color='#666699'>Google</font>";
                ayahoo.InnerHtml = "<font size=2  color='#666699'>雅虎</font>";
                aall.InnerHtml = "<font size=2  color='#666699'>全部</font>";
                asogou.InnerHtml = "<font size=2  color='#666699'>搜狗</font>";
                asoso.InnerHtml = "<font size=2  color='#666699'>搜搜</font>";
                ayoudao.InnerHtml = "<font size=2  color='#666699'>有道</font>";
                break;
            case "asogou":
                showname = "搜狗";
                abaidu.InnerHtml = "<font size=2  color='#666699'>百度</font>";
                agoogle.InnerHtml = "<font size=2  color='#666699'>Google</font>";
                ayahoo.InnerHtml = "<font size=2  color='#666699'>雅虎</font>";
                abing.InnerHtml = "<font size=2  color='#666699'>Bing</font>";
                aall.InnerHtml = "<font size=2  color='#666699'>全部</font>";
                asoso.InnerHtml = "<font size=2  color='#666699'>搜搜</font>";
                ayoudao.InnerHtml = "<font size=2  color='#666699'>有道</font>";
                break;
            case "asoso":
                showname = "搜搜";
                abaidu.InnerHtml = "<font size=2  color='#666699'>百度</font>";
                agoogle.InnerHtml = "<font size=2  color='#666699'>Google</font>";
                ayahoo.InnerHtml = "<font size=2  color='#666699'>雅虎</font>";
                abing.InnerHtml = "<font size=2  color='#666699'>Bing</font>";
                asogou.InnerHtml = "<font size=2  color='#666699'>搜狗</font>";
                aall.InnerHtml = "<font size=2  color='#666699'>全部</font>";
                ayoudao.InnerHtml = "<font size=2  color='#666699'>有道</font>";
                break;
            case "ayoudao":
                showname = "有道";
                abaidu.InnerHtml = "<font size=2  color='#666699'>百度</font>";
                agoogle.InnerHtml = "<font size=2  color='#666699'>Google</font>";
                ayahoo.InnerHtml = "<font size=2  color='#666699'>雅虎</font>";
                abing.InnerHtml = "<font size=2  color='#666699'>Bing</font>";
                asogou.InnerHtml = "<font size=2  color='#666699'>搜狗</font>";
                asoso.InnerHtml = "<font size=2  color='#666699'>搜搜</font>";
                aall.InnerHtml = "<font size=2  color='#666699'>全部</font>";
                break;
            default:
                showname = "全部";
                abaidu.InnerHtml = "<font size=2  color='#666699'>百度</font>";
                agoogle.InnerHtml = "<font size=2  color='#666699'>Google</font>";
                ayahoo.InnerHtml = "<font size=2  color='#666699'>雅虎</font>";
                abing.InnerHtml = "<font size=2  color='#666699'>Bing</font>";
                asogou.InnerHtml = "<font size=2  color='#666699'>搜狗</font>";
                asoso.InnerHtml = "<font size=2  color='#666699'>搜搜</font>";
                ayoudao.InnerHtml = "<font size=2  color='#666699'>有道</font>";
                break;
            }
            System.Web.UI.HtmlControls.HtmlAnchor aname=(System.Web.UI.HtmlControls.HtmlAnchor)FindControl(web);
            aname.InnerHtml = "<font size=2 color=\"#003399\"><b>" + showname + "</b></font>";
            hiddenwebName.Value=web;
            txtSearchWord.Focus();
        }
#endregion

        #region 通过关键字搜索相关网站数据
        private string GetDataBySearchWord(string word,string web)
        {
            StringBuilder sb = new StringBuilder();
            gb2312Encode = System.Web.HttpUtility.UrlEncode(txtSearchWord.Value.Trim(), System.Text.Encoding.GetEncoding("gb2312")).ToUpper();
            utf8Encode = System.Web.HttpUtility.UrlEncode(txtSearchWord.Value.Trim(), System.Text.Encoding.UTF8).ToUpper();
            hiddengb2312.Value = gb2312Encode.Trim();
            hiddenutf8.Value = utf8Encode.Trim();

            sb.Append("<div id='divbaidu' style='display:none;'>");
            sb.Append("  </div>");
            sb.Append(" <div id='divgoogle' style='display:none;'>");
            sb.Append("  </div>");
            sb.Append(" <div id='divyahoo' style='display:none;'>");
            sb.Append("  </div>");
            sb.Append("<div id='divbing' style='display:none;'>");
            sb.Append("  </div>");
            sb.Append(" <div id='divsogou' style='display:none;'>");
            sb.Append("  </div>");
            sb.Append(" <div id='divsoso' style='display:none;'>");
            sb.Append("  </div>");
            sb.Append(" <div id='divyoudao' style='display:none;'>");
            sb.Append("  </div>");

            switch (web)
            { 
                case "aall":
                    WebCount = 7;
                    tdbaidu.Attributes.Add("style", "display:block");
                    tdgoogle.Attributes.Add("style", "display:block");
                    tdyahoo.Attributes.Add("style", "display:block");
                    tdbing.Attributes.Add("style", "display:block");
                    tdsogou.Attributes.Add("style", "display:block");
                    tdsoso.Attributes.Add("style", "display:block");
                    tdyoudao.Attributes.Add("style", "display:block");
                    break;
                case "abaidu":
                    WebCount = 1;
                    tdbaidu.Attributes.Add("style", "display:block");
                    break;
                case "agoogle":
                    WebCount = 1;
                    tdgoogle.Attributes.Add("style", "display:block");
                    break;
                case "ayahoo":
                    WebCount = 1;
                    tdyahoo.Attributes.Add("style", "display:block");
                    break;
                case "abing":
                    WebCount = 1;
                    tdbing.Attributes.Add("style", "display:block");
                    break;
                case "asogou":
                    WebCount = 1;
                    tdsogou.Attributes.Add("style", "display:block");
                    break;
                case "asoso":
                    WebCount = 1;
                    tdsoso.Attributes.Add("style", "display:block");
                    break;
                case "ayoudao":
                    WebCount = 1;
                    tdyoudao.Attributes.Add("style", "display:block");
                    break;
                default:
                    WebCount = 7;
                    tdbaidu.Attributes.Add("style", "display:block");
                    tdgoogle.Attributes.Add("style", "display:block");
                    tdyahoo.Attributes.Add("style", "display:block");
                    tdbing.Attributes.Add("style", "display:block");
                    tdsogou.Attributes.Add("style", "display:block");
                    tdsoso.Attributes.Add("style", "display:block");
                    tdyoudao.Attributes.Add("style", "display:block");
                    break;
            }
            return sb.ToString();
        }
        #endregion
    }
}
