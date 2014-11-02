<%@ Page Title="Salon 4K | My Location" Language="C#" MasterPageFile="~/UserAccount/Account.master"
    AutoEventWireup="true" CodeBehind="MyLocation.aspx.cs" Inherits="Saloon4K.UserAccount.MyLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AccountContent" runat="server">
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#body_lnkMyLocation").addClass("current");
        });
    </script>
    <div class="webappright">
        <div id="locationmap">
        </div>
        <div class="address">
            <h2>
                Address</h2>
            <p>
                Lorem Ipsum<br>
                Dolor Sumi<br>
                Jumeirah, Dubai<br>
                United Arab Emirates<br>
                Phone: <a href="tel:00000000">00000000</a><br>
                P.O.Box: 000000
            </p>
        </div>
    </div>
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false" type="text/javascript"></script>
    <script type="text/javascript">

        var styles = [
  {
      "featureType": "landscape",
      "stylers": [
      { "saturation": 80 }
    ]
  }, {
      "featureType": "poi",
      "stylers": [
      { "saturation": 36 },
      { "lightness": 18 }
    ]
  }, {
      "featureType": "road",
      "stylers": [
      { "saturation": 60 }
    ]
  }, {
      "elementType": "labels.text.stroke",
      "stylers": [
      { "visibility": "on" }
    ]
  }, {
      "featureType": "water",
      "stylers": [
      { "saturation": 100 }
    ]
  }, {
      "featureType": "road",
      "elementType": "geometry.stroke",
      "stylers": [
      { "visibility": "off" }
    ]
  }
];

        var map;
        var mycenter = new google.maps.LatLng(25.107499, 55.183863);
        var myLatLang = new google.maps.LatLng(25.107499, 55.183863);

        function initialize() {
            var mapOptions = {
                zoom: 14,
                center: mycenter,
                scrollwheel: false,
                mapTypeControl: false,
                streetViewControl: false,
                panControl: true,
                draggable: true,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            map = new google.maps.Map(document.getElementById('locationmap'),
        mapOptions);
            var icon = new google.maps.MarkerImage("images/pin.png", null, null, null, new google.maps.Size(50, 57));
            var marker = new google.maps.Marker({
                position: myLatLang,
                map: map,
                title: "Salon 4K",
                icon: icon
            });
            var styledMap = new google.maps.StyledMapType(styles, { name: "Styled Map" });

            map.mapTypes.set('map_style', styledMap);
            map.setMapTypeId('map_style');

            var mapOptions2 = {
                zoom: 16,
                center: mycenter,
                scrollwheel: false,
                mapTypeControl: false,
                streetViewControl: false,
                panControl: false,
                draggable: true,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            map2 = new google.maps.Map(document.getElementById('location'),
        mapOptions2);
            var icon2 = new google.maps.MarkerImage("images/pin.png", null, null, null, new google.maps.Size(50, 57));
            var marker2 = new google.maps.Marker({
                position: myLatLang2,
                map: map2,
                title: "Salon 4K",
                icon: icon2
            });

            map2.mapTypes.set('map_style', styledMap);
            map2.setMapTypeId('map_style');
        };
        google.maps.event.addDomListener(window, 'load', initialize);
    </script>
</asp:Content>
