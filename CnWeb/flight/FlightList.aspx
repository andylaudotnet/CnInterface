<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlightList.aspx.cs" Inherits="CnWeb.flight.FlightList" %>

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
    </style>
    <link href="../style/style.css" type="text/css" rel="stylesheet">
     <script language="javascript" type="text/javascript">
         function onmouseovertr(id,num)
            {
                for(var i=0;i<9;i++)
                {
                     document.getElementById(id).childNodes[i].style.backgroundColor="yellow";
                }
                if(num==2)
                {
                    var newid=parseInt(id.replace("tr",""))+1;
                     for(var i=0;i<9;i++)
                     {
                         document.getElementById("tr"+newid).childNodes[i].style.backgroundColor="yellow";
                    }
                }
                 if(num==3)
                {
                    var newid=parseInt(id.replace("tr",""))-1;
                     for(var i=0;i<9;i++)
                     {
                         document.getElementById("tr"+newid).childNodes[i].style.backgroundColor="yellow";
                    }
                }
            }
            function onmouseouttr(id,num)
            {
                 for(var i=0;i<9;i++)
                {
                     document.getElementById(id).childNodes[i].style.backgroundColor="white";
                }
                if(num==2)
                {
                    var newid=parseInt(id.replace("tr",""))+1;
                     for(var i=0;i<9;i++)
                     {
                       document.getElementById("tr"+newid).childNodes[i].style.backgroundColor="white";
                    }
                }
                 if(num==3)
                {
                    var newid=parseInt(id.replace("tr",""))-1;
                     for(var i=0;i<9;i++)
                     {
                       document.getElementById("tr"+newid).childNodes[i].style.backgroundColor="white";
                    }
                }
            }
        function openprice(bunks)
        {
            window.showModalDialog(bunks,"bunks","dialogWidth=400px;dialogHeight=400px");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <center>
    <div style="width:666px;">
         <table  border="0" cellpadding ="0" cellspacing ="0"  bgcolor="#ffffff" align="center"  width="737px" >
                    <tr>
                        <td  bgcolor="#ffffff"  align="left"><a href="../Index.aspx"  title="旨在提供接口共享平台，体现接口服务价值"><img border="0"  src="../img/logo_cninterface.gif"/></a></td>
                        <td align="right" valign="bottom"><font color="#666699"><%=FlightInfo %></font>&nbsp;<a href="Index.aspx">重新查询</a></td>
                    </tr>
    </table>
        <%=FlightHtml%>
    </div>
    </center>
    </form>
</body>
</html>
