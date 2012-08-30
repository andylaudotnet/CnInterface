
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

var xmlhttpSina;
function GetSinaData() {
    try {
        document.getElementById("tdSinaNews").innerHTML = "<b><a href=\"http://www.sina.com.cn/\" target=\"_blank\"><font color=green>新浪</font></a>新闻：</b><br/><img alt=\"请等待\"  src=\"../img/clocks.gif\"/><font  color=#666699>读取中</font>";
        xmlhttpSina = createHttpRequest();
        var UrlStr = "WebNews.aspx?webname=sina";
        xmlhttpSina.onreadystatechange = processSina;
        xmlhttpSina.open("POST", UrlStr, true);
        xmlhttpSina.setRequestHeader('Connection', 'close');
        xmlhttpSina.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
        xmlhttpSina.send(null);
    }
    catch (e) {
        document.getElementById("tdSinaNews").innerHTML = e;
    }
}
function processSina() {
    try {
        if (xmlhttpSina.readyState == 4) {
            if (xmlhttpSina.status == 200) {
                if (xmlhttpSina.responseText != "") {
                    document.getElementById("tdSinaNews").innerHTML = xmlhttpSina.responseText;
                }
            }
        }
    }
    catch (e) {
        document.getElementById("tdSinaNews").innerHTML = e;
    }
}

var xmlhttpSohu;
function GetSohuData() {
    try {
        document.getElementById("tdSohuNews").innerHTML = "<b><a href=\"http://www.sohu.com/\" target=\"_blank\"><font color=green>搜狐</font></a>新闻：</b><br/><img alt=\"请等待\"  src=\"../img/clocks.gif\"/><font  color=#666699>读取中</font>";
        xmlhttpSohu = createHttpRequest();
        var UrlStr = "WebNews.aspx?webname=sohu";
        xmlhttpSohu.onreadystatechange = processSohu;
        xmlhttpSohu.open("POST", UrlStr, true);
        xmlhttpSohu.setRequestHeader('Connection', 'close');
        xmlhttpSohu.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
        xmlhttpSohu.send(null);
    }
    catch (e) {
        document.getElementById("tdSohuNews").innerHTML = e;
    }
}
function processSohu() {
    try {
        if (xmlhttpSohu.readyState == 4) {
            if (xmlhttpSohu.status == 200) {
                if (xmlhttpSohu.responseText != "") {
                    document.getElementById("tdSohuNews").innerHTML = xmlhttpSohu.responseText;
                }
            }
        }
    }
    catch (e) {
        document.getElementById("tdSohuNews").innerHTML = e;
    }
}

var xmlhttpTom;
function GetTomData() {
    try {
        document.getElementById("tdTomNews").innerHTML = "<b><a href=\"http://www.tom.com/\" target=\"_blank\"><font color=green>TOM</font></a>新闻：</b><br/><img alt=\"请等待\"  src=\"../img/clocks.gif\"/><font  color=#666699>读取中</font>";
        xmlhttpTom = createHttpRequest();
        var UrlStr = "WebNews.aspx?webname=tom";
        xmlhttpTom.onreadystatechange = processTom;
        xmlhttpTom.open("POST", UrlStr, true);
        xmlhttpTom.setRequestHeader('Connection', 'close');
        xmlhttpTom.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
        xmlhttpTom.send(null);
    }
    catch (e) {
        document.getElementById("tdTomNews").innerHTML = e;
    }
}
function processTom() {
    try {
        if (xmlhttpTom.readyState == 4) {
            if (xmlhttpTom.status == 200) {
                if (xmlhttpTom.responseText != "") {
                    document.getElementById("tdTomNews").innerHTML = xmlhttpTom.responseText;
                }
            }
        }
    }
    catch (e) {
        document.getElementById("tdTomNews").innerHTML = e;
    }
}

var xmlhttpYahoo;
function GetYahooData() {
    try {
        document.getElementById("tdYahooNews").innerHTML = "<b><a href=\"http://news.cn.yahoo.com/\" target=\"_blank\"><font color=green>雅虎</font></a>新闻：</b><br/><img alt=\"请等待\"  src=\"../img/clocks.gif\"/><font  color=#666699>读取中</font>";
        xmlhttpYahoo = createHttpRequest();
        var UrlStr = "WebNews.aspx?webname=yahoo";
        xmlhttpYahoo.onreadystatechange = processYahoo;
        xmlhttpYahoo.open("POST", UrlStr, true);
        xmlhttpYahoo.setRequestHeader('Connection', 'close');
        xmlhttpYahoo.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
        xmlhttpYahoo.send(null);
    }
    catch (e) {
        document.getElementById("tdYahooNews").innerHTML = e;
    }
}
function processYahoo() {
    try {
        if (xmlhttpYahoo.readyState == 4) {
            if (xmlhttpYahoo.status == 200) {
                if (xmlhttpYahoo.responseText != "") {
                    document.getElementById("tdYahooNews").innerHTML = xmlhttpYahoo.responseText;
                }
            }
        }
    }
    catch (e) {
        document.getElementById("tdYahooNews").innerHTML = e;
    }
}

var xmlhttpBaidu;
function GetBaiduData() {
    try {
        document.getElementById("tdBaiduNews").innerHTML = "<b><a href=\"http://news.baidu.com/\" target=\"_blank\"><font color=green>百度</font></a>新闻：</b><br/><img alt=\"请等待\"  src=\"../img/clocks.gif\"/><font  color=#666699>读取中</font>";
        xmlhttpBaidu = createHttpRequest();
        var UrlStr = "WebNews.aspx?webname=baidu";
        xmlhttpBaidu.onreadystatechange = processBaidu;
        xmlhttpBaidu.open("POST", UrlStr, true);
        xmlhttpBaidu.setRequestHeader('Connection', 'close');
        xmlhttpBaidu.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
        xmlhttpBaidu.send(null);
    }
    catch (e) {
        document.getElementById("tdBaiduNews").innerHTML = e;
    }
}
function processBaidu() {
    try {
        if (xmlhttpBaidu.readyState == 4) {
            if (xmlhttpBaidu.status == 200) {
                if (xmlhttpBaidu.responseText != "") {
                    document.getElementById("tdBaiduNews").innerHTML = xmlhttpBaidu.responseText;
                }
            }
        }
    }
    catch (e) {
        document.getElementById("tdBaiduNews").innerHTML = e;
    }
}

var xmlhttp163;
function Get163Data() {
    try {
        document.getElementById("td163News").innerHTML = "<b><a href=\"http://www.163.com/\" target=\"_blank\"><font color=green>网易</font></a>新闻：</b><br/><img alt=\"请等待\"  src=\"../img/clocks.gif\"/><font  color=#666699>读取中</font>";
        xmlhttp163 = createHttpRequest();
        var UrlStr = "WebNews.aspx?webname=163";
        xmlhttp163.onreadystatechange = process163;
        xmlhttp163.open("POST", UrlStr, true);
        xmlhttp163.setRequestHeader('Connection', 'close');
        xmlhttp163.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
        xmlhttp163.send(null);
    }
    catch (e) {
        document.getElementById("td163News").innerHTML = e;
    }
}
function process163() {
    try {
        if (xmlhttp163.readyState == 4) {
            if (xmlhttp163.status == 200) {
                if (xmlhttp163.responseText != "") {
                    document.getElementById("td163News").innerHTML = xmlhttp163.responseText;
                }
            }
        }
    }
    catch (e) {
        document.getElementById("td163News").innerHTML = e;
    }
}

function LoadAllNews() {
    GetSinaData();
    GetSohuData();
    GetTomData();
    GetYahooData();
    GetBaiduData();
    Get163Data();
}