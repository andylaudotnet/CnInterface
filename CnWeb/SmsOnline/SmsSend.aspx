<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SmsSend.aspx.cs" Inherits="CnWeb.SmsOnline.SmsSend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>�������߷���</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta name="keywords" content="����,���ŷ���,�������߷���,�ֻ�����,�ֻ����ŷ���,�ֻ��������߷���,����,���ŵ�¼,���Ŷ���,���ź���,�ӿ�,interface,���½ӿ�,�ӿ�����,����ӿ�,����ӿ�,webservice�ӿ�,http�ӿ�,ActiveX dll�ӿ�,��ͨdll�ӿ�,���ݿ�ӿ�,��һҳ����,��ҳ����,��������,google,�ٶ�,�Ż�,bing,�ѹ�,����,�е�." />
     <style type="text/css">
             .ButtonCss
            {
                BACKGROUND-COLOR:#ffffff; BORDER-RIGHT: #A9BAC9 1px solid; PADDING-RIGHT: 8px; BORDER-TOP: #A9BAC9 1px solid; PADDING-LEFT: 8px; FONT-SIZE: 12px;  BORDER-LEFT: #A9BAC9 1px solid; CURSOR: hand; COLOR: #666699; font-weight:bold; PADDING-TOP: 4px; PADDING-BOTTOM: 2px;BORDER-BOTTOM: #A9BAC9 1px solid;
            }
            .text_dialog1,.text_dialog2 {height:19px; line-height:19px; border:1px solid #A9BAC9; padding:0 2px; font-size:12px;font-weight:bold; COLOR: #666699;  }
            .text_dialog2 { border:1px solid #9ECC00;COLOR: #666699; }
           a:link {text-decoration:none;color:#666699;}	/* δ���ʵ����� */
         a:visited {text-decoration:none;color:#666699}	/* �ѷ��ʵ����� */
         a:hover {text-decoration:underline; color:#666699; }	/* ����ƶ��������� */
         a:active {text-decoration:underline;color:#666699}	/* ѡ�������� */
            #loader_container {
	    Z-INDEX: 10; LEFT: 0px; WIDTH: 100%; POSITION: absolute; TOP: 35%; TEXT-ALIGN: center
    } 
        #loader {
	    BORDER-RIGHT: #5a667b 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #5a667b 1px solid; DISPLAY: block; PADDING-LEFT: 5px; FONT-SIZE: 11px; Z-INDEX: 2; PADDING-BOTTOM: 5px; MARGIN: 0px auto; BORDER-LEFT: #5a667b 1px solid; WIDTH: 333px; COLOR: #000000; PADDING-TOP: 5px; BORDER-BOTTOM: #5a667b 1px solid; FONT-FAMILY: Tahoma, Helvetica, sans; BACKGROUND-COLOR:#ffffff; TEXT-ALIGN: left
    }   
    </style>
    <script language="javascript" src="js/smssend.js" type ="text/javascript"></script>
    <link href="../css/base.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table id="tabSmsNormal" border="0" cellpadding ="1" cellspacing ="1"  bgcolor="#e5e3df" width="214px" height="336px">
                                        <tr><td colspan="2" height="10px"></td></tr>
                                        <tr>
                                            <td rowspan="7" width="12px"></td>
                                            <td ><font size="2"><b>�ֻ��������߷��ͣ�</b></font></td>
                                            </tr>
                                        <tr>
                                            <td><input type="hidden" id="hiddenUsername"  runat="server"/><font color=black size=2>�����ֻ��ţ�</font>
                                         </tr>
                                          <tr>
                                            <td>
                                            <asp:TextBox ID="txtSmsmob"  runat="server"  Width="172px" BackColor="#ffffff" MaxLength="11"   class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  ></asp:TextBox></td>
                                       </tr>
                                       <tr><td >
                                                  <font color=black size=2>�������ݣ�</font>
                                                <asp:TextBox ID="txtSms" runat="server" TextMode="MultiLine" Height="90px" Width="172px" MaxLength="100"  class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'"  ></asp:TextBox></td>
                                        </tr>
                                         <tr><td > <font color=black size=2>������������</font></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtsenduser" runat="server"  Width="70px" BackColor="#ffffff"  MaxLength="10"  class="text_dialog1" onmouseover="this.className='text_dialog2'" onMouseOut="this.className='text_dialog1'" ></asp:TextBox><font color="#666699" size="2">(���ĸ�ʽ)</font>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                    <table  width ="100%" border="0" cellpadding ="6" cellspacing ="1">
                                                                  <tr>
                                                                    <td  align="center">
                                                                        <asp:Button  CssClass="ButtonCss"  ID="bntSendNote"    runat="server" Text="���Ͷ���" onclick="bntSendNote_Click"   OnClientClick="return checkparames();"/></td>
                                                                </tr>
                                                                <tr >
                                                                    <td align="left" height="60px" valign="top">
                                                                        <asp:Label ID="labresult" runat="server" Text="" ForeColor="Red"  style="padding-top:expression(document.body.clientHeight/2)"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                    </table>
                                            </td>
                                        </tr>
          </table>
    </div>
    </form>
</body>
</html>
