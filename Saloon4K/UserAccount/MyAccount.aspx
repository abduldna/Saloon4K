<%@ Page Title="Saloon 4k| My Account" Language="C#" MasterPageFile="~/UserAccount/Account.master"
    AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="Saloon4K.UserAccount.MyAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContent" runat="server">
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#body_lnkMyProfile").addClass("current");
        });
    </script>
    <div class="webappright">
        <asp:UpdatePanel runat="server" ID="upRegister">
            <ContentTemplate>
                <div id="divMessage" runat="server" visible="False">
                </div>
                <div id="body_AccountContent_upUsername" style="float: left; margin-left: 15px;">
                    <asp:HiddenField runat="server" ID="hfUserId" Value="0" />
                    <fieldset class="fieldsetgeneral mtop25">
                        <legend>Profile Information</legend>
                        <div id="body_upUsername" class="mtop15">
                            <div class="formrowaccount">
                                <label>
                                    E-mail</label>
                                <asp:TextBox runat="server" ID="txtUsername" CssClass="geninput" Enabled="False"></asp:TextBox>
                            </div>
                            <div class="formrowaccount">
                                <label>
                                    Password</label>
                                <asp:TextBox runat="server" ID="txtPassword" CssClass="geninput"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rftxtPassword" ControlToValidate="txtPassword"
                                    Display="Dynamic" CssClass="error" ValidationGroup="Register" ErrorMessage="Required"></asp:RequiredFieldValidator>
                            </div>
                            <div class="formrowaccount">
                                <label>
                                    Confirm Password</label>
                                <asp:TextBox runat="server" ID="txtConfirmPassword" CssClass="geninput" OnTextChanged="txtConfirmPassword_TextChanged"
                                    AutoPostBack="True"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rftxtConfirmPassword" ControlToValidate="txtConfirmPassword"
                                    Display="Dynamic" CssClass="error" ValidationGroup="Register" ErrorMessage="Required"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </fieldset>
                    <fieldset style="height: auto; margin-top: 15px;" class="fieldsetgeneral">
                        <legend>General Information</legend>
                        <div class="formrowaccount mtop15">
                            <label>
                                Firstname</label>
                            <asp:TextBox runat="server" ID="txtFirstname" CssClass="geninput"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rftxtFirstname" ControlToValidate="txtFirstname"
                                Display="Dynamic" CssClass="error" ValidationGroup="Register" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </div>
                        <div class="formrowaccount">
                            <label>
                                Lastname</label>
                            <asp:TextBox runat="server" ID="txtLastname" CssClass="geninput"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rftxtLastname" ControlToValidate="txtLastname"
                                Display="Dynamic" CssClass="error" ValidationGroup="Register" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </div>
                        <div class="formrowaccount">
                            <label>
                                Address</label>
                            <asp:TextBox runat="server" ID="txtAddress" CssClass="geninput"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rftxtAddress" ControlToValidate="txtAddress"
                                Display="Dynamic" CssClass="error" ValidationGroup="Register" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </div>
                        <div class="formrowaccount">
                            <label>
                                City</label>
                            <asp:TextBox runat="server" ID="txtCity" CssClass="geninput"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rftxtCity" ControlToValidate="txtCity"
                                Display="Dynamic" CssClass="error" ValidationGroup="Register" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </div>
                        <div class="formrowaccount">
                            <label>
                                Country</label>
                            <asp:DropDownList runat="server" ID="ddlCountry" CssClass="floatLeft" Style="width: 220px;"
                                Enabled="False" />
                        </div>
                        <div class="formrowaccount">
                            <label>
                                Phone</label>
                            <asp:TextBox runat="server" ID="txtPhone" CssClass="geninput"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rftxtPhone" ControlToValidate="txtPhone"
                                Display="Dynamic" CssClass="error" ValidationGroup="Register" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </div>
                        <div class="formrowaccount">
                            <label>
                                Facebook Account</label>
                            <asp:TextBox runat="server" ID="txtFacebookAccount" CssClass="geninput"></asp:TextBox>
                        </div>
                        <div class="formrowaccount">
                            <label>
                                About</label>
                            <asp:TextBox runat="server" ID="txtAbout" CssClass="geninput"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="rftxtAbout" ControlToValidate="txtAbout"
                                Display="Dynamic" CssClass="error" ValidationGroup="Register" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </div>
                        <div class="formrowaccount">
                            <asp:Button runat="server" ID="btnRegister" Text="UPDATE" CssClass="searchbtn btnRegister"
                                ValidationGroup="Register" OnClick="btnRegister_Click" Style="margin: 0 0 15px 150px !important;" />
                        </div>
                    </fieldset>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
