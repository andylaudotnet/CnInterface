<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SmpApiSend.aspx.cs" Inherits="CnWeb.SmsOnline.SmpApiSend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <center>
    <div>
        <asp:TextBox ID="txtPhone" runat="server"  Width="217px"></asp:TextBox><br />
        <asp:TextBox ID="txtMessage" runat="server" Height="133px" TextMode="MultiLine"  Width="417px"></asp:TextBox><br />
        <asp:Button ID="btnSend" runat="server" onclick="btnSend_Click" Text="发  送" /><br />
        <asp:Label ID="labResult" runat="server"></asp:Label>
    </div>
    </center>
    </form>
</body>
</html>
