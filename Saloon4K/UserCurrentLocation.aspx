<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserCurrentLocation.aspx.cs"
    Inherits="Saloon4K.UserCurrentLocation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <title>Reverse Geocoding</title>
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/jquery.bpopup.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
    <script type="text/javascript">
        var geocoder;
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(successFunction, errorFunction);
        }
        //Get the latitude and the longitude;
        function successFunction(position) {
            var lat = position.coords.latitude;
            var lng = position.coords.longitude;
            codeLatLng(lat, lng);
        }
        function errorFunction() {
            alert("Geocoder failed");
        }
        function initialize() {
            geocoder = new google.maps.Geocoder();
        }
        function codeLatLng(lat, lng) {
            var latlng = new google.maps.LatLng(lat, lng);
            geocoder.geocode({ 'latLng': latlng }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    console.log(results);
                    if (results[1]) {
                        //formatted address
                        //alert(results[0].formatted_address);
                        var split = results[0].formatted_address.split('-');
                        if (split.length > 0) {
                            $("#lblCountry").html(split[2]);
                        }
                    } else {
                        alert("No results found");
                    }
                } else {
                    alert("Geocoder failed due to: " + status);
                }
            });
        }
    </script>
    <script type="text/javascript">
        $(document).load(function () {
            initialize();
            $("#divPopUp").bPopup();
        });
    </script>
    <style type="text/css">
        .DivPopUp
        {
            display: none;
            width: 840px;
            height: 690px;
            background-image: url(images/popupouterbg.jpg);
            background-repeat: repeat;
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divPopUp" class="DivPopUp">
        You current Location is :
        <asp:Label runat="server" ID="lblCountry" ClientIDMode="Static"></asp:Label>
    </div>
    </form>
</body>
</html>
