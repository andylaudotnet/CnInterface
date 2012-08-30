<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParseXPathManage.aspx.cs" Inherits="CnWeb.Parse.ParseXPathManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>天下接口网</title>
    <meta http-equiv="content-type" content="text/html;charset=utf-8">
    <meta name="keywords" content="接口,interface,天下接口,接口天下,程序接口,网络接口,webservice接口,http接口,ActiveX dll接口,普通dll接口,数据库接口,短信,短信发送,短信在线发送,手机短信,手机短信发送,手机短信在线发送,飞信,飞信登录,飞信短信,飞信好友,第一页搜索,首页搜索,搜索引擎,google,百度,雅虎,bing,搜狗,搜搜,有道." />
    <style type="text/css">
         a:link {text-decoration:none;color:#666699;}	/* 未访问的链接 */
         a:visited {text-decoration:none;color:#666699}	/* 已访问的链接 */
         a:hover {text-decoration:underline; color:#666699; }	/* 鼠标移动到链接上 */
         a:active {text-decoration:underline;color:#666699}	/* 选定的链接 */
         .text_dialog1,.text_dialog2 {height:20px; line-height:19px; border:1px solid #A9BAC9; padding:0 2px; font-size:12px;COLOR:black;  }
         .text_dialog2 { border:1px solid #A9BAC9;COLOR: #666699; }
        .ButtonCss
            {
                BACKGROUND-COLOR:#ffffff; BORDER-RIGHT: #A9BAC9 1px solid; PADDING-RIGHT: 8px; BORDER-TOP: #A9BAC9 1px solid; PADDING-LEFT: 8px; FONT-SIZE: 12px; BORDER-LEFT: #A9BAC9 1px solid; CURSOR: hand; COLOR:#666699; PADDING-TOP: 3px; PADDING-BOTTOM: 1px;BORDER-BOTTOM: #A9BAC9 1px solid;
            }
    </style>
    <link href="../css/base.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="555px"><tr height="23px"><td>&nbsp;</td></tr></table>
    <table  border="0" cellpadding ="4" cellspacing ="1"  bgcolor="#9999ff" align="center"  width="750px" >
                    <tr>
                        <td  bgcolor="#ffffff" colspan="2" ><a href="<%=WebUrl%>" target="_blank"><font color="blue"><b><%=WebName%></b></font></a><font color="#666699"><b>XPath管理：</b></font>&nbsp;&nbsp;<a href="Index.aspx" >返回</a></td>
                    </tr>
                    <tr>
                        <td  bgcolor="#ffffff" width="100px">网络地址：</td>
                        <td  bgcolor="#ffffff"><asp:TextBox ID="txtWebAddress" runat="server" Width="577px" ForeColor="Green"></asp:TextBox><font color="#666699">url</font></td>
                    </tr>
                     <tr>
                        <td  bgcolor="#ffffff" width="100px">网络编码：</td>
                        <td  bgcolor="#ffffff"><asp:TextBox ID="txtWebEncode" runat="server" Width="100px" ForeColor="Green"></asp:TextBox><font color="#666699">encode</font></td>
                    </tr>
                    <tr>
                        <td  bgcolor="#ffffff">第一条记录：</td>
                        <td  bgcolor="#ffffff">
                                <asp:TextBox ID="txtTitle001" runat="server" Width="577px" ForeColor="Green"></asp:TextBox><font color="#666699">title</font>
                                <asp:TextBox ID="txtHref001" runat="server" Width="577px" ForeColor="Green"></asp:TextBox><font color="#666699">href</font>
                                <asp:TextBox ID="txtSrc001" runat="server" Width="577px" ForeColor="Green"></asp:TextBox><font color="#666699">src</font>
                        </td>
                    </tr>
                    <tr>
                        <td  bgcolor="#ffffff">第二条记录：</td>
                        <td  bgcolor="#ffffff">
                                <asp:TextBox ID="txtTitle002" runat="server" Width="577px" ForeColor="Green"></asp:TextBox><font color="#666699">title</font>
                                <asp:TextBox ID="txtHref002" runat="server" Width="577px" ForeColor="Green"></asp:TextBox><font color="#666699">href</font>
                                <asp:TextBox ID="txtSrc002" runat="server" Width="577px" ForeColor="Green"></asp:TextBox><font color="#666699">src</font>
                        </td>
                    </tr>
                    <tr>
                        <td  bgcolor="#ffffff">第三条记录：</td>
                        <td  bgcolor="#ffffff">
                                <asp:TextBox ID="txtTitle003" runat="server" Width="577px" ForeColor="Green"></asp:TextBox><font color="#666699">title</font>
                                <asp:TextBox ID="txtHref003" runat="server" Width="577px" ForeColor="Green"></asp:TextBox><font color="#666699">href</font>
                                <asp:TextBox ID="txtSrc003" runat="server" Width="577px" ForeColor="Green"></asp:TextBox><font color="#666699">src</font>
                        </td>
                    </tr>
                    <tr>
                        <td  bgcolor="#ffffff">第四条记录：</td>
                        <td  bgcolor="#ffffff">
                                <asp:TextBox ID="txtTitle004" runat="server" Width="577px" ForeColor="Green"></asp:TextBox><font color="#666699">title</font>
                                <asp:TextBox ID="txtHref004" runat="server" Width="577px" ForeColor="Green"></asp:TextBox><font color="#666699">href</font>
                                <asp:TextBox ID="txtSrc004" runat="server" Width="577px" ForeColor="Green"></asp:TextBox><font color="#666699">src</font>
                        </td>
                    </tr>
                    <tr>
                        <td  bgcolor="#ffffff">第五条记录：</td>
                        <td  bgcolor="#ffffff">
                                <asp:TextBox ID="txtTitle005" runat="server" Width="577px" ForeColor="Green"></asp:TextBox><font color="#666699">title</font>
                                <asp:TextBox ID="txtHref005" runat="server" Width="577px" ForeColor="Green"></asp:TextBox><font color="#666699">href</font>
                                <asp:TextBox ID="txtSrc005" runat="server" Width="577px" ForeColor="Green"></asp:TextBox><font color="#666699">src</font>
                        </td>
                    </tr>
                    <tr>
                        <td  bgcolor="#ffffff">第六条记录：</td>
                        <td  bgcolor="#ffffff">
                                <asp:TextBox ID="txtTitle006" runat="server" Width="577px" ForeColor="Green"></asp:TextBox><font color="#666699">title</font>
                                <asp:TextBox ID="txtHref006" runat="server" Width="577px" ForeColor="Green"></asp:TextBox><font color="#666699">href</font>
                                <asp:TextBox ID="txtSrc006" runat="server" Width="577px" ForeColor="Green"></asp:TextBox><font color="#666699">src</font>
                        </td>
                    </tr>
                    <tr>
                        <td  bgcolor="#ffffff" colspan="2" align="center">
                            <asp:Button runat="server" ID="btnXpathUpdae" Text ="更  新" CssClass="ButtonCss" 
                                onclick="btnXpathUpdae_Click" />&nbsp;&nbsp;<asp:Label ID="labUpdateResult" runat="server"></asp:Label>
                        </td>
                    </tr>
    </table>
    </div>
    </form>
    <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="678px"><tr height="50px"><td>
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
                <td  align="right"><font size=2 color=#666699><a href="http://www.miibeian.gov.cn/" target='_blank' ><font size=2 color="#666699">京ICP备10038387号 </font></a><img border="0"  src="img/blank.jpg" width="7px"  style="FILTER: alpha(opacity=0);opacity:0;"/> <script src="http://s11.cnzz.com/stat.php?id=2099859&web_id=2099859&show=pic1" language="JavaScript"></script><img border="0"  src="img/blank.jpg" width="7px"  style="FILTER: alpha(opacity=0);opacity:0;"/>联系方式：<a href="http://wpa.qq.com/msgrd?V=1Uin=459313018&Site=ioshenmue&Menu=yes" target="_blank"><font size=2 color="#666699">QQ</font></a><img border="0"  src="img/blank.jpg" width="6px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href="msnim:chat?contact=liwei5000000@163.com"><font size=2 color="#666699">MSN</font></a><img border="0"  src="img/blank.jpg" width="6px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href='http://www.alisoft.com/portal/promotion/alitalk/tbfuchu/go123.html?id=9927375' target='_blank'><font size=2 color="#666699">TEL</font></a></font><img border="0"  src="img/blank.jpg" width="10px" height="1px"  style="FILTER: alpha(opacity=0);opacity:0;"/></td>
                <td>&nbsp;</td>
            </tr>
      </table>
</body>
</html>
