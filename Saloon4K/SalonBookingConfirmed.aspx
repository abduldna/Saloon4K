<%@ Page Title="Salon Booking Confirmed" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="SalonBookingConfirmed.aspx.cs" Inherits="Saloon4K.SalonBookingConfirmed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .confirmationmsg
        {
            float: none;
            font-size: 20px;
            margin: 0 auto !important;
            padding: 20px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div style="text-align: center;">
        <h4 class="confirmationmsg">
            Salon is booked successfully!
        </h4>
    </div>
</asp:Content>
