<%@ Page Title="Categories Management" Language="C#" MasterPageFile="~/Moderator/Moderator.Master"
    AutoEventWireup="true" CodeBehind="PointsManagement.aspx.cs" Inherits="Saloon4K.Moderator.PointsManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cmsBody" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="block">
                    <div class="header">
                        <div id="divMessage" runat="server" visible="False" style="padding: 3px;">
                        </div>
                    </div>
                    <div class="content controls">
                        <div class="form-row">
                            <div class="divControl">
                                <label>
                                    Category Name:</label>
                                <asp:HiddenField runat="server" ID="hfPointId" Value="0" />
                                <asp:DropDownList runat="server" ID="ddlPointsFor" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfddlPointsFor" ControlToValidate="ddlPointsFor"
                                    InitialValue="0" Display="Dynamic" ErrorMessage="Required" ValidationGroup="ValidateControls"
                                    CssClass="required"></asp:RequiredFieldValidator>
                            </div>
                            <div class="divControl">
                                <label>
                                    Points:</label>
                                <asp:TextBox runat="server" ID="txtPoints" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rftxtPoints" ControlToValidate="txtPoints"
                                    Display="Dynamic" ErrorMessage="Required" ValidationGroup="ValidateControls"
                                    CssClass="required"></asp:RequiredFieldValidator>
                            </div>
                            <div class="divControl">
                                <asp:LinkButton Visible="False" runat="server" ID="lnkSave" CssClass="widget-icon widget-icon-medium"
                                    Style="float: left; margin-bottom: 10px; margin-top: 25px;" OnClick="lnkSave_Click"
                                    ValidationGroup="ValidateControls"><span class="icon-save"></span></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="block">
                    <div class="header">
                        <h2>
                            Points Management</h2>
                    </div>
                    <div class="content">
                        <div role="grid" class="dataTables_wrapper">
                            <table class="table table-bordered table-striped dataTable">
                                <thead>
                                    <tr>
                                        <th>
                                            ID
                                        </th>
                                        <th>
                                            Points For
                                        </th>
                                        <th>
                                            Points
                                        </th>
                                        <th>
                                            Added Date
                                        </th>
                                        <th style="width: 5%; text-align: center;" colspan="2">
                                            Action(s)
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater runat="server" ID="rptContent" OnItemCommand="rptContent_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <%# Eval("PointsId") %>
                                                </td>
                                                <td>
                                                    <%# Eval("PointsFor") %>
                                                </td>
                                                <td>
                                                    <%# Eval("PointsCount") %>
                                                </td>
                                                <td>
                                                    <%# Eval("AddedDate","{0:d}") %>
                                                </td>
                                                <td class="aligncenter">
                                                    <asp:ImageButton runat="server" ID="btnEdit" CommandArgument='<%# Eval("PointsId") %>'
                                                        CommandName="Edit" ImageUrl="img/edit.png" CssClass="width45" ToolTip="Edit" />
                                                </td>
                                                <td class="aligncenter">
                                                    <asp:ImageButton Visible='<%#TablePermission=="E" %>' runat="server" ID="btnDelete"
                                                        CommandArgument='<%# Eval("PointsId") %>' CommandName="Delete" ToolTip="Delete"
                                                        ImageUrl="img/delete.png" CssClass="width45" OnClientClick="return confirm('Are you sure you want to delete this Point?')" />
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
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
