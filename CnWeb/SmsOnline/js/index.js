function checkparames() {
    /*if (document.getElementById("hiddenUsername").value == "") {
        alert("未登录，请先登录！");
        return false;
    }*/
    if (document.getElementById("txtSmsmob").value == "") {
        alert("手机号码不能为空!");
        document.getElementById("txtSmsmob").focus();
        return false;
    }
    if (!mobilenumCheck(document.getElementById("txtSmsmob").value)) {
        alert("手机号码格式不正确,请核对后重新输入!");
        document.getElementById("txtSmsmob").focus();
        return false;
    }
    if (document.getElementById("txtSms").value == "") {
        alert("短信内容不能为空!");
        document.getElementById("txtSms").focus();
        return false;
    }
    if (document.getElementById("txtSms").value.indexOf("--") > -1 || document.getElementById("txtSms").value.indexOf("<") > -1 || document.getElementById("txtSms").value.indexOf("'") > -1 || document.getElementById("txtSms").value.indexOf(">") > -1) {
        alert("短信内容中不允许包含<>'--等字符!");
        document.getElementById("txtSms").focus();
        return false;
    }
    if (document.getElementById("txtSms").value.length > 60) {
        alert("短信内容不能超过60个字，当前输入字数为" + document.getElementById("txtSms").value.length + "个!");
        document.getElementById("txtSms").focus();
        return false;
    }
    if (document.getElementById("txtsenduser").value == "") {
        alert("发送人姓名不能为空!");
        document.getElementById("txtsenduser").focus();
        return false;
    }
    if (document.getElementById("txtsenduser").value.indexOf("--") > -1 || document.getElementById("txtsenduser").value.indexOf("<") > -1 || document.getElementById("txtsenduser").value.indexOf("'") > -1 || document.getElementById("txtsenduser").value.indexOf(">") > -1) {
        alert("发送人姓名不允许包含<>'--等字符!");
        document.getElementById("txtsenduser").focus();
        return false;
    }

    //document.getElementById("bntSendNote").disabled = "disabled";
    if (document.getElementById("bntSendNote").value == "发送短信") {
        document.getElementById("bntSendNote").value = "发送中...";
        document.getElementById("labresult").innerHTML = "<font color=#666699 size=2><b>短信发送中...</b></font>";
        return true;
    }
    else {
        return false;
    }
}

function mobilenumCheck(mobilenum) {
    var filter = /^1[3|5|8][0-9]\d{4,8}$/;
    return filter.test(mobilenum);
}

function prom() {
    var name = prompt("此网站暂只提供给QQ好友使用，输入站长QQ号码才可进入该网站：", "");
    if (name == 459313018) {
        document.getElementById("hiddenUsername").value = "1";
        alert("成功进入！");
    }
    else {
        document.getElementById("hiddenUsername").value = "0";
        if (name)
            alert("输入QQ号码错误！");
        prom();
    }
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

var xmlhttpLogin;//用户登录
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
        var UrlStr = "Index.aspx?ResponseLoginName=" + document.getElementById("txtusername").value + "&ResponseLoginPwd=" + document.getElementById("txtpassword").value + "&ResponseCookieStatus=" + cookiestatus;
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
                    document.getElementById("spanusername").innerHTML = "<font size=2  color=#666699>欢迎您！<b>" + document.getElementById("txtusername").value + "</b></font>&nbsp;&nbsp;<a href='../Parse/Index.aspx'><font color=blue size=2>管理中心</font></a>&nbsp;&nbsp;<a href='#' onclick='UserExit();'><font size=2 color=red>退出</font></a>";
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
        alert("登录异常："+e);
    }
}

var xmlhttpLoginOut;//用户退出
function UserExit() {
    try {
        xmlhttpLoginOut = createHttpRequest();
        var UrlStr = "Index.aspx?ResponseUserExit=yes";
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
                    document.getElementById("hiddenUsername").value ="";
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

function choujiang(ssqResult) {
    document.getElementById("tdchoujiangResult").innerHTML = "<font color=#666699 size=3>红色球:</font>";
      var strTemp="";
      var count = 6; 
      
      //随机抽取6个红色球
      for(var i=0;i<count;i++)
     {
        var randnum=parseInt(Math.random()*(33-1)+1);
        if(randnum<10)
           randnum="0"+randnum;
           if(strTemp.indexOf(randnum)>-1)
           {
                count++;
                continue;
           }
           else
           {
               document.getElementById("tdchoujiangResult").innerHTML += "<font color=red size=3><b>" + randnum + "</b></font>，";
               strTemp=strTemp+","+randnum;
            }
     }
     strTemp=strTemp.substring(1);
    
     var collection=strTemp.split(",");
     
     //抽奖结果按从小到大顺序排序
     for(var i=0;i<collection.length;i++)
     { 
           for(var j=0;j<collection.length-1-i;j++)
          {
             if(collection[j]>collection[j+1])
              {
                var temp=collection[j];
                collection[j]=collection[j+1];
                collection[j+1]=temp;
              }
          }
      }

      //获取双色球开奖结果
      var ssqCollection = ssqResult.split(",");
      var ssqCount = 0;
      
      var resultStr="";
      for(var i=0;i<collection.length;i++)
      {
          for (var j = 0; j < ssqCollection.length-1; j++) {
              //抽奖红色球结果与开奖结果比较
              if (collection[i] == ssqCollection[j]) {
                  ssqCount++;
                  resultStr += "，<font color=green size=3><b>" + collection[i]+"</b></font>";
              }
          }
          if (resultStr.indexOf(collection[i]) == -1) {
              resultStr += "，" + collection[i];
          }
      }
      resultStr = resultStr.substring(1); 
      document.getElementById("tdchoujiangResult").innerHTML = "<font color=#666699 size=2>您抽中的红色球为：</font><font color=red size=2><b>" + resultStr + "</b></font>";
     
      var randnum=parseInt(Math.random()*(16-1)+1);
        if(randnum<10)
            randnum = "0" + randnum;

        //抽奖蓝色球与开奖结果比较
        if (ssqCollection[6] == randnum) {
            ssqCount++;
            randnum = "<font color=green size=3><b>" + randnum + "</b></font>";
        }
        else {
            randnum = "<font color=blue size=3><b>" + randnum + "</b></font>";
        }
        if (ssqCollection.length == 7) {
            document.getElementById("tdchoujiangResult").innerHTML += "&nbsp;&nbsp;<font color=#666699 size=2>蓝色球为：</font>" + randnum + "&nbsp;&nbsp;&nbsp;<font color=#666699 size=2>(中<b>" + ssqCount + "</b>个号码)</font>";
        }
        else {
            document.getElementById("tdchoujiangResult").innerHTML += "&nbsp;&nbsp;<font color=#666699 size=2>蓝色球为：</font>" + randnum + "&nbsp;&nbsp;&nbsp;<font color=#666699 size=2>(对照下图查看)</font>";
        }
 }

 function kaijiang() {
     if (document.getElementById("tabkaijiang").style.display == "none") {
         GetChoujiangResult(); //获取抽奖结果
     }
     else {
         document.getElementById("tabchoujiang").style.display = "none";
         document.getElementById("tabkaijiang").style.display = "none";
         //document.getElementById("akaijiang").innerHTML = "<font color=#006600  size=2>试试手气</font>";
         //document.getElementById("akaijiang").title = "点击进行双色球抽奖";
         document.getElementById("tdchoujiangResult").innerHTML = "&nbsp";
     }
 }

 var xmlhttpChoujiang;
 function GetChoujiangResult() {
     try {
             document.getElementById("tabchoujiang").style.display = "block";
             xmlhttpChoujiang = createHttpRequest();
             var UrlStr = "Index.aspx?ResponseSSQ=ssq";
             xmlhttpChoujiang.onreadystatechange = processChoujiang;
             xmlhttpChoujiang.open("POST", UrlStr, true);
             xmlhttpChoujiang.setRequestHeader('Connection', 'close');
             xmlhttpChoujiang.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
             xmlhttpChoujiang.send(null);
     }
     catch (e) {
         document.getElementById("tabchoujiang").style.display = "none";
         document.getElementById("tabkaijiang").style.display = "none";
         //document.getElementById("akaijiang").innerHTML = "<font color=#006600  size=2>试试手气</font>";
         //document.getElementById("akaijiang").title = "点击进行双色球抽奖";
         document.getElementById("tdchoujiangResult").innerHTML = "&nbsp";
         alert("抽奖异常：" + e);
     }
 }

 function processChoujiang() {
     try {
         if (xmlhttpChoujiang.readyState == 4) {
             if (xmlhttpChoujiang.status == 200) {
                 choujiang(xmlhttpChoujiang.responseText); //抽奖函数处理
                     document.getElementById("tabchoujiang").style.display = "none";
                     document.getElementById("tabkaijiang").style.display = "block";
                     //document.getElementById("akaijiang").innerHTML = "<font color=#666699  size=2>隐藏抽奖</font>";
                     //document.getElementById("akaijiang").title = "点击关闭抽奖详情";
                 }
             }
         }
     catch (e) {
         document.getElementById("tabchoujiang").style.display = "none";
         document.getElementById("tabkaijiang").style.display = "none";
         //document.getElementById("akaijiang").innerHTML = "<font color=#006600  size=2>试试手气</font>";
         //document.getElementById("akaijiang").title = "点击进行双色球抽奖";
         document.getElementById("tdchoujiangResult").innerHTML = "&nbsp";
         alert("抽奖异常：" + e);
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

 function SelectSmsType(typeid) {
     if (typeid == 1) {
         document.getElementById("tabchoujiang").style.display = "none";
         document.getElementById("tabkaijiang").style.display = "none";
         document.getElementById("tdchoujiangResult").innerHTML = "&nbsp";
         document.getElementById("rdlSmsType_1").checked = true;
         document.getElementById("tdSmsIframe").innerHTML = "<iframe src=\"SmsNormal.aspx\" width=\"555px\" height=\"200px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
     }
     if (typeid == 2) {
         document.getElementById("tabchoujiang").style.display = "none";
         document.getElementById("tabkaijiang").style.display = "none";
         document.getElementById("tdchoujiangResult").innerHTML = "&nbsp";
         document.getElementById("rdlSmsType_2").checked = true;
         document.getElementById("tdSmsIframe").innerHTML = "<iframe src=\"SmsFetion.aspx\" width=\"555px\" height=\"200px\" scrolling=\"no\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\"></iframe>";
     }
     if (typeid == 3) {
         if (document.getElementById("tabkaijiang").style.display == "none") {
             document.getElementById("rdlSmsType_3").checked = true;
             kaijiang();
         }
     }
 }


 function showStockInfo() {
     if (document.getElementById("tabStockInfo").style.display == "none") {
         document.getElementById("tabStockInfo").style.display = "block";
     }
     else {
         document.getElementById("tabStockInfo").style.display = "none";
     }
 }
