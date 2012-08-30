<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CnWeb.Index" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>天下接口网</title>
    <meta http-equiv="content-type" content="text/html;charset=utf-8">
    <meta name="google-site-verification" content="kCPUUIY43NxeoK8K4_lb1gUUtAY10yBj_XrilL1Zm3E" />
    <meta name="keywords" content="接口,interface,天下接口,接口天下,程序接口,网络接口,webservice接口,http接口,ActiveX dll接口,普通dll接口,数据库接口,短信,短信发送,短信在线发送,手机短信,手机短信发送,手机短信在线发送,飞信,飞信登录,飞信短信,飞信好友,第一页搜索,首页搜索,搜索引擎,google,百度,雅虎,bing,搜狗,搜搜,有道." />
    <meta  name="description" content="旨在提供接口共享平台，体现接口服务价值." />
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
	    Z-INDEX: 10; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 35%; TEXT-ALIGN: center
    } 
        #loader {
	    BORDER-RIGHT: #5a667b 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #5a667b 1px solid; DISPLAY: block; PADDING-LEFT: 5px; FONT-SIZE: 11px; Z-INDEX: 2; PADDING-BOTTOM: 5px; MARGIN: 0px auto; BORDER-LEFT: #5a667b 1px solid; WIDTH: 333px; COLOR: #000000; PADDING-TOP: 5px; BORDER-BOTTOM: #5a667b 1px solid; FONT-FAMILY: Tahoma, Helvetica, sans; BACKGROUND-COLOR:#ffffff; TEXT-ALIGN: left
    }   
    </style>
     <script language="javascript" src="js/index.js" type ="text/javascript"></script>
      <SCRIPT   LANGUAGE="JavaScript">
        function killErrors() {
            return true;
        }
        window.onerror = killErrors;   
  </SCRIPT> 
  <script language="javascript" src="js/indexmenu.js" type ="text/javascript"></script>
</head>
<body onresize="setdivresultlist();">
<!--顶层内容start style="background-image : url(../img/main.jpg);background-repeat : no-repeat;background-position:center;"-->
    <DIV id="loader_container" style="DISPLAY: none; WIDTH: 100%; HEIGHT: 6px" >
				<DIV id="loader">
				         <table  border="0" cellpadding ="4" cellspacing ="1"  bgcolor="#9999ff" align="center"  width="333px" bgcolor="#004000">
				                        <td align="left"  style="background-image:url(img/menuBackGround.jpg) " colspan="2"><font size=2  color="#666699"><b>用户登录:</b></font></td>
                                        <tr>
                                            <td align="center" bgcolor="#ffffff" width="15%"><input type="hidden" id="hidden1" runat="server" /><font  size=2 color=black>用&nbsp;&nbsp;户&nbsp;&nbsp;名：</font></td>
                                            <td bgcolor="#ffffff" width="85%"> <input type="text"  id="txtusername"   onkeydown="LoginOnkeydownEvent();"  style="width:145px"  class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"/><font color=#666699 size=2>*</font></td>
                                        </tr>
                                          <tr>
                                            <td align="center" bgcolor="#ffffff"><font color=black size=2>密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码：</font></td>
                                            <td bgcolor="#ffffff"> <input type="password"  id="txtpassword"  onkeydown="LoginOnkeydownEvent();"   style="width:145px"    class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"/><font color=#666699 size=2>*</font></td>
                                        </tr>
                                         <tr>
                                            <td align="center" bgcolor="#ffffff" colspan="2"><input type="checkbox" id="ckbLoginStatus" /><font  size="2" color="black">记住我的登录状态。</font>&nbsp;<font  size="2" color="#666699">(公用电脑请勿选择此项)</font></td>
                                         </tr>
                                          <tr>
                                            <td bgcolor="#ffffff" colspan="2">
                                                <table  border="0" cellpadding ="0" cellspacing ="0"  width="100%">
                                                    <tr>
                                                        <td width="73%" align="right"><input  type="button"  id="btnLogin"  value="登录" onclick="CheckLoginNamePwd();"  class="ButtonCss" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="button"  id="btncancel"  value="取消"  class="ButtonCss" onclick="loginCancel();" /></td>
                                                        <td width="27%">&nbsp;&nbsp;<a href="user/Register.aspx"><font size=2>新用户注册</font></a></td>
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
     <div id="div_login" style="text-align:right;margin-right:15px;margin-top:2px;"><span id="spanusername" runat="server"><a href="user/UserLogin.aspx"><font size=2>登录</font></a></span></div>
     <div id="divlikeselectresultlist"   onclick="event.cancelBubble = true;" style="POSITION: absolute; top:197px;left:443px;display: none; width: 337px; height:175px;BACKGROUND-COLOR:#ffffff;BORDER-LEFT: #9999ff 1px solid;BORDER-RIGHT: #9999ff 1px solid; BORDER-TOP: #A9BAC9 1px solid;BORDER-BOTTOM: #9999ff 1px solid;"></div>
     <input type="hidden" id="hiddenchangestatu" value="0"/><input type="hidden" id="hiddennewnamelist" value="0"/>
    <form id="form1" runat="server"><input type="hidden" id="hiddenUsername"  runat="server"/>
     <div style ="position:absolute; top:76px; left :752px; width:1px;height:1px;background-color:White; display:none;" id="DivInterfaceDiff">
          <table border="0" cellpadding ="4" cellspacing ="1"  bgcolor="#9999ff" width="375px" >
                    <tr height="55px" >
                        <td bgcolor="#ffffff"><font size=2 color=#666699>各种接口区别：<br>
                                一、WebService接口   通用性强、可以跨平台。<br />
                                二、ActiveX dll       调用简单、方便的COM控件，需要注册控件。<br />
                                三、HTTP接口     通用性强、接入灵活、通信快速、可以跨平台。<br />
                                四、普通DLL接口      适合各种C/S软件方便引用。<br />
                                五、数据库接口        适合数据库开发用户选择。</font>
                        </td>
                     </tr>
          </table>
      </div>
      <div  id="divshowintervideos"   onclick="event.cancelBubble = true;"  style ="position:absolute; top:336px; left :433px; width:465px;height:251px;background-color:White; display:none; border-bottom: #9999ff 1px solid; border-left:#9999ff 1px solid; border-right:#9999ff 1px solid; border-top:#9999ff 1px solid; OVERFLOW-Y: auto;scrollbar-Face-Color:rgb(234,242,255);scrollbar-3dLight-Color:rgb(120,172,255);scrollbar-DarkShadow-Color:rgb(120,172,255);scrollbar-Shadow-Color:rgb(234,242,255);">
         
      </div>
    <div>
     <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="678px">
                <tr height="1px"><td>&nbsp;</td></tr>
      </table>
     <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="678px" >
                <tr><td align="center"><a href="/"><img border="0"  src="img/logo_cninterface.gif" style="cursor:hand" title="旨在提供接口共享平台，体现接口服务价值"/></a></td></tr>
     </table>
      <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="678px">
                <tr height="28px"><td>&nbsp;</td></tr>
      </table>
      <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="678px">
                <tr>
                      <td align="right"><a href="#" id="aall" runat="server"  onclick="setSelectList(this.id);"><font size=2 color="#003399"><b>全部</b></font></a><img border="0"  src="img/blank.jpg" width="9px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href="#" id="aHTTP"  runat="server"  onclick="setSelectList(this.id);"><font size=2 color="#666699">HTTP</font></a><img border="0"  src="img/blank.jpg" width="9px" style="FILTER: alpha(opacity=0);opacity:0;"/><a href="#" id="aWebservice" runat="server"  onclick="setSelectList(this.id);"><font size=2 color="#666699">WebService</font></a><img border="0"  src="img/blank.jpg" width="9px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href="#" id="aDLL"  runat="server"  onclick="setSelectList(this.id);"><font size=2  color="#666699">普通DLL</font></a><img border="0"  src="img/blank.jpg" width="9px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href="#"  id="aADLL"  runat="server"  onclick="setSelectList(this.id);"><font size=2 color="#666699">ActiveXDLL</font></a><img border="0"  src="img/blank.jpg" width="9px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href="#" id="aData"  runat="server"  onclick="setSelectList(this.id);"><font size=2 color="#666699">数据库</font></a><span id="spannbsp">&nbsp;&nbsp;</span><input style="background-color:#ffffff;width:1px;border:0px solid #ffffff;FILTER: alpha(opacity=0);opacity:0;"  type ="text" size="1"  id="txtDivInterfaceDiff" /><img border="0" id="imginterfacetype"  src="img/blank.jpg" width="0px"  style="FILTER: alpha(opacity=0);opacity:0;"/></td>
                      <td colspan="2"><input type="hidden" id="hiddenInterfaceName"  runat="server" value="aall"/></td></tr>
                 <tr>
                      <td  width="71%" align="right"><input type="text"  style="width:333px"  id="txtInterfaceName"    onkeyup="GetNameList();"  runat="server"    class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'" /></td>
                      <td  width="2%">&nbsp;</td>
                      <td  width="27%"><asp:Button  CssClass="ButtonCss"  ID="bntInterfaceSelect"  
                              runat="server" Text="搜&nbsp;&nbsp;&nbsp;索" onclick="bntInterfaceSelect_Click"  OnClientClick="return checksearchname();" />
                              <span onmouseover="showInterfaceDiff();"  onmouseout="noShowInterfaceDiff();"  style="cursor:hand;cursor:pointer;"><font size=2 color="#666699">区别</font></span>
                              </td>
                </tr>
                 <tr><td colspan="3" align="center" valign="middle">
                    <div id="tb" style="width:503px; text-align:left;margin-right:25px;"></div>
                 </td></tr>
                <tr ><td colspan="3" align="center" valign="middle"><a href="Parse/WebNews.aspx"  target="_blank"><font size=2 color="#666699">各大网站最新新闻</font></a>&nbsp;&nbsp;<a href="html/VideoIndex.html"  target="_blank"><font size=2 color="#666699">各大网站最新视频</font></a><img border="0"  src="img/blank.jpg" width="35px" height="1px" style="FILTER: alpha(opacity=0);opacity:0;"/></td></tr>
      </table>
      <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="678px"><tr height="38px"><td>&nbsp;</td></tr></table>
      <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="678px">
            <tr>
                    <td  width="71%"  align="right"><font size=2 color=#666699><a href ="http://www.stockfoo.com" target="_blank"><font size=2 color="#666699">股富财经</font></a> - <a href="SmsOnline/Index.aspx"  title="提供手机短信在线发送功能"><font size=2 color="#666699">短信在线发送</font></a> - <a href ="Page1Search.aspx" title="旨在集成各大搜索引擎网站第一页数据，给用户最想要的信息"><font size=2 color="#666699">第一页搜索</font></a></font><img border="0"  src="img/blank.jpg" width="42px" height="1px"  style="FILTER: alpha(opacity=0);opacity:0;"/></td>
                    <td  width="29%">&nbsp;</td>
            </tr>
             <tr>
                <td  align="right"><font size=2 color=#666699>Copyright © 2010 CnInterface.com  版权所有</font><img id="imgblank" border="0"  src="img/blank.jpg" width="35px" height="1px"  style="FILTER: alpha(opacity=0);opacity:0;"/></td>
                <td>&nbsp;</td>
            </tr>
             <tr>
                <td  align="right"><font size=2 color=#666699><a href="http://www.miibeian.gov.cn/" target='_blank' ><font size=2 color="#666699">京ICP备10038387号 </font></a><img border="0"  src="img/blank.jpg" width="7px"  style="FILTER: alpha(opacity=0);opacity:0;"/> 联系方式：<a href="http://wpa.qq.com/msgrd?V=1Uin=459313018&Site=ioshenmue&Menu=yes" target="_blank"><font size=2 color="#666699">QQ</font></a><img border="0"  src="img/blank.jpg" width="6px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href="msnim:chat?contact=liwei5000000@163.com"><font size=2 color="#666699">MSN</font></a><img border="0"  src="img/blank.jpg" width="6px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href='http://www.alisoft.com/portal/promotion/alitalk/tbfuchu/go123.html?id=9927375' target='_blank'><font size=2 color="#666699">TEL</font></a></font><img border="0"  src="img/blank.jpg" width="18px" height="1px"  style="FILTER: alpha(opacity=0);opacity:0;"/></td>
                <td>&nbsp;</td>
            </tr>
      </table>
    </div>
    </form>
    <script language="javascript" type="text/javascript">
        document.onclick = hiddenNamelist;
        function onloadlogic() {
            if (navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("spannbsp").textContent = "";
		document.getElementById("imginterfacetype").style.width = "8px";
                document.getElementById("imgblank").style.width = "14px";
                document.getElementById("bntInterfaceSelect").style.backgroundColor="#ffffff";
            }
        }
        onloadlogic();
     </script>
    <div id="divshowmobile" style="float:left;position:absolute;left:6px; top:7px;z-index:1000; display:none; FILTER: alpha(opacity=78); " onclick="showmobile();"><img id="imgmobile" border="0" width="50px" height="99px" src="img/littlemobile.png" alt="手机短信在线发送" style="cursor:hand;"/></div>
    <div id="divmobile01" style="float:left;position:absolute;left:6px; top:5px; width:300px;height:600px;display:block; FILTER:alpha(opacity=0);">
            <img border="0" src="img/mobile.png" usemap="#planetmap" alt="" />
            <map name="planetmap" id="planetmap">
               <area shape="circle" coords="48,434,14" href ="javascript:setfrmMobile(1);" alt="视频" />
              <area shape="circle" coords="104,434,14" href ="javascript:setfrmMobile(2);"  alt="短信" />
              <area shape="circle" coords="157,435,14" href ="javascript:setfrmMobile(3);" alt="Wap" />
              <area shape="circle" coords="211,433,14" href ="javascript:setfrmMobile(4);"  alt="地图" />
              <area shape="circle" coords="131,478,14" href ="javascript:setfrmMobile(5);" alt="隐藏手机" />
            </map>
    </div>
    <div id="divmobile02"  style="width:212px;height:336px;float:left; position:absolute;left:30px; top:84px; display:block; FILTER:alpha(opacity=0);">
        <iframe id="frmMobile" src='SmsOnline/SmsSend.aspx' width='214px' height="340px" scrolling="no" frameborder="0" marginwidth="0" marginheight="0"></iframe>
    </div>
    <div id="divmarquee"  style="display:block; FILTER:alpha(opacity=0);height:1px;width:100px; text-align:center;border:0px solid #9999ff;position:absolute;left:88px;top:20px"><marquee direction="right"><font color="red" size="2">***************</font></marquee></div>
    <script language="javascript">
        function setfrmMobile(num) {
            switch (num) {
                case 1:
                    document.getElementById("frmMobile").src = "html/video.html";
                    break;
                case 2:
                    document.getElementById("frmMobile").src = "SmsOnline/SmsSend.aspx";
                    break;
                case 3:
                    document.getElementById("frmMobile").src = "html/wap.html";
                    break;
                case 4:
                    document.getElementById("frmMobile").src = "html/earth.html";
                    break;
                case 5:
                    if (navigator.userAgent.indexOf("MSIE") > -1) {
                        setinter = window.setInterval(hidefunction, 30);
                    }
                    break;
                default:
                    break;
            }
        }
        function setmarquee() {
            if (navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divmarquee").style.top = "17px";
            }
        }
        var setinter;
        function showmobile() {
            document.getElementById("divshowmobile").style.display = "none";
            setmarquee();
            setinter = window.setInterval(showfunction, 30);
        }
       
        var i = 0;
        function showfunction() {
            i = i + 2;
            if (i < 100) {
                document.getElementById("divmobile01").style.filter = "Alpha(Opacity=" + i + ")";
                document.getElementById("divmobile02").style.filter = "Alpha(Opacity=" + i + ")";
                document.getElementById("divmarquee").style.filter = "Alpha(Opacity=" + i + ")";
            }
            else {
                i = 0;
                window.setInterval(setinter);  
            }
        }
        var j = 100;
        function hidefunction() {
            j = j- 5;
            if (j > 0) {
                document.getElementById("divmobile01").style.filter = "Alpha(Opacity=" + j+ ")";
                document.getElementById("divmobile02").style.filter = "Alpha(Opacity=" + j + ")";
                document.getElementById("divmarquee").style.filter = "Alpha(Opacity=" + j + ")";
            }
            else {
                j = 100;
                document.getElementById("divmobile01").style.filter = "Alpha(Opacity=0)";
                document.getElementById("divmobile02").style.filter = "Alpha(Opacity=0)";
                document.getElementById("divmarquee").style.filter = "Alpha(Opacity=0)";
                document.getElementById("divshowmobile").style.display = "block";
                document.getElementById("frmMobile").src = "SmsOnline/SmsSend.aspx";
                window.setInterval(setinter);
            }
        }
        function onloadsetting() {
            if (navigator.userAgent.indexOf("MSIE") > -1)
                document.getElementById("divshowmobile").style.display = "block";
        }
        onloadsetting();
    </script>
    <div style="display:none;"><script src="http://s11.cnzz.com/stat.php?id=2099859&web_id=2099859&show=pic1" language="JavaScript"></script></div>
</body>
</html>
