<%@ Page Title="Deals Management" Language="C#" MasterPageFile="~/Moderator/Moderator.Master"
    AutoEventWireup="true" CodeBehind="SearchDeals.aspx.cs" Inherits="Saloon4K.Moderator.SearchDeals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cmsBody" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="block">
                    <a class="btn btn-default btn-block btn-clean btnAddNew" href="~/Moderator/AddEditDeals.aspx"
                        runat="server">ADD DEAL</a>
                    <div class="header">
                        <h2>
                            Deals Management</h2>
                    </div>
                    <div class="content controls">
                        <div class="form-row">
                            <div id="divMessage" runat="server" visible="False">
                            </div>
                            <div class="divControl">
                                <label>
                                    Country</label>
                                <asp:DropDownList runat="server" ID="ddlCountry" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"
                                    CssClass="width225" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div role="grid" class="dataTables_wrapper">
                            <asp:UpdatePanel runat="server" ID="upUser">
                                <ContentTemplate>
                                    <table class="table table-bordered table-striped dataTable">
                                        <thead>
                                            <tr>
                                                <th>
                                                    ID
                                                </th>
                                                <th>
                                                    Name
                                                </th>
                                                <th>
                                                    Description
                                                </th>
                                                <th>
                                                    Featured
                                                </th>
                                                <th>
                                                    Area of Deal
                                                </th>
                                                <th>
                                                    Country
                                                </th>
                                                <th style="width: 5%; text-align: center;">
                                                    Edit
                                                </th>
                                                <th style="width: 5%; text-align: center;">
                                                    Delete
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater runat="server" ID="rptDeals" OnItemCommand="rptDeals_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <%# Eval("DealId") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Name") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Description") %>
                                                        </td>
                                                        <td class="aligncenter">
                                                            <asp:Image runat="server" ID="imgFeatured" Style="width: 32px;" ImageUrl="img/featured.png"
                                                                Visible='<%# IsFeaturedValue(Eval("IsFeatured")) %>' />
                                                        </td>
                                                        <td>
                                                            <%# Eval("AreaOfDeal") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Country") %>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton runat="server" ID="btnEdit" CommandArgument='<%# Eval("DealId") %>'
                                                                CommandName="Edit" ImageUrl="img/edit.png" CssClass="width45" />
                                                        </td>
                                                        <td class="aligncenter">
                                                            <asp:ImageButton runat="server" ID="btnDelete" CommandArgument='<%# Eval("DealId") %>'
                                                                CommandName="Delete" ImageUrl="img/delete.png" CssClass="width45" OnClientClick="return confirm('Are you sure you want to delete this deal?')" />
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
