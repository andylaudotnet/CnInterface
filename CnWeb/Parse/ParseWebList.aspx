<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParseWebList.aspx.cs" Inherits="CnWeb.Parse.ParseWebList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>www.CnInterface.com天下接口</title>
    <meta http-equiv="content-type" content="text/html;charset=utf-8">
    <meta name="keywords" content="接口,天下接口,价值接口,程序接口,网络接口,webservice接口,http接口,ActiveX dll接口,普通dll接口,数据库接口,短信,短信发送,短信在线发送,手机短信,手机短信发送,手机短信在线发送" />
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
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="555px"><tr height="30px"><td>&nbsp;</td></tr></table>
     <table  border="0" cellpadding ="4" cellspacing ="1"  bgcolor="#9999ff" align="center"  width="555px" >
                    <tr>
                        <td colspan="5" bgcolor="#ffffff"  align="left"  style="background-image:url(img/menuBackGround.jpg) "><font color="#666699"><b>请选择网站进行XPath管理：</b></font>&nbsp;&nbsp;<a href="Index.aspx" >返回</a></td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=youku">优酷网</a></td>
                        <td align="center" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=tudou">土豆网</a></td>
                        <td align="center" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=baidu">百度视频搜索</a></td>
                        <td align="center" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=xunlei">迅雷看看</a></td>
                        <td align="center" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=joy">激动网</a></td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=sina">新浪视频</a></td>
                        <td align="center" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=ku6">酷6视频</a></td>
                        <td align="center" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=sohu">搜狐视频</a></td>
                        <td align="center" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=qq">QQ播客</a></td>
                        <td align="center" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=hunantv">芒果TV</a></td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=tencent">腾讯宽频</a></td>
                        <td align="center" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=6cn">六间房</a></td>
                        <td align="center" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=ifeng">凤凰宽频</a></td>
                        <td align="center" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=news">新华网</a></td>
                        <td align="center" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=56">56网</a></td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=pps">PPS</a></td>
                        <td align="center" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=pplive">PPLive</a></td>
                        <td align="center" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=funshion">风行</a></td>
                        <td align="center" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=uusee">UUsee</a></td>
                        <td align="center" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=m1905">m1905电影网</a></td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=pomoho">爆米花</a></td>
                        <td align="center" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=letv">乐视网</a></td>
                        <td align="center" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=aeeboo">爱播网</a></td>
                         <td align="left" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=openv">天线高清</a></td>
                        <td align="center" bgcolor="#ffffff" ><a href="ParseXPathManage.aspx?web=google">google视频搜索</a></td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=17173">17173游戏视频</a></td>
                        <td align="center" bgcolor="#ffffff"><a href="ParseXPathManage.aspx?web=cntv">中国网络电视台</a></td>
                        <td align="right" bgcolor="#ffffff"  colspan="3"><a href="http://www.265.com/Shipin_Boke/"  target="_blank">更多</a>&nbsp;&nbsp;</td>
                    </tr>
     </table>
    </div>
    </form>
</body>
</html>
