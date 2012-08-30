using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace CnWeb.SmsOnline
{
    public partial class SmsSend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtSmsmob.Text = "";
                txtSms.Text = "";
                txtsenduser.Text = "";
                //labresult.Text = "<font color=#666699 size=2>请勿发送违法违规违德信息。</font>";
                if (Session["username"] != null && Session["username"].ToString().Trim() != "")
                {
                    hiddenUsername.Value = Session["username"].ToString();
                }
            }
        }

        /// <summary>
        /// 验证手机
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private bool IsMobile(string source)
        {
            return Regex.IsMatch(source, @"^1[358]\d{9}$", RegexOptions.IgnoreCase);
        }
        /// <summary>
        /// 验证是否中文
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private bool IsChinese(string source)
        {
            return Regex.IsMatch(source, @"^[\u4e00-\u9fa5]+$", RegexOptions.IgnoreCase);
        }

        protected void bntSendNote_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSmsmob.Text.Trim() == "")
                {
                    labresult.Text = "<font color=red size=2><b>手机号码不能为空！</b></font>";
                    txtSmsmob.Focus();
                    return;
                }
                if (!IsMobile(txtSmsmob.Text.Trim()))
                {
                    labresult.Text = "<font color=red size=2><b>输入手机号码格式有误！</b></font>";
                    txtSmsmob.Focus();
                    return;
                }
                if (txtSms.Text.Trim() == "")
                {
                    labresult.Text = "<font color=red size=2><b>短信内容不能为空！</b></font>";
                    txtSms.Focus();
                    return;
                }
                if (txtSms.Text.Trim().Length > 60)
                {
                    labresult.Text = "<font  size=2 color=red>短信内容不能超过60个字!<br/></font><font  size=2 color=#666699>(当前输入字数为" + txtSms.Text.Trim().Length.ToString() + "个)</font>";
                    txtSms.Focus();
                    return;
                }
                if (txtsenduser.Text.Trim() == "")
                {
                    labresult.Text = "<font color=red size=2><b>发送者姓名不能为空！</b></font>";
                    txtsenduser.Focus();
                    return;
                }
                if (!IsChinese(txtsenduser.Text.Trim()))
                {
                    labresult.Text = "<font color=red size=2><b>发送者姓名须为中文！</b></font>";
                    txtsenduser.Focus();
                    return;
                }
                if (GetTodayMessageCountTotal() > (Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["AllEverdayMaxMobileNum"]) - 1))
                {
                    labresult.Text = "<font color=red size=2><b>今日短信发送用户已饱和!</b></font><br><font size=2  color=#666699>(请明日再来发送)</font>&nbsp;<a href='MobileMessages.aspx' target='_blank'><font color=#0353ce  size=2>已发短信</font></a>";
                    return;
                }
                if (GetTodayMessageCount() > (Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PCEverdayMaxMobileNum"]) - 1))
                {
                    labresult.Text = "<font color=red size=2><b>抱歉！一台电脑每日最多<br/>可发送" + System.Configuration.ConfigurationManager.AppSettings["PCEverdayMaxMobileNum"].ToString() + "条短信。</b></font><a href='MobileMessages.aspx' target='_blank'><font color=#0353ce  size=2>已发短信</font></a>";
                    return;
                }

                string userid = "monkeytree";
                string password = "800108winic";
                string username = txtsenduser.Text.Trim();
                SmsService.Service1 ws = new SmsService.Service1();
                string result = "-13";
                if (System.Configuration.ConfigurationManager.AppSettings["SmsIsReally"].ToString().Trim() == "1")
                {
                    result = ws.SendMessages(userid, password, txtSmsmob.Text.Trim(), txtSms.Text.Trim() + "--" + txtsenduser.Text.Trim() + "", "");
                }
                if (result.IndexOf("-") > -1)
                {
                    labresult.Text = "<font color=red size=2><b>短信发送失败！</b><br><font color=#666699  size=2>" + GetErrorInfo(result) + "</font>";
                }
                else
                {
                    try
                    {
                        string conStr =System.Configuration.ConfigurationManager.AppSettings["ConnectionStr"].ToString();
                        string sql = "update Cn_InterfaceUser set MessageCount=MessageCount+1,MessgaeDate=getdate() where username='" + username + "'";
                        sql = sql + "  insert into wetuo_UserMobileMessages" +
                                        " (UserName,ToMobileNo,MobileMessage,FromName,SendDateTime,UserIP)" +
                                        " values" +
                                        " ('" + username + "','" + txtSmsmob.Text.Trim() + "','" + txtSms.Text.Trim() + "','" + txtsenduser.Text.Trim() + "',getdate(),'" + Request.ServerVariables.Get("Remote_Addr").ToString().Trim() + "')";
                        int value = 0;
                        using (SqlConnection conn = new SqlConnection(conStr))
                        {
                            conn.Open();
                            SqlCommand cmd = conn.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = sql;
                            value = cmd.ExecuteNonQuery();
                        }
                        if (value > 0)
                        {
                            labresult.Text = "<font color=green size=2><b>短信发送成功！</b></font><a href='MobileMessages.aspx' target='_blank'><font color=#0353ce  size=2>已发短信</font></a>";
                            txtSms.Text = "";
                        }
                        else
                        {
                            labresult.Text = "<font color=green size=2><b>短信发送成功！</b></font><a href='MobileMessages.aspx' target='_blank'><font color=#0353ce  size=2>已发短信</font></a><br><font color=#666699  size=2>(该条信息未记录)</font>";
                            txtSms.Text = "";
                        }
                    }
                    catch
                    {
                        labresult.Text = "<font color=green size=2><b>短信发送成功！</b></font><a href='MobileMessages.aspx' target='_blank'><font color=#0353ce  size=2>已发短信</font></a><br><font color=#666699  size=2>(该条信息未记录)</font>";
                        txtSms.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                labresult.Text = "<font color=red size=2><b>发送异常！</b></font><br><font color=#666699  size=2>" + ex.Message + "</font>";
            }
        }


        private int GetTodayMessageCountTotal()
        {
            string conStr =System.Configuration.ConfigurationManager.AppSettings["ConnectionStr"].ToString();
            string sql = "select count(id) from wetuo_UserMobileMessages where CONVERT(varchar(12) , SendDateTime, 112 )='" + DateTime.Now.ToString("yyyyMMdd") + "'";
            int messagecount = 0;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                messagecount = (int)cmd.ExecuteScalar();
            }
            return messagecount;
        }

        private int GetTodayMessageCount()
        {
            string conStr =System.Configuration.ConfigurationManager.AppSettings["ConnectionStr"].ToString();
            string sql = "select count(id) from wetuo_UserMobileMessages where CONVERT(varchar(12) , SendDateTime, 112 )='" + DateTime.Now.ToString("yyyyMMdd") + "' and  UserIP='" + Request.ServerVariables.Get("Remote_Addr").ToString().Trim() + "'";
            int messagecount = 0;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                messagecount = (int)cmd.ExecuteScalar();
            }
            return messagecount;
        }


        private string GetErrorInfo(string code)
        {
            string errorinfo = "";
            switch (code)
            {
                case "-01":
                    errorinfo = "当前账号余额不足";
                    break;
                case "-02":
                    errorinfo = "当前用户ID错误！";
                    break;
                case "-03":
                    errorinfo = "当前密码错误！";
                    break;
                case "-04":
                    errorinfo = "参数内容类型错误！";
                    break;
                case "-05":
                    errorinfo = "手机号码格式不对！";
                    break;
                case "-06":
                    errorinfo = "短信内容编码不对！";
                    break;
                case "-07":
                    errorinfo = "短信含有敏感字符!";
                    break;
                case "-08":
                    errorinfo = "无接收数据！";
                    break;
                case "-09":
                    errorinfo = "系统维护中！";
                    break;
                case "-10":
                    errorinfo = "手机号码数量超长！";
                    break;
                case "-11":
                    errorinfo = "短信内容超长！";
                    break;
                case "-12":
                    errorinfo = "其它错误！";
                    break;
                case "-13":
                    errorinfo = "此为虚拟通道,不能发送。";
                    break;
                default:
                    errorinfo = code;
                    break;
            }
            return errorinfo;
        }
    }
}
