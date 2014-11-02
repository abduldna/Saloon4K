<%@ Page Title="Sarah Beauty | Directory" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Directory.aspx.cs" Inherits="Saloon4K.Directory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/stylesToggle.css" rel="stylesheet" type="text/css" />
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
            <div class="dircontainer w">
                <div id="divMessage" runat="server" visible="False">
                </div>
                <div class="ribbonDirectory">
                    <span style="float: left;">Directory </span><span class="options" style="float: right;
                        width: 170px;"><span style="color: white; font-size: 13px; float: left; width: 124px;
                            text-align: left; margin-top: 7px;">Switch Options: </span><a href="#" id="details-list"
                                class="sorticon active" title="List View">
                                <img src="images/details-list.png" title="Details View" alt="list"></a>
                        <a href="#" id="thumbnails-list" class="sorticon" title="Thumbnail View">
                            <img src="images/thumbnails-list.png" alt="thumbnails"></a> </span>
                </div>
                <div class="dirrow" id="content">
                    <ul id="listdisplay" style="margin-top: 20px;">
                        <asp:Repeater runat="server" ID="rptCategories" OnItemCommand="rptCategories_ItemCommand">
                            <ItemTemplate>
                                <li>
                                    <asp:LinkButton runat="server" ID="lnkSaloons" CommandArgument='<%# Eval("CategoryId") %>'
                                        CommandName="Details" Style="float: left;">
                                        <asp:Image runat="server" ID="imgCategoryImage" ImageUrl='<%# ConfigurationManager.AppSettings["SiteUrl"]+"Uploads/Categories/"+Eval("Image") %>' />
                                    </asp:LinkButton>
                                    <span class="innercontent" style="float: left; width: 350px;">
                                        <h5 class="h5">
                                            <asp:Label runat="server" ID="lblName" Text='<%# Eval("Name") %>'></asp:Label>
                                        </h5>
                                        <p>
                                            <%# Eval("Description") %></p>
                                    </span></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="leaderboard" style="float: left; margin: 25px auto 10px 115px; display: none;">
                    <img alt="advertisement" src="images/leaderboard.jpg" />
                </div>
            </div>
        </div>
        <script type="text/javascript">
            $(function () {
                $('.options a').on('click', function (e) {
                    e.preventDefault();

                    if ($(this).hasClass('active')) {
                        // do nothing if the clicked link is already active
                        return;
                    }

                    $('.options a').removeClass('active');
                    $(this).addClass('active');

                    var clickid = $(this).attr('id');


                    $('#listdisplay').fadeOut(240, function () {
                        if (clickid == 'thumbnails-list') {
                            $(this).addClass('thumbview');
                        } else {
                            $(this).removeClass('thumbview');
                        }

                        $('#listdisplay').fadeIn(200);
                    });
                });
            });
</script>
</asp:Content>
