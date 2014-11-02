<%@ Page Title="Permissions Managment" Language="C#" MasterPageFile="~/Moderator/Moderator.Master"
    AutoEventWireup="true" CodeBehind="PermissionsManagement.aspx.cs" Inherits="Saloon4K.Moderator.PermissionsManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cmsBody" runat="server">
    <div class="container">
        <asp:UpdatePanel runat="server" ID="upPermissions">
            <ContentTemplate>
                <div class="row">
                    <div class="col-md-12">
                        <div class="block">
                            <div class="header">
                                <h3 style="margin-top: 10px;">
                                    Manage Deals
                                </h3>
                            </div>
                            <div class="content controls">
                                <div class="form-row">
                                    <div id="divMessage" runat="server" visible="False">
                                    </div>
                                    <div class="divControl">
                                        <label>
                                            Permissions For:</label>
                                        <asp:DropDownList runat="server" ID="ddlRole" CssClass="form-control" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged"
                                            AutoPostBack="True" />
                                        <asp:RequiredFieldValidator ID="rfddlRole" runat="server" ControlToValidate="ddlRole"
                                            InitialValue="0" ValidationGroup="Req" ErrorMessage="Required" Display="Dynamic">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                    <div id="divPermissions" runat="server" visible="False">
                                        <h2 class="clr" style="margin: 0 0 0 40px; padding: 15px;">
                                            Permission for Modules</h2>
                                        <div class="divControl">
                                            <label>
                                                Dashboard:</label>
                                            <asp:DropDownList runat="server" ID="ddlDashboard" CssClass="form-control">
                                                <asp:ListItem Value="N/A">Not Available</asp:ListItem>
                                                <asp:ListItem Value="E">Edit</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="divControl">
                                            <label>
                                                Users:</label>
                                            <asp:DropDownList runat="server" ID="ddlUsers" CssClass="form-control">
                                                <asp:ListItem Value="N/A">Not Available</asp:ListItem>
                                                <asp:ListItem Value="E">Edit</asp:ListItem>
                                                <asp:ListItem Value="R">Read Only</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="divControl">
                                            <label>
                                                Deals:</label>
                                            <asp:DropDownList runat="server" ID="ddlDeals" CssClass="form-control">
                                                <asp:ListItem Value="N/A">Not Available</asp:ListItem>
                                                <asp:ListItem Value="E">Edit</asp:ListItem>
                                                <asp:ListItem Value="R">Read Only</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="divControl ">
                                            <label>
                                                Directories:</label>
                                            <asp:DropDownList runat="server" ID="ddlDirectories" CssClass="form-control">
                                                <asp:ListItem Value="N/A">Not Available</asp:ListItem>
                                                <asp:ListItem Value="E">Edit</asp:ListItem>
                                                <asp:ListItem Value="R">Read Only</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="divControl">
                                            <label>
                                                Salons:</label>
                                            <asp:DropDownList runat="server" ID="ddlSalons" CssClass="form-control">
                                                <asp:ListItem Value="N/A">Not Available</asp:ListItem>
                                                <asp:ListItem Value="E">Edit</asp:ListItem>
                                                <asp:ListItem Value="R">Read Only</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="divControl">
                                            <label>
                                                Adds:</label>
                                            <asp:DropDownList runat="server" ID="ddlAdds" CssClass="form-control">
                                                <asp:ListItem Value="N/A">Not Available</asp:ListItem>
                                                <asp:ListItem Value="E">Edit</asp:ListItem>
                                                <asp:ListItem Value="R">Read Only</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="divControl">
                                            <label>
                                                Points:</label>
                                            <asp:DropDownList runat="server" ID="ddlPoints" CssClass="form-control">
                                                <asp:ListItem Value="N/A">Not Available</asp:ListItem>
                                                <asp:ListItem Value="E">Edit</asp:ListItem>
                                                <asp:ListItem Value="R">Read Only</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="divControl">
                                            <label>
                                                System Managers:</label>
                                            <asp:DropDownList runat="server" ID="ddlSystemManagers" CssClass="form-control">
                                                <asp:ListItem Value="N/A">Not Available</asp:ListItem>
                                                <asp:ListItem Value="E">Edit</asp:ListItem>
                                                <asp:ListItem Value="R">Read Only</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="divControl">
                                            <asp:HiddenField runat="server" ID="hfEntityId" Value="0" />
                                            <asp:Button ID="btnSubmit" runat="server" Text="SAVE" class="btn btn-default btn-block btn-clean"
                                                ValidationGroup="Req" OnClick="btnSubmit_Click" Style="width: 100px; float: left;
                                                margin: 0 auto 0 170px" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
