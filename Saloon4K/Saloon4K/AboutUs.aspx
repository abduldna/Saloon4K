<%@ Page Title="Salon 4K | About Us" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="Saloon4K.AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="content">
        <div class="aboutcontent">
            <div class="aboutleft">
                <div class="ribbon">
                    About Us</div>
                <p>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                    <br>
                    <br>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                    <br>
                    <br>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                    exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
                    irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
                    pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
                    deserunt mollit anim id est laborum.
                    <br>
                </p>
            </div>
            <div class="rowads">
                <div class="searchcontainer">
                    <div class="finder">
                        FINDER</div>
                    <div class="searhchtype">
                        <div class="radiotype">
                            <asp:RadioButton ID="rdbSaloon" runat="server" />
                            <span>SALON</span></div>
                        <div class="radiotype">
                            <asp:RadioButton ID="rdbDeal" runat="server" />
                            <span>DEAL</span></div>
                    </div>
                    <div class="searchrow">
                        <span>I AM LOOKING FOR</span><br />
                        <asp:TextBox ID="txtLookingFor" runat="server" CssClass="mainfield"></asp:TextBox>
                    </div>
                    <div class="searchrow">
                        <span>IN</span><br>
                        <asp:TextBox ID="txtLookingForIn" runat="server" CssClass="mainfield"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnSearch" runat="server" CssClass="searchbtn" Text="SEARCH" />
                </div>
                <div class="advt">
                    <asp:Image runat="server" ID="SingleImageRight" CssClass="verticalAdd" onmouseenter="MouseTracking(this.id);" />
                    <asp:HiddenField runat="server" ID="SingleImageRighthf" Value="" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
