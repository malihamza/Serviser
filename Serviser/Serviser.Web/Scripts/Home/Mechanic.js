var mechanicHub = $.connection.mechanicHub;
var hub = $.connection.hub;
var map;
var mechanic_markers = [];
var problem_id_list = [];
var my_position = { Latitude: 0, Longitude: 0 };
var my_marker;






if (navigator.geolocation) {


    var nav = navigator.geolocation;
    nav.getCurrentPosition(success, failure);

    function success(position) {
        var lati = position.coords.latitude;
        var longi = position.coords.longitude;
        my_position.Latitude = lati;
        my_position.Longitude = longi;


        map = new google.maps.Map(document.getElementById('map_div'),
            {
                center: { lat: lati, lng: longi },
                zoom: 17,
                zoomControl: false,
                gestureHandling: 'none',
                scaleControl: false
            });
        addMarkerOnMyLocation();

        hub.start().done(function () { mechanicHub.server.saveMyLocationAndTime(my_position, userId); });

    }

    function failure() {
       // alert("failed");
    }

}



function addMarkerOnMyLocation() {
    my_marker = new google.maps.Marker(
        {
            position: { lat: my_position.Latitude, lng: my_position.Longitude },
            title: 'My Location',
            map: map
            //  animation: google.maps.Animation.DROP
        });
}


setInterval(function () {
    hub.start().done(function () { mechanicHub.server.saveMyLocationAndTime(my_position, userId); });
 
}, 5000);


function addMarker(longi, lati, map, title, icon1) {
    var marker = new google.maps.Marker(
        {
            position: { lat: lati, lng: longi },
            title: title,
            map: map
            //animation: google.maps.Animation.DROP
        });
    
   
}



mechanicHub.client.showCustomerRequest = function (data)
{
    $("#customerName").html(data.FirstName + " " + data.LastName);
    $("#customerNumber").html(data.PhoneNumber);
    document.getElementById("loader").style.visibility = "visible";
}
