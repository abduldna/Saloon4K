<%@ Page Title="User Profile" Language="C#" MasterPageFile="~/Moderator/Moderator.Master"
    AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Saloon4K.Moderator.UserProfile" %>

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
                                    My Profile
                                </h3>
                            </div>
                            <div class="content controls">
                                <div class="form-row">
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
                                        <asp:DropDownList runat="server" ID="ddlRole" CssClass="form-control" Enabled="False">
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
                                        <asp:LinkButton runat="server" ID="lnkSave" CssClass="widget-icon widget-icon-medium"
                                            OnClick="lnkSave_Click" ValidationGroup="ValidateControls"><span class="icon-save"></span></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
