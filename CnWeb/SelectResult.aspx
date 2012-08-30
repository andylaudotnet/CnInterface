<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectResult.aspx.cs" Inherits="CnWeb.SelectResult" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>天下接口网</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta name="keywords" content="接口,interface,天下接口,接口天下,程序接口,网络接口,webservice接口,http接口,ActiveX dll接口,普通dll接口,数据库接口,短信,短信发送,短信在线发送,手机短信,手机短信发送,手机短信在线发送,飞信,飞信登录,飞信短信,飞信好友,第一页搜索,首页搜索,搜索引擎,google,百度,雅虎,bing,搜狗,搜搜,有道." />
    <style type="text/css">
         a:link {text-decoration:none;color:blue;}	/* 未访问的链接 */
         a:visited {text-decoration:none;color:blue}	/* 已访问的链接 */
         a:hover {text-decoration:underline; color:blue; }	/* 鼠标移动到链接上 */
         a:active {text-decoration:underline;color:blue}	/* 选定的链接 */
         .text_dialog1,.text_dialog2 {height:20px; line-height:19px; border:1px solid #A9BAC9; padding:0 2px; font-size:12px;COLOR:black;  }
         .text_dialog2 { border:1px solid #9ECC00;COLOR: #666699; }
        .ButtonCss
            {
                BACKGROUND-COLOR:#ffffff; BORDER-RIGHT: #A9BAC9 1px solid; PADDING-RIGHT: 10px; BORDER-TOP: #A9BAC9 1px solid; PADDING-LEFT: 10px; FONT-SIZE: 12px;  BORDER-LEFT: #A9BAC9 1px solid; CURSOR: hand; COLOR:#666699; PADDING-TOP: 3px; PADDING-BOTTOM: 3px;BORDER-BOTTOM: #A9BAC9 1px solid;
            }
    </style>
     <script language="javascript" src="js/index.js" type ="text/javascript"></script>
      <SCRIPT   LANGUAGE="JavaScript">
        function killErrors() {
            return true;
        }
        window.onerror = killErrors;   
  </SCRIPT> 
  <link href="css/base.css" type="text/css" rel="Stylesheet" />
</head>
<body onresize="divposition();">
    <form id="form1" runat="server">
    <div>
     <table  border="0" cellpadding ="4" cellspacing ="0"  align="left" width="100%" style="float:right">
                <tr>
                      <td align="left" width="161px"><a href="/"><img border="0"  src="img/logo_cninterface.gif"  style="cursor:hand" title="旨在提供接口共享平台，体现接口服务价值"/></a></td>
                      <td align="left" valign="bottom">
                          <table  border="0" cellpadding ="0" cellspacing ="0"  align="left" width="100%">
                                <tr>
                                    <td><input type="hidden" id="hiddenInterfaceName"  runat="server" value="aall"/><a href="#" id="aall" runat="server" style="text-decoration:none" onclick="setSelectList(this.id);"><font size=2 color="#003399"><b>全部</b></font></a><img border="0"  src="img/blank.jpg" width="10px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href="#" id="aHTTP"  runat="server"  onclick="setSelectList(this.id);"><font size=2 color="#666699">HTTP</font></a><img border="0"  src="img/blank001.jpg" width="8px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href="#" id="aWebservice" runat="server"  onclick="setSelectList(this.id);"><font size=2 color="#666699">WebService</font></a><img border="0"  src="img/blank001.jpg" width="8px"   style="FILTER: alpha(opacity=0);opacity:0;"/><a href="#" id="aDLL"  runat="server"  onclick="setSelectList(this.id);"><font size=2  color="#666699">普通DLL</font></a><img border="0"  src="img/blank001.jpg" width="8px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href="#"  id="aADLL"  runat="server"  onclick="setSelectList(this.id);"><font size=2 color="#666699">ActiveXDLL</font></a><img border="0"  src="img/blank001.jpg" width="8px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href="#" id="aData"  runat="server"  onclick="setSelectList(this.id);"><font size=2 color="#666699">数据库</font></a></td>
                                </tr>
                                <tr>
                                    <td><input type="text"  style="width:333px"  id="txtInterfaceName"  runat="server"    class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button  
                                            CssClass="ButtonCss"  ID="bntInterfaceSelect"   runat="server" Text="搜&nbsp;&nbsp;&nbsp;索" 
                                            onclick="bntInterfaceSelect_Click"/></td>
                                </tr>
                          </table>
                      </td>
                </tr>
      </table>
      <table  border="0" cellpadding ="4" cellspacing ="0" width="100%"  style="float:right">
            <tr bgcolor="#edf8f8">
                <td>
                    <a href ="#"  onclick="window.external.AddFavorite(location.href, document.title);"><font size=2  color="#666699">把CnInterface.com收藏起来</font></a>
                </td>
                <td align="right">
                    <font size=2 color="#666699">找到相关结果约<%=SearchResultCount%>条，用时<%=SearchTime%>秒</font>
                </td>
            </tr>
      </table>
      <div id="divposition"   style="width:98%;">
          <div id="DivSearchResults" runat="server"  style="float:left;width: 678px;"></div>
          <div id="divinterfaceAD"   runat="server"  style="float:right;width: 250px;">
                <ul>
                    <br /><br />
                    <li><font color=blue>百港电子 rs485<font color=red>接口</font>保护</font><br /><font size=2 >瞬态抑制二极管TVS的专业生产厂家rs485<font color=red>接口</font>保护 质优价廉,欢迎选购!<font color=#006600>www.bwecl.com</font></font></li>
                    <li><font color=blue>德州仪器 rs232<font color=red>接口</font></font><br /><font size=2 >德州仪器是全球领先的芯片生产商半导体解决方案的专家<font color=#006600>www.ti.com.cn</font></font></li>
                    <li><font color=blue>sata<font color=red>接口</font>专线:0755-27618778</font><br /><font size=2 >深圳鸿越,专业sata<font color=red>接口</font>生产厂家,品质保证,优质价廉.欢迎来电咨询!<font color=#006600>www.hyonn.com</font></font></li>
                    <li><font color=blue>购买电话<font color=red>接口</font> 就到弘宇</font><br /><font size=2 >弘宇电话<font color=red>接口</font>规格齐全 技术含量高价格合理 是您的最佳选择<font color=#006600>www.chinahye.com</font></font></li>
                    <li><font color=blue>艾卡can<font color=red>接口</font>卡 物美价廉 睿..</font><br /><font size=2 >深圳艾卡电子技术有限公司专业提供can<font color=red>接口</font>卡,多串口卡,性价比高,兼容性好,可以安装..<font color=#006600>www.advcom.cn</font></font></li>
                    <li><font color=blue>高性价比的can<font color=red>接口</font>卡适配器..</font><br /><font size=2 >专业生产CAN适配器,USB-CAN所有CAN卡均支持CANTools工具软件<font color=#006600>www.glinker.cn</font></font></li>
                    <li><font color=blue>蓝光can<font color=red>接口</font>卡</font><br /><font size=2 >使用can<font color=red>接口</font>卡系列产品,选蓝光CANcan<font color=red>接口</font>卡<font color=#006600>www.jnnbl.com</font></font></li>
                    <li><font color=blue>RS232/485/CAN/USB隔离器</font><br /><font size=2 >四星电子专业生产rs485<font color=red>接口</font>保护等产品工业级设计,防雷击抗干扰,保护<font color=red>接口</font><font color=#006600>www.fourstar-dy.com</font></font></li>
                    <br /><br />
                    <li  ><span style="background-color:#edf8f8"><a href="Index.aspx"><font color=blue>来天下接口推广您的产品</font></a></span></li>
                </ul> 
          </div>
      </div>
      <table  border="0" cellpadding ="4" cellspacing ="0" width="98%" style="float:right"><tr height="18px"><td  align="center"></td></tr></table>
      <div  id="DivTheSameResults" runat="server"  style="background-color:#edf8f8;height:60px;width:100%;clear:both"><table width="96%" height="100%" border="0" align="center" cellpadding="0" cellspacing="0"><tr><td style="font-size:14px;font-weight:bold;height:35px;width:70px;">相关搜索</td><td rowspan="2" valign="middle"><table border="0" cellpadding="0" cellspacing="0"><tr><td nowrap class="f14"><font color="blue"><a href="SelectResult.aspx?p=1&s=hdmi接口"><font color="blue">hdmi接口</font></a></td><td nowrap class="s">&nbsp;</td><td nowrap class="f14"><a href="SelectResult.aspx?p=1&s=use接口"><font color="blue">use接口</font></a></td><td nowrap class="s">&nbsp;</td><td nowrap class="f14"><a href="SelectResult.aspx?p=1&s=vga接口"><font color="blue">vga接口</font></a></td><td nowrap class="s">&nbsp;</td><td nowrap class="f14"><a href="SelectResult.aspx?p=1&s=硬盘接口"><font color="blue">硬盘接口</font></a></td><td nowrap class="s">&nbsp;</td><td nowrap class="f14"><a href="SelectResult.aspx?p=1&s=dvi接口"><font color="blue">dvi接口</font></a></td></tr><tr><td nowrap class="f14"><a href="SelectResult.aspx?p=1&s=显卡接口"><font color="blue">显卡接口</font></a></td><td nowrap class="s">&nbsp;</td><td nowrap class="f14"><a href="SelectResult.aspx?p=1&s=网络接口"><font color="blue">网络接口</font></a></td><td nowrap class="s">&nbsp;</td><td nowrap class="f14"><a href="SelectResult.aspx?p=1&s=java接口"><font color="blue">java接口</font></a></td><td nowrap class="s">&nbsp;</td><td nowrap class="f14"><a href="SelectResult.aspx?p=1&s=sata接口"><font color="blue">sata接口</font></a></td><td nowrap class="s">&nbsp;</td><td nowrap class="f14"><a href="SelectResult.aspx?p=1&s=ide接口"><font color="blue">ide接口</font></a></td></tr></table></td></tr><tr><td>&nbsp;</td></tr></table></div>
      <table  border="0" cellpadding ="4" cellspacing ="0" width="98%" style="float:right"><tr height="30px"><td  align="center"></td></tr></table>
      <table  border="0" cellpadding ="4" cellspacing ="0" width="98%" style="float:right">
                <tr height="10px">
                    <td  align="center"  > <font size=2 color="#666699">©2010 CnInterface 此内容系天下接口根据您的指令自动搜索的结果，不代表天下接口赞成被搜索网站的内容或立场
                    </td>
                </tr>
      </table>
    </div>
    </form>
    <script language="javascript" type="text/javascript">
        function onloadlogic() {
            if (navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("bntInterfaceSelect").style.backgroundColor = "#ffffff";
            }
        }
        function divposition() {
            if (parseInt(document.body.scrollWidth) < 950) {
                document.getElementById("divposition").style.width = "950px";
            }
            else {
                document.getElementById("divposition").style.width = document.body.scrollWidth+"px";
            }
        }
        onloadlogic();
     </script>
     <div style="display:none;"><script src="http://s11.cnzz.com/stat.php?id=2099859&web_id=2099859&show=pic1" language="JavaScript"></script></div>
</body>
</html>
