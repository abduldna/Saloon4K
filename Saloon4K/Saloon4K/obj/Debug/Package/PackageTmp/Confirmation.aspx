<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Confirmation.aspx.cs" Inherits="Saloon4K.Confirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            var timer;
            $("#thumbs").mouseenter(function () {
                var that = this;
                timer = setTimeout(function () {
                    //$('#thumbs').removeClass('hovered');
                    //$(that).addClass('hovered');
                    alert("A");
                }, 3000);
            }).mouseleave(function () {
                clearTimeout(timer);
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="divMessage" runat="server" visible="False" style="margin-bottom: 50px; margin-left: 470px;
        margin-top: 50px; text-align: center; width: 50%;">
    </div>
    <div id="thumbs" style="display: none;">
        this is ok!
    </div>
</asp:Content>
