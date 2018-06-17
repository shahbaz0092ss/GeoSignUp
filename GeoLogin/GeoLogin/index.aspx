<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Work Log</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
              <style>
      /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
      #map {
        height: 100vh;
        display: none;
      }
      /* Optional: Makes the sample page fill the window. */
    
      #floating-panel {
        position: absolute;
        top: 80px;
        left: 25%;
        z-index: 5;
        background-color: #fff;
        padding: 5px;
        border: 1px solid #999;
        text-align: center;
        font-family: 'Roboto','sans-serif';
        line-height: 30px;
        padding-left: 10px;
      }
    </style>

    <div id="map"></div>
            <div>
               <asp:TextBox id="name" placeholder="Full Name" runat="server"></asp:TextBox>
               <asp:TextBox id="currentLocation" placeholder="" runat="server"></asp:TextBox>
                <asp:Button ID="submitForm" runat="server" Text="Submit" OnClick="submitForm_Click" />
             </div>
    <script>
        // Note: This example requires that you consent to location sharing when
        // prompted by your browser. If you see the error "The Geolocation service
        // failed.", it means you probably did not give permission for the browser to
        // locate you.
        var map, infoWindow;
        function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: -34.397, lng: 150.644 },
                zoom: 18
            });
            infoWindow = new google.maps.InfoWindow;

            // Try HTML5 geolocation.
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(function (position) {
                    var pos = {
                        lat: position.coords.latitude,
                        lng: position.coords.longitude
                    };

                    console.log(pos.lat + " and " + pos.lng);
                    infoWindow.setPosition(pos);

                    // Reverse Geocoding
                    var geocoder = new google.maps.Geocoder;
                    var latlng = { lat: pos.lat, lng: pos.lng };
                    geocoder.geocode({ 'location': latlng }, function (results, status) {
                        if (status === 'OK') {
                            if (results[0]) {

                                infoWindow.setContent(results[0].formatted_address);
                                console.log(results[0].formatted_address);
                                document.getElementById("currentLocation").value = results[0].formatted_address;
                            } else {
                                window.alert('No results found');
                            }
                        } else {
                            window.alert('Geocoder failed due to: ' + status);
                        }
                    });


                    // infoWindow.setContent('<b>YOU ARE HERE !</b>');
                    infoWindow.open(map);
                    map.setCenter(pos);
                }, function () {
                    handleLocationError(true, infoWindow, map.getCenter());
                });
            } else {
                // Browser doesn't support Geolocation
                handleLocationError(false, infoWindow, map.getCenter());
            }
        }

        function handleLocationError(browserHasGeolocation, infoWindow, pos) {
            infoWindow.setPosition(pos);
            infoWindow.setContent(browserHasGeolocation ?
                'Error: The Geolocation service failed.' :
                'Error: Your browser doesn\'t support geolocation.');
            infoWindow.open(map);
        }
    </script>
   <script async defer
    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC6v5-2uaq_wusHDktM9ILcqIrlPtnZgEk">
    </script>
    <script>
        window.onload = initMap;
    </script>
        </div>
    </form>
</body>
</html>
