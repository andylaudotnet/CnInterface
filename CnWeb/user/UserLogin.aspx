<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="CnWeb.user.UserLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>天下接口网</title>
    <meta http-equiv="content-type" content="text/html;charset=utf-8">
    <meta name="keywords" content="接口,interface,天下接口,接口天下,程序接口,网络接口,webservice接口,http接口,ActiveX dll接口,普通dll接口,数据库接口,短信,短信发送,短信在线发送,手机短信,手机短信发送,手机短信在线发送,飞信,飞信登录,飞信短信,飞信好友,第一页搜索,首页搜索,搜索引擎,google,百度,雅虎,bing,搜狗,搜搜,有道." />
    <style type="text/css">
         a:link {text-decoration:none;color:#666699;}	/* 未访问的链接 */
         a:visited {text-decoration:none;color:#666699}	/* 已访问的链接 */
         a:hover {text-decoration:underline; color:red; }	/* 鼠标移动到链接上 */
         a:active {text-decoration:underline;color:#666699}	/* 选定的链接 */
         .text_dialog1,.text_dialog2 {height:20px; line-height:19px; border:1px solid #A9BAC9; padding:0 2px; font-size:12px;COLOR:black;  }
         .text_dialog2 { border:1px solid #A9BAC9;COLOR: #666699; }
        .ButtonCss
            {
                BORDER-RIGHT: #A9BAC9 1px solid; PADDING-RIGHT: 10px; BORDER-TOP: #A9BAC9 1px solid; PADDING-LEFT: 10px; FONT-SIZE: 12px;  BORDER-LEFT: #A9BAC9 1px solid; CURSOR: hand; COLOR:#666699; PADDING-TOP: 3px; PADDING-BOTTOM: 3px;BORDER-BOTTOM: #A9BAC9 1px solid;BACKGROUND-COLOR:#ffffff; 
            }
             #loader_container {
	    Z-INDEX: 10; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 30%; TEXT-ALIGN: center
    } 
        #loader {
	    BORDER-RIGHT: #5a667b 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #5a667b 1px solid; DISPLAY: block; PADDING-LEFT: 5px; FONT-SIZE: 11px; Z-INDEX: 2; PADDING-BOTTOM: 5px; MARGIN: 0px auto; BORDER-LEFT: #5a667b 1px solid; WIDTH: 333px; COLOR: #000000; PADDING-TOP: 5px; BORDER-BOTTOM: #5a667b 1px solid; FONT-FAMILY: Tahoma, Helvetica, sans; BACKGROUND-COLOR:#ffffff; TEXT-ALIGN: left
    }   
    </style>
 <script language="javascript" type ="text/javascript">
        function btnLogin_onclick() {
            if (document.getElementById("txtusername").value == "") {
                alert("请输入用户名！");
                document.getElementById("txtusername").focus();
                return false;
            }
            if (document.getElementById("txtusername").value.indexOf("'") > -1 || document.getElementById("txtusername").value.indexOf("<") > -1 || document.getElementById("txtusername").value.indexOf(">") > -1 || document.getElementById("txtusername").value.indexOf("--") > -1) {
                alert("输入的用户名中含有非法符号<>'--,请删除！");
                document.getElementById("txtusername").focus();
                return false;
            }
            if (document.getElementById("txtpassword").value == "") {
                alert("请输入密码！");
                document.getElementById("txtpassword").focus();
                return false;
            }
            if (document.getElementById("txtpassword").value.indexOf("'") > -1 || document.getElementById("txtpassword").value.indexOf("<") > -1 || document.getElementById("txtpassword").value.indexOf(">") > -1 || document.getElementById("txtpassword").value.indexOf("--") > -1) {
                alert("输入的密码中含有非法符号<>'--,请删除！");
                document.getElementById("txtpassword").focus();
                return false;
            }
            return true;
        }
        function showSelectpwd(username) {
            if (username != "") { 
                
            }
        }
        function showSelectpwd() {
            document.getElementById("loader_container").style.display = "block";
            //document.getElementById("backimg").style.display = "block";
            document.getElementById("backimg").style.height = document.body.offsetHeight;
            document.getElementById("backimg").style.width = document.body.scrollWidth;
            if (document.getElementById("txtusername").value != "")
                document.getElementById("txtname").value = document.getElementById("txtusername").value;
        }
        function NoshowSelectpwd() {
            document.getElementById("loader_container").style.display = "none";
            document.getElementById("backimg").style.display = "none";
        }
        function selectUserpassword() {
            if (document.getElementById("txtname").value == "") {
                alert("请输入用户名！");
                document.getElementById("txtname").focus();
                return false;
            }
            else {
                CheckUserNameIsExist();
            }
        }

        function createHttpRequest() {
            try {
                return new ActiveXObject('MSXML2.XMLHTTP.4.0');
            }
            catch (e) {
                try {
                    return new ActiveXObject('MSXML2.XMLHTTP.3.0');
                }
                catch (e) {
                    try {
                        return new ActiveXObject('MSXML2.XMLHTTP.5.0');
                    } catch (e) {
                        try {
                            return new ActiveXObject('MSXML2.XMLHTTP');
                        } catch (e) {
                            try {
                                return new ActiveXObject('Microsoft.XMLHTTP');
                            } catch (e) {
                                if (window.XMLHttpRequest) {
                                    return new XMLHttpRequest();
                                }
                                else {
                                    return null;
                                }
                            }
                        }
                    }
                }
            }
        }

        var xmlhttpRegister;
        function CheckUserNameIsExist() {
            try {
                if (document.getElementById("txtname").value == "")
                    return;
                document.getElementById("txtname").value = document.getElementById("txtname").value.replace("<", "").replace(">", "").replace("'", "").replace("--", "");
                xmlhttpRegister = createHttpRequest();
                document.getElementById("spanusernamecheck").innerHTML = "<font size=2 color=blue>用户名检查中...</font>";
                var UrlStr = "UserLogin.aspx?ResponseUserName=" + document.getElementById("txtname").value;
                xmlhttpRegister.onreadystatechange = processReqChange1;
                xmlhttpRegister.open("POST", UrlStr, true);
                xmlhttpRegister.setRequestHeader('Connection', 'close');
                xmlhttpRegister.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
                xmlhttpRegister.send(null);
            }
            catch (e) {
                document.getElementById("spanusernamecheck").innerHTML = "<font size=2 color=red>网络忙，请稍后操作!</font>";
                document.getElementById("hiddenCheckOk").value = "error";
            }
        }
        function processReqChange1() {
            try {
                if (xmlhttpRegister.readyState == 4) {
                    if (xmlhttpRegister.status == 200) {
                        if (xmlhttpRegister.responseText == "exsit") {
                            document.getElementById("spanusernamecheck").innerHTML = "<font size=2 color=green><b>*</b></font>";
                            document.getElementById("hiddenCheckOk").value = "ok";
                            var pwd = GetUserPassword();
                            if (pwd != "") {
                                if (window.confirm("您确定您的用户名是" + document.getElementById("txtname").value + "？\n\n(请勿非法窃取该用户密码！)")) {
                                    if (pwd != "iperror") {
                                        alert("请熟记该用户的密码：" + pwd + "\n\n点击确定系统将自动为您登录！");
                                        NoshowSelectpwd();
                                        document.getElementById("txtusername").value = document.getElementById("txtname").value;
                                        document.getElementById("txtpassword").value = pwd;
                                        document.getElementById("BtnLogin").click();
                                    }
                                    else {
                                        alert("该台电脑不是该用户注册时所使用的电脑！\n\n(需在原来用户注册时所使用的电脑上才可找回密码)");
                                    }
                                }
                            }
                            else {
                                alert("输入用户名为管理员用户，普通用户无权找回此用户密码！");
                                document.getElementById("txtname").focus();
                            }
                        }
                        else {
                            document.getElementById("spanusernamecheck").innerHTML = "<font size=2 color=red>不存在此用户!</font>";
                            document.getElementById("hiddenCheckOk").value = "error";
                        }
                    }
                }
            }
            catch (e) {
                document.getElementById("spanusernamecheck").innerHTML = "<font size=2 color=red>网络忙，请稍后操作!</font>";
                document.getElementById("hiddenCheckOk").value = "error";
            }
        }

        function GetUserPassword() {
            try {
                xmlhttpGetUserPassword = createHttpRequest();
                var UrlStr = "UserLogin.aspx?ResponseGetUserPassword=" + document.getElementById("txtname").value + "&ResponseIPAddress=" + document.getElementById("hiddenIPAddress").value;
                    xmlhttpGetUserPassword.open("POST", UrlStr, false);
                    xmlhttpGetUserPassword.setRequestHeader('Connection', 'close');
                    xmlhttpGetUserPassword.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
                    xmlhttpGetUserPassword.send(null);
                    return xmlhttpGetUserPassword.responseText;
            }
            catch (e) {
                return e;
            }
        }
    </script>
     <style type="text/css">#loader_container {
	Z-INDEX: 10; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 32%; TEXT-ALIGN: center
}
    #loader {
	BORDER-RIGHT: #5a667b 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #5a667b 1px solid; DISPLAY: block; PADDING-LEFT: 5px; FONT-SIZE: 11px; Z-INDEX: 2; PADDING-BOTTOM: 5px; MARGIN: 0px auto; BORDER-LEFT: #5a667b 1px solid; WIDTH: 400px; COLOR: #000000; PADDING-TOP: 5px; BORDER-BOTTOM: #5a667b 1px solid; FONT-FAMILY: Tahoma, Helvetica, sans; BACKGROUND-COLOR: #ffffff; TEXT-ALIGN: left
}
</style>
<link href="../css/base.css" type="text/css" rel="Stylesheet" />
</head>
<body     bgcolor="#ffffff" >
    <form id="form1" runat="server">
    <!--顶层内容start-->
    <DIV id="loader_container" style="DISPLAY: none; WIDTH: 100%; HEIGHT: 6px">
				<DIV id="loader">
				     <center>
				        <table border="0" width="400px" cellpadding="6" cellspacing="1"  bgcolor="#9999ff">
				            <tr><td colspan=2  style="background-image:url(../img/menuBackGround.jpg) " ><font size=3 color="#666699"><b>找&nbsp;回&nbsp;密&nbsp;码</b></font></td></tr>
				            <tr>
				                <td width="120" align="right" bgcolor="#ffffff"><font size=2 color="#666699"><b>用户名：<input type="hidden" id="hiddenVideoID" runat="server" /></b></font></td>
				                <td width="280" align="left" bgcolor="#ffffff"><input type="text" ID="txtname"  class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'" ><span id="spanusernamecheck"><font color="red">*</font></span>
                                <input type="hidden" id="hiddenCheckOk" /></td>
				            </tr>
				            <tr>
				                <td colspan ="2" align ="center" bgcolor="#ffffff">&nbsp;&nbsp;<input  class="ButtonCss"  type="button" value="找回密码" id="btnselectpwd" onclick="selectUserpassword();" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input  class="ButtonCss"   type="button" value="取消" onclick="NoshowSelectpwd();" />
				            </tr>
				        </table>
				     </center>
		        </DIV>
	</DIV>
    <!--顶层内容end-->
    <DIV id="backimg" style="DISPLAY: none; Z-INDEX: 1; BACKGROUND: url(../img/backgroudimage.png); FILTER: alpha(opacity=70); LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 0px; HEIGHT: 0px"><FONT face="宋体"></FONT></DIV>
   
   <!--底层内容start-->
    <div>
    <center ><table  border ="0" cellpadding ="0" cellspacing ="0" width ="555px" bgcolor="#ffffff"><tr><td align="left"><a href="http://www.cninterface.com"><img border="0"  src="img/indexHeader.jpg"/></a></td></tr></table>
         <center>
				        <table border="0" width="555px" border='0'  cellSpacing='1' cellPadding='4' bgcolor="#9999ff">
				            <tr><td colspan=2  style="background-image:url(../img/menuBackGround.jpg) "  align="left"><input type="hidden" id="hiddenIPAddress" runat="server" /> <font size=3 color="#666699"><b>用户登录：</b></font></td></tr>
				            <tr>
				                <td width="35%" align="right" bgcolor="#ffffff"><font size=2 color="#666699"><b>用户名：</b></font>&nbsp;&nbsp;&nbsp;</td>
				                <td width="65%" align="left" bgcolor="#ffffff"><input type ="hidden" id="hiddenPreUrl"  runat ="server" /><asp:TextBox 
                                        ID="txtusername" runat="server" Width="150px"  class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'" ></asp:TextBox>
                                </td>
				            </tr>
				            <tr >
				                <td align="right" bgcolor="#ffffff"><font size=2 color="#666699"><b>密&nbsp;&nbsp;&nbsp;&nbsp;码：</b></font>&nbsp;&nbsp;&nbsp;</td>
				                <td  align="left" bgcolor="#ffffff"><asp:TextBox ID="txtpassword" runat="server" Width="150px" TextMode="Password"  class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'" ></asp:TextBox>&nbsp;&nbsp;<a href="#" onclick="showSelectpwd();" ><font size="2">忘记密码?</font></span>
                                </td>
				            </tr>
				            <tr>
				                <td colspan ="2" align ="center" bgcolor="#ffffff"><asp:Button ID="BtnLogin" 
                                        runat="server"  OnClientClick="return btnLogin_onclick()"  Text="登&nbsp;&nbsp;&nbsp;录" 
                                        onclick="BtnLogin_Click" CssClass="ButtonCss" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href ="Register.aspx"><font size="2" >新用户注册</font></a>
				            </tr>
				        </table>
				     </center>
				      <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="678px"><tr height="80px"><td>
           &nbsp;</td></tr></table>
      <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="678px">
            <tr>
                    <td  width="71%"  align="right"><font size=2 color=#666699><a href ="#" onclick="window.external.AddFavorite(location.href, document.title);"><font size=2 color="#666699">
                        收藏本站</font> - <a href="http://www.cninterface.com" title="旨在提供接口共享平台，体现接口服务价值"><font size=2 color="#666699">天下接口网</font></a> - <a href ="#" title="网站创意诞生于2010年3月2日,旨在提供短信在线发送平台，提供用户方便."><font size=2 color="#666699">关于我们</font></a></font><img border="0"  src="img/blank.jpg" width="70px" height="1px"  style="FILTER: alpha(opacity=0);opacity:0;"/></td>
                    <td  width="29%">&nbsp;</td>
            </tr>
            <tr>
                <td  align="right"><font size=2 color=#666699>Copyright © 2010 CnInterface.com  版权所有</font><img border="0"  src="img/blank.jpg" width="43px" height="1px"  style="FILTER: alpha(opacity=0);opacity:0;"/></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td  align="right"><font size=2 color=#666699><a href="http://www.miibeian.gov.cn/" target='_blank' ><font size=2 color="#666699">京ICP备10038387号 </font></a><img border="0"  src="img/blank.jpg" width="7px"  style="FILTER: alpha(opacity=0);opacity:0;"/>联系方式：<a href="http://wpa.qq.com/msgrd?V=1Uin=459313018&Site=ioshenmue&Menu=yes" target="_blank"><font size=2 color="#666699">QQ</font></a><img border="0"  src="img/blank.jpg" width="6px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href="msnim:chat?contact=liwei5000000@163.com"><font size=2 color="#666699">MSN</font></a><img border="0"  src="img/blank.jpg" width="6px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href='http://www.alisoft.com/portal/promotion/alitalk/tbfuchu/go123.html?id=9927375' target='_blank'><font size=2 color="#666699">TEL</font></a></font><img border="0"  src="img/blank.jpg" width="24px" height="1px"  style="FILTER: alpha(opacity=0);opacity:0;"/></td>
                <td>&nbsp;</td>
            </tr>
      </table>
    </div>
    </form>
    <div style="display:none;"><script src="http://s11.cnzz.com/stat.php?id=2099859&web_id=2099859&show=pic1" language="JavaScript"></script></div>
</body>
</html>

