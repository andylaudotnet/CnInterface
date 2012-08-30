<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SmsNormal.aspx.cs" Inherits="CnWeb.SmsNormal" %>

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
    </style>
    <script language="javascript" src="js/index.js" type ="text/javascript"></script>
    <link href="../css/base.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table id="tabSmsNormal" border="0" cellpadding ="4" cellspacing ="1"  bgcolor="#9999ff" align="center" width="555px">
                                        <tr>
                                            <td align="right" bgcolor="#ffffff"><input type="hidden" id="hiddenUsername"  runat="server"/><font color=black size=2>手&nbsp;&nbsp;机&nbsp;&nbsp;号：</font></td>
                                            <td bgcolor="#ffffff"> <asp:TextBox ID="txtSmsmob"  runat="server"  Width="110px" BackColor="#ffffff" MaxLength="11"   class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  ></asp:TextBox><asp:Label ID="labmobileInfo" runat="server" Text="<font color=#666699 size=2>*接收者手机号(11位),小灵通前加区号</font>"></asp:Label></td>
                                        </tr>
                                        <tr>
                                           <td bgcolor="#ffffff"  align="right" ><font color=black size=2>短信内容：</font></td>
                                            <td bgcolor="#ffffff">
                                                <asp:TextBox ID="txtSms" runat="server" TextMode="MultiLine" Height="80px" Width="310px" MaxLength="66"  class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  ></asp:TextBox><asp:Label ID="labcontextInfo" runat="server" Text="<font color=#666699 size=2>*60字以内,含符号</font>"></asp:Label>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td  align="right"  bgcolor="#ffffff"><font color=black size=2>发送者姓名：</font></td>
                                            <td bgcolor="#ffffff"> <asp:TextBox ID="txtsenduser" runat="server"  Width="110px" BackColor="#ffffff"  MaxLength="10"  class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'" ></asp:TextBox><asp:Label ID="labsenderInfo" runat="server" Text="<font color=#666699 size=2>*中文格式,便于接收者知悉</font>"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td  colspan="2"  align="left" bgcolor="#ffffff">
                                                <table  border="0" cellpadding ="0" cellspacing ="0"  width="100%" bgcolor="#ffffff">
                                                    <tr>
                                                        <td align="left" width="53%" valign="middle"><asp:Label ID="labresult" runat="server" Text="" ForeColor="Red"  style="padding-top:expression(document.body.clientHeight/2)"></asp:Label></td>
                                                        <td align="left" width="*"><asp:Button  CssClass="ButtonCss"  ID="bntSendNote" 
                                                                runat="server" Text="发送短信" 
                                                                onclick="bntSendNote_Click"   OnClientClick="return checkparames();"/>&nbsp;&nbsp;&nbsp;&nbsp;<a href='MobileMessages.aspx' target='_blank'><font color=#006600  size=2>本机已发短信</font></a></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
          </table>
    </div>
    </form>
</body>
</html>
