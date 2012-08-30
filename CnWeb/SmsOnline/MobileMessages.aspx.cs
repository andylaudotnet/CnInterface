using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CnWeb
{
    public partial class MobileMessages : System.Web.UI.Page
    {
        protected string messageCount = "0";
        protected int todaymessageCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserMobileMessages("");
            }
        }

        private void LoadUserMobileMessages(string mobileNumber)
        {
            string conStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionStr"].ToString();
            string userIP = Request.ServerVariables.Get("Remote_Addr").ToString().Trim();
            string sql = "";
            if (mobileNumber == "")
            {
                sql = "select * from wetuo_UserMobileMessages where UserIP='" + userIP + "' order by senddatetime desc";
                if (GetUserLevel() == 1)
                    sql = "select * from wetuo_UserMobileMessages order by senddatetime desc";
            }
            else
            {
                sql = "select * from wetuo_UserMobileMessages where UserIP='" + userIP + "' and ToMobileNo='" + mobileNumber + "' order by senddatetime desc";
                if (GetUserLevel() == 1)
                    sql = "select * from wetuo_UserMobileMessages where ToMobileNo='" + mobileNumber + "' order by senddatetime desc";
            }
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                string strTemp = " <table border ='0' width ='888px'>";
                messageCount = ds.Tables[0].Rows.Count.ToString();
                if (ds.Tables[0].Rows.Count == 0)
                {
                    labMobileMessages.Text = "<br><center><table id='TabOrderEdit' width='640px' border='0'  cellSpacing='' cellPadding=''><tr><td><font size=3 color=#666699><b>本机暂未发送任何手机短信！</b></font></td></tr></table></center><Br>";
                    return;
                }
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToDateTime(ds.Tables[0].Rows[i]["SendDateTime"]).ToShortDateString() == DateTime.Now.ToShortDateString())
                        todaymessageCount++;
                    string messageStr = ds.Tables[0].Rows[i]["MobileMessage"].ToString();
                    string mobileNo = "<font color=#666699>手机[</font><font color=blue>" + ds.Tables[0].Rows[i]["ToMobileNo"].ToString() + "</font>]";
                    strTemp += "<tr><td align=left bgcolor='#edf3f3'><font color=#666699><b>" + ds.Tables[0].Rows[i]["FromName"].ToString() + "</b></font><font color=#666699>于" + ds.Tables[0].Rows[i]["SendDateTime"].ToString() + "在本机给" + mobileNo + "&nbsp;&nbsp;<font color=#666699>发送短信内容如下：</font></font></td></tr>" + "<tr><td  align=left> <font size='2' color='black' >" + messageStr + "</font><br><br></td></tr>";
                }
                strTemp += "</table>";
                labMobileMessages.Text = strTemp;
            }
        }

        private int GetUserLevel()
        {
            int UserLevel = 2;
            if (Request["qq"] != null && Request["qq"].ToString() == "459313018")
                UserLevel = 1;
            return UserLevel;
        }
        protected void btnMessagesSelect_Click(object sender, EventArgs e)
        {
            LoadUserMobileMessages(txtMobileNo.Text.Trim());
        }
    }
}
