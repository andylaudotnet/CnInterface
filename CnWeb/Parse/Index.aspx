<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CnWeb.Parse.Index" %>

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
    <script language="javascript" type="text/javascript">
        function choisesourceno(num) {
                if (parseInt(num) == 1) {
                         var no = document.getElementById("selectsourceno").options[document.getElementById("selectsourceno").selectedIndex].value;
                         if (parseInt(no) == 0) {
                                document.getElementById("selectsourceno").focus();
                                return false;
                          }else
                          {
                                window.location.href = "Manualparse.aspx?sourceno=" + no;
                            }
                }
                if (parseInt(num) == 2) {
                    var no = document.getElementById("selectautoparse").options[document.getElementById("selectautoparse").selectedIndex].value;
                    switch (no) {
                        case "0":
                            document.getElementById("selectautoparse").focus();
                            return false;
                            break;
                        case "1":
                            window.location.href = "GetBaiduInterface.aspx";
                            break;
                        case "2":
                            window.location.href = "GetGoogleInterface.aspx";
                            break;
                        case "3":
                            window.location.href = "GetYahooInterface.aspx";
                            break;
                        case "4":
                            window.location.href = "GetBingInterface.aspx";
                            break;
                        case "5":
                            window.location.href = "GetSosoInterface.aspx";
                            break;
                        case "6":
                            window.location.href = "GetSogouInterface.aspx";
                            break;
                        case "7":
                            window.location.href = "GetYoudaoInterface.aspx";
                            break;
                        case "8":
                            window.location.href = "GetGougouInterface.aspx";
                            break;
                        case "9":
                            window.location.href = "AutomatismParse.aspx";
                            break;
                        default:
                            break;
                    }
                    
                }
                 if (parseInt(num) == 3) {
                     var webname = document.getElementById("selectWebName").options[document.getElementById("selectWebName").selectedIndex].value;
                     if (webname == "all") {
                         window.location.href = "GetDataBuildHtml.aspx";
                     }
                     else {
                         window.location.href = "ParseVideos.aspx?webname=" + webname;
                     }
                 } 
                 if (parseInt(num) == 4) {
                     var no = document.getElementById("selectvideoxpath").options[document.getElementById("selectvideoxpath").selectedIndex].value;
                     if (no == "all") {
                         document.getElementById("selectvideoxpath").focus();
                         return false;
                     }
                     else {
                         window.location.href = "ParseXPathManage.aspx?web=" + no;
                     }
                 }
                 if (parseInt(num) == 5) {
                     var no = document.getElementById("selectWebName").options[document.getElementById("selectWebName").selectedIndex].value;
                     window.location.href = "CreateImagesXml.aspx?web=" + no;
                 }
             }
             function onchangewebname() {
                 var webname = document.getElementById("selectWebName").options[document.getElementById("selectWebName").selectedIndex].value;
                 if (webname == "all") {
                     document.getElementById("btncreatehtml").value = "创建html";
                 }
                 else {
                     document.getElementById("btncreatehtml").value = "创建html";
                 }
             }
    </script>
    <link href="../css/base.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="555px"><tr height="20px"><td>&nbsp;</td></tr></table>
             <table  border="0" cellpadding ="0" cellspacing ="0"  bgcolor="#ffffff" align="center"  width="555px" >
                    <tr>
                        <td  bgcolor="#ffffff"  align="left"><a href="../Index.aspx"  title="旨在提供接口共享平台，体现接口服务价值"><img border="0"  src="img/indexHeader.jpg"/></a></td>
                    </tr>
              </table>
             <table  border="0" cellpadding ="4" cellspacing ="1"  bgcolor="#ffffff" align="center"  width="555px" >
                    <tr>
                        <td colspan="2" bgcolor="#ffffff"  align="left"  style="background-image:url(img/menuBackGround.jpg) "><font color="#666699"><b>网站管理：</b></font></td>
                    </tr>
                    <tr>
                         <td align="center" bgcolor="#ffffff" colspan="2">
                                <table  border="0" cellpadding ="6" cellspacing ="1" width="100%"  bgcolor="#9999ff" >
                                    <tr>
                                            <td align="left" width="50%" bgcolor="#ffffff">
                                                  手工添加接口：<select id="selectsourceno">    
                                                    <option value="0">请选择数据来源</option>
						                            <option value="4">Baidu</option>
						                            <option value="5">Google</option>
						                            <option value="6">Yahoo</option>
						                            <option value="7">Bing</option>
						                            <option value="8">Soso</option>
						                            <option value="9">Sogou</option>
						                            <option value="10">Youdao</option>
						                            <option value="11">Gougou</option>
                                                    <option value="2">天空软件站</option>
                                                    <option value="1">华军软件园</option>
                                                    <option value="3">其他</option>
                                                  </select>
                                            </td>
                                             <td align="left" width="*" bgcolor="#ffffff">
                                                 <input type="button"  value="进入手工添加页面" class="ButtonCss" onclick="choisesourceno(1);"/> 
                                            </td>
                                    </tr>
                                     <tr>
                                            <td align="left" width="50%" bgcolor="#ffffff">
                                                   自动添加接口：<select id="selectautoparse">    
                                                    <option value="0">请选择数据来源</option>
						                            <option value="1">Baidu</option>
						                            <option value="2">Google</option>
						                            <option value="3">Yahoo</option>
						                            <option value="4">Bing</option>
						                            <option value="5">Soso</option>
						                            <option value="6">Sogou</option>
						                            <option value="7">Youdao</option>
						                            <option value="8">Gougou</option>
                                                    <option value="9">天空和华军</option>
                                                  </select>
                                            </td>
                                             <td align="left" width="*" bgcolor="#ffffff">
                                                 <input type="button"  value="进入自动添加页面" class="ButtonCss" onclick="choisesourceno(2);"/> 
                                            </td>
                                    </tr>
                                    <tr>
                                            <td align="left" width="50%" bgcolor="#ffffff">
                                            创建视频html：
                                            <select id="selectWebName" onchange="onchangewebname();">    
                                                    <option value="all">全部网站</option>
                                                    <option value="17173">17173游戏视频</option>
                                                    <option value="56">56网</option>
                                                    <option value="6cn">六间房</option>
                                                    <option value="baidu">百度视频搜索</option>
                                                    <option value="cntv">中国网络电视台</option>
                                                    <option value="hunantv">芒果TV</option>
                                                    <option value="ifeng">凤凰宽频</option>
                                                    <option value="ku6">酷6网</option>
                                                    <option value="news">新华网</option>
                                                    <option value="openv">天线高清</option>
                                                    <option value="qq">QQ播客</option>
                                                    <option value="sina">新浪视频</option>
                                                    <option value="sohu">搜狐视频</option>
                                                    <option value="tencent">腾讯宽频</option>
                                                    <option value="tudou">土豆网</option>
                                                    <option value="xunlei">迅雷看看</option>
                                                    <option value="youku">优酷网</option>
                                                    <option value="pps">PPS</option>
                                                    <option value="pplive">PPLive</option>
                                                    <option value="uusee">UUSee</option>
                                                    <option value="m1905">m1905电影网</option>
                                                    <option value="funshion">风行</option>
                                                    <option value="joy">激动网</option>
                                                    <option value="letv">乐视网</option>
                                                    <option value="pomoho">爆米花</option>
                                                    <option value="aeeboo">爱播网</option>
                                                    <option value="google">google视频搜索</option>
                                                  </select>
                                            </td>
                                            <td align="left" width="*" bgcolor="#ffffff">
                                                 <input type="button" id="btncreatehtml"  value="创建html" class="ButtonCss"  onclick="choisesourceno(3);"/> &nbsp;&nbsp;<input type="button" id="btncreatexml"  value="创建Xml" class="ButtonCss"  onclick="choisesourceno(5);"/> 
                                            </td>
                                    </tr>
                                     <tr>
                                            <td align="left" width="50%" bgcolor="#ffffff">
                                            视频Xpath管理：
                                            <select id="selectvideoxpath">    
                                                    <option value="all">请选择网站</option>
                                                    <option value="17173">17173游戏视频</option>
                                                    <option value="56">56网</option>
                                                    <option value="6cn">六间房</option>
                                                    <option value="baidu">百度视频搜索</option>
                                                    <option value="cntv">中国网络电视台</option>
                                                    <option value="hunantv">芒果TV</option>
                                                    <option value="ifeng">凤凰宽频</option>
                                                    <option value="ku6">酷6网</option>
                                                    <option value="news">新华网</option>
                                                    <option value="openv">天线高清</option>
                                                    <option value="qq">QQ播客</option>
                                                    <option value="sina">新浪视频</option>
                                                    <option value="sohu">搜狐视频</option>
                                                    <option value="tencent">腾讯宽频</option>
                                                    <option value="tudou">土豆网</option>
                                                    <option value="xunlei">迅雷看看</option>
                                                    <option value="youku">优酷网</option>
                                                    <option value="pps">PPS</option>
                                                    <option value="pplive">PPLive</option>
                                                    <option value="uusee">UUSee</option>
                                                    <option value="m1905">m1905电影网</option>
                                                    <option value="funshion">风行</option>
                                                    <option value="joy">激动网</option>
                                                    <option value="letv">乐视网</option>
                                                    <option value="pomoho">爆米花</option>
                                                    <option value="aeeboo">爱播网</option>
                                                    <option value="google">google视频搜索</option>
                                                  </select>
                                            </td>
                                            <td align="left" width="*" bgcolor="#ffffff">
                                                 <input type="button"  value="进入管理Xpath页面" class="ButtonCss"  onclick="choisesourceno(4);"/> 
                                            </td>
                                    </tr>
                                </table>
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
