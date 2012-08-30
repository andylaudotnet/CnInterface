<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MobileMessages.aspx.cs" Inherits="CnWeb.MobileMessages"  EnableViewState="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <title>手机短信在线发送</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
   <meta name="keywords" content="短信,短信发送,短信在线发送,手机短信,手机短信发送,手机短信在线发送,飞信,飞信登录,飞信短信,飞信好友,接口,interface,天下接口,接口天下,程序接口,网络接口,webservice接口,http接口,ActiveX dll接口,普通dll接口,数据库接口,第一页搜索,首页搜索,搜索引擎,google,百度,雅虎,bing,搜狗,搜搜,有道." />
       <style type="text/css">
        a:link {text-decoration:none;color:#666699;}	/* 未访问的链接 */
         a:visited {text-decoration:none;color:#666699}	/* 已访问的链接 */
         a:hover {text-decoration:underline; color:#666699; }	/* 鼠标移动到链接上 */
         a:active {text-decoration:underline;color:#666699}	/* 选定的链接 */
         .ButtonCss
        {
            BACKGROUND-COLOR:#ffffff; BORDER-RIGHT: #A9BAC9 1px solid; PADDING-RIGHT: 8px; BORDER-TOP: #A9BAC9 1px solid; PADDING-LEFT: 8px; FONT-SIZE: 12px;  BORDER-LEFT: #A9BAC9 1px solid; CURSOR: hand; COLOR: #666699; font-weight:bold; PADDING-TOP: 4px; PADDING-BOTTOM: 2px;BORDER-BOTTOM: #A9BAC9 1px solid;
        }
        .text_dialog1,.text_dialog2 {height:19px; line-height:19px; border:1px solid #A9BAC9; padding:0 2px; font-size:12px;font-weight:bold; COLOR: #000066;  }
        .text_dialog2 { border:1px solid #9ECC00;COLOR: #000066; }
    </style>
    <link href="../css/base.css" type="text/css" rel="Stylesheet" />
</head>
<body bgcolor="#ffffff" >
     <form id="form1" runat="server">
    <div>
    <center>
<table   border ="0" cellpadding ="3" cellspacing ="1" width ="888px" bgcolor="#9999ff">
           
            <tr><td align="left"  style="background-image:url(img/menuBackGround.jpg) " ><font color="#666699"> 本机共发送手机短信<font color=blue><b><%=messageCount %></b></font>条 | 今日已发送<font color=blue><b><%=todaymessageCount.ToString()%></b></font>条 </font></td></tr>
            
            <tr>
                <td  bgcolor="#ffffff"  align="left">&nbsp;<font size=2 color=#666699><b>请输入你要查询的手机号码：</b></font>
                    <asp:TextBox ID="txtMobileNo" runat="server"   class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'" ></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnMessagesSelect" runat="server" 
                        Text="查询" onclick="btnMessagesSelect_Click"   CssClass="ButtonCss" />
                </td>
           </tr>
           <tr>
                <td align="left"  bgcolor="#ffffff" ><asp:Label ID="labMobileMessages" runat="server" ></asp:Label></td>
            </tr>
   </table>
   </center>
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
                <td  align="right"><font size=2 color=#666699><a href="http://www.miibeian.gov.cn/" target='_blank' ><font size=2 color="#666699">京ICP备10038387号 </font></a><img border="0"  src="img/blank.jpg" width="7px"  style="FILTER: alpha(opacity=0);opacity:0;"/>联系方式：<a href="http://wpa.qq.com/msgrd?V=1Uin=459313018&Site=ioshenmue&Menu=yes" target="_blank"><font size=2 color="#666699">QQ</font></a><img border="0"  src="img/blank.jpg" width="6px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href="msnim:chat?contact=liwei5000000@163.com"><font size=2 color="#666699">MSN</font></a><img border="0"  src="img/blank.jpg" width="6px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href='http://www.alisoft.com/portal/promotion/alitalk/tbfuchu/go123.html?id=9927375' target='_blank'><font size=2 color="#666699">TEL</font></a></font><img border="0"  src="img/blank.jpg" width="24px" height="1px"  style="FILTER: alpha(opacity=0);opacity:0;"/></td>
                <td>&nbsp;</td>
            </tr>
      </table>
      <div style="display:none;"><script src="http://s11.cnzz.com/stat.php?id=2099859&web_id=2099859&show=pic1" language="JavaScript"></script></div>
</body>
</html>
