<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Saloon4K.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Confirm Your Location</title>
    <link href="css/bravado.css" rel="stylesheet" type="text/css" />
    <link href="css/CountryLocation.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin: 0; padding: 0;">
    <form id="form1" runat="server">
    <div class="header">
        <div class="headercontainer">
            <div class="logo">
                <a href="~/Default.aspx" runat="server">
                    <img src="~/images/salon4k.png" alt="SALON 4K" runat="server" /></a>
            </div>
        </div>
    </div>
    <div class="divMain">
        <h3 style="font-family: calibri; color: #2A2A2A; padding: 0;">
            Select your country</h3>
        <div class="divCountry">
            <asp:LinkButton runat="server" ID="lnkBahrain" OnClick="lnkBahrain_Click">
            <img src="images/HomeBahrain.png" alt="Bahrain" />
            <label>Bahrain</label>
            </asp:LinkButton>
        </div>
        <div class="divCountry">
            <asp:LinkButton runat="server" ID="lnkKuwait" OnClick="lnkKuwait_Click">
            <img src="images/HomeKuwait.png" alt="Kuwait" />
            <label>Kuwait</label>
            </asp:LinkButton>
        </div>
        <div class="divCountry">
            <asp:LinkButton runat="server" ID="lnkOman" OnClick="lnkOman_Click">
            <img src="images/HomeOman.png" alt="Oman" />
            <label>Oman</label>
            </asp:LinkButton>
        </div>
        <div class="divCountry">
            <asp:LinkButton runat="server" ID="lnkQatar" OnClick="lnkQatar_Click">
            <img src="images/HomeQatar.png" alt="Qatar" />
            <label>Qatar</label>
            </asp:LinkButton>
        </div>
        <div class="divCountry">
            <asp:LinkButton runat="server" ID="lnkSaudiArabia" OnClick="lnkSaudiArabia_Click">
            <img src="images/HomeSaudi.png" alt="Saudi Arabia" />
            <label>Saudi Arabia</label>
            </asp:LinkButton>
        </div>
        <div class="divCountry">
            <asp:LinkButton runat="server" ID="lnkUae" OnClick="lnkUae_Click">
            <img src="images/HomeUAE.png" alt="UAE" />
            <label>UAE</label>
            </asp:LinkButton>
        </div>
    </div>
    </form>
</body>
</html>
