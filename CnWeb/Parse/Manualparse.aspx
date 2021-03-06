﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manualparse.aspx.cs" Inherits="CnWeb.Parse.Manualparse" %>

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
                BACKGROUND-COLOR:#ffffff; BORDER-RIGHT: #A9BAC9 1px solid; PADDING-RIGHT: 8px; BORDER-TOP: #A9BAC9 1px solid; PADDING-LEFT: 8px; FONT-SIZE: 12px;  BORDER-LEFT: #A9BAC9 1px solid; CURSOR: hand; COLOR:#666699; PADDING-TOP: 3px; PADDING-BOTTOM: 1px;BORDER-BOTTOM: #A9BAC9 1px solid;
            }
    </style>
    <link href="../css/base.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="555px"><tr height="30px"><td>&nbsp;</td></tr></table>
    <table  border="0" cellpadding ="4" cellspacing ="1"  bgcolor="#9999ff" align="center"  width="555px" >
        <tr>
            <td bgcolor="#ffffff" colspan="2" style="background-image:url(img/menuBackGround.jpg) "><font color="#666699"><b>人工Parse添加接口：</b></font></td>
        </tr>
        <tr>
            <td bgcolor="#ffffff" width="100px"><font size=2>接口类型：</font></td>
            <td bgcolor="#ffffff">
                     <asp:DropDownList ID="ddlInterfaceType" runat="server"></asp:DropDownList><font color="#666699">*</font>
            </td>
        </tr>
        <tr>
            <td bgcolor="#ffffff"><font size=2>发布时间：</font></td>
            <td bgcolor="#ffffff"><asp:TextBox ID="txtInterfaceAppearTime"  runat="server"  Width="102px" BackColor="#ffffff"   class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  ></asp:TextBox><font color="#666699" size="2">*(格式:2010-03-15)</font></td>
        </tr>
         <tr>
            <td bgcolor="#ffffff"><font size=2>接口名称：</font></td>
            <td bgcolor="#ffffff"><asp:TextBox ID="txtInterfaceName"  runat="server"  Width="222px" BackColor="#ffffff"   class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  ></asp:TextBox><font color="#666699" size="2">*</font></td>
        </tr>
         <tr>
            <td bgcolor="#ffffff"><font size=2>接口地址：</font></td>
            <td bgcolor="#ffffff"><asp:TextBox ID="txtInterfaceUrl"  runat="server"  Width="405px" BackColor="#ffffff"   class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  ></asp:TextBox><font color="#666699" size="2">*</font></td>
        </tr>
         <tr>
            <td bgcolor="#ffffff"><font size=2>接口描述内容：</font></td>
            <td bgcolor="#ffffff"><asp:TextBox ID="txtInterfaceBody" runat="server" TextMode="MultiLine" Height="180px" Width="405px"  class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  ></asp:TextBox><font color="#666699" size="2">*</font></td>
        </tr>
         <tr>
            <td bgcolor="#ffffff"><font size=2>接口来源名称：</font></td>
            <td bgcolor="#ffffff"><asp:TextBox ID="txtInterfaceSource"  runat="server"  Width="222px" BackColor="#ffffff"   class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  ></asp:TextBox><font color="#666699" size="2">*</font></td>
        </tr>
         <tr>
            <td bgcolor="#ffffff"><font size=2>接口来源地址：</font></td>
            <td bgcolor="#ffffff"><asp:TextBox ID="txtInterfaceSourceUrl"  runat="server"  Width="405px" BackColor="#ffffff"   class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  ></asp:TextBox><font color="#666699" size="2">*</font></td>
        </tr>
         <tr>
            <td bgcolor="#ffffff" colspan="2" align="center">
                 <asp:Button  CssClass="ButtonCss"  ID="bntInterfaceAdd"  runat="server" 
                     Text="添加接口" onclick="bntInterfaceAdd_Click" />&nbsp;&nbsp;&nbsp;<a href="Index.aspx"><font size=2>返回</font></a>
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
