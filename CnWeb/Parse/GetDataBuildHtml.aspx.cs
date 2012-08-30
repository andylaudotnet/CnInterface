using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CnBusinessLogic;

namespace CnWeb.Parse
{
    public partial class GetDataBuildHtml : System.Web.UI.Page
    {
        protected ParseWork w;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || CnInterfaceUser.GetUserLevel(Session["username"].ToString().Trim())!=1)
            {
                Response.Redirect("~/Index.aspx");
            }
            if (Session["GetDataBuildHtml"] == null)
            {
                w = new ParseWork("videohtml");
                Session["GetDataBuildHtml"] = w;
            }
            else
            {
                w = (ParseWork)Session["GetDataBuildHtml"];
            }
            switch (w.State)
            {
                case 0:
                    {
                        this.div_load.Visible = false;
                        break;
                    }
                case 1:
                    {
                        this.lab_state.Text = "已运行<font color=blue>" + ((TimeSpan)(DateTime.Now - w.StartTime)).TotalSeconds.ToString("0.000") + " </font><font color='#666699'>秒，数据抓取完成：<font color=blue>" + w.Percent + " </font>%</font>";
                        this.btn_startwork.Enabled = false;
                        this.btn_startwork.Text = "数据抓取生成中...";
                        Page.RegisterStartupScript("", "<script>window.setTimeout('location.href=location.href',1000);</script>");
                        this.lab_jg.Text = "";
                        break;
                    }
                case 2:
                    {
                        this.lab_jg.Text = "<font color='#666699'>任务结束,成功抓取生成视频HTML<font color=blue>" + w.finishcount.ToString() + "</font>个 (<a href=\"../html/VideoIndex.html\" target=\"_blank\"><font color=blue>查看</font></a>)，用时<font color=blue>" + ((TimeSpan)(w.FinishTime - w.StartTime)).TotalSeconds.ToString("0.000") + " </font>秒</font>";
                        labparselog.Text = w.ParseLogicstr;
                        this.btn_startwork.Enabled = true;
                        this.btn_startwork.Text = "点击开始抓取生成视频HTML";
                        this.div_load.Visible = false;
                        Session["GetDataBuildHtml"] = null;
                        break;
                    }
                case 3:
                    {
                        this.lab_jg.Text = "<font color='#666699'>任务结束,在<font color=blue>" + ((TimeSpan)(w.ErrorTime - w.StartTime)).TotalSeconds.ToString("0.000") + "</font>秒的时候发生错误导致任务失败</font>'";
                        labparselog.Text = w.ParseLogicstr;
                        this.btn_startwork.Enabled = true;
                        this.btn_startwork.Text = "点击开始抓取生成视频HTML";
                        this.div_load.Visible = false;
                        Session["GetDataBuildHtml"] = null;
                        break;
                    }
            }
        }

        protected void btn_startwork_Click(object sender, EventArgs e)
        {
            if (w.State != 1)
            {
                this.btn_startwork.Enabled = false;
                this.div_load.Visible = true;
                w.runwork();
                Page.RegisterStartupScript("", "<script>location.href=location.href;</script>");
            }
        }
    }
}
