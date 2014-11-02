<%@ Page Title="Sarah Beauty | Contact Us" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Saloon4K.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .error
        {
            float: left !important;
            font-size: 15px !important;
            margin-top: 6px !important;
            width: 115px !important;
            text-align: left !important;
            color: #D8275D !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="content">
        <div class="contactcontent">
            <div id="divMessage" runat="server" visible="false">
            </div>
            <div class="contactleft">
                <h4 class="address">
                    ADDRESS</h4>
                <p>
                    
                    Lorem ipsum dolor sit amet, consectetur<br>
                    adipiscing elit. Nam ullamcorper lacinia . Wakee
                </p>
                <h4 class="phone">
                    TELEPHONE</h4>
                <p>
                    +971 50 5555555</p>
            </div>
            <div class="contactright">
                <div class="map">
                </div>
                <div class="contactform">
                    <div class="contact-form inputnormal">
                        <div style="display: none;" class="success">
                            Contact form submitted! <strong>We will be in touch soon.</strong>
                        </div>
                        <div>
                            <div class="coll-1">
                                <div class="txt-form">
                                    Name:<span>*</span></div>
                                <label class="name">
                                    <asp:TextBox ID="txtName" runat="server" Placeholder="Name" CssClass="inputnormal"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rftxtName" runat="server" ControlToValidate="txtName"
                                        CssClass="error" Display="Dynamic" ErrorMessage="Required" ValidationGroup="Contact"></asp:RequiredFieldValidator>
                                </label>
                            </div>
                            <div class="coll-2">
                                <div class="txt-form">
                                    Email:<span>*</span></div>
                                <label class="email">
                                    <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" CssClass="inputnormal"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rftxtEmail" runat="server" ControlToValidate="txtEmail"
                                        CssClass="error" Display="Dynamic" ErrorMessage="Required" ValidationGroup="Contact"></asp:RequiredFieldValidator>
                                </label>
                            </div>
                            <div class="coll-3">
                                <div class="txt-form">
                                    phone:<span>*</span></div>
                                <label class="phone notRequired">
                                    <asp:TextBox ID="txtPhone" runat="server" Placeholder="Phone" CssClass="inputnormal"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rftxtPhone" runat="server" ControlToValidate="txtPhone"
                                        CssClass="error" Display="Dynamic" ErrorMessage="Required" ValidationGroup="Contact"></asp:RequiredFieldValidator>
                                </label>
                            </div>
                            <div style="float: left; width: 100%;">
                                <div class="txt-form">
                                    Comment<span>*</span></div>
                                <label class="message">
                                    <asp:TextBox ID="txtComments" runat="server" Placeholder="Comments" TextMode="MultiLine"
                                        CssClass="inputnormal"></asp:TextBox>
                                    <span style="display: none;" class="error">*The message is too short.</span> <span
                                        style="display: none;" class="empty">*This field is required.</span>
                                </label>
                            </div>
                            <asp:Button ID="btnSubmit" runat="server" CssClass="sbtbtn" Text="SUBMIT" ValidationGroup="Contact"
                                OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
