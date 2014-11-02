<%@ Page Title="Salon 4K | My Avatar" Language="C#" MasterPageFile="~/UserAccount/Account.master"
    AutoEventWireup="true" CodeBehind="MyAvatar.aspx.cs" Inherits="Saloon4K.UserAccount.MyAvatar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContent" runat="server">
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#body_lnkMyAvatar").addClass("current");
        });
    </script>
    <div class="displaycontainer">
        <div class="avatarimage">
            <img src="~/images/avatarimage.jpg" alt="avatarimage" runat="server" />
        </div>
        <div class="colorbtn">
            COLOR
        </div>
        <div id="Expandable">
        </div>
    </div>
    <div class="librarycontainer">
        <div class="libraryhead">
            LIBRARY</div>
        <ul class="hairselecter">
            <li>
                <img src="~/images/hair1.jpg" alt="hairstyle 1" runat="server" runat="server" /></li>
            <li>
                <img src="~/images/hair1.jpg" alt="hairstyle 1" runat="server" /></li>
            <li>
                <img src="~/images/hair1.jpg" alt="hairstyle 1" runat="server" /></li>
            <li>
                <img src="~/images/hair1.jpg" alt="hairstyle 1" runat="server" /></li>
            <li>
                <img src="~/images/hair1.jpg" alt="hairstyle 1" runat="server" /></li>
            <li>
                <img src="~/images/hair1.jpg" alt="hairstyle 1" runat="server" /></li>
            <li>
                <img src="~/images/hair1.jpg" alt="hairstyle 1" runat="server" /></li>
            <li>
                <img src="~/images/hair1.jpg" alt="hairstyle 1" runat="server" /></li>
            <li>
                <img src="~/images/hair1.jpg" alt="hairstyle 1" runat="server" /></li>
            <li>
                <img src="~/images/hair1.jpg" alt="hairstyle 1" runat="server" /></li>
            <li>
                <img src="~/images/hair1.jpg" alt="hairstyle 1" runat="server" /></li>
            <li>
                <img src="~/images/hair1.jpg" alt="hairstyle 1" runat="server" /></li>
        </ul>
        <div class="pages">
            <span class="pageno">1/2</span>
        </div>
        <div class="edit">
            <a href="#">EDIT</a></div>
        <div class="move">
            <div class="top">
                <img src="~/images/move_top.png" alt="move_top" runat="server" /></div>
            <div class="down">
                <img src="~/images/move_bottom.png" alt="move_bottom" runat="server" /></div>
            <span>MOVE</span>
        </div>
    </div>
    <div class="customface">
        <ul>
            <li>face</li>
            <li>eyes</li>
            <li>nose</li>
            <li>mouth</li>
            <li>ears</li>
            <li>hair</li>
            <li>clothes</li>
            <li>stuffs</li>
            <li>Background</li>
            <li>make up</li>
        </ul>
    </div>
</asp:Content>
