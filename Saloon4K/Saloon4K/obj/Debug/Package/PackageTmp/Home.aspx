<%@ Page Title="Salon 4K | Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="Saloon4K.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ShowPopUp() {
            $('#DivPopUp').bPopup({
                onOpen: function () {
                },
                onClose: function () {
                }
            });
            $('#<%=upBook.ClientID %>').parent().appendTo($("form:first"));
        }
        function closePopUp() {
            $('#DivPopUp').bPopup().close();
        }       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="content">
        <div class="homecontent">
            <asp:UpdatePanel runat="server" ID="upDeals" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:UpdateProgress ID="uproupDeals" runat="server" AssociatedUpdatePanelID="upDeals">
                        <ProgressTemplate>
                            <div class="mask-div">
                                <img alt="loader" src="~/images/loading.gif" runat="server" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div class="row1container">
                        <div id="divMessage" runat="server" visible="False" style="width: 97%;">
                        </div>
                        <asp:Repeater runat="server" ID="rptDealsofthday" OnItemDataBound="rptDealsofthday_ItemDataBound"
                            OnItemCommand="rptDealsofthday_ItemCommand">
                            <ItemTemplate>
                                <div class="row1">
                                    <div class="ribbon">
                                        DEAL OF THE DAY</div>
                                    <asp:HiddenField runat="server" ID="hfImage" Value='<%# Eval("Image") %>' />
                                    <div class="dealpic">
                                        <asp:Image runat="server" ID="imgImage" />
                                    </div>
                                    <div class="sharebar">
                                        <div class="fblike">
                                            <img src="images/like.png" alt="like" /></div>
                                        <div class="share">
                                            <img src="images/share.png" alt="share" /></div>
                                        <div class="fav noborder">
                                            <asp:ImageButton runat="server" CommandName="Favourite" ID="btnFavourite" CommandArgument='<%# Eval("DealId") %>'
                                                ImageUrl="~/images/heart.png" ToolTip="Make it favourite" />
                                        </div>
                                    </div>
                                    <div class="dealcontent">
                                        <span class="dealspan width235">
                                            <%# Eval("Name").ToString().Length > 35 ? Eval("Name").ToString().Substring(0,35) : Eval("Name").ToString()%></span>
                                        <p class="width235">
                                            <span>
                                                <%# Eval("Description") %></span>
                                        </p>
                                    </div>
                                    <div class="divPrice">
                                        Price:
                                        <asp:Label runat="server" ID="lblActualPrice" Style="text-decoration: line-through;
                                            font-size: 11px;" Text='<%# Eval("ActualPrice") + "&nbsp;AED" %>'></asp:Label>
                                        <asp:Label runat="server" ID="lblDiscountedPrice" Text='<%# Eval("DiscountedPrice") + "&nbsp;AED" %>'
                                            Style="font-weight: bold;"></asp:Label>
                                    </div>
                                    <div class="readmore">
                                        <asp:HiddenField runat="server" ID="hfDealIdRepeater" Value='<%# Eval("DealId") %>' />
                                        <asp:LinkButton runat="server" ID="lnkReadMore" OnClick="lnkReadMore_Click">read more</asp:LinkButton>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="rowads">
                        <div class="searchcontainer">
                            <div class="finder">
                                FINDER</div>
                            <div class="searhchtype">
                                <div class="radiotype">
                                    <asp:RadioButton ID="rdbSaloon" runat="server" />
                                    <span>SALON</span></div>
                                <div class="radiotype">
                                    <asp:RadioButton ID="rdbDeal" runat="server" />
                                    <span>DEAL</span></div>
                            </div>
                            <div class="searchrow">
                                <span>I AM LOOKING FOR</span><br />
                                <asp:TextBox ID="txtLookingFor" runat="server" CssClass="mainfield"></asp:TextBox>
                            </div>
                            <div class="searchrow">
                                <span>IN</span><br />
                                <asp:TextBox ID="txtLookingForIn" runat="server" CssClass="mainfield"></asp:TextBox>
                            </div>
                            <asp:Button ID="btnSearch" runat="server" CssClass="searchbtn" Text="SEARCH" />
                        </div>
                        <div class="advt">
                            <asp:Image runat="server" ID="SingleImageRight" CssClass="verticalAdd" onmouseenter="MouseTracking(this.id);" />
                            <asp:HiddenField runat="server" ID="SingleImageRighthf" Value="" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="DivPopUp" class="DivPopUp">
            <div class="closebtn">
                <a id="lncClose" href="javascript:void(0);" onclick="closePopUp();">
                    <img src="images/close.png" alt="close" />
                </a>
            </div>
            <asp:UpdatePanel runat="server" ID="upBook" UpdateMode="Always">
                <ContentTemplate>
                    <asp:UpdateProgress ID="uproupBook" runat="server" AssociatedUpdatePanelID="upBook">
                        <ProgressTemplate>
                            <div class="mask-div">
                                <img id="Img1" alt="loader" src="~/images/loading.gif" runat="server" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div class="reviewleft">
                        <div class="ribbon">
                            DEAL OF THE DAY</div>
                        <div class="popuppic">
                            <asp:Image runat="server" ID="imgDealImage" Style="width: 590px; height: 300px;" />
                        </div>
                        <div class="popupcontent">
                            <fieldset>
                                <legend>Deal Details</legend>
                                <h2 id="lblName" runat="server">
                                </h2>
                                <span>Actual Price:</span><p id="lblactualPrice" runat="server" style="min-height: 30px;">
                                </p>
                                <span>Discounted Price:</span>
                                <p id="lbldiscountedPrice" runat="server" style="min-height: 30px;">
                                </p>
                                <span>Address:</span>
                                <p id="lblAddress" runat="server" style="min-height: 30px;">
                                </p>
                            </fieldset>
                            <fieldset class="mtop10">
                                <legend>Salon Details</legend><span>Name:</span>
                                <p runat="server" id="lblSaloonName">
                                </p>
                                <span>Email:</span>
                                <p id="lblSaloonEmail" runat="server">
                                </p>
                                <span>Phone:</span>
                                <p id="lblSaloonPhone" runat="server">
                                </p>
                                <span>Description:</span>
                                <p id="lblSaloonDescription" runat="server">
                                </p>
                            </fieldset>
                        </div>
                        <div>
                            <asp:HiddenField runat="server" ID="hfUserId" />
                            <asp:HiddenField runat="server" ID="hfDealId" />
                            <div id="divBookingMessage" runat="server" visible="False" style="width: 92%; margin-left: 25px;">
                                please login fist to compelte the action.
                            </div>
                            <span class="dealFavourite" id="lblFavourite" runat="server" title="Favourite of people">
                            </span><span class="dealBooked" id="lblBooked" runat="server" title="Booked by people">
                            </span>
                            <asp:Button runat="server" ID="btnBook" Text="BOOK" CssClass="btnBook btn" Visible="False"
                                OnClick="btnBook_Click" />
                        </div>
                    </div>
                    <div class="reviewright">
                        <h3 style="color: white; margin-left: 17px;">
                            FEATURED ADDS</h3>
                        <ul>
                            <li class="star">
                                <asp:Image runat="server" ID="imgPopUp1" CssClass="popUpAdd" onmouseenter="MouseTracking(this.id);" />
                                <asp:HiddenField runat="server" ID="imgPopUp1hf" Value="" />
                            </li>
                            <li class="star">
                                <asp:Image runat="server" ID="imgPopUp2" CssClass="popUpAdd" onmouseenter="MouseTracking(this.id);" />
                                <asp:HiddenField runat="server" ID="imgPopUp2hf" Value="" />
                            </li>
                            <li class="star">
                                <asp:Image runat="server" ID="imgPopUp3" CssClass="popUpAdd" onmouseenter="MouseTracking(this.id);" />
                                <asp:HiddenField runat="server" ID="imgPopUp3hf" Value="" />
                            </li>
                        </ul>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
