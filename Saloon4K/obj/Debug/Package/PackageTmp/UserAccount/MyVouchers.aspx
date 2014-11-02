<%@ Page Title="My Vouchers" Language="C#" MasterPageFile="~/UserAccount/Account.master"
    AutoEventWireup="true" CodeBehind="MyVouchers.aspx.cs" Inherits="Saloon4K.UserAccount.MyVouchers" %>

<%@ Import Namespace="Saloon4kBLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AccountContent" runat="server">
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#body_lnkMyVouchers").addClass("current");
        });
    </script>
    <style type="text/css">
        .floatLeft
        {
            float: left;
        }
        .clr
        {
            clear: both;
        }
        .bookname
        {
            width: 485px !important;
        }
    </style>
    <div class="webappright">
        <h2>
            My Vouchers</h2>
        <div id="divMessage" runat="server" visible="False">
        </div>
        <ul class="booklist">
            <asp:Repeater runat="server" ID="rptBookedDeals" OnItemCommand="rptBookedDeals_ItemCommand">
                <ItemTemplate>
                    <li>
                        <div class="bookname">
                            <h2 id="lblNameDeal" runat="server">
                                <%# Eval("Voucher") %></h2>
                            <span class="floatLeft">Booked For:
                                <%# Eval("EntityType")%></span> <span class="floatLeft clr">Name:
                                    <%# Eval("EntityType").ToString()=="DEAL"?Utilities.Helper.GetDealName(Convert.ToInt32(Eval("EntityId"))):Utilities.Helper.GetSalonName(Convert.ToInt32(Eval("EntityId"))) %></span>
                            <span class="floatLeft clr">Generated Date:
                                <%# Eval("GeneratedDate","{0:d}") %>
                            </span>
                        </div>
                        <div class="book">
                            <asp:Button runat="server" ID="lnkBookDelete" CommandName="Delete" ToolTip="Delete"
                                CommandArgument='<%# Eval("UserVoucherId") %>' OnClientClick="return confirm('Are you sure you want to delete this item?')"
                                Text="REMOVE" Style="background-color: #E02760; border: none; color: white; padding: 5px;
                                width: 80px;" />
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
