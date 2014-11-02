<%@ Page Title="Adds Search" Language="C#" MasterPageFile="~/Moderator/Moderator.Master"
    AutoEventWireup="true" CodeBehind="AddsSearch.aspx.cs" Inherits="Saloon4K.Moderator.AddsSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cmsBody" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="block">
                    <div class="header">
                        <h2>
                            Adds Management</h2>
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
                                                    Name
                                                </th>
                                                <th>
                                                    Email
                                                </th>
                                                <th>
                                                    Phone
                                                </th>
                                                <th>
                                                    Image
                                                </th>
                                                <th>
                                                    Alignment
                                                </th>
                                                <th>
                                                    Start Date
                                                </th>
                                                <th>
                                                    End Date
                                                </th>
                                                <th>
                                                    Page Name
                                                </th>
                                                <th>
                                                    Status
                                                </th>
                                                <th style="width: 5%; text-align: center;">
                                                    Activate
                                                </th>
                                                <th style="width: 5%; text-align: center;">
                                                    Delete
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater runat="server" ID="rptAdds" OnItemCommand="rptAdds_ItemCommand" OnItemDataBound="rptAdds_ItemDataBound">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <%# GetUserName(Eval("UserId"))%>
                                                        </td>
                                                        <td>
                                                            <%# GetEmail(Eval("UserId"))%>
                                                        </td>
                                                        <td>
                                                            <%# GetPhone(Eval("UserId"))%>
                                                        </td>
                                                        <td>
                                                            <asp:Image runat="server" ID="imgImage" ImageUrl='<%# ConfigurationManager.AppSettings["SiteUrl"]+"Uploads/Adds/"+Eval("Image1") %>'
                                                                Style="width: 100px; height: 100px;" />
                                                        </td>
                                                        <td>
                                                            <%# Eval("Alignment1") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("StartDate","{0:d}") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("EndDate", "{0:d}")%>
                                                        </td>
                                                        <td>
                                                            <%# Eval("PageName")%>
                                                        </td>
                                                        <td style="width: 10%;">
                                                            <asp:Label runat="server" ID="lblAddStatus" Text='<%# Eval("AddStatus") %>'></asp:Label>
                                                        </td>
                                                        <td class="aligncenter">
                                                            <asp:ImageButton runat="server" ID="btnActivate" CommandArgument='<%# Eval("AddsManagementId") %>'
                                                                CommandName="Activate" ImageUrl="img/edit.png" CssClass="width45" OnClientClick="return confirm('Are you sure you want to activate this add?')" />
                                                        </td>
                                                        <td class="aligncenter">
                                                            <asp:ImageButton runat="server" ID="btnDelete" CommandArgument='<%# Eval("AddsManagementId") %>'
                                                                CommandName="Delete" ImageUrl="img/delete.png" CssClass="width45" OnClientClick="return confirm('Are you sure you want to delete this add?')" />
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
