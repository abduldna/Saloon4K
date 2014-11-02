<%@ Page Title="Add Type" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddType.aspx.cs" Inherits="Saloon4K.AddType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="content">
        <div class="homecontent mtop10">
            <a runat="server" href="AddManagement.aspx" title="Purchase add for web app">
                <img runat="server" src="~/images/webapps.png" alt="web apps" style="margin: 65px 0 0 85px;
                    float: left;" />
            </a><a runat="server" href="AddManagementForMobile.aspx" title="Purchase add for mobile app">
                <img runat="server" src="~/images/mob-apps.png" alt="web apps" />
            </a>
        </div>
    </div>
</asp:Content>
