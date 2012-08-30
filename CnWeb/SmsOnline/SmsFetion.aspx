<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SmsFetion.aspx.cs" Inherits="CnWeb.SmsFetion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>手机短信在线发送</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta name="keywords" content="短信,短信发送,短信在线发送,手机短信,手机短信发送,手机短信在线发送,飞信,飞信登录,飞信短信,飞信好友,接口,interface,天下接口,接口天下,程序接口,网络接口,webservice接口,http接口,ActiveX dll接口,普通dll接口,数据库接口,第一页搜索,首页搜索,搜索引擎,google,百度,雅虎,bing,搜狗,搜搜,有道." />
     <style type="text/css">
             .ButtonCss
            {
                BACKGROUND-COLOR:#ffffff; BORDER-RIGHT: #A9BAC9 1px solid; PADDING-RIGHT: 8px; BORDER-TOP: #A9BAC9 1px solid; PADDING-LEFT: 8px; FONT-SIZE: 12px;  BORDER-LEFT: #A9BAC9 1px solid; CURSOR: hand; COLOR: #666699; font-weight:bold; PADDING-TOP: 4px; PADDING-BOTTOM: 2px;BORDER-BOTTOM: #A9BAC9 1px solid;
            }
            .text_dialog1,.text_dialog2 {height:19px; line-height:19px; border:1px solid #A9BAC9; padding:0 2px; font-size:12px;font-weight:bold; COLOR: #666699;  }
            .text_dialog2 { border:1px solid #9ECC00;COLOR: #666699; }
           a:link {text-decoration:none;color:#666699;}	/* 未访问的链接 */
         a:visited {text-decoration:none;color:#666699}	/* 已访问的链接 */
         a:hover {text-decoration:underline; color:#666699; }	/* 鼠标移动到链接上 */
         a:active {text-decoration:underline;color:#666699}	/* 选定的链接 */
            #loader_container {
	    Z-INDEX: 10; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 35%; TEXT-ALIGN: center
    } 
        #loader {
	    BORDER-RIGHT: #5a667b 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #5a667b 1px solid; DISPLAY: block; PADDING-LEFT: 5px; FONT-SIZE: 11px; Z-INDEX: 2; PADDING-BOTTOM: 5px; MARGIN: 0px auto; BORDER-LEFT: #5a667b 1px solid; WIDTH: 333px; COLOR: #000000; PADDING-TOP: 5px; BORDER-BOTTOM: #5a667b 1px solid; FONT-FAMILY: Tahoma, Helvetica, sans; BACKGROUND-COLOR:#ffffff; TEXT-ALIGN: left
    }   
         .style2
         {
             width: 104px;
         }
         .style3
         {
             height: 19px;
             line-height: 19px;
             border: 1px solid #A9BAC9;
             padding: 0 2px;
             font-size: 12px;
             font-weight: bold;
             COLOR: #666699;
             width: 104px;
         }
         .style4
         {
             width: 174px;
         }
    </style>
    <script type="text/javascript" language="javascript">
        function showzhijiefetion() {
            document.getElementById("tabFetionLogin").style.display = "none";
            document.getElementById("tabFetionSend").style.display = "none";
            document.getElementById("tabzhijieFetion").style.display = "block";
        }
        function checkloginuser() {
            if (document.getElementById("txtFetionUsername").value == "") {
                alert("手机/飞信号不能为空！");
                document.getElementById("txtFetionUsername").focus();
                return false;
            }
            if (document.getElementById("txtFetionPwd").value == "") {
                alert("密码不能为空！");
                document.getElementById("txtFetionPwd").focus();
                return false;
            }
            document.getElementById("labFetionLoginResult").innerHTML = "<font color=#666699 size=2><b>登录中...</b></font>";
            return true;
        }
        function checkzhijiefetion() {
            if (document.getElementById("txtzhijieUsername").value == "") {
                alert("登录手机号不能为空！");
                document.getElementById("txtzhijieUsername").focus();
                return false;
            }
            if (document.getElementById("txtzhijieUserPwd").value == "") {
                alert("登录密码不能为空！");
                document.getElementById("txtzhijieUserPwd").focus();
                return false;
            }
            if (document.getElementById("txtzhijieReciever").value == "") {
                alert("好友手机号不能为空！");
                document.getElementById("txtzhijieReciever").focus();
                return false;
            }
            if (!(mobilenumCheck(document.getElementById("txtzhijieReciever").value))) {
                alert("好友手机号格式有误！");
                document.getElementById("txtzhijieReciever").focus();
                return false;
            }
            if (document.getElementById("txtzhijieContext").value == "") {
                alert("短信内容不能为空！");
                document.getElementById("txtzhijieContext").focus();
                return false;
            }
            document.getElementById("labfetionzhijieresult").innerHTML = "<font color=#666699 size=2><b>发送中...</b></font>";
            return true;
        }
        function checksenduser() {
            if (document.getElementById("txtFetionMobile").value == "") {
                alert("手机/飞信号不能为空！");
                document.getElementById("txtFetionMobile").focus();
                return false;
            }
            if (document.getElementById("txtFetionContext").value == "") {
                alert("短信内容不能为空！");
                document.getElementById("txtFetionContext").focus();
                return false;
            }
            document.getElementById("labFetionSendResult").innerHTML = "<font color=#666699 size=2><b>发送中...</b></font>";
            return true;
        }
        function mobilenumCheck(mobilenum) {
            var filter = /^1[3|5|8][0-9]\d{4,8}$/;
            return filter.test(mobilenum);
        }
    </script>
    <link href="../css/base.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div style ="position:absolute; top:86px;left:230px; width:115px;height:18px;background-color:White; display:none;FILTER:alpha(opacity=99);" id="divPageWaiting"><font size="2" color="#666699"><b>页面加载中...</b></font></div>
    
     <script type="text/javascript" language="javascript">
                function pageloading() {
                    document.getElementById("divPageWaiting").style.display="block";
               }
               function pageunloading() {
                   document.getElementById("divPageWaiting").style.display = "none";
               }
               pageloading();
        </script>
     <div>
     <table id="tabFetionLogin"  runat="server"   border="0" cellpadding ="4" cellspacing ="1"  bgcolor="#9999ff" align="center" width="555px" height="190px">
                                        <tr>
                                            <td align="center" bgcolor="#ffffff" colspan="2"><font color=#666699 size=2><b>飞信用户登录</b></font></td>
                                        </tr>
                                        <tr>
                                           <td bgcolor="#ffffff"><font color=black size=2>手机/飞信号：</font><input type="hidden"  id ="hiddenfetionid"  runat="server" /></td>
                                            <td bgcolor="#ffffff"><asp:TextBox ID="txtFetionUsername" runat="server"  Width="200px" BackColor="#ffffff"  MaxLength="20"  class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'" ></asp:TextBox><asp:Label ID="labfetionloginusername" runat ="server" Text="<font color=#666699 size=2>*输入正确手机号码或飞信号码</font>"></asp:Label>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td align="center" bgcolor="#ffffff"><font color=black size=2>密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码：</font></td>
                                            <td bgcolor="#ffffff"> <asp:TextBox ID="txtFetionPwd" runat="server"  Width="200px" TextMode="Password"  BackColor="#ffffff"  MaxLength="20"  class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'" ></asp:TextBox><asp:Label ID="labfetionloginuserpwd" runat ="server" Text="<font color=#666699 size=2>*输入正确密码</font>"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  colspan="2"  align="left" bgcolor="#ffffff">
                                                <table  border="0" cellpadding ="0" cellspacing ="0"  width="100%" bgcolor="#ffffff">
                                                    <tr>
                                                        <td align="left" width="43%" valign="middle">
                                                            <asp:Label ID="labFetionLoginResult" runat="server" Text="" ForeColor="Red"  style="padding-top:expression(document.body.clientHeight/2)"></asp:Label>
                                                        </td>
                                                        <td align="left" width="*">
                                                           <asp:Button  CssClass="ButtonCss"  ID="btnFetionLogin"  runat="server" 
                                                                Text="登 录" onclick="btnFetionLogin_Click"  OnClientClick="return checkloginuser();"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='https://www.fetion.com.cn/account/register' target='_blank'><font color=#006600  size=2>飞信新用户注册</font></a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
          </table>
           <table id="tabFetionSend"   runat="server" style="display:none"  border="0" cellpadding ="4" cellspacing ="1"  bgcolor="#9999ff" align="center" width="555px" height="190px">
                                      <tr>
                                            <td align="left" bgcolor="#ffffff" class="style2"  ><font color=#666699 size=2>我的好友列表:</font>  
                                            </td>
                                            <td bgcolor="#ffffff"> <font color=black size=2>好友/手机号：</font>&nbsp;&nbsp;<asp:TextBox ID="txtFetionMobile"  runat="server"  Width="110px" BackColor="#ffffff" MaxLength="20"   class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  ></asp:TextBox><asp:Label ID="labmobileInfo" runat="server" Text="<font color=#666699 size=2>*请从左列表选择或直接输入手机号</font>"></asp:Label></td>
                                        </tr>
                                        <tr>
                                             <td align="left" bgcolor="#ffffff" rowspan="2" class=style3>
                                                 <asp:ListBox ID="lbfetionfriends" runat="server" AutoPostBack="true" 
                                                     onselectedindexchanged="lbfetionfriends_SelectedIndexChanged" 
                                                     Height="161px" Width="109px" CssClass="text_dialog1" 
                                                     Font-Strikeout="False"></asp:ListBox>
                                            </td>
                                            <td bgcolor="#ffffff"><font color=black size=2>短&nbsp;&nbsp;信&nbsp;&nbsp;内&nbsp;&nbsp;容：</font>
                                                <asp:TextBox ID="txtFetionContext" runat="server" TextMode="MultiLine" Height="80px" Width="260px" MaxLength="65"  class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  ></asp:TextBox><asp:Label ID="labcontextInfo" runat="server" Text="<font color=#666699 size=2>*</font>"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  align="left" bgcolor="#ffffff">
                                                <table  border="0" cellpadding ="0" cellspacing ="0"  width="100%" bgcolor="#ffffff">
                                                    <tr>
                                                        <td align="left" width="53%" valign="middle"><asp:Label ID="labFetionSendResult" runat="server" Text="" ForeColor="Red"  style="padding-top:expression(document.body.clientHeight/2)"></asp:Label></td>
                                                        <td align="left" width="*">
                                                            <asp:Button  CssClass="ButtonCss"  ID="bntFetionSend" 
                                                                runat="server" Text="发送短信" onclick="bntFetionSend_Click"  OnClientClick="return checksenduser();"/>&nbsp;&nbsp;&nbsp;&nbsp;<a href='MobileMessages.aspx' target='_blank'><font color=#006600  size=2>本机已发短信</font></a></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
          </table>
          <table id="tabzhijieFetion"   runat="server" style="display:none"  border="0" cellpadding ="4" cellspacing ="1"  bgcolor="#9999ff" align="center" width="555px" height="190px">
                                        <tr>
                                            <td align="right" bgcolor="#ffffff" class="style4"  > <font color=black size=2>您的移动飞信登录手机号：</font></td>
                                            <td bgcolor="#ffffff"><asp:TextBox ID="txtzhijieUsername"  runat="server"  Width="120px" BackColor="#ffffff" MaxLength="20"   class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  ></asp:TextBox><asp:Label ID="Label1" runat="server" Text="<font color=#666699 size=2>*</font>"></asp:Label></td>
                                        </tr>
                                         <tr>
                                            <td align="right" bgcolor="#ffffff" class="style4"><font color=black size=2>您的移动飞信登录密码：</font></td>
                                            <td bgcolor="#ffffff"> <asp:TextBox ID="txtzhijieUserPwd" runat="server"  Width="120px" TextMode="Password"  BackColor="#ffffff"  MaxLength="20"  class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'" ></asp:TextBox><asp:Label ID="Label5" runat ="server" Text="<font color=#666699 size=2>*</font>"></asp:Label></td>
                                        </tr>
                                          <tr>
                                            <td align="right" bgcolor="#ffffff" class="style4"  > <font color=black size=2>接收短信的飞信好友手机号：</font></td>
                                            <td bgcolor="#ffffff"><asp:TextBox ID="txtzhijieReciever"  runat="server"  Width="120px" BackColor="#ffffff" MaxLength="20"   class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  ></asp:TextBox><asp:Label ID="Label4" runat="server" Text="<font color=#666699 size=2>*可以与登录手机号相同</font>"></asp:Label></td>
                                        </tr>
                                        <tr>
                                             <td align="right" bgcolor="#ffffff" class="style4" >
                                               <font color=black size=2>短&nbsp;&nbsp;信&nbsp;&nbsp;内&nbsp;&nbsp;容：</font>
                                            </td>
                                            <td bgcolor="#ffffff">
                                                <asp:TextBox ID="txtzhijieContext" runat="server" TextMode="MultiLine" Height="55px" Width="300px" MaxLength="65"  class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  ></asp:TextBox><asp:Label ID="Label2" runat="server" Text="<font color=#666699 size=2>*</font>"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  align="left" bgcolor="#ffffff" colspan="2">
                                                <table  border="0" cellpadding ="0" cellspacing ="0"  width="100%" bgcolor="#ffffff">
                                                    <tr>
                                                        <td align="left" width="53%" valign="middle"><asp:Label ID="labfetionzhijieresult" runat="server" Text="<font color=#666699 size=2>注：发送双方需要互为移动飞信好友。</font>" ForeColor="Red"  style="padding-top:expression(document.body.clientHeight/2)"></asp:Label></td>
                                                        <td align="left" width="*">
                                                            <asp:Button  CssClass="ButtonCss"  ID="btnfetionzhijie" 
                                                                runat="server" Text="发送短信" onclick="btnfetionzhijie_Click"  OnClientClick="return checkzhijiefetion();"/>&nbsp;&nbsp;&nbsp;&nbsp;<a href='MobileMessages.aspx' target='_blank'><font color=#006600  size=2>本机已发短信</font></a></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
          </table>
    </div>
    </form>
</body>
</html>
<script type="text/javascript" language="javascript">pageunloading();</script>