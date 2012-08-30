<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CnWeb.Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="css/imgplayer.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" src="js/imgplayer.js" type ="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <!--图片库分页展示开始-->
         <div><b>图片库分页展示：</b></div>
        <!--图片库分页展示开始-->
                    <script type="text/javascript" language="javascript">
                        initimages();
		            </script>
		            <!-- 图片播放器主体 begin -->
			            <div id="ImgPlayer">
				            <!-- 大图 begin -->
				            <div id="ImgBlk">
				                <table  border="0" cellpadding ="0" cellspacing ="0" width="100%">
				                    <tr>
				                        <td align="left" height="20px"><span id="sweb"></span>：<span id="tt" style="font-weight:bold;font-size:14px;">loading...</span></td>
				                        <td align="right"><a href="html/VideoIndex.html"  target="_blank" title="更多视频网站最新视频"><font size=2 color="#666699">更多...</font></a></td>
				                    </tr>
				                </table>
					            <div id="ss_img_div"><a href="javascript:ss.hotlink();"><img  id="ss_img" style="filter:blendTrans(Duration=1);" width="432" height="240" src="imgtemp/loading.jpg"/></a></div>
					            
					            <div id="ImgNum">
						            <!-- 数字 begin -->
						            <ul  id="divpagedata">
            							
						            </ul>
						            <!-- 数字 end -->
						            <!-- 播放 begin -->
						            <div id="Play" onclick="ss.play(); document.getElementById('Pause').style.display='block'; this.style.display='none';" onmousemove="this.style.color='#c00';" onmouseout="this.style.color='#7D98BF';" style="display:none;">播放</div>
						            <!-- 播放 end -->
						            <!-- 暂停 begin -->
						            <div id="Pause" onclick="ss.pause(); document.getElementById('Play').style.display='block'; this.style.display='none';" onmousemove="this.style.color='#c00';" onmouseout="this.style.color='#7D98BF';">暂停</div>
						            <!-- 暂停 end -->
					            </div>
					            
				            </div>
				            <!-- 大图 end -->
			            </div>
			            <!-- 图片播放器主体 end -->
			            <script type="text/javascript">
			                GetIndexData(0);
			            </script>
                    <!--图片库分页展示结束-->
                       
        <br />
                    <table  border="0" cellpadding ="0" cellspacing ="0"  width="100%" align="center">
        <tr><td align="left"><b>各大视频网站标签云：</b></td></tr>
         <tr><td align="left">
            <script type="text/javascript" src="js/swfobject.js"></script>
            <div id="divsftagcloud"><br /><p><font color="#666699">显示该flash须安装Flash Player 9或</font><a href="http://www.skycn.com/soft/5671.html" target="_blank">更高版本</a>。</p></div>
            <script type="text/javascript">
                var sftagcloud = new SWFObject("js/tagcloud.swf", "tagcloudflash", "400", "260", "9", "#ffffff");
                sftagcloud.addParam("allowScriptAccess", "always");
                sftagcloud.addVariable("tcolor", "0x0353ce");
                sftagcloud.addVariable("tcolor2", "0x0353ce");
                sftagcloud.addVariable("hicolor", "0xcc0000");
                sftagcloud.addVariable("tspeed", "100");
                sftagcloud.addVariable("distr", "true");
                sftagcloud.addVariable("mode", "tags");
                sftagcloud.addVariable("tagcloud", "<%=TagCloudCode%>");
                sftagcloud.write("divsftagcloud");
            </script>
        </td></tr>
    </table>
    
    <div><b>图片不间断连续滚动：</b></div>
    <div id="colee_left" style="overflow:hidden;width:100%; border: #666699 0px solid;">
        <table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td id="colee_left1" valign="top" align="center">
                 <%=PicGoingOk%><%=PicGoingError%>
            </td>
            <td id="colee_left2" valign="top"></td>
        </tr>
        </table>
     </div>
        <script>
            //使用div时，请保证colee_left2与colee_left1是在同一行上.
            var speed = 30//速度数值越大速度越慢
            var colee_left2 = document.getElementById("colee_left2");
            var colee_left1 = document.getElementById("colee_left1");
            var colee_left = document.getElementById("colee_left");
            colee_left2.innerHTML = colee_left1.innerHTML
            function Marquee3() {
                if (colee_left2.offsetWidth - colee_left.scrollLeft <= 0)//offsetWidth 是对象的可见宽度
                    colee_left.scrollLeft -= colee_left1.offsetWidth//scrollWidth 是对象的实际内容的宽，不包边线宽度
                else {
                    colee_left.scrollLeft++
                }
            }
            var MyMar3 = setInterval(Marquee3, speed)
            colee_left.onmouseover = function() { clearInterval(MyMar3) }
            colee_left.onmouseout = function() { MyMar3 = setInterval(Marquee3, speed) }
        </script>
     
    </form>
</body>
</html>
