<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoogleResult.aspx.cs" Inherits="CnWeb.GoogleResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<style type="text/css">
         a:link {text-decoration:none;color:blue;}	/* 未访问的链接 */
        a:visited {text-decoration:none;color:blue}	/* 已访问的链接 */
        a:hover {text-decoration:underline; color:blue; cursor:hand;}	/* 鼠标移动到链接上 */
        a:active {text-decoration:none;color:blue}	/* 选定的链接 */
        .buttonCss
        {
            BACKGROUND-COLOR:#ffffff; BORDER-RIGHT: #A9BAC9 1px solid; PADDING-RIGHT: 8px; BORDER-TOP: #A9BAC9 1px solid; PADDING-LEFT: 8px; FONT-SIZE: 12px; BORDER-LEFT: #A9BAC9 1px solid; CURSOR: hand; COLOR: #666699; font-weight:bold; PADDING-TOP: 3px; PADDING-BOTTOM: 2px;BORDER-BOTTOM: #A9BAC9 1px solid;
        }
        .text_dialog1,.text_dialog2 {height:19px; line-height:19px; border:1px solid #A9BAC9; padding:0 2px; font-size:12px; COLOR: #666699;  }
        .text_dialog2 { border:1px solid #9ECC00;COLOR: #666699; }
    </style>
    <link href="css/base.css" type="text/css" rel="Stylesheet" />
</head>
<body>
<!--google自定义搜索start-->
                   <form action="http://www.haopingba.com/GoogleResult.aspx" id="cse-search-box">
                      <div>
                      <table  border="0" cellpadding ="4" cellspacing ="0"  align="left" width="100%" style="float:right">
                                        <tr>
                                              <td align="left" width="218px">
                                              <input type="hidden" name="cx" value="006205424212150052046:d7r2umawbsq" />
                                                <input type="hidden" name="cof" value="FORID:9" />
                                                <input type="hidden" name="ie" value="UTF-8" />
                                              <a href="http://www.cninterface.com"><img border="0"  src="img/logo_cninterface.gif"  style="cursor:hand" title="旨在提供接口共享平台，体现接口服务价值"/></a></td>
                                              <td align="left" valign="bottom">
                                                        <input id="txtsearch" type="text" name="q" size="60" value="<%=searchword%>"  class="text_dialog1" 
                                                        onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'" />&nbsp;&nbsp;
                                                                                <input id="btnsearch" type="submit" name="sa" value="点击查询"  class="buttonCss"/>
                                              </td>
                                        </tr>
                        </table>
                      </div>
                    </form>
                    <script type="text/javascript" src="http://www.google.com/cse/brand?form=cse-search-box&lang=zh-Hans"></script>
                    <div id="cse-search-results"></div>
                        <script type="text/javascript">
                            var googleSearchIframeName = "cse-search-results";
                            var googleSearchFormName = "cse-search-box";
                            var googleSearchFrameWidth = 1001;
                            var googleSearchDomain = "www.google.com";
                            var googleSearchPath = "/cse";
                        </script>
                        <script type="text/javascript" src="http://www.google.com/afsonline/show_afs_search.js"></script>
<!--google自定义搜索end-->
 <table  border="0" cellpadding ="0" cellspacing ="0"  align="center" width="678px">
                <tr height="40px"><td>&nbsp;</td></tr>
      </table>
  <table  border="0" cellpadding ="4" cellspacing ="0" width="98%" style="float:right">
                <tr height="10px">
                    <td  align="center"><font size=2 color="#666699">©2010 CnInterface 此内容系天下接口根据您的指令自动搜索的结果，不代表天下接口赞成被搜索网站的内容或立场
                    </td>
                </tr>
      </table>
      <script language="javascript">
          function formonload() {
              alert(window.location.href);
          }
          //formonload();
      </script>
      <div style="display:none;"><script src="http://s11.cnzz.com/stat.php?id=2099859&web_id=2099859&show=pic1" language="JavaScript"></script></div>
</body>
</html>