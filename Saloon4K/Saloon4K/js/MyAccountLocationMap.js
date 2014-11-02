var map;
var geocoder;
function InitializeMap() {
    var autocomplete = new window.google.maps.places.Autocomplete($("#addressinput")[0], {});
    window.google.maps.event.addListener(autocomplete, 'place_changed', function () {
        // ReSharper disable UnusedLocals
        var place = autocomplete.getPlace();
        // ReSharper restore UnusedLocals        
    });
    var latlng = new window.google.maps.LatLng(25.091196, 55.15538);
    var myOptions =
                            {
                                zoom: 15,
                                center: latlng,
                                mapTypeId: window.google.maps.MapTypeId.ROADMAP,
                                disableDefaultUI: true

                            };
    map = new window.google.maps.Map(document.getElementById("divMapPickUpLocation"), myOptions);
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

function FindLocaitonPichUp() {
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
            jQuery("#body_AccountContent_txtAddress").val(region);
            if (loc.length > 0) {
                jQuery("#body_AccountContent_txtLatitude").val(loc[0]);
                jQuery("#body_AccountContent_txtLongitude").val(loc[1]);
            }
            if (results[0].address_components.length > 0) {
                for (var i = 0; i < results[0].address_components.length; i++) {
                    var addr = results[0].address_components[i];
                    var getCountry;
                    if (addr.types[0] == 'country') {
                        getCountry = addr.long_name;
                        jQuery("#body_AccountContent_txtCountry").val(getCountry);
                    }
                    else if (addr.types[0] == 'locality') {
                        getCountry = addr.long_name;
                        jQuery("#body_AccountContent_txtCity").val(getCountry);
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
    FindLocaitonPichUp();
}
window.onload = InitializeMap;
                    