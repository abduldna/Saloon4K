<%@ Page Title="Salon Bookings" Language="C#" MasterPageFile="~/Moderator/Moderator.Master"
    AutoEventWireup="true" CodeBehind="SalonBookings.aspx.cs" Inherits="Saloon4K.Moderator.SalonBookings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cmsBody" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="block">
                    <div class="header">
                        <h2>
                            Deals Bookings</h2>
                    </div>
                    <div class="content controls">
                        <div role="grid" class="dataTables_wrapper">
                            <asp:UpdatePanel runat="server" ID="upUser">
                                <ContentTemplate>
                                    <table class="table table-bordered table-striped dataTable">
                                        <thead>
                                            <tr>
                                                <th>
                                                    Salon
                                                </th>
                                                <th>
                                                    User Name
                                                </th>
                                                <th>
                                                    Voucher
                                                </th>
                                                <th>
                                                    Points
                                                </th>
                                                <th>
                                                    Booking Date
                                                </th>
                                                <th>
                                                    Booking Time
                                                </th>
                                                <th>
                                                    Status
                                                </th>
                                                <th style="width: 5%; text-align: center;" colspan="2">
                                                    Action(s)
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater runat="server" ID="rptDeals" OnItemCommand="rptDeals_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <%# Saloon4kBLL.Utilities.Helper.GetSalonName(Convert.ToInt32(Eval("SaloonId")))%>
                                                        </td>
                                                        <td>
                                                            <%# Saloon4kBLL.Utilities.Helper.GetUserName(Convert.ToInt32(Eval("UserId")))%>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Voucher") ?? "N/A"%>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Points") ?? "N/A"%>
                                                        </td>
                                                        <td>
                                                            <%# Eval("BookingDate", "{0:d}")%>
                                                        </td>
                                                        <td>
                                                            <%# Eval("BookingTime") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Status")??"N/A" %>
                                                        </td>
                                                        <td class="aligncenter">
                                                            <asp:ImageButton runat="server" ID="btnDelete" CommandArgument='<%# Eval("SaloonId") %>'
                                                                CommandName="Confirm" ToolTip="Confirm" ImageUrl="img/edit.png" CssClass="width45"
                                                                OnClientClick="return confirm('Are you sure you want to confirm this salon booking?')" />
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                    <div class="dataTables_info" id="DataTables_Table_2_info">
                                        Showing 1 to 5 of 10 entries</div>
                                    <div class="dataTables_paginate paging_full_numbers" id="DataTables_Table_2_paginate">
                                        <a class="first paginate_button paginate_button_disabled" tabindex="0" id="DataTables_Table_2_first">
                                            First</a><a class="previous paginate_button paginate_button_disabled" tabindex="0"
                                                id="DataTables_Table_2_previous">Previous</a><span><a class="paginate_active" tabindex="0">1</a><a
                                                    class="paginate_button" tabindex="0">2</a></span><a class="next paginate_button"
                                                        tabindex="0" id="DataTables_Table_2_next">Next</a><a class="last paginate_button"
                                                            tabindex="0" id="DataTables_Table_2_last">Last</a></div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
