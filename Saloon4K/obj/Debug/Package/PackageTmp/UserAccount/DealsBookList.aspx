<%@ Page Title="Sarah Beauty | Deals Booklist" Language="C#" MasterPageFile="~/UserAccount/Account.master"
    AutoEventWireup="true" CodeBehind="DealsBookList.aspx.cs" Inherits="Saloon4K.UserAccount.DealsBookList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContent" runat="server">
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#body_lnkMyBooklist").addClass("current");
        });
    </script>
    <div class="webappright">
        <h2>
            My Booklist</h2>
        <div id="divMessage" runat="server" visible="False">
        </div>
        <ul class="booklist">
            <asp:Repeater runat="server" ID="rptBookedDeals" OnItemDataBound="rptBookedDeals_ItemDataBound"
                OnItemCommand="rptBookedDeals_ItemCommand">
                <ItemTemplate>
                    <li>
                        <asp:HiddenField runat="server" ID="hfImage" Value='<%# Eval("Image") %>' />
                        <div class="bookpic">
                            <asp:Image runat="server" ID="imgImageDeal" Style="width: 120px; height: 120px;" />
                        </div>
                        <div class="bookname">
                            <h2 id="lblNameDeal" runat="server">
                                <%# Eval("Name") %></h2>
                            <p id="lblDescriptionDeal" runat="server">
                                <%# Eval("Description") %>
                            </p>
                            <asp:HiddenField runat="server" ID="hfDealId" Value='<%# Eval("DealId") %>' />
                            <asp:HiddenField runat="server" ID="hfUserId" Value='<%# Eval("UserId") %>' />
                        </div>
                        <div class="book">
                            <asp:Button runat="server" ID="lnkBookDelete" CommandName="Delete" ToolTip="Delete" CommandArgument='<%# Eval("UserFavouriteBookedDealId") %>'
                                OnClientClick="return confirm('Are you sure you want to delete this item?')"
                                Text="REMOVE" Style="background-color: #E02760; border: none; color: white; padding: 5px;
                                width: 80px;" />
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
