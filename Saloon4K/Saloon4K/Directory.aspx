<%@ Page Title="Salon 4K | Directory" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Directory.aspx.cs" Inherits="Saloon4K.Directory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .dirrow
        {
            float: left;
            margin: 0;
            width: 670px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="content">
        <div class="directorycontent">
            <div class="adarealeft">
                <div class="ads320">
                    <asp:Image runat="server" ID="imgLeft1" CssClass="directoryAdd" onmouseenter="MouseTracking(this.id);" />
                    <asp:HiddenField runat="server" ID="imgLeft1hf" Value="" />
                </div>
                <div class="ads320">
                    <asp:Image runat="server" ID="imgLeft2" CssClass="directoryAdd" onmouseenter="MouseTracking(this.id);" />
                    <asp:HiddenField runat="server" ID="imgLeft2hf" Value="" />
                </div>
                <div class="ads320">
                    <asp:Image runat="server" ID="imgLeft3" CssClass="directoryAdd" onmouseenter="MouseTracking(this.id);" />
                    <asp:HiddenField runat="server" ID="imgLeft3hf" Value="" />
                </div>
            </div>
            <div class="dircontainer">
                <div id="divMessage" runat="server" visible="False">
                </div>
                <div class="ribbonDirectory">
                    Directory</div>
                <h5>
                    &nbsp;</h5>
                <div class="dirrow">
                    <asp:Repeater runat="server" ID="rptCategories" OnItemCommand="rptCategories_ItemCommand">
                        <ItemTemplate>
                            <div class="divCategories">
                                <asp:LinkButton runat="server" ID="lnkSaloons" CommandArgument='<%# Eval("CategoryId") %>'
                                    CommandName="Details">
                                    <asp:Image runat="server" ID="imgCategoryImage" ImageUrl='<%# ConfigurationManager.AppSettings["SiteUrl"]+"Uploads/Categories/"+Eval("Image") %>' />
                                    <div class="DirectoryTitle">
                                        <asp:Label runat="server" ID="lblName" Text='<%# Eval("Name") %>'></asp:Label>
                                    </div>
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="leaderboard" style="float: left; margin: 25px auto 10px 115px; display: none;">
                <img alt="advertisement" src="images/leaderboard.jpg" />
            </div>
        </div>
    </div>
</asp:Content>
