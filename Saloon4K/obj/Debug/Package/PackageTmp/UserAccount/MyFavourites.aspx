<%@ Page Title="Sarah Beauty | My Favourites" Language="C#" MasterPageFile="~/UserAccount/Account.master"
    AutoEventWireup="true" CodeBehind="MyFavourites.aspx.cs" Inherits="Saloon4K.UserAccount.MyFavourites" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContent" runat="server">
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#body_lnkMyFavourites").addClass("current");
        });
    </script>
    <div class="webappright">
        <h2>
            My Favorites</h2>
        <div id="divMessage" runat="server" visible="False">
        </div>
        <ul class="favlist">
            <asp:Repeater runat="server" ID="rptFavouriteDeals" OnItemDataBound="rptFavouriteDeals_ItemDataBound"
                OnItemCommand="rptFavouriteDeals_ItemCommand">
                <ItemTemplate>
                    <li style="width: 638px;">
                        <asp:HiddenField runat="server" ID="hfImage" Value='<%# Eval("Image") %>' />
                        <div class="favpic">
                            <asp:Image runat="server" ID="imgImageDeal" Style="width: 120px; height: 120px;" />
                        </div>
                        <div class="favname" style="width: 425px;">
                            <h2 id="lblNameDeal" runat="server">
                                <%# Eval("Name") %></h2>
                            <p id="lblDescriptionDeal" runat="server">
                                <%# Eval("Description") %>
                            </p>
                            <asp:HiddenField runat="server" ID="hfDealId" Value='<%# Eval("DealId") %>' />
                            <asp:HiddenField runat="server" ID="hfUserId" Value='<%# Eval("UserId") %>' />
                        </div>
                        <div class="delete">
                            <asp:ImageButton runat="server" ID="imgDeleteDeal" CommandName="Delete" CommandArgument='<%# Eval("UserFavouriteBookedDealId") %>'
                                ImageUrl="~/images/delete.jpg" ToolTip="Delete from you favourite list" OnClientClick="return confirm('Are you sure you want to delete this item?')" />
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
