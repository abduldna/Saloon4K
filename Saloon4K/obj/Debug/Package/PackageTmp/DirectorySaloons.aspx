<%@ Page Title="Directory Salons" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DirectorySaloons.aspx.cs" Inherits="Saloon4K.DirectorySaloons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#body_txtBookingDate").datepicker();
            $("#body_txtBookingTime").timepicker();
        });
        function ShowPopUp() {
            $('#DivPopUp').bPopup({
                onOpen: function () {
                },
                onClose: function () {
                }
            });
            $('#<%=upSaloonDetails.ClientID %>').parent().appendTo($("form:first"));
        }
        function showPhoneDiv() {
            $("#divEmail").hide();
            $("#divPhone").slideDown('slow');
            return false;
        }

        function closePopUp() {
            $('#DivPopUp').bPopup().close();
        }

        function showEmail() {
            $("#divPhone").hide();
            $("#divEmail").slideDown('slow');
            return false;
        }
    </script>
    <style type="text/css">
        .btnBookNow
        {
            float: left;
            margin-left: 8px;
            margin-top: 5px;
            width: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="content">
        <div class="directorycontent">
            <div class="adarealeft">
                <div class="ads320">
                    <asp:Image runat="server" ID="imgLeft1" CssClass="directoryAdd" onmouseenter="MouseTracking(this.id);" />
                    <asp:HiddenField runat="server" ID="imgLeft1hf" Value="" />
                </div>
                <div class="ads320">
                    <asp:Image runat="server" ID="imgLeft2" CssClass="directoryAdd" onmouseenter="MouseTracking(this.id);" />
                    <asp:HiddenField runat="server" ID="imgLeft2hf" Value="" />
                </div>
                <div class="ads320">
                    <asp:Image runat="server" ID="imgLeft3" CssClass="directoryAdd" onmouseenter="MouseTracking(this.id);" />
                    <asp:HiddenField runat="server" ID="imgLeft3hf" Value="" />
                </div>
            </div>
            <div class="dircontainer">
                <div class="ribbonDirectory" id="divDirectoryName" runat="server" style="text-align: center;">
                </div>
                <a href="javascript:void(0);" onclick="history.go(-1);" class="ancBack" title="Back">
                    <img src="~/images/backbtn.png" runat="server" alt="Back" />
                </a>
                <h5>
                    <div id="divMessage" runat="server" visible="False">
                    </div>
                </h5>
                <div class="dirrow">
                    <asp:Repeater runat="server" ID="rptSaloons" OnItemCommand="rptSaloons_ItemCommand">
                        <ItemTemplate>
                            <div class="floatLeft clearfix mtop10 salonDiv">
                                <div class="floatLeft">
                                    <asp:Image CssClass="salonImage" runat="server" ID="imgSalonImage" ImageUrl='<%# ConfigurationManager.AppSettings["SiteUrl"]+"Uploads/Saloons/"+Eval("Image1") %>' />
                                </div>
                                <div class="floatLeft width72Percent">
                                    <asp:Label runat="server" ID="lblSalonName" CssClass="salonCaption" Text='<%# Eval("Name") %>'></asp:Label>
                                    <asp:Label runat="server" ID="bllSalonDescription" CssClass="salonDescription" Text='<%# Eval("Description") %>'></asp:Label>
                                    <asp:ImageButton runat="server" ID="btnInterested" ImageUrl="images/heart.png" ToolTip="Make Interested"
                                        CommandName="Interested" CssClass="salonInterested" CommandArgument='<%# Eval("SaloonId") %>' />
                                    <asp:ImageButton runat="server" ID="btnViewMore" ImageUrl="~/images/view_more.jpg"
                                        ToolTip="View More" CssClass="salonViewDetails" CommandName="View" CommandArgument='<%# Eval("SaloonId") %>' />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="leaderboard" style="float: left; margin: 25px auto 10px 115px; display: none;">
                <img alt="advertisement" src="images/leaderboard.jpg" />
            </div>
        </div>
        <div id="DivPopUp" class="DivPopUp" style="height: auto; padding-bottom: 22px;">
            <div class="closebtn">
                <a id="lncClose" href="javascript:void(0);" onclick="closePopUp();">
                    <img src="images/close.png" alt="close" />
                </a>
            </div>
            <asp:UpdatePanel runat="server" ID="upSaloonDetails" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:UpdateProgress ID="uppro" runat="server" AssociatedUpdatePanelID="upSaloonDetails">
                        <ProgressTemplate>
                            <div class="mask-div">
                                <img alt="loader" src="~/images/loader2.gif" runat="server" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div class="popUp" style="height: auto;">
                        <div class="ribbon">
                            Salon Details
                        </div>
                        <div class="popUpPicture" style="margin: 44px 0 0 10px;">
                            <div class="banner" id="divSlider" runat="server" style="width: 45%;">
                                <div class="flexslider">
                                    <section class="slider">
                                        <ul class="slides">
                                            <li>
                                                <asp:Image runat="server" ID="imgSaloonImage1" CssClass="salondetailsImage" />
                                            </li>
                                            <li>
                                                <asp:Image runat="server" ID="imgSaloonImage2" CssClass="salondetailsImage" />
                                            </li>
                                            <li>
                                                <asp:Image runat="server" ID="imgSaloonImage3" CssClass="salondetailsImage" />
                                            </li>
                                        </ul>
                                    </section>
                                </div>
                            </div>
                            <div class="popUpContentArea popsalon">
                                <fieldset>
                                    <legend>Salon Details</legend>
                                    <asp:HiddenField runat="server" ID="hfSaloonAddress" />
                                    <asp:HiddenField runat="server" ID="hfSaloonCity" />
                                    <asp:HiddenField runat="server" ID="hfSaloonCountry" />
                                    <asp:HiddenField runat="server" ID="hfSaloonPhone" />
                                    <h2 id="lblSaloonName" runat="server">
                                    </h2>
                                    <span id="lblAddress" runat="server">Address:</span>
                                    <p id="lblDescription" runat="server" style="min-height: 62px;">
                                    </p>
                                    <asp:HiddenField runat="server" ID="hfUserId" Value="0" />
                                    <asp:HiddenField runat="server" ID="hfSaloonId" Value="0" />
                                    <span class="dealFavourite" id="lblInterested" runat="server" title="Favourite of people"
                                        style="margin-left: 288px;"></span><span class="dealBooked" id="lblBooked" runat="server"
                                            title="Booked by people"></span>
                                    <asp:Button runat="server" ID="btnBookEmail" Text="BOOK BY EMAIL" CssClass="readmore btn"
                                        Visible="False" Style="width: 160px; margin: 7px 5px 0 0;" OnClientClick="return showEmail();" />
                                    <asp:Button runat="server" ID="btnBookPhone" Text="BOOK BY PHONE" CssClass="readmore btn"
                                        Visible="False" Style="width: 160px; margin: 7px 5px 0 0;" OnClientClick="return showPhoneDiv();" />
                                </fieldset>
                            </div>
                            <div>
                                <div id="divBookingMessage" runat="server" visible="False" style="width: 92%; margin-left: 25px;
                                    margin-top: 5px;">
                                </div>
                                <div class="divPhone" id="divPhone" runat="server" clientidmode="Static" style="display: none;">
                                    <fieldset style="height: 142px; width: 789px;">
                                        <legend>Book By Phone</legend>
                                        <div class="divBookDetails">
                                            <div class="floatLeft">
                                                <span class="floatLeft">Phone:</span>
                                                <asp:Label runat="server" ID="lblPhone" Style="font-weight: bold;" CssClass="marginLeft10 floatLeft"></asp:Label>
                                                <asp:CheckBox runat="server" ID="cbAnswered" CssClass="floatLeft" Style="margin: 4px 0 0 20px;" /><span
                                                    class="floatLeft" style="margin-top: 0;">Was you call answered?</span>
                                                <asp:Button runat="server" ID="btnAnswered" Text="SUBMIT" CssClass="readmore btn btnBookNow"
                                                    OnClick="btnAnswered_Click" Style="margin: -5px 0 0 40px;" />
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                                <div class="divEmail" id="divEmail" runat="server" clientidmode="Static" style="display: none;">
                                    <fieldset style="height: 142px; width: 789px;">
                                        <legend>Book By Email</legend>
                                        <div class="divBookDetails">
                                            <label class="floatLeft">
                                                Booking Date:&nbsp;</label><asp:TextBox runat="server" ID="txtBookingDate" CssClass="floatLeft bookingttextbox"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rftxtBookingDate" ControlToValidate="txtBookingDate"
                                                ErrorMessage="*" Display="Dynamic" ValidationGroup="Book" CssClass="color floatLeft mtop12"></asp:RequiredFieldValidator>
                                            <label class="floatLeft mleft2">
                                                Booking Time:&nbsp;</label><asp:TextBox runat="server" ID="txtBookingTime" CssClass="floatLeft bookingttextbox"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rftxtBookingTime" ControlToValidate="txtBookingTime"
                                                ErrorMessage="*" Display="Dynamic" ValidationGroup="Book" CssClass="color floatLeft mtop12"></asp:RequiredFieldValidator>
                                            <label class="floatLeft mleft2" style="clear: both !important;">
                                                Salon Email:&nbsp;</label><asp:Label runat="server" ID="lblSaloonEmail" CssClass="floatLeft captionEmail"></asp:Label>
                                            <div id="divPoints" runat="server" class="divpoints" visible="False">
                                                <span class="ptsspan">Points:</span>
                                                <asp:DropDownList runat="server" ID="ddlPoints" CssClass="ddlpts" />
                                            </div>
                                            <asp:Button runat="server" ID="btnBookNow" Text="BOOK NOW" CssClass="readmore btn btnBookNow"
                                                OnClick="btnBookNow_Click" ValidationGroup="Book" />
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
