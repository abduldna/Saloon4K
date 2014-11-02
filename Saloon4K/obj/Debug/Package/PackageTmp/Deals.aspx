<%@ Page Title="Sarah Beauty | Deals" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Deals.aspx.cs" Inherits="Saloon4K.Deals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var name;
       var imgUrl;
       var desc;
   function test(id) {
         $.ajax({
            url: "http://localhost:64196/Home.aspx/FaceBookShare",
            data: "{ 'prefix': '" + id + "'}",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            error: function(XMLHttpRequest, textStatus, errorThrown) {
                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
            },
            complete: function(jqXHR, status) {
//                alert("complete: " + status + "\n\nResponse: " + jqXHR.responseText);
            },
            success: function(data) {
                populateData(data.d);
            },
        });

        FB.ui(
            {
                method: 'feed',
                name: '<b> Here is deal of the day ' +' '+ name,
                link: 'http://bravadoexps.com',
                Picture:imgUrl,
                caption: 'Saloon4K.com',
                description: '<b>' + desc,
                message: ''
            });
    }
    function populateData(msg) {                                    
                 name = msg.Name;
                 desc = msg.Description;
                 imgUrl = msg.Image;
     }
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
                        <div class="featureddeals">
                            <asp:ImageButton runat="server" ID="btnFeatured" OnClick="btnFeatured_Click" ImageUrl="~/images/featureddeals.jpg" />
                        </div>
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
                                                <div class='fb-like' data-href='http://localhost:64196/Deals.aspx?querystring=<%#Eval("DealId") %>&'
                                                    data-layout="button_count" data-send='false' data-width='400' data-show-faces='false'>
                                                </div>
                                            </div>
                                            <div class="share">
                                                <img src="images/fb_share.png" style="cursor: pointer" title="Share on Facebook"
                                                    alt="share" onclick="test('<%#Eval("DealId") %>')" class="value" /></div>
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
                                            <asp:HiddenField runat="server" ID="hfSalonIdRepeater" Value='<%# Eval("SaloonId") %>' />
                                            <asp:LinkButton runat="server" ID="lnkReadMore" OnClick="lnkReadMore_Click">read more</asp:LinkButton>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="rowads">
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
                                <img alt="loader" src="~/images/loading.gif" runat="server" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div class="reviewleft">
                        <div class="ribbon">
                            DEAL OF THE DAY</div>
                        <asp:Image runat="server" ID="imgDealImage" CssClass="dealImage" />
                        <fieldset class="dealfs">
                            <legend>Deal Details</legend>
                            <h2 id="lblName" runat="server">
                            </h2>
                            <span>Actual Price:</span><p id="lblactualPrice" runat="server" style="min-height: 30px;">
                            </p>
                            <span>Discounted Price:</span>
                            <p id="lbldiscountedPrice" runat="server" style="min-height: 30px;">
                            </p>
                            <span style="width: 75px;">Address:</span>
                            <p id="lblAddress" runat="server" style="min-height: 30px;">
                            </p>
                        </fieldset>
                        <div class="popupcontent">
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
                                <asp:HiddenField runat="server" ID="hfUserId" />
                                <asp:HiddenField runat="server" ID="hfDealId" />
                                <asp:HiddenField runat="server" ID="hfSalonId" />
                                <div id="divBookingMessage" runat="server" visible="False" style="width: 92%; margin-left: 25px;">
                                    please login fist to compelte the action.
                                </div>
                                <div style="float: left; margin-top: 15px;">
                                    <div class="dealFavourite" id="lblFavourite" runat="server" title="Favourite of people">
                                    </div>
                                    <div class="dealBooked" id="lblBooked" runat="server" title="Booked by people">
                                    </div>
                                    <div id="divPoints" runat="server" class="divpoints" visible="False">
                                        <span class="ptsspan">Points:</span>
                                        <asp:DropDownList runat="server" ID="ddlPoints" CssClass="ddlpts" />
                                    </div>
                                    <asp:Button runat="server" ID="btnBook" Text="BOOK" CssClass="btnBook btn" Visible="False"
                                        OnClick="btnBook_Click" />
                                </div>
                            </fieldset>
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
