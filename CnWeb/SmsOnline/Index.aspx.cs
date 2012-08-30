using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CnWeb
{
    public partial class _Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ResponseLoginName"] != null)
            {
                UserLogin(Request["ResponseLoginName"].ToString().Trim(), Request["ResponseLoginPwd"].ToString().Trim(), Request["ResponseCookieStatus"].ToString().Trim());
            }
            if (Request["ResponseUserExit"] != null)
            {
                UserExit();
            }
            if (Request["ResponseSSQ"] != null)
            {
                GetSSQResult();
            }
            if (!IsPostBack)
            {
                if (Session["username"] != null && Session["username"].ToString().Trim()!="")
                {
                    hiddenUsername.Value = Session["username"].ToString();
                    spanusername.InnerHtml = "<font size=2  color=#666699>欢迎您！<b>" + Session["username"].ToString() + "</b></font>&nbsp;&nbsp;<a href='../Parse/Index.aspx'><font color=blue size=2>管理中心</font></a>&nbsp;&nbsp;<a href='#' onclick='UserExit();'><font size=2 color=red>退出</font></a>";
                }
                else 
                {
                    HttpCookie szUserName = Request.Cookies["cninterfaceusername"];
                    if (szUserName != null && szUserName.Value.Trim()!="")
                    {
                        Session["username"] = szUserName.Value;
                        hiddenUsername.Value = szUserName.Value;
                        spanusername.InnerHtml = "<font size=2  color=#666699>欢迎您！<b>" + szUserName.Value + "</b></font>&nbsp;&nbsp;<a href='../Parse/Index.aspx'><font color=blue size=2>管理中心</font></a>&nbsp;&nbsp;<a href='#' onclick='UserExit();'><font size=2 color=red>退出</font></a>";
                    }
                }
            }
        }

       /// <summary>
       /// 用户登录
       /// </summary>
       /// <param name="name"></param>
       /// <param name="pwd"></param>
       /// <param name="cookiestatus"></param>
        private void UserLogin(string name, string pwd,string cookiestatus)
        {
                System.Threading.Thread.Sleep(100);
                string conStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionStr"].ToString();
                string sql = "select count(ID)  from Cn_InterfaceUser where username=@username and password=@password";
                int count = 0;
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@username", name);
                    cmd.Parameters.AddWithValue("@password", pwd);
                    count = (int)cmd.ExecuteScalar();
                }
                if (count > 0)
                {
                    LogUserInfo(name);
                    Session["username"] = name;
                    if (cookiestatus == "1")
                    {
                        HttpCookie hc = new HttpCookie("cninterfaceusername", Server.HtmlEncode(name));
                        hc.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(hc);
                    }
                    Response.Write("ok");
                    Response.Flush();
                    Response.End();
                }
                else
                {
                    Response.Write("error");
                    Response.Flush();
                    Response.End();
                }
        }

        /// <summary>
        /// 用户退出登录 
        /// </summary>
        protected void UserExit()
        {
            Session["username"] = null;
            Session.Remove("username");
            HttpCookie hc = Response.Cookies["cninterfaceusername"];
            hc = null;
            Response.Write("exitok");
            Response.Flush();
            Response.End();
        }

        /// <summary>
        /// 用户登录日志记录
        /// </summary>
        /// <param name="username"></param>
        private void LogUserInfo(string username)
        {
            string conStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionStr"].ToString();
            string sql = "update Cn_InterfaceUser set LoginCount=LoginCount+1,modifytime=getdate(),IpAddress='" + Request.ServerVariables.Get("Remote_Addr").ToString() + "' where username='" + username + "'";
            int value = 0;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                value = cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 获取双色球开奖结果
        /// </summary>
        /// <returns></returns>
        private void GetSSQResult()
        {
            string ssqResult = "";
            try
            {
                System.Threading.Thread.Sleep(3000);
                string html = new System.Net.WebClient().DownloadString("http://www.zhcw.com/kaijiang/index_kj.html");
                html = html.Substring(html.IndexOf("<dd>"), html.IndexOf("</dd>") - html.IndexOf("<dd>") + 4).Replace("\r\n","");
                string regStr = "<li class=\"qiured\">(.*?)</li>          <li class=\"qiured\">(.*?)</li>          <li class=\"qiured\">(.*?)</li>          <li class=\"qiured\">(.*?)</li>          <li class=\"qiured\">(.*?)</li>          <li class=\"qiured\">(.*?)</li>          <li class=\"qiublud\">(.*?)</li>";
                var regex = new System.Text.RegularExpressions.Regex(regStr);
                System.Text.RegularExpressions.Match m;
                if ((m = regex.Match(html)).Success && m.Groups.Count == 8)
                {
                    for (int i = 1; i < 8; i++)
                    {
                        ssqResult += "," + m.Groups[i].Value;
                    }
                    ssqResult = ssqResult.Substring(1);
                }
            }
            catch (Exception ex)
            {
                ssqResult = ex.Message;
            }
            Response.Write(ssqResult);
            Response.Flush();
            Response.End();
        }
    }
}
