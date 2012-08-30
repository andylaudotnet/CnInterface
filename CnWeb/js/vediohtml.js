//显示各大网站今日最新视频
function showintervideos(name, trnum) {
    document.getElementById("divshowintervideos").style.width = "475px";
    document.getElementById("divshowintervideos").style.height = "251px";
    switch (name) {
        case "youku":
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://www.youku.com\" target=\"_blank\"><font size='2'  color='#003399'><b>优酷网</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/YoukuVideos.html\"  width=\"465px\"  height=\"231px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "tudou":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "275px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "485px";
                document.getElementById("divshowintervideos").style.height = "282px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://www.tudou.com\" target=\"_blank\"><font size='2'  color='#003399'><b>土豆网</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/TudouVideos.html\"  width=\"465px\"  height=\"255px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "baidu":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "275px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "485px";
                document.getElementById("divshowintervideos").style.height = "282px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://video.baidu.com/\" target=\"_blank\"><font size='2'  color='#003399'><b>百度视频搜索</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/BaiduVideos.html\"  width=\"465px\"  height=\"255px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "xunlei":
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://www.xunlei.com/\" target=\"_blank\"><font size='2'  color='#003399'><b>迅雷看看</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/XunleiVideos.html\"  width=\"465px\"  height=\"231px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "56":
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://www.56.com/\" target=\"_blank\"><font size='2'  color='#003399'><b>56网</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/56Videos.html\"  width=\"465px\"  height=\"231px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "joy":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "310px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "485px";
                document.getElementById("divshowintervideos").style.height = "310px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://www.joy.cn/\" target=\"_blank\"><font size='2'  color='#003399'><b>激动网</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/JoyVideos.html\"  width=\"465px\"  height=\"290px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "sina":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "275px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "485px";
                document.getElementById("divshowintervideos").style.height = "285px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://video.sina.com.cn/\" target=\"_blank\"><font size='2'  color='#003399'><b>新浪视频</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/SinaVideos.html\"  width=\"465px\"  height=\"255px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "sinablog":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "270px";
                document.getElementById("divshowintervideos").style.width = "485px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "485px";
                document.getElementById("divshowintervideos").style.height = "270px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"95%\" ><tr><td colspan='2'><a href=\"http://v.sina.com.cn/\" target=\"_blank\"><font size='2'  color='#003399'><b>新浪播客</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/SinablogVideos.html\"  width=\"465px\"  height=\"380px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "openv":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "265px";
                document.getElementById("divshowintervideos").style.width = "485px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "485px";
                document.getElementById("divshowintervideos").style.height = "242px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"95%\" ><tr><td colspan='2'><a href=\"http://hd.openv.com/\" target=\"_blank\"><font size='2'  color='#003399'><b>天线高清</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/OpenvVideos.html\"  width=\"465px\"  height=\"244px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "sohu":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "275px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "485px";
                document.getElementById("divshowintervideos").style.height = "285px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://tv.sohu.com/\" target=\"_blank\"><font size='2'  color='#003399'><b>搜狐视频</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/SohuVideos.html\"  width=\"465px\"  height=\"255px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "6cn":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "280px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "475px";
                document.getElementById("divshowintervideos").style.height = "280px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://www.6.cn\" target=\"_blank\"><font size='2'  color='#003399'><b>六间房</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/6cnVideos.html\"  width=\"465px\"  height=\"260px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "qq":
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://video.qq.com/\" target=\"_blank\"><font size='2'  color='#003399'><b>QQ播客</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/QQVideos.html\"  width=\"465px\"  height=\"231px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "hunantv":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "310px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "485px";
                document.getElementById("divshowintervideos").style.height = "310px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://tv.hunantv.com/\" target=\"_blank\"><font size='2'  color='#003399'><b>芒果TV</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/HunantvVideos.html\"  width=\"465px\"  height=\"290px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "cntv":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "275px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "475px";
                document.getElementById("divshowintervideos").style.height = "280px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://www.cntv.cn/\" target=\"_blank\"><font size='2'  color='#003399'><b>中国网络电视台</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/CntvVideos.html\"  width=\"465px\"  height=\"255px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "tencent":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "280px";
                document.getElementById("divshowintervideos").style.width = "485px";
                if (navigator.userAgent.indexOf("Chrome") > -1) {
                    document.getElementById("divshowintervideos").style.height = "290px";
                }
            }
            else {
                document.getElementById("divshowintervideos").style.width = "485px";
                document.getElementById("divshowintervideos").style.height = "295px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"94%\" ><tr><td colspan='2'><a href=\"http://bb.news.qq.com/\" target=\"_blank\"><font size='2'  color='#003399'><b>腾讯宽频</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/TencentVideos.html\"  width=\"465px\"  height=\"260px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "17173":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "275px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "475px";
                document.getElementById("divshowintervideos").style.height = "280px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://media.17173.com/\" target=\"_blank\"><font size='2'  color='#003399'><b>17173游戏视频</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/17173Videos.html\"  width=\"465px\"  height=\"255px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "ifeng":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "275px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "475px";
                document.getElementById("divshowintervideos").style.height = "280px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://v.ifeng.com/\" target=\"_blank\"><font size='2'  color='#003399'><b>凤凰宽频</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/IfengVideos.html\"  width=\"465px\"  height=\"255px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "news":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "275px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "475px";
                document.getElementById("divshowintervideos").style.height = "280px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://www.xinhuanet.com/video/\" target=\"_blank\"><font size='2'  color='#003399'><b>新华网</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/NewsVideos.html\"  width=\"465px\"  height=\"255px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "ku6":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "275px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "475px";
                document.getElementById("divshowintervideos").style.height = "280px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://www.ku6.com/\" target=\"_blank\"><font size='2'  color='#003399'><b>酷6视频</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/Ku6Videos.html\"  width=\"465px\"  height=\"255px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "pps":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "265px";
                document.getElementById("divshowintervideos").style.width = "485px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "485px";
                document.getElementById("divshowintervideos").style.height = "258px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"95%\" ><tr><td colspan='2'><a href=\"http://www.pps.tv/\" target=\"_blank\"><font size='2'  color='#003399'><b>PPS</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/PPSVideos.html\"  width=\"465px\"  height=\"243px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "pplive":
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://www.pptv.com/\" target=\"_blank\"><font size='2'  color='#003399'><b>PPLive</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/PPLiveVideos.html\"  width=\"465px\"  height=\"231px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "uusee":
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://www.uusee.com/\" target=\"_blank\"><font size='2'  color='#003399'><b>UUsee</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/UUseeVideos.html\"  width=\"465px\"  height=\"231px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "m1905":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "280px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "485px";
                document.getElementById("divshowintervideos").style.height = "306px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://www.m1905.com/\" target=\"_blank\"><font size='2'  color='#003399'><b>m1905电影网</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/M1905Videos.html\"  width=\"465px\"  height=\"250px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "funshion":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "240px";
                document.getElementById("divshowintervideos").style.width = "485px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "485px";
                document.getElementById("divshowintervideos").style.height = "242px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"95%\" ><tr><td colspan='2'><a href=\"http://www.funshion.com/\" target=\"_blank\"><font size='2'  color='#003399'><b>风行</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/FunshionVideos.html\"  width=\"465px\"  height=\"220px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "pomoho":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "255px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "485px";
                document.getElementById("divshowintervideos").style.height = "285px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://www.pomoho.com\" target=\"_blank\"><font size='2'  color='#003399'><b>爆米花</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/PomohoVideos.html\"  width=\"465px\"  height=\"235px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "letv":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "275px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "485px";
                document.getElementById("divshowintervideos").style.height = "285px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://www.letv.com\" target=\"_blank\"><font size='2'  color='#003399'><b>乐视网</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/LetvVideos.html\"  width=\"465px\"  height=\"255px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "aeeboo":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "255px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "485px";
                document.getElementById("divshowintervideos").style.height = "285px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://www.aeeboo.com\" target=\"_blank\"><font size='2'  color='#003399'><b>爱播网</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/AeebooVideos.html\"  width=\"465px\"  height=\"235px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        case "google":
            if (navigator.userAgent.indexOf("MSIE 8.0") > 0 || navigator.userAgent.indexOf("MSIE") <= 0) {
                document.getElementById("divshowintervideos").style.height = "275px";
            }
            else {
                document.getElementById("divshowintervideos").style.width = "485px";
                document.getElementById("divshowintervideos").style.height = "285px";
            }
            document.getElementById("divshowintervideos").innerHTML = "<table border=\"0\" cellpadding =\"2\" cellspacing =\"0\"   width=\"100%\" ><tr><td colspan='2'><a href=\"http://video.google.cn\" target=\"_blank\"><font size='2'  color='#003399'><b>Google视频搜索</b></font></a><font size='2'  color='#666699'>今日最新视频：</font></td><td align='right'><span style='cursor:hand'  onclick='hiddenNamelist();'  title='关闭'><font size=2 color=red><b>关闭</b></font></span><img border=\"0\"  src=\"img/blank.jpg\" width=\"1px\" height=\"10px\"/></td></tr></table><iframe src=\"html/GoogleVideos.html\"  width=\"465px\"  height=\"255px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
        default:
            document.getElementById("divshowintervideos").innerHTML = "<iframe src=\"html/message.html\"  width=\"465px\"  height=\"251px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
            break;
    }
    if (navigator.userAgent.indexOf("MSIE") > 0) {
        switch (trnum) {
            case 1:
                if (navigator.userAgent.indexOf("MSIE 8.0") > 0) {
                    document.getElementById("divshowintervideos").style.left = "442px";
                    document.getElementById("divshowintervideos").style.top = "240px";
                }
                else {
                    document.getElementById("divshowintervideos").style.top = "249px";
                }
                break;
            case 2:
                if (navigator.userAgent.indexOf("MSIE 8.0") > 0) {
                    document.getElementById("divshowintervideos").style.left = "442px";
                    document.getElementById("divshowintervideos").style.top = "260px";
                }
                else {
                    document.getElementById("divshowintervideos").style.top = "268px";
                }
                break;
            case 3:
                if (navigator.userAgent.indexOf("MSIE 8.0") > 0) {
                    document.getElementById("divshowintervideos").style.left = "442px";
                    document.getElementById("divshowintervideos").style.top = "280px";
                }
                else {
                    document.getElementById("divshowintervideos").style.top = "289px";
                }
                break;
            case 4:
                if (navigator.userAgent.indexOf("MSIE 8.0") > 0) {
                    document.getElementById("divshowintervideos").style.left = "442px";
                    document.getElementById("divshowintervideos").style.top = "300px";
                }
                else {
                    document.getElementById("divshowintervideos").style.top = "309px";
                }
                break;
            case 5:
                if (navigator.userAgent.indexOf("MSIE 8.0") > 0) {
                    document.getElementById("divshowintervideos").style.left = "442px";
                    document.getElementById("divshowintervideos").style.top = "321px";
                }
                else {
                    document.getElementById("divshowintervideos").style.top = "328px";
                }
                break;
            case 6:
                if (navigator.userAgent.indexOf("MSIE 8.0") > 0) {
                    document.getElementById("divshowintervideos").style.left = "442px";
                    document.getElementById("divshowintervideos").style.top = "342px";
                }
                else {
                    document.getElementById("divshowintervideos").style.top = "348px";
                }
                break;
            default:
                document.getElementById("divshowintervideos").style.top = "342px";
                break;
        }
    }
    else {
        document.getElementById("divshowintervideos").style.left = "444px";
        switch (trnum) {
            case 1:
                document.getElementById("divshowintervideos").style.top = "240px";
                if (navigator.userAgent.indexOf("Chrome") > -1)
                    document.getElementById("divshowintervideos").style.top = "248px";
                if (navigator.userAgent.indexOf("Opera") > -1)
                    document.getElementById("divshowintervideos").style.top = "232px";
                break;
            case 2:
                document.getElementById("divshowintervideos").style.top = "260px";
                if (navigator.userAgent.indexOf("Chrome") > -1)
                    document.getElementById("divshowintervideos").style.top = "267px";
                if (navigator.userAgent.indexOf("Opera") > -1)
                    document.getElementById("divshowintervideos").style.top = "249px";
                break;
            case 3:
                document.getElementById("divshowintervideos").style.top = "278px";
                if (navigator.userAgent.indexOf("Chrome") > -1)
                    document.getElementById("divshowintervideos").style.top = "286px";
                if (navigator.userAgent.indexOf("Opera") > -1)
                    document.getElementById("divshowintervideos").style.top = "266px";
                break;
            case 4:
                document.getElementById("divshowintervideos").style.top = "298px";
                if (navigator.userAgent.indexOf("Chrome") > -1)
                    document.getElementById("divshowintervideos").style.top = "305px";
                if (navigator.userAgent.indexOf("Opera") > -1)
                    document.getElementById("divshowintervideos").style.top = "283px";
                break;
            case 5:
                document.getElementById("divshowintervideos").style.top = "318px";
                if (navigator.userAgent.indexOf("Chrome") > -1)
                    document.getElementById("divshowintervideos").style.top = "325px";
                if (navigator.userAgent.indexOf("Opera") > -1)
                    document.getElementById("divshowintervideos").style.top = "300px";
                break;
            case 6:
                document.getElementById("divshowintervideos").style.top = "338px";
                if (navigator.userAgent.indexOf("Chrome") > -1)
                    document.getElementById("divshowintervideos").style.top = "345px";
                if (navigator.userAgent.indexOf("Opera") > -1)
                    document.getElementById("divshowintervideos").style.top = "318px";
                break;
            default:
                document.getElementById("divshowintervideos").style.top = "340px";
                break;

        }
    }
    showshowintervideos("divshowintervideos", "txtInterfaceName");
    document.getElementById("divshowintervideos").style.display = "block";
}

function showshowintervideos(showname, positionname) {
    var cf = document.getElementById(showname);
    var oImg = document.getElementById(positionname);
    if (navigator.userAgent.indexOf("MSIE") <= 0) {
        var leftvalue = parseInt(document.body.scrollWidth) - (parseInt(document.body.scrollWidth) / 2 + 189);
        cf.style.left = (leftvalue + 26) + "px";
        if (navigator.userAgent.indexOf("Chrome") > -1) {
            cf.style.left = (leftvalue + 18) + "px";
        }
    }
    else {
        var eT = 0, eL = 0, p = oImg;
        var sT = document.body.scrollTop, sL = document.body.scrollLeft;
        var eH = oImg.height + 25, eW = oImg.width;
        while (p && p.tagName != "BODY") { eT += p.offsetTop; eL += p.offsetLeft; p = p.offsetParent; }
        cf.style.left = ((document.body.clientWidth - (eL - sL) >= cf.style.posWidth) ? (eL + eW) : (eL - cf.style.posWidth)) + 35;
        if (navigator.userAgent.indexOf("MSIE 8.0") > 0) {
            cf.style.left = ((document.body.clientWidth - (eL - sL) >= cf.style.posWidth) ? (eL + eW) : (eL - cf.style.posWidth)) + 24;
        }
    }
}