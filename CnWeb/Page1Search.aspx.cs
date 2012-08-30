using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CnBusinessLogic;

namespace CnWeb
{
    public partial class Page1Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtSearchWord.Focus();
                if (Session["username"] != null && Session["username"].ToString().Trim() != "")
                {
                    hiddenUsername.Value = Session["username"].ToString();
                    spanusername.InnerHtml = "<font size=2  color=#666699>欢迎您！<b>" + Session["username"].ToString() + "</b></font>&nbsp;&nbsp;<a href='Parse/Index.aspx'><font color=blue size=2>管理中心</font></a>&nbsp;&nbsp;<a href='#' onclick='UserExit();'><font size=2 color=red>退出</font></a>";
                }
                else
                {
                    HttpCookie szUserName = Request.Cookies["cninterfaceusername"];
                    if (szUserName != null && szUserName.Value.Trim() != "")
                    {
                        Session["username"] = szUserName.Value;
                        hiddenUsername.Value = szUserName.Value;
                        spanusername.InnerHtml = "<font size=2  color=#666699>欢迎您！<b>" + szUserName.Value + "</b></font>&nbsp;&nbsp;<a href='Parse/Index.aspx'><font color=blue size=2>管理中心</font></a>&nbsp;&nbsp;<a href='#' onclick='UserExit();'><font size=2 color=red>退出</font></a>";
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!txtSearchWord.Value.Trim().Equals(""))
            {
                Response.Redirect("Page1Result.aspx?web=" + hiddenwebName.Value.Trim() + "&searchword=" + Server.UrlEncode(txtSearchWord.Value));
            }
            else
            {
                SetWebShow(hiddenwebName.Value.Trim());
                txtSearchWord.Focus();
            }
        }

        #region 设置web显示
        private void SetWebShow(string web)
        {
            string showname = "";
            switch (web)
            {
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
            System.Web.UI.HtmlControls.HtmlAnchor aname = (System.Web.UI.HtmlControls.HtmlAnchor)FindControl(web);
            aname.InnerHtml = "<font size=2 color=\"#003399\"><b>" + showname + "</b></font>";
            hiddenwebName.Value = web;
            txtSearchWord.Focus();
        }
        #endregion
    }
}
