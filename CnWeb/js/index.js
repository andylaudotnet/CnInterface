
//div定位通用函数 (showname:需定位div ID，positionname：相对标签ID)
function showDivStage(showname,positionname) {
    var cf = document.getElementById(showname);
    var oImg = document.getElementById(positionname);
    if (navigator.userAgent.indexOf("MSIE") <= 0) {
        var leftvalue = parseInt(document.body.scrollWidth) - (parseInt(document.body.scrollWidth) / 2 + 189)+333;
        cf.style.left = leftvalue + "px";
        /*if (navigator.userAgent.indexOf("Chrome") > -1) {
            cf.style.left = (leftvalue - 6) + "px";
            cf.style.top ="230px";
        }*/
    }
    else
    {
        var eT = 0, eL = 0, p = oImg;
        var sT = document.body.scrollTop, sL = document.body.scrollLeft;
        var eH = oImg.height + 25, eW = oImg.width;
        while (p && p.tagName != "BODY") { eT += p.offsetTop; eL += p.offsetLeft; p = p.offsetParent; }
        cf.style.top = ((document.body.clientHeight - (eT - sT) - eH >= cf.style.posHeight) ? (eT + eH) : (eT - cf.style.posHeight)) - 100;
        cf.style.left = ((document.body.clientWidth - (eL - sL) >= cf.style.posWidth) ? (eL + eW) : (eL - cf.style.posWidth)) + 13;
        if (navigator.userAgent.indexOf("MSIE 8.0")>0) {
            cf.style.top = ((document.body.clientHeight - (eT - sT) - eH >= cf.style.posHeight) ? (eT + eH) : (eT - cf.style.posHeight)) - 124;
            cf.style.left = ((document.body.clientWidth - (eL - sL) >= cf.style.posWidth) ? (eL + eW) : (eL - cf.style.posWidth)) + 4;
        }
    }
}

//显示各种接口区别
function showInterfaceDiff() {
        showDivStage("DivInterfaceDiff", "txtDivInterfaceDiff");
        document.getElementById("DivInterfaceDiff").style.display = "block";
}
//隐藏各种接口区别
function noShowInterfaceDiff() {
        document.getElementById("DivInterfaceDiff").style.display = "none";
}
 
//接口类型选择显示逻辑
function setSelectList(id) {
    var showname="";
    switch (id) {
        case "aall":
            showname = "全部";
            document.getElementById("aWebservice").innerHTML = "<font size=2  color='#666699'>Webservice</font>";
            document.getElementById("aHTTP").innerHTML = "<font size=2  color='#666699'>HTTP</font>";
            document.getElementById("aDLL").innerHTML = "<font size=2  color='#666699'>普通DLL</font>";
            document.getElementById("aADLL").innerHTML = "<font size=2  color='#666699'>ActiveXDLL</font>";
            document.getElementById("aData").innerHTML = "<font size=2  color='#666699'>数据库</font>";
            break;
        case "aWebservice":
            showname = "Webservice";
            document.getElementById("aall").innerHTML = "<font size=2  color='#666699'>全部</font>";
            document.getElementById("aHTTP").innerHTML = "<font size=2  color='#666699'>HTTP</font>";
            document.getElementById("aDLL").innerHTML = "<font size=2  color='#666699'>普通DLL</font>";
            document.getElementById("aADLL").innerHTML = "<font size=2  color='#666699'>ActiveXDLL</font>";
            document.getElementById("aData").innerHTML = "<font size=2  color='#666699'>数据库</font>";
            break;
        case "aHTTP":
            showname = "HTTP";
            document.getElementById("aall").innerHTML = "<font size=2  color='#666699'>全部</font>";
            document.getElementById("aWebservice").innerHTML = "<font size=2  color='#666699'>Webservice</font>";
            document.getElementById("aDLL").innerHTML = "<font size=2  color='#666699'>普通DLL</font>";
            document.getElementById("aADLL").innerHTML = "<font size=2  color='#666699'>ActiveXDLL</font>";
            document.getElementById("aData").innerHTML = "<font size=2  color='#666699'>数据库</font>";
        break;
        case "aDLL":
            showname = "普通DLL";
            document.getElementById("aall").innerHTML = "<font size=2  color='#666699'>全部</font>";
            document.getElementById("aHTTP").innerHTML = "<font size=2  color='#666699'>HTTP</font>";
            document.getElementById("aWebservice").innerHTML = "<font size=2  color='#666699'>Webservice</font>";
            document.getElementById("aADLL").innerHTML = "<font size=2  color='#666699'>ActiveXDLL</font>";
            document.getElementById("aData").innerHTML = "<font size=2  color='#666699'>数据库</font>";
        break;
        case "aADLL":
            showname = "ActiveXDLL";
            document.getElementById("aall").innerHTML = "<font size=2  color='#666699'>全部</font>";
            document.getElementById("aHTTP").innerHTML = "<font size=2  color='#666699'>HTTP</font>";
            document.getElementById("aDLL").innerHTML = "<font size=2  color='#666699'>普通DLL</font>";
            document.getElementById("aWebservice").innerHTML = "<font size=2  color='#666699'>Webservice</font>";
            document.getElementById("aData").innerHTML = "<font size=2  color='#666699'>数据库</font>";
        break;
        case "aData":
            showname = "数据库";
            document.getElementById("aall").innerHTML = "<font size=2  color='#666699'>全部</font>";
            document.getElementById("aHTTP").innerHTML = "<font size=2  color='#666699'>HTTP</font>";
            document.getElementById("aDLL").innerHTML = "<font size=2  color='#666699'>普通DLL</font>";
            document.getElementById("aADLL").innerHTML = "<font size=2  color='#666699'>ActiveXDLL</font>";
            document.getElementById("aWebservice").innerHTML = "<font size=2  color='#666699'>Webservice</font>";
        break;
        default:
            showname = "Webservice";
            document.getElementById("aall").innerHTML = "<font size=2  color='#666699'>全部</font>";
            document.getElementById("aHTTP").innerHTML = "<font size=2  color='#666699'>HTTP</font>";
            document.getElementById("aDLL").innerHTML = "<font size=2  color='#666699'>普通DLL</font>";
            document.getElementById("aADLL").innerHTML = "<font size=2  color='#666699'>ActiveXDLL</font>";
            document.getElementById("aData").innerHTML = "<font size=2  color='#666699'>数据库</font>";
        break;
    }
    document.getElementById(id).innerHTML = "<font size=2 color=\"#003399\"><b>" + showname + "</b></font>";
    //document.getElementById(id).style.textDecoration = "none";
    document.getElementById("hiddenInterfaceName").value = id;
    //document.getElementById("txtInterfaceName").value = "";
    document.getElementById("txtInterfaceName").focus();
}

function checksearchname()
{
    if(document.getElementById("txtInterfaceName").value=="")
    {
        document.getElementById("txtInterfaceName").focus();
        return false;
    }
    return true;
}

//返回浏览器版本
function getversion() {
    var Sys = {};
    var ua = navigator.userAgent.toLowerCase();
    if (window.ActiveXObject)
        Sys.ie = ua.match(/msie ([\d.]+)/)[1]
    else if (document.getBoxObjectFor)
        Sys.firefox = ua.match(/firefox\/([\d.]+)/)[1]
    else if (window.MessageEvent && !document.getBoxObjectFor)
        Sys.chrome = ua.match(/chrome\/([\d.]+)/)[1]
    else if (window.opera)
        Sys.opera = ua.match(/opera.([\d.]+)/)[1]
    else if (window.openDatabase)
        Sys.safari = ua.match(/version\/([\d.]+)/)[1];

    if (Sys.ie) return 'IE' + Sys.ie;
    if (Sys.firefox) return 'Firefox ' + Sys.firefox;
    if (Sys.chrome) return 'Chrome ' + Sys.chrome;
    if (Sys.opera) return 'Opera ' + Sys.opera;
    if (Sys.safari) return 'Safari' + Sys.safari;
}


function getBodySize() {
    var bodySize = [];
    with (document.documentElement) {
        bodySize[0] = (scrollWidth > clientWidth) ? scrollWidth : clientWidth; //如果滚动条的宽度大于页面的宽度，取得滚动条的宽度，否则取页面宽度
        bodySize[1] = (scrollHeight > clientHeight) ? scrollHeight : clientHeight; //如果滚动条的高度大于页面的高度，取得滚动条的高度，否则取高度
    }
    return bodySize;
}

function loginFuction() {
    document.getElementById("backimg").style.display = "block";
    var bodySize = getBodySize();
    width = bodySize[0] + "px";
    height = bodySize[1] + "px";
    document.getElementById("backimg").style.width = width;
    document.getElementById("backimg").style.height = height;
    document.getElementById("loader_container").style.display = "block";
    document.getElementById("txtusername").focus();
}

function loginCancel() {
    document.getElementById("backimg").style.display = "none";
    document.getElementById("loader_container").style.display = "none";
}

function createHttpRequest() {
    try {
        return new ActiveXObject('Msxml2.XMLHTTP.7.0');
    }
    catch (e) {
        try {
            return new ActiveXObject('Msxml2.XMLHTTP.6.0');
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

var xmlhttpLogin; //用户登录
function CheckLoginNamePwd() {
    try {
        if (document.getElementById("txtusername").value == "") {
            document.getElementById("txtusername").focus();
            return;
        }
        if (document.getElementById("txtpassword").value == "") {
            document.getElementById("txtpassword").focus();
            return;
        }
        var cookiestatus = "0";
        if (document.getElementById("ckbLoginStatus").checked) {
            cookiestatus = "1";
        }
        document.getElementById("txtusername").disabled = "disabled";
        document.getElementById("txtpassword").disabled = "disabled";
        document.getElementById("btnLogin").disabled = "disabled";
        document.getElementById("btnLogin").value = "登录中";
        xmlhttpLogin = createHttpRequest();
        var UrlStr = "SmsOnline/Index.aspx?ResponseLoginName=" + document.getElementById("txtusername").value + "&ResponseLoginPwd=" + document.getElementById("txtpassword").value + "&ResponseCookieStatus=" + cookiestatus;
        xmlhttpLogin.onreadystatechange = processCheckLogin;
        xmlhttpLogin.open("POST", UrlStr, true);
        xmlhttpLogin.setRequestHeader('Connection', 'close');
        xmlhttpLogin.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
        xmlhttpLogin.send(null);
    }
    catch (e) {
        document.getElementById("hiddenUsername").value = "";
        document.getElementById("txtusername").disabled = "";
        document.getElementById("txtpassword").disabled = "";
        document.getElementById("btnLogin").disabled = "";
        document.getElementById("btnLogin").value = "登录";
        alert("登录异常：" + e);
    }
}
function processCheckLogin() {
    try {
        if (xmlhttpLogin.readyState == 4) {
            if (xmlhttpLogin.status == 200) {
                if (xmlhttpLogin.responseText == "ok") {
                    document.getElementById("txtusername").disabled = "";
                    document.getElementById("txtpassword").disabled = "";
                    document.getElementById("btnLogin").disabled = "";
                    document.getElementById("btnLogin").value = "登录";
                    if (document.getElementById("hiddenUsername").value == "")
                        document.getElementById("hiddenUsername").value = document.getElementById("txtusername").value;
                    document.getElementById("spanusername").innerHTML = "<font size=2  color=#666699>欢迎您！<b>" + document.getElementById("txtusername").value + "</b></font>&nbsp;&nbsp;<a href='Parse/Index.aspx'><font color=blue size=2>管理中心</font></a>&nbsp;&nbsp;<a href='#' onclick='UserExit();'><font size=2 color=red>退出</font></a>";
                    document.getElementById("txtusername").value = "";
                    document.getElementById("txtpassword").value = "";
                    loginCancel();
                }
                else if (xmlhttpLogin.responseText == "error") {
                    document.getElementById("hiddenUsername").value = "";
                    document.getElementById("loader_container").style.display = "block";
                    document.getElementById("backimg").style.display = "block";
                    var bodySize = [];
                    with (document.documentElement) {
                        bodySize[0] = (scrollWidth > clientWidth) ? scrollWidth : clientWidth;
                        bodySize[1] = (scrollHeight > clientHeight) ? scrollHeight : clientHeight;
                    }
                    document.getElementById("backimg").style.width = bodySize[0] + "px";
                    document.getElementById("backimg").style.height = bodySize[1] + "px";

                    document.getElementById("txtusername").disabled = "";
                    document.getElementById("txtpassword").disabled = "";
                    document.getElementById("btnLogin").disabled = "";
                    document.getElementById("txtusername").focus();
                    document.getElementById("btnLogin").value = "登录";
                    alert("用户名或密码不正确，请核对后重新登录！");
                }
                else {
                    CheckLoginNamePwd();
                }
            }
        }
    }
    catch (e) {
        document.getElementById("hiddenUsername").value = "";
        document.getElementById("loader_container").style.display = "block";
        document.getElementById("backimg").style.display = "block";
        var bodySize = [];
        with (document.documentElement) {
            bodySize[0] = (scrollWidth > clientWidth) ? scrollWidth : clientWidth;
            bodySize[1] = (scrollHeight > clientHeight) ? scrollHeight : clientHeight;
        }
        document.getElementById("backimg").style.width = bodySize[0] + "px";
        document.getElementById("backimg").style.height = bodySize[1] + "px";

        document.getElementById("txtusername").disabled = "";
        document.getElementById("txtpassword").disabled = "";
        document.getElementById("btnLogin").disabled = "";
        document.getElementById("txtusername").focus();
        document.getElementById("btnLogin").value = "登录";
        alert("登录异常：" + e);
    }
}

var xmlhttpLoginOut; //用户退出
function UserExit() {
    try {
        xmlhttpLoginOut = createHttpRequest();
        var UrlStr = "SmsOnline/Index.aspx?ResponseUserExit=yes";
        xmlhttpLoginOut.onreadystatechange = processLoginOut;
        xmlhttpLoginOut.open("POST", UrlStr, true);
        xmlhttpLoginOut.setRequestHeader('Connection', 'close');
        xmlhttpLoginOut.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
        xmlhttpLoginOut.send(null);
    }
    catch (e) {
        alet("网络忙，请稍候重新退出！");
    }
}

function processLoginOut() {
    try {
        if (xmlhttpLoginOut.readyState == 4) {
            if (xmlhttpLoginOut.status == 200) {
                if (xmlhttpLoginOut.responseText == "exitok") {
                    document.getElementById("spanusername").innerHTML = "<a href=\"user/UserLogin.aspx\"><font size=2>登录</font></a>";
                    document.getElementById("hiddenUsername").value = "";
                }
                else {
                    UserExit();
                }
            }
        }
    }
    catch (e) {
        alet("网络忙，请稍候重新退出！");
    }
}


//js获取cookie
var acookie = document.cookie.split("; ");
function getcookie(sname) {//获取单个cookies
    for (var i = 0; i < acookie.length; i++) {
        var arr = acookie[i].split("=");
        if (sname == arr[0]) {
            if (arr.length > 1)
                return unescape(arr[1]);
            else
                return "";
        }
    }
    return "";
}

function getUserCookie() {
    var username = getcookie("cninterfaceusername");
    if (username != "") {
        document.getElementById("spanusername").innerHTML = "<font size=2  color=#666699>欢迎您！<b>" + username + "</b></font>&nbsp;&nbsp;<a href='#' onclick='UserExit();'><font size=2 color=red>退出</font></a>";
    }
}


function LoginOnkeydownEvent() {
    if (event.keyCode == 13) {
        document.getElementById("btnLogin").click();
    }
}

//div定位通用函数 (showname:需定位div ID，positionname：相对标签ID)
function showDivNameList(showname, positionname) {
    var cf = document.getElementById(showname);
    var oImg = document.getElementById(positionname);
    if (navigator.userAgent.indexOf("MSIE") <= 0) {
        var leftvalue = parseInt(document.body.scrollWidth) - (parseInt(document.body.scrollWidth) / 2 + 189);
        cf.style.left = leftvalue + "px";
        if (navigator.userAgent.indexOf("Chrome") > -1) {
            cf.style.left = (leftvalue - 6) + "px";
            cf.style.top ="205px";
        }
        if (navigator.userAgent.indexOf("Opera") > -1) {
            cf.style.top = "190px";
        }
    }
    else {
        var eT = 0, eL = 0, p = oImg;
        var sT = document.body.scrollTop, sL = document.body.scrollLeft;
        var eH = oImg.height + 25, eW = oImg.width;
        while (p && p.tagName != "BODY") { eT += p.offsetTop; eL += p.offsetLeft; p = p.offsetParent; }
        cf.style.top = ((document.body.clientHeight - (eT - sT) - eH >= cf.style.posHeight) ? (eT + eH) : (eT - cf.style.posHeight)) +210;
        cf.style.left = ((document.body.clientWidth - (eL - sL) >= cf.style.posWidth) ? (eL + eW) : (eL - cf.style.posWidth)) + 10;
        if (navigator.userAgent.indexOf("MSIE 8.0")>0) {
            cf.style.top = ((document.body.clientHeight - (eT - sT) - eH >= cf.style.posHeight) ? (eT + eH) : (eT - cf.style.posHeight)) +195;
            cf.style.left = ((document.body.clientWidth - (eL - sL) >= cf.style.posWidth) ? (eL + eW) : (eL - cf.style.posWidth));
        }
    }
}
var xmlhttpGetNameList; //查询提示列表
function GetNameList() {
    try {
        if (document.getElementById("hiddenchangestatu").value == "1") {
            return;
        }
        if(document.getElementById("txtInterfaceName").value=="" ||  document.getElementById("txtInterfaceName").value.indexOf("--") > -1 || document.getElementById("txtInterfaceName").value.indexOf("<") > -1 || document.getElementById("txtInterfaceName").value.indexOf("'") > -1 || document.getElementById("txtInterfaceName").value.indexOf(">") > -1)
        {
            document.getElementById("divlikeselectresultlist").style.display = "none";
            document.getElementById("divlikeselectresultlist").innerHTML = "";
            return;
        }
        if (navigator.userAgent.indexOf("MSIE") > 0) {
            event.cancelBubble = true;
        }
        xmlhttpGetNameList = createHttpRequest();
        var UrlStr = "Index.aspx?ResponseGetNameList="+escape(document.getElementById("txtInterfaceName").value.replace(/^\s\s*/, '').replace(/\s\s*$/, ''));
        xmlhttpGetNameList.onreadystatechange = processGetNameList;
        xmlhttpGetNameList.open("POST", UrlStr, true);
        xmlhttpGetNameList.setRequestHeader('Connection', 'close');
        xmlhttpGetNameList.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
        xmlhttpGetNameList.send(null);
    }
    catch (e) {
        //alert(e);
        document.getElementById("divlikeselectresultlist").style.display = "none";
        document.getElementById("divlikeselectresultlist").innerHTML = "";
    }
}
xmlhttpGetNameList
function processGetNameList() {
    try {
        if (xmlhttpGetNameList.readyState == 4) {
            if (xmlhttpGetNameList.status == 200) {
                if (xmlhttpGetNameList.responseText != "0") {
                    showDivNameList("divlikeselectresultlist","txtInterfaceName"); 
                    document.getElementById("divlikeselectresultlist").style.display="block"; 
                    document.getElementById("divlikeselectresultlist").innerHTML = xmlhttpGetNameList.responseText;
                    document.getElementById("hiddennewnamelist").value = "new";
                    if (navigator.userAgent.indexOf("MSIE") <= 0) {
                        document.getElementById("divlikeselectresultlist").style.height = "170px";
                    }
                    if (navigator.userAgent.indexOf("MSIE 8.0")>0) {
                        document.getElementById("divlikeselectresultlist").style.height = "170px";
                    }
                }
                else {
                    document.getElementById("divlikeselectresultlist").style.display = "none";
                    document.getElementById("divlikeselectresultlist").innerHTML = "";
                }
            }
        }
    }
    catch (e) {
        //alert(e);
        document.getElementById("divlikeselectresultlist").style.display = "none";
        document.getElementById("divlikeselectresultlist").innerHTML = "";
    }
}

 function hiddenNamelist() {
     document.getElementById("divlikeselectresultlist").style.display = "none";
     document.getElementById("divshowintervideos").style.display = "none";
    }

function trOnmouseOver(id)
{
    document.getElementById(id).style.backgroundColor = "#d4d4d4";//多余代码
    if (navigator.userAgent.indexOf("MSIE") > 0) {
        document.getElementById("hiddenchangestatu").value = "1";
        document.getElementById("txtInterfaceName").value = document.getElementById(id).firstChild.innerText;
    }
    else {
        document.getElementById("hiddenchangestatu").value = "1";
        document.getElementById("txtInterfaceName").value = document.getElementById(id).firstChild.textContent;
    }
    var count = parseInt(document.getElementById("hiddennamecount").value);
    var start = parseInt(id.replace("TrNumber", ""));
    for (var i = 0; i < count; i++) {
        if (i == start) {
            document.getElementById("TrNumber" + i).style.backgroundColor = "#d4d4d4";
        }
        else {
            document.getElementById("TrNumber" + i).style.backgroundColor = "#ffffff";
        }
    }
}
function trOnmouseOut(id)
{
    document.getElementById(id).style.backgroundColor = "#ffffff";
    document.getElementById("hiddenchangestatu").value = "0";
}
function tdOnclick(id) {
    document.getElementById("hiddenchangestatu").value = "1";
    if (navigator.userAgent.indexOf("MSIE") > 0) {
        document.getElementById("txtInterfaceName").value = document.getElementById(id).innerText;
    }
    else {
        document.getElementById("txtInterfaceName").value = document.getElementById(id).textContent;
    }
    document.getElementById("divlikeselectresultlist").style.display = "none";
    document.getElementById("divlikeselectresultlist").innerHTML = "";
    document.getElementById("bntInterfaceSelect").click();
}
document.onkeydown = onkeydownlogic;
var begin = -1;
function onkeydownlogic(e) {
    var e = e || event;
    var currKey = e.keyCode || e.which || e.charCode;
    //alert(currKey);return;
    if (document.getElementById("divlikeselectresultlist").style.display == "block" && (currKey == "38" || currKey == "40")) {
        var count = parseInt(document.getElementById("hiddennamecount").value);
        if (document.getElementById("hiddennewnamelist").value == "new") {
            begin = -1;
            document.getElementById("hiddennewnamelist").value ="old";
        }
        if (currKey == "38") {
            if (begin <= 0) {
                begin = count - 1;
            }
            else {
                begin = begin - 1;
            }
        }
        if (currKey == "40") {
            if (begin == count - 1) {
                begin = 0;
            }
            else {
                begin = begin + 1;
            }
        }

        for (var i = 0; i < count; i++) {
            if (i == begin) {
                document.getElementById("TrNumber" + i).style.backgroundColor = "#d4d4d4";
            }
            else {
                document.getElementById("TrNumber" + i).style.backgroundColor = "#ffffff";
            }
        }
        if (navigator.userAgent.indexOf("MSIE") > 0) {
            document.getElementById("hiddenchangestatu").value = "1";
            document.getElementById("txtInterfaceName").value = document.getElementById("TrNumber" + begin).firstChild.innerText;
        }
        else {
            document.getElementById("hiddenchangestatu").value = "1";
            document.getElementById("txtInterfaceName").value = document.getElementById("TrNumber" + begin).firstChild.textContent;
        }
    }
    else {
        document.getElementById("hiddenchangestatu").value = "0";
    }
}
//窗口或框架被调整尺寸
function setdivresultlist() {
    if (document.getElementById("divlikeselectresultlist").style.display == "block") {
        showDivNameList("divlikeselectresultlist", "txtInterfaceName"); 
    }
     if (document.getElementById("divshowintervideos").style.display == "block") {
       showshowintervideos("divshowintervideos", "txtInterfaceName");
     }
}



