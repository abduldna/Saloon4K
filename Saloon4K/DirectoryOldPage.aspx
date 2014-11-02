<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DirectoryOldPage.aspx.cs" Inherits="Saloon4K.DirectoryOldPage" %>

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

        function showEmail() {
            $("#divPhone").hide();
            $("#divEmail").slideDown('slow');
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="content">
        <div class="directorycontent">
            <div class="adarealeft">
                <div class="ads320">
                    <img src="~/images/ad320.jpg" alt="add" runat="server" /></div>
                <div class="ads320">
                    <img id="Img2" src="~/images/chanel.jpg" runat="server" alt="chanel" /></div>
            </div>
            <div class="dircontainer">
                <div id="divMessage" runat="server" visible="False">
                </div>
                <div class="ribbon">
                    Directory</div>
                <h5>
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
                    incididunt ut labore et dolore magna aliqua.</h5>
                <div class="dirrow">
                    <asp:Repeater runat="server" ID="rptCategories" OnItemDataBound="rptCategories_ItemDataBound"
                        OnItemCommand="rptCategories_ItemCommand">
                        <ItemTemplate>
                            <div class="divCategories">
                                <asp:HiddenField runat="server" ID="hfCategoryId" Value='<%# Eval("CategoryId") %>' />
                                <h3>
                                    <%# Eval("Name") %>
                                </h3>
                                <ul class="dirlist" >
                                    <asp:Repeater runat="server" ID="rptSaloons" OnItemCommand="rptSaloons_ItemCommand">
                                        <ItemTemplate>
                                            <li>
                                                <asp:LinkButton runat="server" ID="lnkSaloonName" CommandName="View" CommandArgument='<%# Eval("SaloonId") %>'
                                                    CssClass="saloonName" ToolTip="View Details">
                                                <%# Eval("Name") %>    
                                                </asp:LinkButton>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="leaderboard" style="float: left; margin: 25px auto 10px 115px; display: none;">
                <img alt="advertisement" src="images/leaderboard.jpg" />
            </div>
        </div>
        <div id="DivPopUp" class="DivPopUp">
            <div class="closebtn">
                <a id="lncClose" href="javascript:void(0);">
                    <img src="images/close.png" alt="close" />
                </a>
            </div>
            <asp:UpdatePanel runat="server" ID="upSaloonDetails" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:UpdateProgress ID="uppro" runat="server" AssociatedUpdatePanelID="upSaloonDetails">
                        <ProgressTemplate>
                            <div class="mask-div">
                                <img id="Img1" alt="loader" src="~/images/loader2.gif" runat="server" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div class="popUp">
                        <div class="ribbon">
                            Salon Details
                        </div>
                        <div class="popUpPicture">
                            <div class="banner" id="divSlider" runat="server">
                                <div class="flexslider">
                                    <section class="slider">
                                        <ul class="slides">
                                            <li>
                                                <asp:Image runat="server" ID="imgSaloonImage1" Style="width: 735px; height: 360px;" />
                                            </li>
                                            <li>
                                                <asp:Image runat="server" ID="imgSaloonImage2" Style="width: 735px; height: 360px;" />
                                            </li>
                                            <li>
                                                <asp:Image runat="server" ID="imgSaloonImage3" Style="width: 735px; height: 360px;" />
                                            </li>
                                        </ul>
                                    </section>
                                </div>
                            </div>
                        </div>
                        <div class="popUpContentArea" style="margin-left: 20px; margin-top: 15px; width: 760px;">
                            <h2 id="lblSaloonName" runat="server">
                            </h2>
                            <asp:HiddenField runat="server" ID="hfSaloonAddress" />
                            <asp:HiddenField runat="server" ID="hfSaloonCity" />
                            <asp:HiddenField runat="server" ID="hfSaloonState" />
                            <asp:HiddenField runat="server" ID="hfSaloonPhone" />
                            <span id="lblAddress" runat="server">Address:</span>
                            <p id="lblDescription" runat="server">
                            </p>
                            <asp:HiddenField runat="server" ID="hfUserId" Value="0" />
                            <asp:HiddenField runat="server" ID="hfSaloonId" Value="0" />
                            <asp:Button runat="server" ID="btnBookEmail" Text="BOOK BY EMAIL" CssClass="readmore btn"
                                Visible="False" Style="width: 160px;" OnClientClick="return showEmail();" />
                            <asp:Button runat="server" ID="btnBookPhone" Text="BOOK BY PHONE" CssClass="readmore btn"
                                Visible="False" Style="width: 160px;" OnClientClick="return showPhoneDiv();" />
                            <div class="divPhone" id="divPhone" runat="server" clientidmode="Static" style="display: none;">
                            </div>
                            <div class="divEmail" id="divEmail" runat="server" clientidmode="Static" style="display: none;">
                                <label class="floatLeft">
                                    Booking Date:&nbsp;</label><asp:TextBox runat="server" ID="txtBookingDate" CssClass="floatLeft width85"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rftxtBookingDate" ControlToValidate="txtBookingDate"
                                    ErrorMessage="*" Display="Dynamic" ValidationGroup="Book" CssClass="color floatLeft"></asp:RequiredFieldValidator>
                                <label class="floatLeft mleft2">
                                    Booking Time:&nbsp;</label><asp:TextBox runat="server" ID="txtBookingTime" CssClass="floatLeft width85"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rftxtBookingTime" ControlToValidate="txtBookingTime"
                                    ErrorMessage="*" Display="Dynamic" ValidationGroup="Book" CssClass="color floatLeft"></asp:RequiredFieldValidator>
                                <label class="floatLeft mleft2">
                                    Salon Email:&nbsp;</label><asp:Label runat="server" ID="lblSaloonEmail" CssClass="floatLeft"
                                        Style="width: 265px;"></asp:Label>
                                <asp:Button runat="server" ID="btnBookNow" Text="BOOK NOW" CssClass="readmore btn"
                                    Style="float: right; margin-right: -4px;" OnClick="btnBookNow_Click" ValidationGroup="Book" />
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
