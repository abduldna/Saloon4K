<%@ Page Title="Sarah Beauty | Register" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Saloon4K.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="content">
        <div class="salonkcontent">
            <div class="registationcontainer" style="height: 734px;">
                <asp:UpdatePanel runat="server" ID="upRegister">
                    <ContentTemplate>
                        <div class="ribbon">
                            Registration</div>
                        <div class="reginner" style="height: 675px;">
                            <div class="regright">
                                <div class="registerationcontent">
                                    <div class="formarea">
                                        <div id="divMessage" runat="server" visible="False" style="margin-top: 8px;">
                                        </div>
                                        <fieldset style="margin-top: -15px;" class="fieldsetgeneral">
                                            <legend>Profile Information</legend>
                                            <div id="body_upUsername" class="mtop15">
                                                <div class="formrow1">
                                                    <label>
                                                        E-mail</label>
                                                    <asp:TextBox runat="server" ID="txtUsername" CssClass="geninput" OnTextChanged="txtUsername_TextChanged"
                                                        AutoPostBack="True"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rftxtUsername" ControlToValidate="txtUsername"
                                                        Display="Dynamic" CssClass="error" ValidationGroup="Register" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="retxtUsername" runat="server" ControlToValidate="txtUsername"
                                                        ValidationExpression="^([0-9a-zA-Z]+[-._+&amp;])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$"
                                                        ValidationGroup="Register" CssClass="error" ErrorMessage="Invalid Email" Display="Dynamic">
                                                    </asp:RegularExpressionValidator>
                                                </div>
                                                <div class="formrow1">
                                                    <label>
                                                        Password</label>
                                                    <asp:TextBox runat="server" ID="txtPassword" CssClass="geninput"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rftxtPassword" ControlToValidate="txtPassword"
                                                        Display="Dynamic" CssClass="error" ValidationGroup="Register" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="formrow1">
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
                                            <div class="formrow1 mtop15">
                                                <label>
                                                    Firstname</label>
                                                <asp:TextBox runat="server" ID="txtFirstname" CssClass="geninput"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="rftxtFirstname" ControlToValidate="txtFirstname"
                                                    Display="Dynamic" CssClass="error" ValidationGroup="Register" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="formrow1">
                                                <label>
                                                    Lastname</label>
                                                <asp:TextBox runat="server" ID="txtLastname" CssClass="geninput"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="rftxtLastname" ControlToValidate="txtLastname"
                                                    Display="Dynamic" CssClass="error" ValidationGroup="Register" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="formrow1">
                                                <label>
                                                    Address</label>
                                                <asp:TextBox runat="server" ID="txtAddress" CssClass="geninput"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="rftxtAddress" ControlToValidate="txtAddress"
                                                    Display="Dynamic" CssClass="error" ValidationGroup="Register" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="formrow1">
                                                <label>
                                                    City</label>
                                                <asp:TextBox runat="server" ID="txtCity" CssClass="geninput"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="rftxtCity" ControlToValidate="txtCity"
                                                    Display="Dynamic" CssClass="error" ValidationGroup="Register" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="formrow1">
                                                <label>
                                                    Country</label>
                                                <asp:DropDownList runat="server" ID="ddlCountry" CssClass="floatLeft" Style="width: 220px;" />
                                                <asp:RequiredFieldValidator runat="server" ID="rfddlCountry" ControlToValidate="ddlCountry"
                                                    InitialValue="0" Display="Dynamic" CssClass="error" ValidationGroup="Register"
                                                    ErrorMessage="Required"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="formrow1">
                                                <label>
                                                    Phone</label>
                                                <asp:TextBox runat="server" ID="txtPhone" CssClass="geninput"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="rftxtPhone" ControlToValidate="txtPhone"
                                                    Display="Dynamic" CssClass="error" ValidationGroup="Register" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="formrow1">
                                                <label>
                                                    Facebook Account</label>
                                                <asp:TextBox runat="server" ID="txtFacebookAccount" CssClass="geninput"></asp:TextBox>
                                            </div>
                                            <div class="formrow1">
                                                <label>
                                                    About</label>
                                                <asp:TextBox runat="server" ID="txtAbout" CssClass="geninput"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="rftxtAbout" ControlToValidate="txtAbout"
                                                    Display="Dynamic" CssClass="error" ValidationGroup="Register" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="formrow1">
                                                <asp:Button runat="server" ID="btnRegister" Text="REGISTER" CssClass="searchbtn btnRegister"
                                                    ValidationGroup="Register" OnClick="btnRegister_Click" />
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnRegister" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
