using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CnDataAcess.Entity;
using CnBusinessLogic;

namespace CnWeb.Parse
{
    public partial class Manualparse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || CnInterfaceUser.GetUserLevel(Session["username"].ToString().Trim())!=1)
            {
                Response.Redirect("~/Index.aspx");
            }
            if (!IsPostBack)
            {
                int sourceno;
                if (Request["sourceno"] != null)
                {
                    sourceno = Convert.ToInt32(Request["sourceno"]);
                    if (sourceno == 2)
                    {
                        txtInterfaceSource.Text = "天空软件站";
                        txtInterfaceSourceUrl.Text = "http://www.skycn.com";
                    }
                    if (sourceno == 1)
                    {
                        txtInterfaceSource.Text = "华军软件园";
                        txtInterfaceSourceUrl.Text = "http://www.onlinedown.net/";
                    }
                    if (sourceno == 4)
                    {
                        txtInterfaceSource.Text = "百度搜索";
                        txtInterfaceSourceUrl.Text = "http://www.baidu.com/";
                    }
                    if (sourceno == 5)
                    {
                        txtInterfaceSource.Text = "Google搜索";
                        txtInterfaceSourceUrl.Text = "http://www.google.com.hk/";
                    }
                    if (sourceno == 6)
                    {
                        txtInterfaceSource.Text = "Yahoo搜索";
                        txtInterfaceSourceUrl.Text = "http://www.yahoo.cn/";
                    }
                    if (sourceno == 7)
                    {
                        txtInterfaceSource.Text = "Bing搜索";
                        txtInterfaceSourceUrl.Text = "http://www.bing.com/";
                    }
                    if (sourceno == 8)
                    {
                        txtInterfaceSource.Text = "Soso搜索";
                        txtInterfaceSourceUrl.Text = "http://www.soso.com/";
                    }
                    if (sourceno == 9)
                    {
                        txtInterfaceSource.Text = "Sogou搜索";
                        txtInterfaceSourceUrl.Text = "http://www.sogou.com/";
                    }
                    if (sourceno == 10)
                    {
                        txtInterfaceSource.Text = "有道搜索";
                        txtInterfaceSourceUrl.Text = "http://www.youdao.com/";
                    }
                    if (sourceno == 11)
                    {
                        txtInterfaceSource.Text = "狗狗搜索";
                        txtInterfaceSourceUrl.Text = "http://www.gougou.com/";
                    }
                }
                else
                {
                    Response.Redirect("Index.aspx");
                }

               DataTable dt=InterfaceType.GetInterfaceType();
                ddlInterfaceType.Items.Clear();
                ddlInterfaceType.Items.Add(new ListItem("请选择类型", "-1"));
                foreach(DataRow dr in dt.Rows)
                {
                    ListItem li = new ListItem();
                    li.Text = dr["CnInterfaceTypeName"].ToString();
                    li.Value = dr["ID"].ToString();
                    ddlInterfaceType.Items.Add(li);
                }
            }
        }

        protected void bntInterfaceAdd_Click(object sender, EventArgs e)
        {
            if (ddlInterfaceType.SelectedItem.Value == "-1")
            {
                ddlInterfaceType.Focus();
                return;
            }
            if (txtInterfaceUrl.Text.Equals("")
                ||txtInterfaceName.Text.Equals("")
                ||txtInterfaceBody.Text.Equals("")
                ||txtInterfaceSource.Text.Equals("")
                ||txtInterfaceSourceUrl.Text.Equals(""))
            {
                return;
            }
            CnInterfaceInfo cnf = new CnInterfaceInfo();
            cnf.CnInterfaceTypeID = Convert.ToInt32(ddlInterfaceType.SelectedItem.Value);
            cnf.CnInterfaceAppearTime = Convert.ToDateTime(txtInterfaceAppearTime.Text);
            cnf.CnInterfaceName = txtInterfaceName.Text;
            cnf.CnInterfaceUrl = txtInterfaceUrl.Text;
            cnf.CnInterfacebody = txtInterfaceBody.Text;
            cnf.CnInterfaceSource = txtInterfaceSource.Text;
            cnf.CnInterfaceSourceUrl = txtInterfaceSourceUrl.Text;
            InterfaceInfo IFI = new InterfaceInfo();
            int insertcount = IFI.InsertCnInterfaceInfo(cnf);
            Response.Write(insertcount.ToString());
        }
    }
}
