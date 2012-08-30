using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CnBusinessLogic;

namespace CnWeb.Parse
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null )
            {
                Response.Redirect("~/Index.aspx");
            }
            else if (CnInterfaceUser.GetUserLevel(Session["username"].ToString().Trim()) != 1)
            {
                Response.Redirect("~/user/UserInfoEdit.aspx");
            }
            else
            { 
                
            }
            //Response.Write(Server.MapPath("../html/BuildHTMLLog.txt"));
        }
    }
}
