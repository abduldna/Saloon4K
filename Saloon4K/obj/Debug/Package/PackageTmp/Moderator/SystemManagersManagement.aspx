<%@ Page Title="System Managers" Language="C#" MasterPageFile="~/Moderator/Moderator.Master"
    AutoEventWireup="true" CodeBehind="SystemManagersManagement.aspx.cs" Inherits="Saloon4K.Moderator.SystemManagersManagement" %>

<%@ Import Namespace="Saloon4kBLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cmsBody" runat="server">
    <asp:UpdatePanel runat="server" ID="upUser">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="block">
                            <div class="header">
                                <h3 style="margin-top: 10px;">
                                    Manage System Managers
                                </h3>
                            </div>
                            <div class="content controls">
                                <div class="form-row" style="margin-top: 55px;">
                                    <div id="divMessage" runat="server" visible="False">
                                    </div>
                                    <div class="divControl">
                                        <label>
                                            Country:</label>
                                        <asp:DropDownList runat="server" ID="ddlCountry" AutoPostBack="True" CssClass="form-control"
                                            OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" />
                                        <asp:RequiredFieldValidator runat="server" ID="rfddlCountry" ControlToValidate="ddlCountry"
                                            Display="Dynamic" ErrorMessage="Required" ValidationGroup="ValidateControls"
                                            InitialValue="0" CssClass="required"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="divControl">
                                        <label>
                                            Salon:</label>
                                        <asp:DropDownList runat="server" ID="ddlSalon" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" ID="rfvddlSalon" ControlToValidate="ddlSalon"
                                            Display="Dynamic" ErrorMessage="Required" ValidationGroup="ValidateControls"
                                            InitialValue="0" CssClass="required"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="divControl clr">
                                        <label>
                                            Name:</label>
                                        <asp:TextBox runat="server" ID="txtName" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="rftxtName" ControlToValidate="txtName"
                                            Display="Dynamic" ErrorMessage="Required" ValidationGroup="ValidateControls"
                                            CssClass="required"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="divControl">
                                        <label>
                                            Email:</label>
                                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="rftxtEmail" ControlToValidate="txtEmail"
                                            Display="Dynamic" ErrorMessage="Required" ValidationGroup="ValidateControls"
                                            CssClass="required"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="divControl">
                                        <label>
                                            Password:</label>
                                        <asp:TextBox runat="server" ID="txtpassword" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="rftxtpassword" ControlToValidate="txtpassword"
                                            Display="Dynamic" ErrorMessage="Required" ValidationGroup="ValidateControls"
                                            CssClass="required"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="divControl">
                                        <label>
                                            Confirm Password:</label>
                                        <asp:TextBox runat="server" ID="txtConfirmPassword" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="rftxtConfirmPassword" ControlToValidate="txtConfirmPassword"
                                            Display="Dynamic" ErrorMessage="Required" ValidationGroup="ValidateControls"
                                            CssClass="required"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator runat="server" ID="cvtxtConfirmPassword" ControlToValidate="txtConfirmPassword"
                                            ControlToCompare="txtpassword" Display="Dynamic" ErrorMessage="Password does not match"
                                            ValidationGroup="ValidateControls" CssClass="required"></asp:CompareValidator>
                                    </div>
                                    <div class="divControl">
                                        <label>
                                            Role:</label>
                                        <asp:DropDownList runat="server" ID="ddlRole" CssClass="form-control">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="AdminLevel1">Admin Level 1</asp:ListItem>
                                            <asp:ListItem Value="AdminLevel2">Admin Level 2</asp:ListItem>
                                            <asp:ListItem Value="Manager">Manager</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator runat="server" ID="rfddlRole" ControlToValidate="ddlRole"
                                            InitialValue="0" Display="Dynamic" ErrorMessage="Required" ValidationGroup="ValidateControls"
                                            CssClass="required"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="divControl">
                                        <label>
                                            Gender:</label>
                                        <asp:DropDownList runat="server" ID="ddlGender" CssClass="form-control">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="Male">Male</asp:ListItem>
                                            <asp:ListItem Value="Female">Female</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator runat="server" ID="rfddlGender" ControlToValidate="ddlGender"
                                            InitialValue="0" Display="Dynamic" ErrorMessage="Required" ValidationGroup="ValidateControls"
                                            CssClass="required"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6 mbottom10 mleft30 texalign-right mtop25">
                                        <asp:HiddenField runat="server" ID="hfEntityId" />
                                        <asp:LinkButton Visible="False" runat="server" ID="lnkSave" CssClass="widget-icon widget-icon-medium"
                                            OnClick="lnkSave_Click" ValidationGroup="ValidateControls"><span class="icon-save"></span></asp:LinkButton>
                                    </div>
                                </div>
                                <div role="grid" class="dataTables_wrapper">
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
                                                    Email
                                                </th>
                                                <th>
                                                    Salon Name
                                                </th>
                                                <th>
                                                    Role
                                                </th>
                                                <th>
                                                    Country
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
                                                            <%# Eval("SystemManagerId")%>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Name") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Email") %>
                                                        </td>
                                                        <td class="aligncenter">
                                                            <%# Utilities.Helper.GetSalonName(Convert.ToInt32(Eval("SalonId"))) %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Role") %>
                                                        </td>
                                                        <td>
                                                            <%# Eval("Country") %>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton runat="server" ID="btnEdit" CommandArgument='<%# Eval("SystemManagerId") %>'
                                                                CommandName="Edit" ToolTip="Edit" ImageUrl="img/edit.png" CssClass="width45" />
                                                        </td>
                                                        <td class="aligncenter">
                                                            <asp:ImageButton Visible='<%#TablePermission=="E" %>' runat="server" ID="btnDelete"
                                                                CommandArgument='<%# Eval("SystemManagerId") %>' CommandName="Delete" ToolTip="Delete"
                                                                ImageUrl="img/delete.png" CssClass="width45" OnClientClick="return confirm('Are you sure you want to delete this user?')" />
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
