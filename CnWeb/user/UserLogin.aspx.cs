using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CnWeb.user
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ResponseUserName"] != null)
            {
                checkUsername(Request["ResponseUserName"].ToString());
            }
            if (Request["ResponseGetUserPassword"] != null)
            {
                GetUserPassword(Request["ResponseGetUserPassword"].ToString(), Request["ResponseIPAddress"].ToString().Trim());
            }
            if (!IsPostBack)
            {
                if (Request["UrlReferrer"] != null)
                    hiddenPreUrl.Value = Request["UrlReferrer"].ToString();
                else
                    hiddenPreUrl.Value = "~/Index.aspx";
                txtusername.Focus();
                hiddenIPAddress.Value = Request.ServerVariables.Get("Remote_Addr").ToString().Trim();
            }
        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string name = txtusername.Text;
            string pwd = txtpassword.Text;
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
                HttpCookie hc = new HttpCookie("cninterfaceusername", Server.HtmlEncode(name));
                hc.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(hc);
                Response.Redirect(hiddenPreUrl.Value);
            }
            else
            {
                hiddenIPAddress.Value = Request.ServerVariables.Get("Remote_Addr").ToString().Trim();
                Page.RegisterStartupScript("aa", "<script>alert('输入的用户名或密码错误，请核对后重新登录！');</script>");
            }
        }
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

        private void checkUsername(string username)
        {
            string conStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionStr"].ToString();
            string sql = "select count(ID)  from Cn_InterfaceUser where username='" + username + "'";
            int count = 0;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                count = (int)cmd.ExecuteScalar();
            }
            string result = "no";
            if (count > 0)
            {
                result = "exsit";
            }
            Response.Write(result);
            Response.Flush();
            Response.End();
        }

        private void GetUserPassword(string username, string ipaddress)
        {
            string conStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionStr"].ToString();
            string sql = "select password  from Cn_InterfaceUser where userlevel=2 and ipaddress='" + ipaddress + "' and username='" + username + "'";
            string pwd = "iperror";
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                    pwd = sdr["password"].ToString();
            }
            Response.Write(pwd);
            Response.Flush();
            Response.End();
        }
    }
}
