<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceTest.aspx.cs" Inherits="Saloon4K.ServiceTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding: 35px;">
        <div id="divMessage" runat="server" visible="False">
        </div>
        <asp:TextBox runat="server" ID="txtDeviceId" Style="width: 700px; padding: 5px;" />
        <asp:Button runat="server" ID="btnSend" Text="Send" OnClick="btnSend_Click" />
    </div>
    </form>
</body>
</html>
