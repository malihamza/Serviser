var mechanicHub = $.connection.mechanicHub;
var map;
var mechanic_markers = [];
var my_position = { Latitude: 20, Longitude: 20 };









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
        addMarker(longi, lati, map, 'Your Current Location');
    }

    function failure() {
        alert("failed");
    }

}


function addMarker(longi, lati, map, title, icon1) {
    var marker = new google.maps.Marker(
        {
            position: { lat: lati, lng: longi },
            title: title,
            map: map,
            animation: google.maps.Animation.DROP
        });
    
   
}




$.connection.hub.start()
    .done(function () {
        mechanicHub.server.updateLocationOfMechanic(my_position);
    })
    .fail(function () {
        alert("Hello");
    });

mechanicHub.client.showLocation = function (data)
{
    alert(data.Latitude + "  " + data.Longitude);
}
