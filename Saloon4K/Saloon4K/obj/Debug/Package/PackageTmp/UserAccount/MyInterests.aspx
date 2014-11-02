<%@ Page Title="Salon 4K | My Interests" Language="C#" MasterPageFile="~/UserAccount/Account.master"
    AutoEventWireup="true" CodeBehind="MyInterests.aspx.cs" Inherits="Saloon4K.UserAccount.MyInterests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContent" runat="server">
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#body_lnkMyInterests").addClass("current");
        });
    </script>
    <div class="webappright">
        <h2>
            My Interested Salons</h2>
        <div id="divMessage" runat="server" visible="False">
        </div>
        <ul class="booklist">
            <asp:Repeater runat="server" ID="rptBookedDeals" OnItemDataBound="rptBookedDeals_ItemDataBound"
                OnItemCommand="rptBookedDeals_ItemCommand">
                <ItemTemplate>
                    <li style="width: 638px;">
                        <asp:HiddenField runat="server" ID="hfImage" Value='<%# Eval("Image1") %>' />
                        <div class="bookpic">
                            <asp:Image runat="server" ID="imgImageDeal" Style="width: 120px; height: 120px;" />
                        </div>
                        <div class="bookname" style="width: 425px;">
                            <h2 id="lblNameDeal" runat="server">
                                <%# Eval("Name") %></h2>
                            <p id="lblDescriptionDeal" runat="server">
                                <%# Eval("Description") %>
                            </p>
                            <asp:HiddenField runat="server" ID="hfSalonId" Value='<%# Eval("SaloonId") %>' />
                            <asp:HiddenField runat="server" ID="hfUserId" Value='<%# Eval("UserId") %>' />
                        </div>
                        <div class="book">
                            <asp:ImageButton runat="server" ID="imgDeleteDeal" CommandName="Delete" CommandArgument='<%# Eval("UserBookedInterestedSaloonId") %>'
                                ImageUrl="~/images/delete.jpg" ToolTip="Delete from you favourite list" OnClientClick="return confirm('Are you sure you want to delete this item?')" />
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
