<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CnWeb._Index" %>

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
<body bgcolor="#ffffff">
     <!--顶层内容start-->
    <DIV id="loader_container" style="DISPLAY: none; WIDTH: 100%; HEIGHT: 6px">
				<DIV id="loader">
				         <table  border="0" cellpadding ="4" cellspacing ="1"  bgcolor="#9999ff" align="center"  width="333px" >
				                        <td align="left"  style="background-image:url(img/menuBackGround.jpg) "colspan="2"><font size=2  color="#666699"><b>用户登录:</b></font></td>
                                        <tr>
                                            <td align="center" bgcolor="#ffffff" width="15%"><input type="hidden" id="hidden1" runat="server" /><font color=black size=2>用&nbsp;&nbsp;户&nbsp;&nbsp;名：</font></td>
                                            <td bgcolor="#ffffff" width="85%"> <input type="text"  id="txtusername"   onkeydown="LoginOnkeydownEvent();"  style="width:145px"  class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"/><font color=#666699 size=2>*</font></td>
                                        </tr>
                                          <tr>
                                            <td align="center" bgcolor="#ffffff"><font color=black size=2>密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码：</font></td>
                                            <td bgcolor="#ffffff"> <input type="password"  id="txtpassword"  onkeydown="LoginOnkeydownEvent();"   style="width:145px"    class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"/><font color=#666699 size=2>*</font></td>
                                        </tr>
                                         <tr>
                                            <td align="center" bgcolor="#ffffff" colspan="2"><input type="checkbox" id="ckbLoginStatus" /><font color="black" size="2">记住我的登录状态。</font>&nbsp;<font color="#666699" size="2">(公用电脑请勿选择此项)</font></td>
                                         </tr>
                                          <tr>
                                            <td bgcolor="#ffffff" colspan="2">
                                                <table  border="0" cellpadding ="0" cellspacing ="0"  width="100%">
                                                    <tr>
                                                        <td width="73%" align="right"><input  type="button"  id="btnLogin"  value="登录" onclick="CheckLoginNamePwd();"  class="ButtonCss" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="button"  id="btncancel"  value="取消"  class="ButtonCss" onclick="loginCancel();" /></td>
                                                        <td width="27%">&nbsp;&nbsp;<a href="../user/Register.aspx"><font size=2>新用户注册</font></a></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                         </table>
				</DIV>
	</DIV>
    <!--顶层内容end-->
    <DIV id="backimg" style="DISPLAY: none; Z-INDEX: 1; BACKGROUND: url(img/backgroudimage.png); FILTER: alpha(opacity=78); LEFT: 0px; WIDTH: 0px; POSITION: absolute; TOP: 0px; HEIGHT:0px"><FONT face="宋体"></FONT></DIV>
   
   <!--底层内容start-->
    <div id="div_login" style="text-align:right;margin-right:15px;margin-top:2px;"><span id="spanusername" runat="server"><a href="http://www.cninterface.com/user/UserLogin.aspx"><font size=2>登录</font></a></span></div>
    <form id="form1" runat="server">
    <div>
             
            <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="555px" >
                <tr><td ><input type="hidden" id="hiddenUsername"  runat="server"/><input type="hidden" id="hiddenSsqResult"/><a href="http://www.cninterface.com"><img border="0"  src="img/indexHeader.jpg"/></a></td></tr>
            </table>
            <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="555px"  >
              <tr>
                                            <td align="left" bgcolor="#ffffff"  width="60%" height="25px" style="background-image:url(img/menuBackGround.jpg) ">
                                             <input id="rdlSmsType_1" type="radio" name="rdlSmsType" value="1" checked="checked"  onclick="SelectSmsType(1);"  style="cursor:hand;cursor:pointer;"/><font color="#666699" size=2   onclick="SelectSmsType(1);"   style="cursor:hand;cursor:pointer;">短信在线发送</font>
                                             <input id="rdlSmsType_2" type="radio" name="rdlSmsType" value="2"   onclick="SelectSmsType(2);"  style="cursor:hand;cursor:pointer;"/><font color=#666699 size=2  onclick="SelectSmsType(2);"   style="cursor:hand;cursor:pointer;">飞信功能</font>
                                             <input id="rdlSmsType_3" type="radio" name="rdlSmsType" value="3"   onclick="SelectSmsType(3);"  style="cursor:hand;cursor:pointer;"/><font color=#666699 size=2  onclick="SelectSmsType(3);"   style="cursor:hand;cursor:pointer;">双色球抽奖</font>
                                             &nbsp;&nbsp;
                                             </td>
                                             <td align="right" width="40%"  style="background-image:url(img/menuBackGround.jpg) ">
                                                <a href='stock.htm' target="_blank"  title="股票信息"><font color=#006600  size=2>股票实时行情</font></a>&nbsp;
                                             </td>
                </tr>
             </table>
             <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="555px">
               <tr><td id="tdSmsIframe" runat="server" bgcolor="#ffffff"><iframe src='SmsNormal.aspx' width='555px' height="200px" scrolling="no" frameborder="0" marginwidth="0" marginheight="0"></iframe></td></tr>
            </table>
           <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="555px">
                 <tr height="10px"><td>&nbsp;</td></tr>
            </table>
             <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="555px"  id="tabchoujiang" style="display:none" >
                 <tr><td align="center"><img border="0"  src="img/yun123.gif" width="55px" height="55px"/></td></tr>
                  <tr><td  align="center"><font color=#666699 size=2><b>正在抽奖中...</b></font></td></tr>
            </table>
          <table  border="0" cellpadding ="4" cellspacing ="1"  bgcolor="#9999ff" align="center" width="545px"  id="tabkaijiang" style="display:none" >
                <tr ><td id="tdchoujiangResult"  bgcolor="#ffffff">&nbsp;</td></tr>
                <tr><td bgcolor="#ffffff"><iframe src='http://www.zhcw.com/kaijiang/index_kj.html' width='545px' height="120px" scrolling="no" frameborder="0" marginwidth="0" marginheight="0"></iframe></td></tr>
            </table>
           <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="678px"><tr height="80px"><td>
           &nbsp;</td></tr></table>
      <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="678px">
            <tr>
                    <td  width="71%"  align="right"><font size=2 color=#666699><a href ="#" onclick="window.external.AddFavorite('http://www.cninterface.com/', document.title);"><font size=2 color="#666699">
                        收藏本站</font> - <a href="../flight/Index.aspx" title="旨在提供机票航班实时查询"><font size=2 color="#666699">机票查询</font></a> - <a href ="http://www.cninterface.com/SmsOnline/Index.aspx" title="网站创意诞生于2010年3月2日,旨在提供短信在线发送平台，提供用户方便."><font size=2 color="#666699">关于我们</font></a></font><img border="0"  src="img/blank.jpg" width="70px" height="1px"  style="FILTER: alpha(opacity=0);opacity:0;"/></td>
                    <td  width="29%">&nbsp;</td>
            </tr>
            <tr>
                <td  align="right"><font size=2 color=#666699>Copyright © 2010 CnInterface.com  版权所有</font><img border="0"  src="img/blank.jpg" width="43px" height="1px"  style="FILTER: alpha(opacity=0);opacity:0;"/></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td  align="right"><font size=2 color=#666699><a href="http://www.miibeian.gov.cn/" target='_blank' ><font size=2 color="#666699">京ICP备10038387号 </font></a><img border="0"  src="img/blank.jpg" width="7px"  style="FILTER: alpha(opacity=0);opacity:0;"/><img border="0"  src="img/blank.jpg" width="7px"  style="FILTER: alpha(opacity=0);opacity:0;"/> 联系方式：<a href="http://wpa.qq.com/msgrd?V=1Uin=459313018&Site=ioshenmue&Menu=yes" target="_blank"><font size=2 color="#666699">QQ</font></a><img border="0"  src="img/blank.jpg" width="6px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href="msnim:chat?contact=liwei5000000@163.com"><font size=2 color="#666699">MSN</font></a><img border="0"  src="img/blank.jpg" width="6px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href='http://www.alisoft.com/portal/promotion/alitalk/tbfuchu/go123.html?id=9927375' target='_blank'><font size=2 color="#666699">TEL</font></a></font><img border="0"  src="img/blank.jpg" width="10px" height="1px"  style="FILTER: alpha(opacity=0);opacity:0;"/></td>
                <td>&nbsp;</td>
            </tr>
      </table>
    </form>
    <div style="display:none;"><script src="http://s11.cnzz.com/stat.php?id=2099859&web_id=2099859&show=pic1" language="JavaScript"></script></div>
</body>
</html>
