using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Net;

namespace CnWeb
{
    public partial class SmsFetion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["FetionUsername"] != null && Session["FetionUserPwd"] != null)
                    {
                        GetUserFetionFriends(Session["FetionUsername"].ToString().Trim(), Session["FetionUserPwd"].ToString().Trim());
                    }
                    else
                    {
                        tabFetionLogin.Attributes.Add("style", "display:block");
                        tabFetionSend.Attributes.Add("style", "display:none");
                        tabzhijieFetion.Attributes.Add("style", "display:none");
                    }
                    labFetionLoginResult.Text = "<font color=#666699 size=2>已记录IP，请勿发送违法违规违德信息。</font>";
                }
            }
            catch(Exception ex)
            {
                labFetionLoginResult.Text = "<font color=#666699 size=2>提示：</font><font color=red size=2><b>登录失败！</b></font>&nbsp;<a href='#' onclick='showzhijiefetion();'><font size=2>点此直接发送</font></a><br><font color=#666699 size=2>(" + ex.Message + "。)</font>";   
            }
        }

        protected void btnFetionLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFetionUsername.Text.Trim() == "")
                {
                    labFetionLoginResult.Text = "<font color=#666699 size=2>提示：</font><font color=red size=2><b>手机/飞信号不能为空！</b></font>";
                    txtFetionUsername.Focus();
                    return;
                }
                if (txtFetionPwd.Text.Trim() == "")
                {
                    labFetionLoginResult.Text = "<font color=#666699 size=2>提示：</font><font color=red size=2><b>密码不能为空！</b></font>";
                    txtFetionPwd.Focus();
                    return;
                }

                if (GetUserFetionFriends(txtFetionUsername.Text.Trim(), txtFetionPwd.Text.Trim()))
                {
                    Session["FetionUsername"] = txtFetionUsername.Text.Trim();
                    Session["FetionUserPwd"] = txtFetionPwd.Text.Trim();
                }
            }
            catch(Exception ex)
            {
                labFetionLoginResult.Text = "<font color=#666699 size=2>提示：</font><font color=red size=2><b>登录失败！</b></font>&nbsp;<a href='#' onclick='showzhijiefetion();'><font size=2>点此直接发送</font></a><br><font color=#666699 size=2>(" + ex.Message + ")</font>";   
            }
        }

        /// <summary>
        /// 获取飞信好友列表
        /// </summary>
        /// <param name="username"></param>
        /// <param name="?">VCY3yenZ</param>
        private  bool GetUserFetionFriends(string username,string userpwd)
        {
                bool status = false;
                FetionService.fWebSer fws = new FetionService.fWebSer();
                fws.CookieContainer = new System.Net.CookieContainer();
                labFetionLoginResult.Text = fws.Login(username,userpwd);
                if (labFetionLoginResult.Text.IndexOf("命令发出成功") == -1)
                {
                    labFetionLoginResult.Text = "<font color=#666699 size=2>提示：</font><font color=red size=2><b>登录失败！</b></font>&nbsp;<a href='#' onclick='showzhijiefetion();'><font size=2>点此直接发送</font></a><br><font color=#666699 size=2>" + labFetionLoginResult.Text + "</font>";
                    return status;
                }
                System.Threading.Thread.Sleep(4000);
                //获取好友列表
                string fl = fws.FList(username).Replace("br>", "");
                if (fl.Trim().IndexOf("<")==-1)
                {
                    labFetionLoginResult.Text = "<font color=#666699 size=2>提示：</font><font color=red size=2><b>登录失败！</b></font>&nbsp;<a href='#' onclick='showzhijiefetion();'><font size=2>点此直接发送</font></a><br><font color=#666699 size=2>" + fl.Trim() + "(网络忙)</font>";
                    return status;
                }
                string[] flarr = fl.Trim().Split('<');  //拆分记录
                FUser[] FUArr = new FUser[flarr.Length];  //创建好友列表数组
                for (int i = 0; i < flarr.Length; i++)
                {
                    //分析每个好友记录
                    string[] farr = flarr[i].Split('|');
                    if (farr.Length < 6) continue;
                    FUArr[i].FNo = farr[0].Replace("\n", "");// 飞信账号
                    FUArr[i].MNo = farr[1];// 飞信手机号
                    FUArr[i].UName = farr[2];// 用户姓名或昵称
                    FUArr[i].isIM = (farr[3] == "信息" ? true : false);// 飞信在线
                    FUArr[i].isSMS = (farr[4] == "短信" ? true : false);// 短信在线
                    FUArr[i].isInvite = (farr[5] == "在线" ? true : false);// 是否活动
                    FUArr[i].GroupName = farr[6];// 好友分组组名
                }
                lbfetionfriends.Items.Clear();
                for (int i = 1; i < FUArr.Length; i++)
                {
                    if (FUArr[i].UName == "." || FUArr[i].UName == "." || FUArr[i].UName == "," || FUArr[i].FNo == "0") { continue; }
                    ListItem li = new ListItem(FUArr[i].UName, (FUArr[i].FNo == "" ? FUArr[i].MNo : FUArr[i].FNo));
                    lbfetionfriends.Items.Add(li);
                }
                lbfetionfriends.Items.RemoveAt(lbfetionfriends.Items.Count - 1);

                fws.Logout(username);   //获取后如果不再使用请注销

                tabFetionLogin.Attributes.Add("style", "display:none");
                tabFetionSend.Attributes.Add("style", "display:block");
                tabzhijieFetion.Attributes.Add("style", "display:none");

                status = true;

                return status;
        }


        protected void lbfetionfriends_SelectedIndexChanged(object sender, EventArgs e)
        {
           txtFetionMobile.Text=lbfetionfriends.SelectedItem.Text;
           hiddenfetionid.Value = lbfetionfriends.SelectedItem.Value;
        }

        protected void bntFetionSend_Click(object sender, EventArgs e)
        {
            if (Session["FetionUsername"] == null || Session["FetionUserPwd"] == null)
            {
                Response.Redirect("SmsFetion.aspx");
                return;
            }
            if (IsMobile(hiddenfetionid.Value))
            {
                string url = "https://sms.api.bz/fetion.php?username=" + Session["FetionUsername"].ToString().Trim() + "&password=" + Session["FetionUserPwd"].ToString().Trim() + "&sendto=" + txtFetionMobile.Text.Trim() + "&message=" + txtFetionContext.Text;   
                HttpWebRequest hwr = (HttpWebRequest)HttpWebRequest.Create(url);   
                hwr.Method = "GET";   
                try  
                {   
                    HttpWebResponse wr =(HttpWebResponse)hwr.GetResponse();   
                    if (wr.StatusCode == HttpStatusCode.OK)   
                    {
                        labFetionSendResult.Text = "<font color=#666699 size=2>提示：</font><font color=green size=2><b>发送成功！</b></font>";   
                    }   
                    else  
                    {
                        labFetionSendResult.Text = "<font color=#666699 size=2>提示：</font><font color=red size=2><b>发送失败！</b></font>";   
                    }   
                }
                catch (Exception ex)
                {
                    labFetionSendResult.Text = "<font color=#666699 size=2>提示：</font><font color=red size=2><b>发送失败！</b></font><br><font color=#666699 size=2>(" + ex.Message + ")</font>";   
                }  
            }
            else
            {
                try
                {
                    FetionService.fWebSer fws = new FetionService.fWebSer();
                    fws.CookieContainer = new System.Net.CookieContainer();
                    labFetionSendResult.Text = fws.Login(Session["FetionUsername"].ToString().Trim(), Session["FetionUserPwd"].ToString().Trim());
                    System.Threading.Thread.Sleep(3000);
                    fws.Send(Session["FetionUsername"].ToString().Trim(), hiddenfetionid.Value.Trim(), txtFetionContext.Text.Trim()); //发送信息

                    fws.Logout(Session["FetionUsername"].ToString().Trim());   //获取后如果不再使用请注销
                    labFetionSendResult.Text = "<font color=#666699 size=2>提示：</font><font color=green size=2><b>发送成功！</b></font>";   
                }
                catch (Exception ex)
                {
                    labFetionSendResult.Text = "<font color=#666699 size=2>提示：</font><font color=red size=2><b>发送失败！</b></font><br><font color=#666699 size=2>(" + ex.Message + ")</font>";   
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
        /// 飞信好友信息结构
        /// </summary>
        public struct FUser
        {
            /// <summary>
            /// 飞信账号
            /// </summary>
            public string FNo;
            /// <summary>
            /// 飞信手机号
            /// </summary>
            public string MNo;
            /// <summary>
            /// 用户姓名或昵称
            /// </summary>
            public string UName;
            /// <summary>
            /// 飞信在线
            /// </summary>
            public bool isIM;
            /// <summary>
            /// 短信在线
            /// </summary>
            public bool isSMS;
            /// <summary>
            /// 是否活动
            /// </summary>
            public bool isInvite;
            /// <summary>
            /// 好友分组组名
            /// </summary>
            public string GroupName;
        }

        /// <summary>
        /// 直接发送飞信短信
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnfetionzhijie_Click(object sender, EventArgs e)
        {
            tabFetionLogin.Attributes.Add("style", "display:none");
            tabFetionSend.Attributes.Add("style", "display:none");
            tabzhijieFetion.Attributes.Add("style", "display:block");
            if (txtzhijieUsername.Text.Trim() == "")
            {
                labfetionzhijieresult.Text = "<font color=#666699 size=2>提示：</font><font color=red size=2><b>登录手机号不能为空！</b></font>";
                txtzhijieUsername.Focus();
                return;
            }
            if (txtzhijieUserPwd.Text.Trim() == "")
            {
                labfetionzhijieresult.Text = "<font color=#666699 size=2>提示：</font><font color=red size=2><b>登录密码不能为空！</b></font>";
                txtzhijieUserPwd.Focus();
                return;
            }
            if (txtzhijieReciever.Text.Trim() == "")
            {
                labfetionzhijieresult.Text = "<font color=#666699 size=2>提示：</font><font color=red size=2><b>好友手机号不能为空！</b></font>";
                txtzhijieReciever.Focus();
                return;
            }
            if (txtzhijieContext.Text.Trim() == "")
            {
                labfetionzhijieresult.Text = "<font color=#666699 size=2>提示：</font><font color=red size=2><b>短信内容不能为空！</b></font>";
                txtzhijieContext.Focus();
                return;
            }
            if (IsMobile(txtzhijieReciever.Text.Trim()))
            {
                string url = "https://sms.api.bz/fetion.php?username=" + txtzhijieUsername.Text.Trim() + "&password=" + txtzhijieUserPwd.Text.Trim() + "&sendto=" + txtzhijieReciever.Text.Trim() + "&message=" + txtzhijieContext.Text.Trim();
                HttpWebRequest hwr = (HttpWebRequest)HttpWebRequest.Create(url);
                hwr.Method = "GET";
                try
                {
                    HttpWebResponse wr = (HttpWebResponse)hwr.GetResponse();
                    if (wr.StatusCode == HttpStatusCode.OK)
                    {
                        labfetionzhijieresult.Text = "<font color=#666699 size=2>提示：</font><font color=green size=2><b>发送成功！</b></font>";
                    }
                    else
                    {
                        labfetionzhijieresult.Text = "<font color=#666699 size=2>提示：</font><font color=red size=2><b>发送失败！</b></font>";
                    }
                }
                catch (Exception ex)
                {
                    labfetionzhijieresult.Text = "<font color=#666699 size=2>提示：</font><font color=red size=2><b>发送失败！</b></font><br><font color=#666699 size=2>(" + ex.Message + ")</font>";
                }
            }
            else
            {
                labfetionzhijieresult.Text = "<font color=#666699 size=2>提示：</font><font color=red size=2><b>好友手机号格式有误！</b></font>";
                txtzhijieReciever.Focus();
            }
        }
    }
}
