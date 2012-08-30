using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CnBusinessLogic;
using System.Data;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

namespace CnWeb
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ResponseGetNameList"] != null)
            {
                GetCnInterfaceNames(Server.HtmlDecode(Request["ResponseGetNameList"].ToString()));
            }
            if (!IsPostBack)
            {
                txtInterfaceName.Value = "接口";
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
                if (Request["e"] != null)
                {
                    Response.Write("<font color=red>提示：</font>"+Request["e"].ToString());
                }
            }
        }
        protected void bntInterfaceSelect_Click(object sender, EventArgs e)
        {
            if (txtInterfaceName.Value.Trim() == "")
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                string searchStr = Server.HtmlEncode(txtInterfaceName.Value.Trim());
                Response.Redirect("SelectResult.aspx?t=" + hiddenInterfaceName.Value.Trim() + "&p=1&s=" + searchStr);
            }
        }
        protected void GetCnInterfaceNames(string name)
        {
            InterfaceInfo ifi = new InterfaceInfo();
            DataSet ds=ifi.GetCnInterfaceNames(name);
            if (ds != null && ds.Tables[0].Rows.Count>0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<table  border=\"0\" cellpadding =\"1\" cellspacing =\"0\" width=\"100%\"> ");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sb.Append("<tr  style='cursor:hand'  id='TrNumber" + i.ToString() + "' onmouseover='trOnmouseOver(this.id);' onmouseout='trOnmouseOut(this.id);'  >");
                    sb.Append("<td id='TdNumber" + i.ToString() + "' onclick='tdOnclick(this.id);'><font size=2 color=#666699>" + ds.Tables[0].Rows[i]["CnInterfaceName"].ToString().Replace(name, "<font color=#006a00>" + name + "</font>") + "</font></td>");
                    sb.Append("</tr>");
                }
                sb.Append("</table><input type=\"hidden\" id=\"hiddennamecount\" value=\"" + ds.Tables[0].Rows.Count .ToString()+ "\">");
                Response.Write(sb.ToString());
                Response.Flush();
                Response.End();
            }
            else
            {
                Response.Write("0");
                Response.Flush();
                Response.End();
            }
        }
    }
}
