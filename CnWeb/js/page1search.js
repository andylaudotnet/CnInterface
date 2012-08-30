//page1search选择显示逻辑
function setSelectList(id) {
    var showname = "";
    switch (id) {
        case "aall":
            showname = "全部";
            document.getElementById("abaidu").innerHTML = "<font size=2  color='#666699'>百度</font>";
            document.getElementById("agoogle").innerHTML = "<font size=2  color='#666699'>Google</font>";
            document.getElementById("ayahoo").innerHTML = "<font size=2  color='#666699'>雅虎</font>";
            document.getElementById("abing").innerHTML = "<font size=2  color='#666699'>Bing</font>";
            document.getElementById("asogou").innerHTML = "<font size=2  color='#666699'>搜狗</font>";
            document.getElementById("asoso").innerHTML = "<font size=2  color='#666699'>搜搜</font>";
            document.getElementById("ayoudao").innerHTML = "<font size=2  color='#666699'>有道</font>";
            break;
        case "abaidu":
            showname = "百度";
            document.getElementById("aall").innerHTML = "<font size=2  color='#666699'>全部</font>";
            document.getElementById("agoogle").innerHTML = "<font size=2  color='#666699'>Google</font>";
            document.getElementById("ayahoo").innerHTML = "<font size=2  color='#666699'>雅虎</font>";
            document.getElementById("abing").innerHTML = "<font size=2  color='#666699'>Bing</font>";
            document.getElementById("asogou").innerHTML = "<font size=2  color='#666699'>搜狗</font>";
            document.getElementById("asoso").innerHTML = "<font size=2  color='#666699'>搜搜</font>";
            document.getElementById("ayoudao").innerHTML = "<font size=2  color='#666699'>有道</font>";
            break;
        case "agoogle":
            showname = "Google";
            document.getElementById("abaidu").innerHTML = "<font size=2  color='#666699'>百度</font>";
            document.getElementById("aall").innerHTML = "<font size=2  color='#666699'>全部</font>";
            document.getElementById("ayahoo").innerHTML = "<font size=2  color='#666699'>雅虎</font>";
            document.getElementById("abing").innerHTML = "<font size=2  color='#666699'>Bing</font>";
            document.getElementById("asogou").innerHTML = "<font size=2  color='#666699'>搜狗</font>";
            document.getElementById("asoso").innerHTML = "<font size=2  color='#666699'>搜搜</font>";
            document.getElementById("ayoudao").innerHTML = "<font size=2  color='#666699'>有道</font>";
            break;
        case "ayahoo":
            showname = "雅虎";
            document.getElementById("abaidu").innerHTML = "<font size=2  color='#666699'>百度</font>";
            document.getElementById("agoogle").innerHTML = "<font size=2  color='#666699'>Google</font>";
            document.getElementById("aall").innerHTML = "<font size=2  color='#666699'>全部</font>";
            document.getElementById("abing").innerHTML = "<font size=2  color='#666699'>Bing</font>";
            document.getElementById("asogou").innerHTML = "<font size=2  color='#666699'>搜狗</font>";
            document.getElementById("asoso").innerHTML = "<font size=2  color='#666699'>搜搜</font>";
            document.getElementById("ayoudao").innerHTML = "<font size=2  color='#666699'>有道</font>";
            break;
        case "abing":
            showname = "Bing";
            document.getElementById("abaidu").innerHTML = "<font size=2  color='#666699'>百度</font>";
            document.getElementById("agoogle").innerHTML = "<font size=2  color='#666699'>Google</font>";
            document.getElementById("ayahoo").innerHTML = "<font size=2  color='#666699'>雅虎</font>";
            document.getElementById("aall").innerHTML = "<font size=2  color='#666699'>全部</font>";
            document.getElementById("asogou").innerHTML = "<font size=2  color='#666699'>搜狗</font>";
            document.getElementById("asoso").innerHTML = "<font size=2  color='#666699'>搜搜</font>";
            document.getElementById("ayoudao").innerHTML = "<font size=2  color='#666699'>有道</font>";
            break;
        case "asogou":
            showname = "搜狗";
            document.getElementById("abaidu").innerHTML = "<font size=2  color='#666699'>百度</font>";
            document.getElementById("agoogle").innerHTML = "<font size=2  color='#666699'>Google</font>";
            document.getElementById("ayahoo").innerHTML = "<font size=2  color='#666699'>雅虎</font>";
            document.getElementById("abing").innerHTML = "<font size=2  color='#666699'>Bing</font>";
            document.getElementById("aall").innerHTML = "<font size=2  color='#666699'>全部</font>";
            document.getElementById("asoso").innerHTML = "<font size=2  color='#666699'>搜搜</font>";
            document.getElementById("ayoudao").innerHTML = "<font size=2  color='#666699'>有道</font>";
            break;
        case "asoso":
            showname = "搜搜";
            document.getElementById("abaidu").innerHTML = "<font size=2  color='#666699'>百度</font>";
            document.getElementById("agoogle").innerHTML = "<font size=2  color='#666699'>Google</font>";
            document.getElementById("ayahoo").innerHTML = "<font size=2  color='#666699'>雅虎</font>";
            document.getElementById("abing").innerHTML = "<font size=2  color='#666699'>Bing</font>";
            document.getElementById("asogou").innerHTML = "<font size=2  color='#666699'>搜狗</font>";
            document.getElementById("aall").innerHTML = "<font size=2  color='#666699'>全部</font>";
            document.getElementById("ayoudao").innerHTML = "<font size=2  color='#666699'>有道</font>";
            break;
        case "ayoudao":
            showname = "有道";
            document.getElementById("abaidu").innerHTML = "<font size=2  color='#666699'>百度</font>";
            document.getElementById("agoogle").innerHTML = "<font size=2  color='#666699'>Google</font>";
            document.getElementById("ayahoo").innerHTML = "<font size=2  color='#666699'>雅虎</font>";
            document.getElementById("abing").innerHTML = "<font size=2  color='#666699'>Bing</font>";
            document.getElementById("asogou").innerHTML = "<font size=2  color='#666699'>搜狗</font>";
            document.getElementById("asoso").innerHTML = "<font size=2  color='#666699'>搜搜</font>";
            document.getElementById("aall").innerHTML = "<font size=2  color='#666699'>全部</font>";
            break;
        default:
            showname = "全部";
            document.getElementById("abaidu").innerHTML = "<font size=2  color='#666699'>百度</font>";
            document.getElementById("agoogle").innerHTML = "<font size=2  color='#666699'>Google</font>";
            document.getElementById("ayahoo").innerHTML = "<font size=2  color='#666699'>雅虎</font>";
            document.getElementById("abing").innerHTML = "<font size=2  color='#666699'>Bing</font>";
            document.getElementById("asogou").innerHTML = "<font size=2  color='#666699'>搜狗</font>";
            document.getElementById("asoso").innerHTML = "<font size=2  color='#666699'>搜搜</font>";
            document.getElementById("ayoudao").innerHTML = "<font size=2  color='#666699'>有道</font>";
            break;
    }
    document.getElementById(id).innerHTML = "<font size=2 color=\"#003399\"><b>" + showname + "</b></font>";
    //document.getElementById(id).style.textDecoration = "none";
    document.getElementById("hiddenwebName").value = id;
    document.getElementById("txtSearchWord").focus();
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

function checksearchword() {
    if (document.getElementById("txtSearchWord").value == "") {
        document.getElementById("txtSearchWord").focus();
        return false;
    }
    return true;
}
