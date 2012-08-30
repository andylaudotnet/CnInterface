using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CnWeb.Parse
{
    public partial class ParseWebList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || !(Session["username"].ToString().Trim().Equals("admin")))
            {
                Response.Redirect("~/Index.aspx");
            }
        }
    }
}
