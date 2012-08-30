<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CnWeb.flight.Index" %>

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
    <LINK href="../style/style.css" type="text/css" rel="stylesheet">
    <script language="javascript">
			function SelectFlightGo()
			{
			    var url="FlightList.aspx?";
			    var beginCity=document .getElementById ("SearchFlight1_ddlDepCity1").options[document .getElementById ("SearchFlight1_ddlDepCity1").selectedIndex].value;
			   
			    var endCity=document .getElementById ("SearchFlight1_ddlDesCity1").options[document .getElementById ("SearchFlight1_ddlDesCity1").selectedIndex].value;
			    
			    var beginDate=document.getElementById("txtArriveDate").value.replace("-","").replace("-","");
			    
			    var Times=document .getElementById ("SearchFlight1_ddlStartTime1").options[document .getElementById ("SearchFlight1_ddlStartTime1").selectedIndex].value;
			    var beginTime=Times.replace(":","");
			    var aircompany=document .getElementById ("SearchFlight1_ddlCompany1").options[document .getElementById ("SearchFlight1_ddlCompany1").selectedIndex].value;
			  
			    var getUrl="FlightList.aspx?bcity="+beginCity+"&ecity="+endCity+"&bdate="+beginDate+"&btime="+beginTime+"&airline="+aircompany;
				window.location.href=getUrl;
			}
		</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
     <table  border="0" cellpadding ="0" cellspacing ="0"  bgcolor="#ffffff" align="center"  width="360px" >
                    <tr>
                        <td  bgcolor="#ffffff"  align="left"><a href="../Index.aspx"  title="旨在提供接口共享平台，体现接口服务价值"><img border="0"  src="../img/logo_cninterface.gif"/></a></td>
                    </tr>
    </table>
    <TABLE  cellSpacing="1" cellPadding="1" width="360" border="1" align="center">
			<TR>
				<TD colSpan="2"  style="background-image:url(../img/menuBackGround.jpg) "><font color="#666699"><b>航班查询：</b></font></TD>
			</TR>
			<TR>
				<TD><label style="WIDTH: 140px; HEIGHT: 37px">出发城市：</label></TD>
				<TD>
					<select id="SearchFlight1_ddlDepCity1" style="WIDTH:106px">
						<OPTION value="AKU">A 阿克苏</OPTION>
						<OPTION value="AAT">A 阿勒泰</OPTION>
						<OPTION value="AKA">A 安康</OPTION>
						<OPTION value="AQG">A 安庆</OPTION>
						<OPTION value="AVA">A 安顺</OPTION>
						<OPTION value="AYN">A 安阳</OPTION>
						<OPTION value="AOG">A 鞍山</OPTION>
						<OPTION value="BFU">B 蚌埠</OPTION>
						<OPTION value="BAV">B 包头</OPTION>
						<OPTION value="BSD">B 保山</OPTION>
						<OPTION value="BHY">B 北海</OPTION>
						<OPTION value="PEK" selected>B 北京首都</OPTION>
						<OPTION value="NAY">B 北京南苑</OPTION>
						<OPTION value="CGQ">C 长春</OPTION>
						<OPTION value="CNI">C 长海</OPTION>
						<OPTION value="CSX">C 长沙</OPTION>
						<OPTION value="CIH">C 长治</OPTION>
						<OPTION value="CGD">C 常德</OPTION>
						<OPTION value="CZX">C 常州</OPTION>
						<OPTION value="CHG">C 朝阳</OPTION>
						<OPTION value="CTU">C 成都</OPTION>
						<OPTION value="CIF">C 赤峰</OPTION>
						<OPTION value="CKG">C 重庆</OPTION>
						<OPTION value="DAX">D 达县</OPTION>
						<OPTION value="DLU">D 大理</OPTION>
						<OPTION value="DLC">D 大连</OPTION>
						<OPTION value="DAT">D 大同</OPTION>
						<OPTION value="DZU">D 大足</OPTION>
						<OPTION value="DDG">D 丹东</OPTION>
						<OPTION value="DIG">D 迪庆</OPTION>
						<OPTION value="DSN">D 东胜</OPTION>
						<OPTION value="DOY">D 东营</OPTION>
						<OPTION value="DNH">D 敦煌</OPTION>
						<OPTION value="ENH">E 恩施</OPTION>
						<OPTION value="FUO">F 佛山</OPTION>
						<OPTION value="FOC">F 福州</OPTION>
						<OPTION value="FUG">F 阜阳</OPTION>
						<OPTION value="FYN">F 富蕴</OPTION>
						<OPTION value="KOW">G 赣州</OPTION>
						<OPTION value="GOQ">G 格尔木</OPTION>
						<OPTION value="GHN">G 广汉</OPTION>
						<OPTION value="CAN">G 广州</OPTION>
						<OPTION value="KWE">G 贵阳</OPTION>
						<OPTION value="KWL">G 桂林</OPTION>
						<OPTION value="HRB">H 哈尔滨</OPTION>
						<OPTION value="HMI">H 哈密</OPTION>
						<OPTION value="HAK">H 海口</OPTION>
						<OPTION value="HLD">H 海拉尔</OPTION>
						<OPTION value="HZG">H 汉中</OPTION>
						<OPTION value="HGH">H 杭州</OPTION>
						<OPTION value="HFE">H 合肥</OPTION>
						<OPTION value="HTN">H 和田</OPTION>
						<OPTION value="HEK">H 黑河</OPTION>
						<OPTION value="HNY">H 衡阳</OPTION>
						<OPTION value="HET">H 呼和浩特</OPTION>
						<OPTION value="TXN">H 黄山</OPTION>
						<OPTION value="HYN">H 黄岩</OPTION>
						<OPTION value="HUZ">H 徽州</OPTION>
						<OPTION value="KNC">J 吉安</OPTION>
						<OPTION value="JIL">J 吉林</OPTION>
						<OPTION value="TNA">J 济南</OPTION>
						<OPTION value="JNG">J 济宁</OPTION>
						<OPTION value="JMU">J 佳木斯</OPTION>
						<OPTION value="JGN">J 嘉峪关</OPTION>
						<OPTION value="JNZ">J 锦州</OPTION>
						<OPTION value="SHS">J 荆沙</OPTION>
						<OPTION value="JGS">J 井冈山</OPTION>
						<OPTION value="JDZ">J 景德镇</OPTION>
						<OPTION value="JIU">J 九江</OPTION>
						<OPTION value="JZH">J 九寨沟</OPTION>
						<OPTION value="CHW">J 酒泉</OPTION>
						<OPTION value="KHG">K 喀什</OPTION>
						<OPTION value="KRY">K 克拉玛依</OPTION>
						<OPTION value="KCA">K 库车</OPTION>
						<OPTION value="KRL">K 库尔勒</OPTION>
						<OPTION value="KMG">K 昆明</OPTION>
						<OPTION value="LXA">L 拉萨</OPTION>
						<OPTION value="LHW">L 兰州</OPTION>
						<OPTION value="LJG">L 丽江</OPTION>
						<OPTION value="LYG">L 连云港</OPTION>
						<OPTION value="LIA">L 梁平</OPTION>
						<OPTION value="LXI">L 林西</OPTION>
						<OPTION value="LNJ">L 临沧</OPTION>
						<OPTION value="LYI">L 临沂</OPTION>
						<OPTION value="LZH">L 柳州</OPTION>
						<OPTION value="LUZ">L 庐山</OPTION>
						<OPTION value="LZO">L 泸州</OPTION>
						<OPTION value="LYA">L 洛阳</OPTION>
						<OPTION value="NZH">M 满洲里</OPTION>
						<OPTION value="LUM">M 芒市</OPTION>
						<OPTION value="MXZ">M 梅县</OPTION>
						<OPTION value="MIG">M 绵阳</OPTION>
						<OPTION value="MDG">M 牡丹江</OPTION>
						<OPTION value="KHN">N 南昌</OPTION>
						<OPTION value="NAO">N 南充</OPTION>
						<OPTION value="NKG">N 南京</OPTION>
						<OPTION value="NNG">N 南宁</OPTION>
						<OPTION value="NTG">N 南通</OPTION>
						<OPTION value="NNY">N 南阳</OPTION>
						<OPTION value="NGB">N 宁波</OPTION>
						<OPTION value="PZI">P 攀枝花</OPTION>
						<OPTION value="NDG">Q 齐齐哈尔</OPTION>
						<OPTION value="IQM">Q 且末</OPTION>
						<OPTION value="SHP">Q 秦皇岛/山海关</OPTION>
						<OPTION value="TAO">Q 青岛</OPTION>
						<OPTION value="IQN">Q 庆阳</OPTION>
						<OPTION value="JUZ">Q 衢州</OPTION>
						<OPTION value="JJN">Q 泉州/晋江</OPTION>
						<OPTION value="SYX">S 三亚</OPTION>
						<OPTION value="SWA">S 汕头</OPTION>
						<OPTION value="SXJ">S 鄯善</OPTION>
						<OPTION value="SSS">S 上海</OPTION>
						<OPTION value="SHA">S 上海虹桥</OPTION>
						<OPTION value="PVG">S 上海浦东</OPTION>
						<OPTION value="SZX">S 深圳</OPTION>
						<OPTION value="SHE">S 沈阳</OPTION>
						<OPTION value="SJW">S 石家庄</OPTION>
						<OPTION value="SYM">S 思茅</OPTION>
						<OPTION value="SZV">S 苏州</OPTION>
						<OPTION value="TCG">T 塔城</OPTION>
						<OPTION value="TYN">T 太原</OPTION>
						<OPTION value="TSN">T 天津</OPTION>
						<OPTION value="TNH">T 通化</OPTION>
						<OPTION value="TGO">T 通辽</OPTION>
						<OPTION value="TEN">T 铜仁</OPTION>
						<OPTION value="WXN">W 万州</OPTION>
						<OPTION value="WEH">W 威海</OPTION>
						<OPTION value="WEF">W 潍坊</OPTION>
						<OPTION value="WNZ">W 温州</OPTION>
						<OPTION value="WUA">W 乌海</OPTION>
						<OPTION value="HLH">W 乌兰浩特</OPTION>
						<OPTION value="URC">W 乌鲁木齐</OPTION>
						<OPTION value="WUX">W 无锡</OPTION>
						<OPTION value="WHU">W 芜湖</OPTION>
						<OPTION value="WUZ">W 梧州</OPTION>
						<OPTION value="WUH">W 武汉</OPTION>
						<OPTION value="WUS">W 武夷山</OPTION>
						<OPTION value="XIY">X 西安</OPTION>
						<OPTION value="XIC">X 西昌</OPTION>
						<OPTION value="XNN">X 西宁</OPTION>
						<OPTION value="JHG">X 西双版纳</OPTION>
						<OPTION value="XIL">X 锡林浩特</OPTION>
						<OPTION value="XMN">X 厦门</OPTION>
						<OPTION value="XIG">X 香港</OPTION>
						<OPTION value="XFN">X 襄樊</OPTION>
						<OPTION value="XEN">X 兴城</OPTION>
						<OPTION value="XIN">X 兴宁</OPTION>
						<OPTION value="XNT">X 邢台</OPTION>
						<OPTION value="XUZ">X 徐州</OPTION>
						<OPTION value="YNT">Y 烟台</OPTION>
						<OPTION value="ENY">Y 延安</OPTION>
						<OPTION value="YNJ">Y 延吉</OPTION>
						<OPTION value="YNZ">Y 盐城</OPTION>
						<OPTION value="YIN">Y 伊宁</OPTION>
						<OPTION value="YBP">Y 宜宾</OPTION>
						<OPTION value="YIH">Y 宜昌</OPTION>
						<OPTION value="YIW">Y 义乌</OPTION>
						<OPTION value="INC">Y 银川</OPTION>
						<OPTION value="UYN">Y 榆林</OPTION>
						<OPTION value="YUA">Y 元谋</OPTION>
						<OPTION value="YCU">Y 运城</OPTION>
						<OPTION value="ZHA">Z 湛江</OPTION>
						<OPTION value="DYG">Z 张家界</OPTION>
						<OPTION value="ZAT">Z 昭通</OPTION>
						<OPTION value="CGO">Z 郑州</OPTION>
						<OPTION value="HSN">Z 舟山</OPTION>
						<OPTION value="ZUH">Z 珠海</OPTION>
						<OPTION value="ZYI">Z 遵义</OPTION>
					</select></TD>
			</TR>
			<TR>
				<TD>
					<LABEL style="WIDTH: 140px; HEIGHT: 35px">到达城市：</LABEL></TD>
				<TD><SELECT id="SearchFlight1_ddlDesCity1" style="WIDTH: 106px">
						<OPTION value="AKU">A 阿克苏</OPTION>
						<OPTION value="AAT">A 阿勒泰</OPTION>
						<OPTION value="AKA">A 安康</OPTION>
						<OPTION value="AQG">A 安庆</OPTION>
						<OPTION value="AVA">A 安顺</OPTION>
						<OPTION value="AYN">A 安阳</OPTION>
						<OPTION value="AOG">A 鞍山</OPTION>
						<OPTION value="BFU">B 蚌埠</OPTION>
						<OPTION value="BAV">B 包头</OPTION>
						<OPTION value="BSD">B 保山</OPTION>
						<OPTION value="BHY">B 北海</OPTION>
						<OPTION value="BBB">B 北京</OPTION>
						<OPTION value="NAY">B 北京南苑</OPTION>
						<OPTION value="PEK">B 北京首都</OPTION>
						<OPTION value="CGQ">C 长春</OPTION>
						<OPTION value="CNI">C 长海</OPTION>
						<OPTION value="CSX" selected>C 长沙</OPTION>
						<OPTION value="CIH">C 长治</OPTION>
						<OPTION value="CGD">C 常德</OPTION>
						<OPTION value="CZX">C 常州</OPTION>
						<OPTION value="CHG">C 朝阳</OPTION>
						<OPTION value="CTU">C 成都</OPTION>
						<OPTION value="CIF">C 赤峰</OPTION>
						<OPTION value="CKG">C 重庆</OPTION>
						<OPTION value="DAX">D 达县</OPTION>
						<OPTION value="DLU">D 大理</OPTION>
						<OPTION value="DLC">D 大连</OPTION>
						<OPTION value="DAT">D 大同</OPTION>
						<OPTION value="DZU">D 大足</OPTION>
						<OPTION value="DDG">D 丹东</OPTION>
						<OPTION value="DIG">D 迪庆</OPTION>
						<OPTION value="DSN">D 东胜</OPTION>
						<OPTION value="DOY">D 东营</OPTION>
						<OPTION value="DNH">D 敦煌</OPTION>
						<OPTION value="ENH">E 恩施</OPTION>
						<OPTION value="FUO">F 佛山</OPTION>
						<OPTION value="FOC">F 福州</OPTION>
						<OPTION value="FUG">F 阜阳</OPTION>
						<OPTION value="FYN">F 富蕴</OPTION>
						<OPTION value="KOW">G 赣州</OPTION>
						<OPTION value="GOQ">G 格尔木</OPTION>
						<OPTION value="GHN">G 广汉</OPTION>
						<OPTION value="CAN">G 广州</OPTION>
						<OPTION value="KWE">G 贵阳</OPTION>
						<OPTION value="KWL">G 桂林</OPTION>
						<OPTION value="HRB">H 哈尔滨</OPTION>
						<OPTION value="HMI">H 哈密</OPTION>
						<OPTION value="HAK">H 海口</OPTION>
						<OPTION value="HLD">H 海拉尔</OPTION>
						<OPTION value="HZG">H 汉中</OPTION>
						<OPTION value="HGH">H 杭州</OPTION>
						<OPTION value="HFE">H 合肥</OPTION>
						<OPTION value="HTN">H 和田</OPTION>
						<OPTION value="HEK">H 黑河</OPTION>
						<OPTION value="HNY">H 衡阳</OPTION>
						<OPTION value="HET">H 呼和浩特</OPTION>
						<OPTION value="TXN">H 黄山</OPTION>
						<OPTION value="HYN">H 黄岩</OPTION>
						<OPTION value="HUZ">H 徽州</OPTION>
						<OPTION value="KNC">J 吉安</OPTION>
						<OPTION value="JIL">J 吉林</OPTION>
						<OPTION value="TNA">J 济南</OPTION>
						<OPTION value="JNG">J 济宁</OPTION>
						<OPTION value="JMU">J 佳木斯</OPTION>
						<OPTION value="JGN">J 嘉峪关</OPTION>
						<OPTION value="JNZ">J 锦州</OPTION>
						<OPTION value="SHS">J 荆沙</OPTION>
						<OPTION value="JGS">J 井冈山</OPTION>
						<OPTION value="JDZ">J 景德镇</OPTION>
						<OPTION value="JIU">J 九江</OPTION>
						<OPTION value="JZH">J 九寨沟</OPTION>
						<OPTION value="CHW">J 酒泉</OPTION>
						<OPTION value="KHG">K 喀什</OPTION>
						<OPTION value="KRY">K 克拉玛依</OPTION>
						<OPTION value="KCA">K 库车</OPTION>
						<OPTION value="KRL">K 库尔勒</OPTION>
						<OPTION value="KMG">K 昆明</OPTION>
						<OPTION value="LXA">L 拉萨</OPTION>
						<OPTION value="LHW">L 兰州</OPTION>
						<OPTION value="LJG">L 丽江</OPTION>
						<OPTION value="LYG">L 连云港</OPTION>
						<OPTION value="LIA">L 梁平</OPTION>
						<OPTION value="LXI">L 林西</OPTION>
						<OPTION value="LNJ">L 临沧</OPTION>
						<OPTION value="LYI">L 临沂</OPTION>
						<OPTION value="LZH">L 柳州</OPTION>
						<OPTION value="LUZ">L 庐山</OPTION>
						<OPTION value="LZO">L 泸州</OPTION>
						<OPTION value="LYA">L 洛阳</OPTION>
						<OPTION value="NZH">M 满洲里</OPTION>
						<OPTION value="LUM">M 芒市</OPTION>
						<OPTION value="MXZ">M 梅县</OPTION>
						<OPTION value="MIG">M 绵阳</OPTION>
						<OPTION value="MDG">M 牡丹江</OPTION>
						<OPTION value="KHN">N 南昌</OPTION>
						<OPTION value="NAO">N 南充</OPTION>
						<OPTION value="NKG">N 南京</OPTION>
						<OPTION value="NNG">N 南宁</OPTION>
						<OPTION value="NTG">N 南通</OPTION>
						<OPTION value="NNY">N 南阳</OPTION>
						<OPTION value="NGB">N 宁波</OPTION>
						<OPTION value="PZI">P 攀枝花</OPTION>
						<OPTION value="NDG">Q 齐齐哈尔</OPTION>
						<OPTION value="IQM">Q 且末</OPTION>
						<OPTION value="SHP">Q 秦皇岛/山海关</OPTION>
						<OPTION value="TAO">Q 青岛</OPTION>
						<OPTION value="IQN">Q 庆阳</OPTION>
						<OPTION value="JUZ">Q 衢州</OPTION>
						<OPTION value="JJN">Q 泉州/晋江</OPTION>
						<OPTION value="SYX">S 三亚</OPTION>
						<OPTION value="SWA">S 汕头</OPTION>
						<OPTION value="SXJ">S 鄯善</OPTION>
						<OPTION value="SHA" >S 上海虹桥</OPTION>
						<OPTION value="PVG">S 上海浦东</OPTION>
						<OPTION value="SZX">S 深圳</OPTION>
						<OPTION value="SHE">S 沈阳</OPTION>
						<OPTION value="SJW">S 石家庄</OPTION>
						<OPTION value="SYM">S 思茅</OPTION>
						<OPTION value="SZV">S 苏州</OPTION>
						<OPTION value="TCG">T 塔城</OPTION>
						<OPTION value="TYN">T 太原</OPTION>
						<OPTION value="TSN">T 天津</OPTION>
						<OPTION value="TNH">T 通化</OPTION>
						<OPTION value="TGO">T 通辽</OPTION>
						<OPTION value="TEN">T 铜仁</OPTION>
						<OPTION value="WXN">W 万州</OPTION>
						<OPTION value="WEH">W 威海</OPTION>
						<OPTION value="WEF">W 潍坊</OPTION>
						<OPTION value="WNZ">W 温州</OPTION>
						<OPTION value="WUA">W 乌海</OPTION>
						<OPTION value="HLH">W 乌兰浩特</OPTION>
						<OPTION value="URC">W 乌鲁木齐</OPTION>
						<OPTION value="WUX">W 无锡</OPTION>
						<OPTION value="WHU">W 芜湖</OPTION>
						<OPTION value="WUZ">W 梧州</OPTION>
						<OPTION value="WUH">W 武汉</OPTION>
						<OPTION value="WUS">W 武夷山</OPTION>
						<OPTION value="XIY">X 西安</OPTION>
						<OPTION value="XIC">X 西昌</OPTION>
						<OPTION value="XNN">X 西宁</OPTION>
						<OPTION value="JHG">X 西双版纳</OPTION>
						<OPTION value="XIL">X 锡林浩特</OPTION>
						<OPTION value="XMN">X 厦门</OPTION>
						<OPTION value="XIG">X 香港</OPTION>
						<OPTION value="XFN">X 襄樊</OPTION>
						<OPTION value="XEN">X 兴城</OPTION>
						<OPTION value="XIN">X 兴宁</OPTION>
						<OPTION value="XNT">X 邢台</OPTION>
						<OPTION value="XUZ">X 徐州</OPTION>
						<OPTION value="YNT">Y 烟台</OPTION>
						<OPTION value="ENY">Y 延安</OPTION>
						<OPTION value="YNJ">Y 延吉</OPTION>
						<OPTION value="YNZ">Y 盐城</OPTION>
						<OPTION value="YIN">Y 伊宁</OPTION>
						<OPTION value="YBP">Y 宜宾</OPTION>
						<OPTION value="YIH">Y 宜昌</OPTION>
						<OPTION value="YIW">Y 义乌</OPTION>
						<OPTION value="INC">Y 银川</OPTION>
						<OPTION value="UYN">Y 榆林</OPTION>
						<OPTION value="YUA">Y 元谋</OPTION>
						<OPTION value="YCU">Y 运城</OPTION>
						<OPTION value="ZHA">Z 湛江</OPTION>
						<OPTION value="DYG">Z 张家界</OPTION>
						<OPTION value="ZAT">Z 昭通</OPTION>
						<OPTION value="CGO">Z 郑州</OPTION>
						<OPTION value="HSN">Z 舟山</OPTION>
						<OPTION value="ZUH">Z 珠海</OPTION>
						<OPTION value="ZYI">Z 遵义</OPTION>
					</SELECT></TD>
			</TR>
			<TR>
				<TD>
					<label style="WIDTH: 140px; HEIGHT: 37px">出发日期：</label></TD>
				<TD>
					<input type="text" id="txtArriveDate" size="12" value ="<%=System.DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")%>">&nbsp;&nbsp;<font color =red size=2>格式如：2010-05-01</font></TD>
			</TR>
			<TR>
				<TD>
					<label style="WIDTH: 140px; HEIGHT: 37px">航空公司：</label></TD>
				<TD>
					<select id="SearchFlight1_ddlCompany1" style="WIDTH:106px">
						<OPTION value="" selected>全部</OPTION>
						<OPTION value="CA">中国国际航空公司</OPTION>
						<OPTION value="OQ">重庆航空公司</OPTION>
						<OPTION value="CZ">中国南方航空公司</OPTION>
						<OPTION value="MU">中国东方航空公司</OPTION>
						<OPTION value="HU">海南航空公司</OPTION>
						<OPTION value="FM">上海航空公司</OPTION>
						<OPTION value="ZH">深圳航空公司</OPTION>
						<OPTION value="SC">山东航空公司</OPTION>
						<OPTION value="3U">四川航空公司</OPTION>
						<OPTION value="MF">厦门航空公司</OPTION>
						<OPTION value="KN">中国联合航空有限公司</OPTION>
						<OPTION value="BK">奥凯航空有限公司</OPTION>
						<OPTION value="EU">鹰联航空公司</OPTION>
						<OPTION value="8C">东星航空公司</OPTION>
						<OPTION value="8L">祥鹏航空公司</OPTION>
						<OPTION value="G5">华夏航空公司</OPTION>
						<OPTION value="HO">吉祥航空公司</OPTION>
						<OPTION value="GS">大新华快运航空公司</OPTION>
						<OPTION value="PN">西部航空公司</OPTION>
						<OPTION value="CN">大新华航空公司</OPTION>
						<OPTION value="NS">东北航空公司</OPTION>
						<OPTION value="JD">金鹿航空公司</OPTION>
					</select></TD>
			</TR>
			<TR>
				<TD>
					<label style="WIDTH: 140px; HEIGHT: 37px">出发时间：</label></TD>
				<TD>
					<select id="SearchFlight1_ddlStartTime1">
						<OPTION value="" selected>全部</OPTION>
						<OPTION value="00:00">00:00</OPTION>
						<OPTION value="06:00">06:00</OPTION>
						<OPTION value="09:00">09:00</OPTION>
						<OPTION value="12:00">12:00</OPTION>
						<OPTION value="15:00">15:00</OPTION>
						<OPTION value="18:00">18:00</OPTION>
						<OPTION value="21:00">21:00</OPTION>
					</select></TD>
			</TR>
			<TR>
				<TD colSpan="2" align ="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					<input type="button" value="查 询" id="btnSelect" onclick ="SelectFlightGo();" style="width:60px;margin-top:8px;padding-top:4px;"></TD>
			</TR>
		</TABLE>
    </div>
    </form>
</body>
</html>
