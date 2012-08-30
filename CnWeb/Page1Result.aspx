<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page1Result.aspx.cs" Inherits="CnWeb.Page1Result" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>搜索各大搜索引擎网站第一页数据</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta name="keywords" content="第一页搜索,首页搜索,搜索引擎,google,百度,雅虎,bing,搜狗,搜搜,有道,接口,interface,天下接口,接口天下,程序接口,网络接口,webservice接口,http接口,ActiveX dll接口,普通dll接口,数据库接口,短信,短信发送,短信在线发送,手机短信,手机短信发送,手机短信在线发送,飞信,飞信登录,飞信短信,飞信好友." />
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
    <script language="javascript" src="js/page1search.js" type ="text/javascript"></script>
     <script language="javascript" src="js/page1result.js" type ="text/javascript"></script>
     <link href="css/base.css" type="text/css" rel="Stylesheet" />
</head>
<body >
    <form id="form1" runat="server">
    <div>
    <table  border="0" cellpadding ="4" cellspacing ="0"  align="left" width="100%" style="float:right">
                <tr>
                      <td align="left" width="161px"><a href="http://www.cninterface.com"><img border="0"  src="img/Page1Search.gif"  style="cursor:hand" title="旨在提供接口共享平台，体现接口服务价值"/></a></td>
                      <td align="left" valign="bottom">
                          <table  border="0" cellpadding ="0" cellspacing ="0"  align="left" width="100%">
                                  <tr><input type="hidden" id="hiddenwebName"  runat="server"/></td>
                                  <td align="left"><a href="#" id="aall" runat="server" style="text-decoration:none" onclick="setSelectList(this.id);"><font size=2 color="#003399"><b>全部</b></font></a><img border="0"  src="img/blank.jpg" width="10px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href="#" id="abaidu"  runat="server"  onclick="setSelectList(this.id);"><font size=2 color="#666699">百度</font></a><img border="0"  src="img/blank.jpg" width="10px" style="FILTER: alpha(opacity=0);opacity:0;"/><a href="#" id="agoogle"  runat="server"  onclick="setSelectList(this.id);"><font size=2  color="#666699">Google</font></a><img border="0"  src="img/blank.jpg" width="10px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href="#"  id="ayahoo"  runat="server"  onclick="setSelectList(this.id);"><font size=2 color="#666699">雅虎</font></a><img border="0"  src="img/blank.jpg" width="10px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href="#" id="abing"  runat="server"  onclick="setSelectList(this.id);"><font size=2 color="#666699">Bing</font></a><img border="0"  src="img/blank.jpg" width="10px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href="#" id="asogou"  runat="server"  onclick="setSelectList(this.id);"><font size=2 color="#666699">搜狗</font></a><img border="0"  src="img/blank.jpg" width="10px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href="#" id="asoso"  runat="server"  onclick="setSelectList(this.id);"><font size=2 color="#666699">搜搜</font></a><img border="0"  src="img/blank.jpg" width="10px"  style="FILTER: alpha(opacity=0);opacity:0;"/><a href="#" id="ayoudao"  runat="server"  onclick="setSelectList(this.id);"><font size=2 color="#666699">有道</font></a><img border="0"  src="img/blank.jpg" width="46px"  style="FILTER: alpha(opacity=0);opacity:0;"/></td>
                                <tr>
                                    <td><input type="text"  style="width:333px"  id="txtSearchWord"  runat="server"    class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button  
                                            CssClass="ButtonCss"  ID="btnSearch"   runat="server" 
                                            Text="搜&nbsp;&nbsp;&nbsp;索" onclick="btnSearch_Click" 
                                            /></td>
                                </tr>
                          </table>
                      </td>
                </tr>
      </table>
      <table  border="0" cellpadding ="4" cellspacing ="0" width="100%"  style="float:right">
            <tr bgcolor="#edf8f8">
                <td>
                    <input type ="hidden" id ="hiddengb2312" runat ="server" /><input type ="hidden" id ="hiddenutf8" runat ="server" />
                    <a href ="#"  onclick="window.external.AddFavorite(location.href, document.title);"><font size=2  color="#666699">把CnInterface.com收藏起来</font></a>
                </td>
                <td align="right">
                    <font size=2 color="#666699">找到<%=WebCount.ToString()%>个相关网站第一页数据，用时<%=SearchTime%>秒</font>
                </td>
            </tr>
      </table>
      <table  border="0" cellpadding ="6" cellspacing ="1"  bgcolor="#ffffff" style="float:left">
        <tr>
            <td bgcolor="#ffffff" width="128px" runat="server" id="tdbaidu" style="display:none"><font color=blue><b>百度</b></font><font color=#666699><b>第一页数据</b></font>&nbsp;<span id='spanbaidu' onclick='controlwebdatashow(this.id);' style="cursor:hand;cursor:pointer;"><font  color=green>查看</font></span></td>
            <td bgcolor="#ffffff" width="128px" runat="server" id="tdgoogle" style="display:none"><font color=blue><b>谷歌</b></font><font color=#666699><b>第一页数据</b></font>&nbsp;<span id='spangoogle' onclick='controlwebdatashow(this.id);'  style="cursor:hand;cursor:pointer;"><br/><font  color=green>查看</font></span></td>
            <td bgcolor="#ffffff" width="128px" runat="server" id="tdyahoo" style="display:none"><font color=blue><b>雅虎</b></font><font color=#666699><b>第一页数据</b></font>&nbsp;<span id='spanyahoo' onclick='controlwebdatashow(this.id);'  style="cursor:hand;cursor:pointer;"><br/><font  color=green>查看</font></span></td>
            <td bgcolor="#ffffff" width="128px" runat="server" id="tdbing" style="display:none"><font color=blue><b>必应</b></font><font color=#666699><b>第一页数据</b></font>&nbsp;<span id='spanbing' onclick='controlwebdatashow(this.id);'  style="cursor:hand;cursor:pointer;"><br/><font  color=green>查看</font></span></td>
            <td bgcolor="#ffffff" width="128px" runat="server" id="tdsogou" style="display:none"><font color=blue><b>搜狗</b></font><font color=#666699><b>第一页数据</b></font>&nbsp;<span id='spansogou' onclick='controlwebdatashow(this.id);'  style="cursor:hand;cursor:pointer;"><br/><font  color=green>查看</font></span></td>
            <td bgcolor="#ffffff" width="128px" runat="server" id="tdsoso" style="display:none"><font color=blue><b>搜搜</b></font><font color=#666699><b>第一页数据</b></font>&nbsp;<span id='spansoso' onclick='controlwebdatashow(this.id);' style="cursor:hand;cursor:pointer;"><br/><font  color=green>查看</font></span></td>
            <td bgcolor="#ffffff" width="128px" runat="server" id="tdyoudao" style="display:none"><font color=blue><b>有道</b></font><font color=#666699><b>第一页数据</b></font>&nbsp;<span id='spanyoudao' onclick='controlwebdatashow(this.id);'  style="cursor:hand;cursor:pointer;"><br/><font  color=green>查看</font></span></td>
        </tr>
      </table>
      <div id="DivSearchResults" runat="server"  style="float:left;width: 678px;"></div>
    </div>
    <table  border="0" cellpadding ="4" cellspacing ="0" width="98%" style="float:right"><tr height="30px"><td  align="center"></td></tr></table>
      <table  border="0" cellpadding ="4" cellspacing ="0" width="98%" style="float:right">
                <tr height="10px">
                    <td  align="center"  > <font size=2 color="#666699">©2010 CnInterface 此内容系天下接口根据您的指令自动搜索的结果，不代表天下接口赞成被搜索网站的内容或立场
                    </td>
                </tr>
      </table>
    </form>
    <script language="javascript">
       LoadAllData();
    </script>
    <div style="display:none;"><script src="http://s11.cnzz.com/stat.php?id=2099859&web_id=2099859&show=pic1" language="JavaScript"></script></div>
</body>
</html>