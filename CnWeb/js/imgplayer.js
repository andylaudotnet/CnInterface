function slide(src,link,text,target,attr,desc,weburl) {
  this.desc = desc
  this.src = src;
  this.link = link;
  this.text = text;
  this.target = target;
  this.attr = attr;
  this.weburl = weburl;
  if (document.images) {
    this.image = new Image();
  }
  this.loaded = false;
  this.load = function() {
    if (!document.images) { return; }

    if (!this.loaded) {
      this.image.src = this.src;
      this.loaded = true;
    }
  }
  this.hotlink = function() {
    var mywindow;
    if (!this.link) return;
    if (this.target) {
      if (this.attr) {
        mywindow = window.open(this.link, this.target, this.attr);
  
      } else {
        mywindow = window.open(this.link, this.target);
      }
      if (mywindow && mywindow.focus) mywindow.focus();

    } else {
      location.href = this.link;
    }
  }
}
function slideshow( slideshowname ) {
  this.name = slideshowname;
  this.repeat = true;
  this.prefetch = -1;
  this.image;
  this.textid;
  this.textarea;
  this.timeout = 5000;
  this.slides = new Array();
  this.current = 0;
  this.timeoutid = 0;
  this.add_slide = function(slide) {
    var i = this.slides.length;
    if (this.prefetch == -1) {
      slide.load();
    }

    this.slides[i] = slide;
  }
  this.play = function(timeout) {
    this.pause();
    if (timeout) {
      this.timeout = timeout;
    }
    if (typeof this.slides[ this.current ].timeout != 'undefined') {
      timeout = this.slides[ this.current ].timeout;
    } else {
      timeout = this.timeout;
    }
    this.timeoutid = setTimeout( this.name + ".loop()", timeout);
  }
  this.pause = function() {
    if (this.timeoutid != 0) {

      clearTimeout(this.timeoutid);
      this.timeoutid = 0;

    }
  }
  this.update = function() {
    if (! this.valid_image()) { return; }
    if (typeof this.pre_update_hook == 'function') {
      this.pre_update_hook();
    }
    var slide = this.slides[ this.current ];
    var dofilter = false;
    if (this.image &&
        typeof this.image.filters != 'undefined' &&
        typeof this.image.filters[0] != 'undefined') {
      dofilter = true;

    }
    slide.load();
    if (dofilter) {
      if (slide.filter &&
          this.image.style &&
          this.image.style.filter) {
        this.image.style.filter = slide.filter;
      }
      this.image.filters[0].Apply();
    }
    this.image.src = slide.image.src;
    if (dofilter) {
      this.image.filters[0].Play();
    }
    this.display_text();
    if (typeof this.post_update_hook == 'function') {
      this.post_update_hook();
    }
    if (this.prefetch > 0) {

      var next, prev, count;
      next = this.current;
      prev = this.current;
      count = 0;
      do {
        if (++next >= this.slides.length) next = 0;
        if (--prev < 0) prev = this.slides.length - 1;
        this.slides[next].load();
        this.slides[prev].load();
      } while (++count < this.prefetch);
    }
  }
  this.goto_slide = function(n) {
    if (n == -1) {
      n = this.slides.length - 1;
    }
    if (n < this.slides.length && n >= 0) {
      this.current = n;
    }
    this.update();
  }
  this.goto_random_slide = function(include_current) {
    var i;
    if (this.slides.length > 1) {
      do {
        i = Math.floor(Math.random()*this.slides.length);
      } while (i == this.current);
      this.goto_slide(i);
    }
  }
  this.next = function() {
    if (this.current < this.slides.length - 1) {
      this.current++;
    } else if (this.repeat) {
      this.current = 0;
    }
    this.update();
  }
  this.previous = function() {
    if (this.current > 0) {
      this.current--;
    } else if (this.repeat) {
      this.current = this.slides.length - 1;
    }
    this.update();
  }
  this.shuffle = function() {
    var i, i2, slides_copy, slides_randomized;
    slides_copy = new Array();
    for (i = 0; i < this.slides.length; i++) {
      slides_copy[i] = this.slides[i];
    }
    slides_randomized = new Array();
    do {
      i = Math.floor(Math.random()*slides_copy.length);
      slides_randomized[ slides_randomized.length ] =
        slides_copy[i];
      for (i2 = i + 1; i2 < slides_copy.length; i2++) {
        slides_copy[i2 - 1] = slides_copy[i2];
      }
      slides_copy.length--;
    } while (slides_copy.length);
    this.slides = slides_randomized;
  }
  this.get_text = function() {
    return(this.slides[ this.current ].text);
  }
  this.get_all_text = function(before_slide, after_slide) {
    all_text = "";
    for (i=0; i < this.slides.length; i++) {
      slide = this.slides[i];
      if (slide.text) {
        all_text += before_slide + slide.text + after_slide;
      }
    }
    return(all_text);
  }
  this.display_text = function(text) {
    if (!text) {
      text = this.slides[ this.current ].text;
    }
    if (this.textarea && typeof this.textarea.value != 'undefined') {
      this.textarea.value = text;
    }
    if (this.textid) {
      r = this.getElementById(this.textid);
      if (!r) { return false; }
      if (typeof r.innerHTML == 'undefined') { return false; }
      r.innerHTML = text;
    }
  }
  this.hotlink = function() {
    this.slides[ this.current ].hotlink();
  }
  this.save_position = function(cookiename) {
    if (!cookiename) {
      cookiename = this.name + '_slideshow';
    }
    document.cookie = cookiename + '=' + this.current;
  }
  this.restore_position = function(cookiename) {
    if (!cookiename) {
      cookiename = this.name + '_slideshow';
    }
    var search = cookiename + "=";
    if (document.cookie.length > 0) {
      offset = document.cookie.indexOf(search);
      if (offset != -1) { 
        offset += search.length;
        end = document.cookie.indexOf(";", offset);
        if (end == -1) end = document.cookie.length;
        this.current = parseInt(unescape(document.cookie.substring(offset, end)));
        }
     }
  }
  this.noscript = function() {
    $html = "\n";
    for (i=0; i < this.slides.length; i++) {
      slide = this.slides[i];
      $html += '<P>';
      if (slide.link) {
        $html += '<a href="' + slide.link + '">';
      }
      $html += '<img src="' + slide.src + '"  title="' + slide.title + '">';
      if (slide.link) {
        $html += "<\/a>";
      }
      if (slide.text) {
        $html += "<BR>\n" + slide.text;
      }
      $html += "<\/P>" + "\n\n";
    }
    $html = $html.replace(/\&/g, "&amp;" );
    $html = $html.replace(/</g, "&lt;" );
    $html = $html.replace(/>/g, "&gt;" );
    return('<pre>' + $html + '</pre>');
  }
  this.loop = function() {
    if (this.current < this.slides.length - 1) {
      next_slide = this.slides[this.current + 1];
      if (next_slide.image.complete == null || next_slide.image.complete) {
        this.next();
      }
    } else {
      this.next();
    }
    this.play( );
  }
  this.valid_image = function() {
    if (!this.image){
      return false;
    }
    else {
      return true;
    }
  }
  this.getElementById = function(element_id) {
    if (document.getElementById) {
      return document.getElementById(element_id);
    }
    else if (document.all) {
      return document.all[element_id];
    }
    else if (document.layers) {
      return document.layers[element_id];
    } else {
      return undefined;
    }
  }
  this.set_image = function(imageobject) {
    if (!document.images)
      return;
    this.image = imageobject;
  }
  this.set_textarea = function(textareaobject) {
    this.textarea = textareaobject;
    this.display_text();
  }
  this.set_textid = function(textidstr) {
    this.textid = textidstr;
    this.display_text();
  }
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


function initimages() {
    ss = new slideshow("ss");
    ss.prefetch = 1;
    ss.sizelmt = true;
    ss.repeat = true;
}

var xmlhttpdata; //图片分页数据读取
var pagenumber;
function GetIndexData(pageindex) {
    try {
        pagenumber = pageindex;
        xmlhttpdata = createHttpRequest();
        var UrlStr = "Default.aspx?ResponseIndexData=" + pageindex;
        xmlhttpdata.onreadystatechange = processindexdata;
        xmlhttpdata.open("POST", UrlStr, true);
        xmlhttpdata.setRequestHeader('Connection', 'close');
        xmlhttpdata.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
        xmlhttpdata.send(null);
    }
    catch (e) {
        alet("网络忙，请稍候操作！");
    }
}
function processindexdata() {
    try {
        if (xmlhttpdata.readyState == 4) {
            if (xmlhttpdata.status == 200) {
                //获取分页数据
                var objxml =null;
                var xmlDoc=null;
                if (window.ActiveXObject){
                    objxml= xmlhttpdata.responseText;
                    xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
                    xmlDoc.async = false;
                    xmlDoc.loadXML(objxml);
                }
                else if (document.implementation && document.implementation.createDocument){
                   // xmlDoc = xmlhttpdata.responseXML.documentElement; 
                    //alert(xmlhttpdata.responseXML);
                    document.getElementById("tdimagesshow").style.display="none";
                }
                else {
                    document.getElementById("tdimagesshow").style.display="none";
                    return;
                }

                var xmlNode = xmlDoc.getElementsByTagName("img");
                //alert(xmlNode.length);
                ss = new slideshow("ss");
                ss.prefetch = 1;
                ss.sizelmt = true;
                ss.repeat = true;
                
                //初始化分页标签和数据
                var html="";
                if (parseInt(pagenumber) > 0) {
                    html += "<li class=\"itemOff\" id=\"imbtnbegin\"  onclick=\"GetIndexData(0)\">首页</li>";
                    html += "<li class=\"itemOff\" id=\"imbtnprev\"  onclick=\"GetIndexData(" + parseInt(pagenumber - 1) + ")\">上页</li>";
                }
                
                for (var i = 0; i < xmlNode.length; i++) {
                    var id=xmlNode.item(i).getAttribute("id");
                    var title = xmlNode.item(i).childNodes[1].text;
                    var url = xmlNode.item(i).childNodes[2].text.replace("$","&");
                    var src = xmlNode.item(i).childNodes[3].text.replace("$","&");
                    var web = xmlNode.item(i).childNodes[0].text;
                    var weburl = xmlNode.item(i).childNodes[4].text;
                    s = new slide();
                    s.src = src;
                    s.title = title;
                    s.link =url;
                    s.con = web;
                    s.weburl = weburl;
                    ss.add_slide(s);
                    //alert(weburl);
                    html += "<li class=\"itemOff\" id=\"imbtn" + i + "\" onclick=\"ss.goto_slide(" + i + ")\">" + id + "</li>";
                }
                var maxcount =xmlDoc.getElementsByTagName("imgcount").item(0).text;
                var count = parseInt(maxcount % 6) == 0 ? parseInt(maxcount / 6) : parseInt(maxcount / 6 + 1);
                
                if (parseInt(count) > 1 && pagenumber < parseInt(count - 1)) {
                    html += "<li class=\"itemOff\" id=\"imbtnnext\"  onclick=\"GetIndexData(" + parseInt(pagenumber + 1) + ")\">下页</li>";
                    html += "<li class=\"itemOff\" id=\"imbtnend\" onclick=\"GetIndexData(" + parseInt(count - 1) + ")\">末页</li>";
                }
                
                for (var i = 0; i < ss.slides.length; i++) {
                    s = ss.slides[i];
                    s.target = "_blank";
                }
                document.getElementById("divpagedata").innerHTML = html;
                
                startpauseimage();
            }
        }
    }
    catch (e) {
        alet("网络忙，请稍候操作！");
    }
}
function startpauseimage() {
    var ttt = 0;
    ss.pre_update_hook = function() {
        if (parseInt(ttt) == 1) {
            //图片展示完一页自动跳转到下页
            //document.getElementById("imbtnnext").click();
        }
        sid = ss.current;
        title = ss.slides[sid].title;
        linkurl = ss.slides[sid].link;
        totals = ss.slides.length;
        scon = ss.slides[sid].con;
        weburl = ss.slides[sid].weburl;
        tempid = parseInt(sid) + 1;

        document.getElementById("tt").innerHTML = '<a href="' + linkurl + '" target="_blank">' + title + '</a>';
        document.getElementById("sweb").innerHTML = "<a href=\"" + weburl + "\" target=\"_blank\"><font size=\"3\" color=\"#003399\"><b>" + scon + "</b></font></a>";
        document.getElementById("ss_img").alt =title;
        for (var i = 0; i < ss.slides.length; i++) {
            document.getElementById("imbtn" + i).className = "itemOff";
        }
        document.getElementById("imbtn" + sid).className = "itemOn";

        //document.getElementById("divmoniter").innerHTML = "<font color='#666699' size='2'>您正在浏览第" + parseInt(pagenumber*6 + tempid) + "张图片。</font>";
        if (parseInt(tempid) == parseInt(totals)) {
            ttt = 1;
        }
        else {
            ttt = 0;
        }

        return;
    }
    if (document.images) {
        ss.image = document.images.ss_img;
        ss.update();
        ss.play();
    }
}


function fileisexists(path) {
    var filespec = "D:\\CnInterface\\CnWeb\\imgtemp\\" + path;
    var fso, s = filespec;
    try {
        fso = new ActiveXObject("Scripting.FileSystemObject");
    }
    catch (e) {
        alert("打开Internet Explorer “工具”菜单栏中的“选项”一栏，单击“安全”栏中的“自定义级别”选项卡，\n将第三项“对没有标记为安全的activex控件进行初始化和脚本运行”设置成“启用”并刷新当前页面即可正常浏览图片。  ");
    }
    if (!fso.FileExists(filespec)) {
        s = "noexists.jpg";
    }
    else {
        s = path;
    }
    return s;
}

