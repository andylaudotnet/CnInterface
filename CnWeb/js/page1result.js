
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

var xmlhttpBaidu;
function GetBaiduData() {
    try {
        document.getElementById("spanbaidu").innerHTML = "<br/><img alt=\"请等待\" height=\"18\" src=\"img/clocks.gif\"/><font  color=#666699>读取中</font>";
        xmlhttpBaidu = createHttpRequest();
        var UrlStr = "Page1Result.aspx?webname=baidu&word="+escape(document.getElementById("hiddengb2312").value);
        xmlhttpBaidu.onreadystatechange = processBaidu;
        xmlhttpBaidu.open("POST", UrlStr, true);
        xmlhttpBaidu.setRequestHeader('Connection', 'close');
        xmlhttpBaidu.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
        xmlhttpBaidu.send(null);
    }
    catch (e) {
        document.getElementById("divbaidu").innerHTML = e;
        document.getElementById("divbaidu").style.display = "none";
    }
}
function processBaidu() {
    try {
        if (xmlhttpBaidu.readyState == 4) {
            if (xmlhttpBaidu.status == 200) {
                if(xmlhttpBaidu.responseText!="")
                {
                    document.getElementById("divbaidu").innerHTML =xmlhttpBaidu.responseText;
                    document.getElementById("spanbaidu").innerHTML = "<br/><font  color=#666699>已显示</font>";
                    document.getElementById('divbaidu').style.display = 'block';
                }
            }
        }
    }
    catch (e) {
        document.getElementById("divbaidu").innerHTML = e;
        document.getElementById("divbaidu").style.display = "none";
    }
}

var xmlhttpGoogle;
function GetGoogleData() {
    try {
        document.getElementById("spangoogle").innerHTML = "<br/><img alt=\"请等待\" height=\"18\" src=\"img/clocks.gif\"/><font  color=#666699>读取中</font>";
        xmlhttpGoogle = createHttpRequest();
        var UrlStr = "Page1Result.aspx?webname=google&word=" + escape(document.getElementById("hiddenutf8").value);
        xmlhttpGoogle.onreadystatechange = processGoogle;
        xmlhttpGoogle.open("POST", UrlStr, true);
        xmlhttpGoogle.setRequestHeader('Connection', 'close');
        xmlhttpGoogle.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
        xmlhttpGoogle.send(null);
    }
    catch (e) {
        document.getElementById("divgoogle").innerHTML = e;
        document.getElementById("divgoogle").style.display = "none";
    }
}
function processGoogle() {
    try {
        if (xmlhttpGoogle.readyState == 4) {
            if (xmlhttpGoogle.status == 200) {
                    document.getElementById("divgoogle").innerHTML =xmlhttpGoogle.responseText;
                    document.getElementById("spangoogle").innerHTML = "<br/><font  color=green>查看</font>";
                    if (document.getElementById("hiddenwebName").value != "aall") {
                        document.getElementById("spangoogle").innerHTML = "<br/><font  color=#666699>已显示</font>";
                        document.getElementById('divgoogle').style.display = 'block';
                    }
            }
        }
    }
    catch (e) {
        document.getElementById("divgoogle").innerHTML = e;
        document.getElementById("divgoogle").style.display = "none";
    }
}

var xmlhttpYahoo;
function GetYahooData() {
    try {
        document.getElementById("spanyahoo").innerHTML = "<br/><img alt=\"请等待\" height=\"18\" src=\"img/clocks.gif\"/><font  color=#666699>读取中</font>";
        xmlhttpYahoo = createHttpRequest();
        var UrlStr = "Page1Result.aspx?webname=yahoo&word="+escape(document.getElementById("hiddenutf8").value);
        xmlhttpYahoo.onreadystatechange = processYahoo;
        xmlhttpYahoo.open("POST", UrlStr, true);
        xmlhttpYahoo.setRequestHeader('Connection', 'close');
        xmlhttpYahoo.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
        xmlhttpYahoo.send(null);
    }
    catch (e) {
        document.getElementById("divyahoo").innerHTML = e;
        document.getElementById("divyahoo").style.display = "none";
    }
}
function processYahoo() {
    try {
        if (xmlhttpYahoo.readyState == 4) {
            if (xmlhttpYahoo.status == 200) {
                    document.getElementById("divyahoo").innerHTML =xmlhttpYahoo.responseText;
                    document.getElementById("spanyahoo").innerHTML = "<br/><font  color=green>查看</font>";
                    if (document.getElementById("hiddenwebName").value != "aall") {
                        document.getElementById("spanyahoo").innerHTML = "<br/><font  color=#666699>已显示</font>";
                        document.getElementById('divyahoo').style.display = 'block';
                    }
            }
        }
    }
    catch (e) {
        document.getElementById("divyahoo").innerHTML = e;
        document.getElementById("divyahoo").style.display = "none";
    }
}

var xmlhttpBing;
function GetBingData() {
    try {
        document.getElementById("spanbing").innerHTML = "<br/><img alt=\"请等待\" height=\"18\" src=\"img/clocks.gif\"/><font  color=#666699>读取中</font>";
        xmlhttpBing = createHttpRequest();
        var UrlStr = "Page1Result.aspx?webname=bing&word=" + escape(document.getElementById("hiddenutf8").value);
        xmlhttpBing.onreadystatechange = processBing;
        xmlhttpBing.open("POST", UrlStr, true);
        xmlhttpBing.setRequestHeader('Connection', 'close');
        xmlhttpBing.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
        xmlhttpBing.send(null);
    }
    catch (e) {
        document.getElementById("divbing").innerHTML = e;
        document.getElementById("divbing").style.display = "none";
    }
}
function processBing() {
    try {
        if (xmlhttpBing.readyState == 4) {
            if (xmlhttpBing.status == 200) {
                    document.getElementById("divbing").innerHTML =xmlhttpBing.responseText;
                    document.getElementById("spanbing").innerHTML = "<br/><font  color=green>查看</font>";
                    if (document.getElementById("hiddenwebName").value != "aall") {
                        document.getElementById("spanbing").innerHTML = "<br/><font  color=#666699>已显示</font>";
                        document.getElementById('divbing').style.display = 'block';
                    }
            }
        }
    }
    catch (e) {
        document.getElementById("divbing").innerHTML = e;
        document.getElementById("divbing").style.display = "none";
    }
}

var xmlhttpSogou;
function GetSogouData() {
    try {
        document.getElementById("spansogou").innerHTML = "<br/><img alt=\"请等待\" height=\"18\" src=\"img/clocks.gif\"/><font  color=#666699>读取中</font>";
        xmlhttpSogou = createHttpRequest();
        var UrlStr = "Page1Result.aspx?webname=sogou&word="+escape(document.getElementById("hiddengb2312").value);
        xmlhttpSogou.onreadystatechange = processSogou;
        xmlhttpSogou.open("POST", UrlStr, true);
        xmlhttpSogou.setRequestHeader('Connection', 'close');
        xmlhttpSogou.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
        xmlhttpSogou.send(null);
    }
    catch (e) {
        document.getElementById("divsogou").innerHTML = e;
        document.getElementById("divsogou").style.display = "none";
    }
}
function processSogou() {
    try {
        if (xmlhttpSogou.readyState == 4) {
            if (xmlhttpSogou.status == 200) {
                    document.getElementById("divsogou").innerHTML =xmlhttpSogou.responseText;
                    document.getElementById("spansogou").innerHTML = "<br/><font  color=green>查看</font>";
                    if (document.getElementById("hiddenwebName").value != "aall") {
                        document.getElementById("spansogou").innerHTML = "<br/><font  color=#666699>已显示</font>";
                        document.getElementById('divsogou').style.display = 'block';
                    }
            }
        }
    }
    catch (e) {
        document.getElementById("divsogou").innerHTML = e;
        document.getElementById("divsogou").style.display = "none";
    }
}

var xmlhttpSoso;
function GetSosoData() {
    try {
        document.getElementById("spansoso").innerHTML = "<br/><img alt=\"请等待\" height=\"18\" src=\"img/clocks.gif\"/><font  color=#666699>读取中</font>";
        xmlhttpSoso = createHttpRequest();
        var UrlStr = "Page1Result.aspx?webname=soso&word="+escape(document.getElementById("hiddengb2312").value);
        xmlhttpSoso.onreadystatechange = processSoso;
        xmlhttpSoso.open("POST", UrlStr, true);
        xmlhttpSoso.setRequestHeader('Connection', 'close');
        xmlhttpSoso.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
        xmlhttpSoso.send(null);
    }
    catch (e) {
        document.getElementById("divsoso").innerHTML = e;
        document.getElementById("divsoso").style.display = "none";
    }
}
function processSoso() {
    try {
        if (xmlhttpSoso.readyState == 4) {
            if (xmlhttpSoso.status == 200) {
                    document.getElementById("divsoso").innerHTML =xmlhttpSoso.responseText;
                    document.getElementById("spansoso").innerHTML = "<br/><font  color=green>查看</font>";
                    if (document.getElementById("hiddenwebName").value != "aall") {
                        document.getElementById("spansoso").innerHTML = "<br/><font  color=#666699>已显示</font>";
                        document.getElementById('divsoso').style.display = 'block';
                    }
            }
        }
    }
    catch (e) {
        document.getElementById("divsoso").innerHTML = e;
        document.getElementById("divsoso").style.display = "none";
    }
}

var xmlhttpYoudao;
function GetYoudaoData() {
    try {
        document.getElementById("spanyoudao").innerHTML ="<br/><img alt=\"请等待\" height=\"18\" src=\"img/clocks.gif\"/><font  color=#666699>读取中</font>";
        xmlhttpYoudao = createHttpRequest();
        var UrlStr = "Page1Result.aspx?webname=youdao&word="+escape(document.getElementById("hiddenutf8").value);
        xmlhttpYoudao.onreadystatechange = processYoudao;
        xmlhttpYoudao.open("POST", UrlStr, true);
        xmlhttpYoudao.setRequestHeader('Connection', 'close');
        xmlhttpYoudao.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
        xmlhttpYoudao.send(null);
    }
    catch (e) {
        document.getElementById("divyoudao").innerHTML = e;
        document.getElementById("divyoudao").style.display = "none";
    }
}
function processYoudao() {
    try {
        if (xmlhttpYoudao.readyState == 4) {
            if (xmlhttpYoudao.status == 200) {
                    document.getElementById("divyoudao").innerHTML =xmlhttpYoudao.responseText;
                    document.getElementById("spanyoudao").innerHTML = "<br/><font  color=green>查看</font>";
                    if (document.getElementById("hiddenwebName").value != "aall") {
                        document.getElementById("spanyoudao").innerHTML = "<br/><font  color=#666699>已显示</font>";
                        document.getElementById('divyoudao').style.display = 'block';
                    }
            }
        }
    }
    catch (e) {
        document.getElementById("divyoudao").innerHTML = e;
        document.getElementById("divyoudao").style.display = "none";
    }
}


function LoadAllData() {
    switch(document.getElementById("hiddenwebName").value)
    {
        case "aall":
            try {
                GetBaiduData();
            } catch (e) { }
            try {
                GetGoogleData();
            } catch (e) { }
            try {
                GetYahooData();
            } catch (e) { }
            try {
                GetBingData();
            } catch (e) { }
            try {
                GetSogouData();
            } catch (e) { }
            try {
                GetSosoData();
            } catch (e) { }
            try {
                GetYoudaoData();
            } catch (e) { }
            break;
        case "abaidu":
            try {
                GetBaiduData();
            } catch (e) { }
            break;
        case "agoogle":
            try {
                GetGoogleData();
            } catch (e) { }
            break;
        case "ayahoo":
            try {
                GetYahooData();
            } catch (e) { }
            break;
        case "abing":
            try {
                GetBingData();
            } catch (e) { }
            break;
        case "asogou":
            try {
                GetSogouData();
            } catch (e) { }
            break;
        case "asoso":
            try {
                GetSosoData();
            } catch (e) { }
            break;
        case "ayoudao":
            try {
                GetYoudaoData();
            } catch (e) { }
            break;
        default:
            try {
                GetBaiduData();
            } catch (e) { }
            try {
                GetGoogleData();
            } catch (e) { }
            try {
                GetYahooData();
            } catch (e) { }
            try {
                GetBingData();
            } catch (e) { }
            try {
                GetSogouData();
            } catch (e) { }
            try {
                GetSosoData();
            } catch (e) { }
            try {
                GetYoudaoData();
            } catch (e) { }
            break;
    }
}

function controlwebdatashow(id) {
    if (document.getElementById(id).innerHTML.indexOf("查看") > -1) {
        switch (id) {
            case "spanbaidu":
                if (document.getElementById("divbaidu").style.display == "none") {
                    document.getElementById("divbaidu").style.display = "block";
                    document.getElementById("spanbaidu").innerHTML = "<br/><font  color=#666699>已显示</font>";
                }
                if (document.getElementById("divgoogle").style.display == "block") {
                    document.getElementById("divgoogle").style.display = "none";
                    document.getElementById("spangoogle").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divyahoo").style.display == "block") {
                    document.getElementById("divyahoo").style.display = "none";
                    document.getElementById("spanyahoo").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divbing").style.display == "block") {
                    document.getElementById("divbing").style.display = "none";
                    document.getElementById("spanbing").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divsogou").style.display == "block") {
                    document.getElementById("divsogou").style.display = "none";
                    document.getElementById("spansogou").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divsoso").style.display == "block") {
                    document.getElementById("divsoso").style.display = "none";
                    document.getElementById("spansoso").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divyoudao").style.display == "block") {
                    document.getElementById("divyoudao").style.display = "none";
                    document.getElementById("spanyoudao").innerHTML = "<br/><font  color=green>查看</font>";
                }
                break;
            case "spangoogle":
                if (document.getElementById("divbaidu").style.display == "block") {
                    document.getElementById("divbaidu").style.display = "none";
                    document.getElementById("spanbaidu").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divgoogle").style.display == "none") {
                    document.getElementById("divgoogle").style.display = "block";
                    document.getElementById("spangoogle").innerHTML = "<br/><font  color=#666699>已显示</font>";
                }
                if (document.getElementById("divyahoo").style.display == "block") {
                    document.getElementById("divyahoo").style.display = "none";
                    document.getElementById("spanyahoo").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divbing").style.display == "block") {
                    document.getElementById("divbing").style.display = "none";
                    document.getElementById("spanbing").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divsogou").style.display == "block") {
                    document.getElementById("divsogou").style.display = "none";
                    document.getElementById("spansogou").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divsoso").style.display == "block") {
                    document.getElementById("divsoso").style.display = "none";
                    document.getElementById("spansoso").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divyoudao").style.display == "block") {
                    document.getElementById("divyoudao").style.display = "none";
                    document.getElementById("spanyoudao").innerHTML = "<br/><font  color=green>查看</font>";
                }
                break;
            case "spanyahoo":
                if (document.getElementById("divbaidu").style.display == "block") {
                    document.getElementById("divbaidu").style.display = "none";
                    document.getElementById("spanbaidu").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divgoogle").style.display == "block") {
                    document.getElementById("divgoogle").style.display = "none";
                    document.getElementById("spangoogle").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divyahoo").style.display == "none") {
                    document.getElementById("divyahoo").style.display = "block";
                    document.getElementById("spanyahoo").innerHTML = "<br/><font  color=#666699>已显示</font>";
                }
                if (document.getElementById("divbing").style.display == "block") {
                    document.getElementById("divbing").style.display = "none";
                    document.getElementById("spanbing").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divsogou").style.display == "block") {
                    document.getElementById("divsogou").style.display = "none";
                    document.getElementById("spansogou").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divsoso").style.display == "block") {
                    document.getElementById("divsoso").style.display = "none";
                    document.getElementById("spansoso").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divyoudao").style.display == "block") {
                    document.getElementById("divyoudao").style.display = "none";
                    document.getElementById("spanyoudao").innerHTML = "<br/><font  color=green>查看</font>";
                }
                break;
            case "spanbing":
                if (document.getElementById("divbaidu").style.display == "block") {
                    document.getElementById("divbaidu").style.display = "none";
                    document.getElementById("spanbaidu").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divgoogle").style.display == "block") {
                    document.getElementById("divgoogle").style.display = "none";
                    document.getElementById("spangoogle").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divyahoo").style.display == "block") {
                    document.getElementById("divyahoo").style.display = "none";
                    document.getElementById("spanyahoo").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divbing").style.display == "none") {
                    document.getElementById("divbing").style.display = "block";
                    document.getElementById("spanbing").innerHTML = "<br/><font  color=#666699>已显示</font>";
                }
                if (document.getElementById("divsogou").style.display == "block") {
                    document.getElementById("divsogou").style.display = "none";
                    document.getElementById("spansogou").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divsoso").style.display == "block") {
                    document.getElementById("divsoso").style.display = "none";
                    document.getElementById("spansoso").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divyoudao").style.display == "block") {
                    document.getElementById("divyoudao").style.display = "none";
                    document.getElementById("spanyoudao").innerHTML = "<br/><font  color=green>查看</font>";
                }
                break;
            case "spansogou":
                if (document.getElementById("divbaidu").style.display == "block") {
                    document.getElementById("divbaidu").style.display = "none";
                    document.getElementById("spanbaidu").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divgoogle").style.display == "block") {
                    document.getElementById("divgoogle").style.display = "none";
                    document.getElementById("spangoogle").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divyahoo").style.display == "block") {
                    document.getElementById("divyahoo").style.display = "none";
                    document.getElementById("spanyahoo").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divbing").style.display == "block") {
                    document.getElementById("divbing").style.display = "none";
                    document.getElementById("spanbing").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divsogou").style.display == "none") {
                    document.getElementById("divsogou").style.display = "block";
                    document.getElementById("spansogou").innerHTML = "<br/><font  color=#666699>已显示</font>";
                }
                if (document.getElementById("divsoso").style.display == "block") {
                    document.getElementById("divsoso").style.display = "none";
                    document.getElementById("spansoso").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divyoudao").style.display == "block") {
                    document.getElementById("divyoudao").style.display = "none";
                    document.getElementById("spanyoudao").innerHTML = "<br/><font  color=green>查看</font>";
                }
                break;
            case "spansoso":
                if (document.getElementById("divbaidu").style.display == "block") {
                    document.getElementById("divbaidu").style.display = "none";
                    document.getElementById("spanbaidu").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divgoogle").style.display == "block") {
                    document.getElementById("divgoogle").style.display = "none";
                    document.getElementById("spangoogle").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divyahoo").style.display == "block") {
                    document.getElementById("divyahoo").style.display = "none";
                    document.getElementById("spanyahoo").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divbing").style.display == "block") {
                    document.getElementById("divbing").style.display = "none";
                    document.getElementById("spanbing").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divsogou").style.display == "block") {
                    document.getElementById("divsogou").style.display = "none";
                    document.getElementById("spansogou").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divsoso").style.display == "none") {
                    document.getElementById("divsoso").style.display = "block";
                    document.getElementById("spansoso").innerHTML = "<br/><font  color=#666699>已显示</font>";
                }
                if (document.getElementById("divyoudao").style.display == "block") {
                    document.getElementById("divyoudao").style.display = "none";
                    document.getElementById("spanyoudao").innerHTML = "<br/><font  color=green>查看</font>";
                }
                break;
            case "spanyoudao":
                if (document.getElementById("divbaidu").style.display == "block") {
                    document.getElementById("divbaidu").style.display = "none";
                    document.getElementById("spanbaidu").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divgoogle").style.display == "block") {
                    document.getElementById("divgoogle").style.display = "none";
                    document.getElementById("spangoogle").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divyahoo").style.display == "block") {
                    document.getElementById("divyahoo").style.display = "none";
                    document.getElementById("spanyahoo").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divbing").style.display == "block") {
                    document.getElementById("divbing").style.display = "none";
                    document.getElementById("spanbing").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divsogou").style.display == "block") {
                    document.getElementById("divsogou").style.display = "none";
                    document.getElementById("spansogou").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divsoso").style.display == "block") {
                    document.getElementById("divsoso").style.display = "none";
                    document.getElementById("spansoso").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divyoudao").style.display == "none") {
                    document.getElementById("divyoudao").style.display = "block";
                    document.getElementById("spanyoudao").innerHTML = "<br/><font  color=#666699>已显示</font>";
                }
                break;
            default:
                if (document.getElementById("divbaidu").style.display == "none") {
                    document.getElementById("divbaidu").style.display = "block";
                    document.getElementById("spanbaidu").innerHTML = "<br/><font  color=#666699>已显示</font>";
                }
                if (document.getElementById("divgoogle").style.display == "block") {
                    document.getElementById("divgoogle").style.display = "none";
                    document.getElementById("spangoogle").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divyahoo").style.display == "block") {
                    document.getElementById("divyahoo").style.display = "none";
                    document.getElementById("spanyahoo").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divbing").style.display == "block") {
                    document.getElementById("divbing").style.display = "none";
                    document.getElementById("spanbing").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divsogou").style.display == "block") {
                    document.getElementById("divsogou").style.display = "none";
                    document.getElementById("spansogou").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divsoso").style.display == "block") {
                    document.getElementById("divsoso").style.display = "none";
                    document.getElementById("spansoso").innerHTML = "<br/><font  color=green>查看</font>";
                }
                if (document.getElementById("divyoudao").style.display == "block") {
                    document.getElementById("divyoudao").style.display = "none";
                    document.getElementById("spanyoudao").innerHTML = "<br/><font  color=green>查看</font>";
                }
                break;
        }
    }
}


