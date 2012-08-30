<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfoEdit.aspx.cs" Inherits="CnWeb.user.UserInfoEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>天下接口网</title>
    <meta http-equiv="content-type" content="text/html;charset=utf-8">
    <meta name="keywords" content="接口,interface,天下接口,接口天下,程序接口,网络接口,webservice接口,http接口,ActiveX dll接口,普通dll接口,数据库接口,短信,短信发送,短信在线发送,手机短信,手机短信发送,手机短信在线发送,飞信,飞信登录,飞信短信,飞信好友,第一页搜索,首页搜索,搜索引擎,google,百度,雅虎,bing,搜狗,搜搜,有道." />
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
    <script language ="javascript">
        function ConfirmElements() {
            if (document.getElementById("txtRealName").value == "") {
                alert("昵称不能为空！");
                document.getElementById("txtRealName").focus();
                return false;
            }
            if (document.getElementById("hiddenNameCheckOk").value == "error") {
                alert("您所输入昵称已被使用，请更改其他可用昵称！");
                document.getElementById("txtRealName").focus();
                return false;
            }
            if (document.getElementById("txtRemark").value == "") {
                txtRemark
                alert("个性签名不能为空！");
                document.getElementById("txtRemark").focus();
                return false;
            }
            return true;
        }

        function createHttpRequest() {
            try {
                return new ActiveXObject('MSXML2.XMLHTTP.4.0');
            }
            catch (e) {
                try {
                    return new ActiveXObject('MSXML2.XMLHTTP.3.0');
                }
                catch (e) {
                    try {
                        return new ActiveXObject('MSXML2.XMLHTTP.5.0');
                    } catch (e) {
                        try {
                            return new ActiveXObject('MSXML2.XMLHTTP');
                        } catch (e) {
                            try {
                                return new ActiveXObject('Microsoft.XMLHTTP');
                            } catch (e) {
                                if (window.XMLHttpRequest) {
                                    return new XMLHttpRequest();
                                }
                                else {
                                    return null;
                                }
                            }
                        }
                    }
                }
            }
        }

        var xmlhttpUserInfoEdit;
        function CheckNameIsExist() {
            try {
                if (document.getElementById("txtRealName").value == "")
                    return;
                xmlhttpUserInfoEdit = createHttpRequest();
                document.getElementById("spannamecheck").innerHTML = "<font size=2 color=blue><b>昵称检查中...</b></font>";
                var UrlStr = "UserInfoEdit.aspx?ResponseName=" + escape(document.getElementById("txtRealName").value) + "&ResponseRealName=" + escape(document.getElementById("hiddenRealName").value);
                xmlhttpUserInfoEdit.onreadystatechange = processReqChange2;
                xmlhttpUserInfoEdit.open("POST", UrlStr, true);
                xmlhttpUserInfoEdit.setRequestHeader('Connection', 'close');
                xmlhttpUserInfoEdit.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
                xmlhttpUserInfoEdit.send(null);
            }
            catch (e) {
                document.getElementById("spannamecheck").innerHTML = "<font size=2 color=red><b>网络忙，请稍后修改此昵称!</b></font>";
                document.getElementById("hiddenNameCheckOk").value = "error";
            }
        }

        function processReqChange2() {
            try {
                if (xmlhttpUserInfoEdit.readyState == 4) {
                    if (xmlhttpUserInfoEdit.status == 200) {
                        if (xmlhttpUserInfoEdit.responseText == "no") {
                            document.getElementById("spannamecheck").innerHTML = "<font size=2 color=green><b>此昵称可用!</b></font>";
                            document.getElementById("hiddenNameCheckOk").value = "ok";
                        }
                        else {
                            document.getElementById("spannamecheck").innerHTML = "<font size=2 color=red><b>此昵称已被使用，请更换其他可用昵称!</b></font>";
                            document.getElementById("hiddenNameCheckOk").value = "error";
                        }
                    }
                }
            }
            catch (e) {
                document.getElementById("spannamecheck").innerHTML = "<font size=2 color=red><b>网络忙，请稍后修改此昵称!</b></font>";
                document.getElementById("hiddenNameCheckOk").value = "error";
            }
        }
    </script>
    <style type="text/css">
        #txtRemark
        {
            height: 98px;
            width: 443px;
        }
    </style>
    <link href="../css/base.css" type="text/css" rel="Stylesheet" />
</head>
<body  bgcolor="#ffffff">
    <form id="form1" runat="server"><input type ="hidden" id ="hiddenRealName"  runat ="server"/><input type ="hidden" id ="hiddenNameCheckOk" />
<table   align="center"  border ="0" cellpadding ="0" cellspacing ="0" width ="770px" bgcolor="#ffffff" >
        <tr>
            <td>
                        <table   align="left"  border ="0" cellpadding ="0" cellspacing ="0" width ="800px" bgcolor="#ffffff"><tr><td><a href="http://www.cninterface.com"><img border="0"  src="img/indexHeader.jpg"/></a></td></tr></table>

            </td>
        </tr>
             <tr>
            <td>
                 <table align="left"  border ="0" cellpadding ="4" cellspacing ="1" width ="800px" bgcolor="#9999ff">
            <tr>
                <td align="left"  bgcolor="#ffffff" colspan ="2"  style="background-image:url(../img/menuBackGround.jpg) " ><font size="3" color="#666699" ><b>个人信息:</b></font></td>
            </tr>
            <tr>
                <td bgcolor="#ffffff" width="40%" align="right"><font color=black size=2>用户名：</font></td>
                <td bgcolor="#ffffff" width="60%" align="left"  id ="txtUsername" runat ="server"></td>
            </tr>
            <tr>
                <td bgcolor="#ffffff" width="40%" align="right"><font color=black size=2>用户自定义头像： </font></td>
                <td bgcolor="#ffffff" width="60%" align="left" >
                    <asp:Image  ID="imgUserImg" runat="server" Height="75px" Width="90px"  ImageUrl="img/noupload.jpg"/>&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:FileUpload ID="FileUploadImg" runat="server"    class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnUploadImg" runat="server" Text="上传"   onclick="btnUploadImg_Click"  CssClass="ButtonCss"/>
               </td>
            </tr>
             <tr>
                            <td bgcolor="#ffffff" width="40%" align="right"><font color=black size=2>中文昵称：</font></td>
                            <td bgcolor="#ffffff" width="60%" align="left"><input type ="text" id ="txtRealName" runat ="server"  onblur="CheckNameIsExist();"     class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'" /><font color=red >*</font><span id="spannamecheck"><font size=2>中文
                                </font></span></td>
             </tr>
             <tr>
                            <td bgcolor="#ffffff" width="40%" align="right"><font color=black size=2>性别：</font></td>
                            <td bgcolor="#ffffff" width="60%" align="left">
                                <select id ="sltUserSex" runat ="server" >
                                     <option value="男" selected>男</option>
                                     <option value="女">女</option>
                                </select>
                            </td>
            </tr>
          
           <tr>
                            <td bgcolor="#ffffff" width="40%" align="right"><font color=black size=2>出生日期：</font></td>
                            <td bgcolor="#ffffff" width="60%" align="left"><input type ="text" id ="txtUserBirthday" runat ="server"  value =""   class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'" /></td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" width="40%" align="right"><font color=black size=2>电话：</font></td>
                            <td bgcolor="#ffffff" width="60%" align="left"><input type ="text" id ="txtUserTel" runat ="server"    class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'" /></td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" width="40%" align="right"><font color=black size=2>手机：</font></td>
                            <td bgcolor="#ffffff" width="60%" align="left"><input type ="text" id ="txtUserMobile" runat ="server"   class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  /></td>
                        </tr>
                         <tr>
                            <td bgcolor="#ffffff" width="40%" align="right"><font color=black size=2>Email：</font></td>
                            <td bgcolor="#ffffff" width="60%" align="left"><input type ="text" id ="txtUserEmail" runat ="server"   class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  /></td>
                        </tr>
                         <tr>
                            <td bgcolor="#ffffff" width="40%" align="right"><font color=black size=2>Msn：</font></td>
                            <td bgcolor="#ffffff" width="60%" align="left"><input type ="text" id ="txtUserMsn" runat ="server"   class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  /></td>
                        </tr>
                        <tr>
                            <td bgcolor="#ffffff" width="40%" align="right"><font color=black size=2>QQ：</font></td>
                            <td bgcolor="#ffffff" width="60%" align="left"><input type ="text" id ="txtQQ" runat ="server"   class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  /></td>
                        </tr>
                         <tr>
                            <td bgcolor="#ffffff" width="40%" align="right"><font color=black size=2>地址：</font></td>
                            <td bgcolor="#ffffff" width="60%" align="left"><input type ="text" id ="txtAddress" runat ="server"    class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'" /></td>
                        </tr>
                         <tr>
                            <td bgcolor="#ffffff" width="40%" align="right"><font color=black size=2>邮编：</font></td>
                            <td bgcolor="#ffffff" width="60%" align="left"><input type ="text" id ="txtZip" runat ="server"   class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  /></td>
                        </tr>
                          <tr>
                            <td bgcolor="#ffffff" width="40%" align="right"><font color=black size=2>受教育程度：</font></td>
                            <td bgcolor="#ffffff" width="60%" align="left">
                                <select id ="sltEducation" runat="server">
                                    <option value="">请选择</option>
                                    <option value="高中及以下">高中及以下</option>
                                    <option value="专科(大专)">专科(大专)</option>
                                    <option value="本科">本科</option>
                                    <option value="硕士">硕士</option>
                                    <option value="博士及以上">博士及以上</option>
                                </select>
                            </td>
                        </tr>
                          <tr>
                            <td bgcolor="#ffffff" width="40%" align="right"><font color=black size=2>行业：</font></td>
                            <td bgcolor="#ffffff" width="60%" align="left">
                                <select id ="sltProfession" runat="server">
                                 <option value="">请选择</option>
                                    <option value="销售/市场营销">销售/市场营销</option>
                                    <option value="技术研发/售前售后工程师">技术研发/售前售后工程师</option>
                                    <option value="企业管理/行政/人力资源">企业管理/行政/人力资源</option>
                                    <option value="证券/金融/投资">证券/金融/投资</option>
                                    <option value="公关/咨询/媒体">公关/咨询/媒体</option>
                                    <option value="公务员/科/教/文/卫">公务员/科/教/文/卫</option>
                                     <option value="私营企业主/贸易">私营企业主/贸易</option>
                                      <option value="其他">其他</option>
                                </select>
                            </td>
                        </tr>
                          <tr>
                            <td bgcolor="#ffffff" width="40%" align="right"><font color=black size=2>国家：</font></td>
                            <td bgcolor="#ffffff" width="60%" align="left">
                                <select id ="sltCountry" runat="server">
                                <option value="">请选择</option>
                                    <option value="中国">中国</option>
                                    <option value="美国">美国</option>
                                    <option value="英国">英国</option>
                                    <option value="法国">法国</option>
                                    <option value="德国">德国</option>
                                    <option value="巴西">巴西</option>
                                    <option value="韩国">韩国</option>
                                    <option value="伊朗">伊朗</option>
                                    <option value="朝鲜">朝鲜</option>
                                     <option value="泰国">泰国</option>
                                     <option value="越南">越南</option>
                                     <option value="印度">印度</option>
                                     <option value="南非">南非</option>
                                      <option value="日本">日本</option>
                                     <option value="墨西哥">墨西哥</option>
                                     <option value="意大利">意大利</option>
                                     <option value="新加坡">新加坡</option>
                                    <option value="俄罗斯">俄罗斯</option>
                                    <option value="加拿大">加拿大</option>
                                     <option value="马来西亚">马来西亚</option>
                                    <option value="澳大利亚">澳大利亚</option>
                                    <option value="巴基斯坦">巴基斯坦</option>
                                    <option value="其他">其他</option>
                                </select>
                            </td>
                        </tr>
                          <tr>
                            <td bgcolor="#ffffff" width="40%" align="right"><font color=black size=2>省份：</font></td>
                            <td bgcolor="#ffffff" width="60%" align="left">
                                <select id ="sltProvince" runat="server">
                                 <option value="">请选择</option>
                                   <option value="北京">北京</option>
                                    <option value="上海">上海</option>
                                    <option value="香港">香港</option>
                                    <option value="澳门">澳门</option>
                                    <option value="湖南">湖南</option>
                                    <option value="深圳">深圳</option>
                                    <option value="广东">广东</option>
                                    <option value="天津">天津</option>
                                    <option value="广西">广西</option>
                                    <option value="江西">江西</option>
                                    <option value="山西">山西</option>
                                    <option value="江苏">江苏</option>
                                     <option value="四川">四川</option>
                                       <option value="重庆">重庆</option>
                                      <option value="浙江">浙江</option>
                                      <option value="湖北">湖北</option>
                                      <option value="山东">山东</option>
                                      <option value="辽宁">辽宁</option>
                                      <option value="哈尔滨">哈尔滨</option>
                                      <option value="大连">大连</option>
                                       <option value="内蒙古">内蒙古</option>
                                      <option value="河南">河南</option>
                                      <option value="河北">河北</option>
                                      <option value="西藏">西藏</option>
                                      <option value="新疆">新疆</option>
                                      <option value="宁夏">宁夏</option>
                                       <option value="其他">其他</option>
                                </select>
                            </td>
                        </tr>
                          <tr>
                            <td bgcolor="#ffffff" width="40%" align="right"><font color=black size=2>城市：</font></td>
                            <td bgcolor="#ffffff" width="60%" align="left">
                                <select id ="sltCity" runat="server">
                                 <option value="">请选择</option>
                                     <option value="北京">北京</option>
                                    <option value="上海">上海</option>
                                    <option value="长沙">长沙</option>
                                     <option value="香港">香港</option>
                                    <option value="澳门">澳门</option>
                                    <option value="广州">广州</option>
                                    <option value="深圳">深圳</option>
                                    <option value="澳门">澳门</option>
                                    <option value="天津">天津</option>
                                    <option value="大连">大连</option>
                                    <option value="南昌">南昌</option>
                                     <option value="常德">常德</option>
                                      <option value="岳阳">岳阳</option>
                                       <option value="邵阳">邵阳</option>
                                        <option value="耒阳">耒阳</option>
                                         <option value="祁阳">祁阳</option>
                                          <option value="郴州">郴州</option>
                                           <option value="浏阳">浏阳</option>
                                            <option value="株洲">株洲</option>
                                             <option value="衡山">衡山</option>
                                    <option value="衡阳">衡阳</option>
                                    <option value="武汉">武汉</option>
                                    <option value="安徽">安徽</option>
                                    <option value="浙江">浙江</option>
                                    <option value="成都">成都</option>
                                     <option value="昆明">昆明</option>
                                      <option value="扬州">扬州</option>
                                       <option value="其他">其他</option>
                                </select>
                            </td>
                        </tr>
                          <tr>
                            <td bgcolor="#ffffff" width="40%" align="right"><font color=black size=2>上网地点：</font></td>
                            <td bgcolor="#ffffff" width="60%" align="left">
                                <select id ="sltNetAddress" runat="server">
                                 <option value="">请选择</option>
                                    <option value="办公室">办公室</option>
                                    <option value="住所">住所</option>
                                    <option value="网吧">网吧</option>
                                    <option value="户外">户外</option>
                                    <option value="其他">其他</option>
                                </select>
                            </td>
                        </tr>
                          <tr>
                            <td bgcolor="#ffffff" width="40%" align="right"><font color=black size=2>知晓本站渠道：</font></td>
                            <td bgcolor="#ffffff" width="60%" align="left">
                                <select id ="sltchannel" runat="server">
                                    <option value="广告">广告</option>
                                    <option value=">朋友介绍" selected="selected">朋友介绍</option>
                                    <option value="3其他网站链接">其他网站链接</option>
                                    <option value="搜索">搜索</option>
                                    <option value="其他">其他</option>
                                </select>
                            </td>
                        </tr>
            <tr>
                <td bgcolor="#ffffff"  width="40%" align="right"><font color="black">个性签名：</font></td>
                <td bgcolor="#ffffff" width="60%" align="left"><textarea id ="txtRemark" runat ="server"    class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'" ></textarea></td>
            </tr>
            <tr>
                <td bgcolor="#ffffff" colspan="2"  align="center"><asp:Button   ID="btnregister1" runat="server" onclick="btnregister1_Click" Text="保 存"   CssClass="ButtonCss" />
                &nbsp;&nbsp;&nbsp;<a href="http://www.cninterface.com">返回</a></td>
            </tr>
        </table>
            </td>
        </tr>
    </table>
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
    </form>
    <div style="display:none;"><script src="http://s11.cnzz.com/stat.php?id=2099859&web_id=2099859&show=pic1" language="JavaScript"></script></div>
</body>
</html>