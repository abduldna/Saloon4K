<%@ Page Title="Salon Management" Language="C#" MasterPageFile="~/Moderator/Moderator.Master"
    AutoEventWireup="true" CodeBehind="AddEditSalons.aspx.cs" Inherits="Saloon4K.Moderator.AddEditSalons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PickUpArea() {
            $("#divPopUp").bPopup();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cmsBody" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="block">
                    <div class="header">
                        <h3 style="margin-top: 10px;">
                            Manage Salons
                        </h3>
                    </div>
                    <div class="content controls">
                        <div class="form-row" style="margin-top: 55px;">
                            <div id="divMessage" runat="server" visible="False">
                            </div>
                            <div class="divControl">
                                <label>
                                    Country:</label>
                                <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ID="rfddlCountry" ControlToValidate="ddlCountry"
                                    Display="Dynamic" ErrorMessage="Required" ValidationGroup="ValidateControls"
                                    CssClass="required"></asp:RequiredFieldValidator>
                            </div>
                            <div class="divControl">
                                <label>
                                    Name:</label>
                                <asp:TextBox runat="server" ID="txtName" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rftxtName" ControlToValidate="txtName"
                                    Display="Dynamic" ErrorMessage="Required" ValidationGroup="ValidateControls"
                                    CssClass="required"></asp:RequiredFieldValidator>
                            </div>
                            <div class="divControl clearAdmin">
                                <label>
                                    Contact Email:</label>
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rftxtEmail" ControlToValidate="txtEmail"
                                    Display="Dynamic" ErrorMessage="Required" ValidationGroup="ValidateControls"
                                    CssClass="required"></asp:RequiredFieldValidator>
                            </div>
                            <div class="divControl">
                                <label>
                                    Contact Phone:</label>
                                <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rftxtPhone" ControlToValidate="txtPhone"
                                    Display="Dynamic" ErrorMessage="Required" ValidationGroup="ValidateControls"
                                    CssClass="required"></asp:RequiredFieldValidator>
                            </div>
                            <div class="divControl">
                                <label>
                                    Address 1&nbsp;&nbsp;(<asp:LinkButton runat="server" ID="lnkPickUpArea" OnClick="lnkPickUpArea_Click"
                                        Style="text-decoration: underline">Select</asp:LinkButton>):</label>
                                <asp:TextBox runat="server" ID="txtAddress1" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rftxtAddress1" ControlToValidate="txtAddress1"
                                    Display="Dynamic" ErrorMessage="Required" ValidationGroup="ValidateControls"
                                    CssClass="required"></asp:RequiredFieldValidator>
                            </div>
                            <div class="divControl">
                                <label>
                                    Address 2:</label>
                                <asp:TextBox runat="server" ID="txtAddress2" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rftxtAddress2" ControlToValidate="txtAddress2"
                                    Display="Dynamic" ErrorMessage="Required" ValidationGroup="ValidateControls"
                                    CssClass="required"></asp:RequiredFieldValidator>
                            </div>
                            <div class="divControl">
                                <label>
                                    Latitude:</label>
                                <asp:TextBox runat="server" ID="txtLatitude" CssClass="form-control" Style="width: 100px !important;"></asp:TextBox>
                                <label style="width: 80px !important;">
                                    Longitude:</label>
                                <asp:TextBox runat="server" ID="txtLongitude" CssClass="form-control" Style="width: 100px !important;"></asp:TextBox>
                            </div>
                            <div class="divControl">
                                <label>
                                    City:</label>
                                <asp:TextBox runat="server" ID="txtCity" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rftxtCity" ControlToValidate="txtCity"
                                    Display="Dynamic" ErrorMessage="Required" ValidationGroup="ValidateControls"
                                    CssClass="required"></asp:RequiredFieldValidator>
                            </div>
                            <div class="divControl">
                                <label>
                                    Country:</label>
                                <asp:TextBox runat="server" ID="txtCountry" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rftxtCountry" ControlToValidate="txtCountry"
                                    Display="Dynamic" ErrorMessage="Required" ValidationGroup="ValidateControls"
                                    CssClass="required"></asp:RequiredFieldValidator>
                            </div>
                            <div class="divControl">
                                <label>
                                    Description
                                </label>
                                <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control txtarea" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="divControl">
                                <label>
                                    Image-1:</label>
                                <asp:FileUpload runat="server" ID="fuImage1" CssClass="form-control" />&nbsp;&nbsp;
                                <asp:HyperLink runat="server" ID="hplImage1" Visible="False" Target="_blank">View</asp:HyperLink>
                                <asp:HiddenField runat="server" ID="hfImage1" Value="0" />
                            </div>
                            <div class="divControl">
                                <label>
                                    Image-2:</label>
                                <asp:FileUpload runat="server" ID="fuImage2" CssClass="form-control" />&nbsp;&nbsp;
                                <asp:HyperLink runat="server" ID="hplImage2" Visible="False" Target="_blank">View</asp:HyperLink>
                                <asp:HiddenField runat="server" ID="hfImage2" Value="0" />
                            </div>
                            <div class="divControl">
                                <label>
                                    Image-3:</label>
                                <asp:FileUpload runat="server" ID="fuImage3" CssClass="form-control" />&nbsp;&nbsp;
                                <asp:HyperLink runat="server" ID="hplImage3" Visible="False" Target="_blank">View</asp:HyperLink>
                                <asp:HiddenField runat="server" ID="hfImage3" Value="0" />
                            </div>
                            <div class="divControl">
                                <label>
                                    &nbsp;
                                </label>
                                <div class="divvoucher">
                                    <asp:CheckBox runat="server" ID="cbAcceptVouchers" />
                                    <asp:Label runat="server" ID="lblAcceptVouchers">Accept Vouchers</asp:Label>
                                </div>
                            </div>
                            <div class="col-md-9 mtop25 divCat">
                                <h2>
                                    Select Directories</h2>
                                <asp:Repeater runat="server" ID="rptSaloonCategories">
                                    <ItemTemplate>
                                        <div>
                                            <asp:HiddenField runat="server" ID="hfCategoryId" Value='<%# Eval("CategoryId") %>' />
                                            <asp:CheckBox runat="server" ID='cbCategory' CssClass="floatLeft" />
                                            <asp:Label runat="server" ID="lblCategory" Text='<%# Eval("Name") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="col-md-6 mbottom10 mleft30 texalign-right mtop25">
                                <asp:LinkButton Visible="False" runat="server" ID="lnkSave" CssClass="widget-icon widget-icon-medium"
                                    OnClick="lnkSave_Click" ValidationGroup="ValidateControls"><span class="icon-save"></span></asp:LinkButton>
                            </div>
                        </div>
                        <!--Pick Up Location-->
                        <div id="divPopUp" class="ModeratorDivPopUp">
                            <asp:LinkButton runat="server" ID="lnkReload" OnClick="lnkReload_Click"><img src="img/close.png" alt="close" /></asp:LinkButton>
                            <div style="width: 100%;">
                                <div class="clr">
                                    <input id="addressinput" type="text" style="margin-bottom: 15px; margin-left: 10px;
                                        margin-top: 10px; width: 695px; padding: 4px; float: left;" />
                                    <input id="btnFindAddress" type="button" value="Find" onclick="return btnFindAddress_onclick()"
                                        class="searchbtn" style="background-color: #CE2357; float: left; margin-left: 15px;
                                        margin-top: 9px; width: 80px;" />
                                </div>
                                <div id="divMap" style="background-color: #E5E3DF; height: 310px; margin-bottom: 15px;
                                    margin-left: 10px; overflow: hidden; position: relative; width: 788px;">
                                </div>
                            </div>
                        </div>
                        <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
                        <%-- ReSharper disable UsageOfPossiblyUnassignedValue --%>
                        <script type="text/javascript">
                            var map;
                            var geocoder;
                            function InitializeMap() {
                                var latlng = new window.google.maps.LatLng(25.091196, 55.15538);
                                var myOptions =
                                {
                                    zoom: 15,
                                    center: latlng,
                                    mapTypeId: window.google.maps.MapTypeId.ROADMAP,
                                    disableDefaultUI: true

                                };
                                map = new window.google.maps.Map(document.getElementById("divMap"), myOptions);
                                var marker = new window.google.maps.Marker
                                (
                                    {
                                        position: new window.google.maps.LatLng(25.091196, 55.15538),
                                        map: map,
                                        title: 'View Details',
                                        draggable: true
                                    }
                                );
                                var infowindow = new window.google.maps.InfoWindow({
                                    content: 'Location info:<br/>Country Name:<br/>LatLng:'
                                });
                                window.google.maps.event.addListener(marker, 'click', function () {
                                    // Calling the open method of the infoWindow 
                                    infowindow.open(map, marker);
                                });
                            }

                            function FindLocaiton() {
                                geocoder = new window.google.maps.Geocoder();
                                InitializeMap();

                                var address = document.getElementById("addressinput").value;
                                geocoder.geocode({ 'address': address }, function (results, status) {
                                    if (status == window.google.maps.GeocoderStatus.OK) {
                                        map.setCenter(results[0].geometry.location);
                                        var marker = new window.google.maps.Marker({
                                            map: map,
                                            position: results[0].geometry.location
                                        });
                                        var region;
                                        var loc = [];

                                        if (results[0].formatted_address) {
                                            //Get formated address
                                            region = results[0].formatted_address;
                                            //Get latitude longitude values
                                            loc[0] = results[0].geometry.location.lat();
                                            loc[1] = results[0].geometry.location.lng();
                                        }
                                        var infowindow = new window.google.maps.InfoWindow({
                                            content: '<div style =width:400px; height:400px;>Location info:<br/>Country Name:<br/>' + region + '<br/>LatLng:<br/>' + results[0].geometry.location + '</div>'
                                        });
                                        window.google.maps.event.addListener(marker, 'click', function () {
                                            // Calling the open method of the infoWindow 
                                            infowindow.open(map, marker);
                                        });
                                        jQuery("#cmsBody_txtAddress").val(region);
                                        if (loc.length > 0) {
                                            jQuery("#cmsBody_txtLatitude").val(loc[0]);
                                            jQuery("#cmsBody_txtLongitude").val(loc[1]);
                                        }
                                        if (results[0].address_components.length > 0) {
                                            for (var i = 0; i < results[0].address_components.length; i++) {
                                                var addr = results[0].address_components[i];
                                                var getCountry;
                                                if (addr.types[0] == 'country') {
                                                    getCountry = addr.long_name;
                                                    jQuery("#cmsBody_txtCountry").val(getCountry);
                                                }
                                                else if (addr.types[0] == 'locality') {
                                                    getCountry = addr.long_name;
                                                    jQuery("#cmsBody_txtCity").val(getCountry);
                                                }
                                            }
                                        }
                                    }
                                    else {
                                        alert("Geocode was not successful for the following reason: " + status);
                                    }
                                });
                            }

                            function btnFindAddress_onclick() {
                                FindLocaiton();
                            }
                            window.onload = InitializeMap;
                        </script>
                        <%-- ReSharper restore UsageOfPossiblyUnassignedValue --%>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
