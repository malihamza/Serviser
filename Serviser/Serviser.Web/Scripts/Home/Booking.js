var mechanicHub = $.connection.mechanicHub;
var map;
var mechanic_markers = [];
var problem_id_list = [];
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


$.connection.hub.start()
    .done(function () {
        //alert("Helkklo");
    })
    .fail(function () {
        alert("Failed TO start a realtime connection");
    });


mechanicHub.client.updateMechanics = function (data) {
    for (let i = 0; i < mechanic_markers.length; i++) {
        mechanic_markers[i].setMap(null);
    }

    mechanic_markers.splice(0, mechanic_markers.length);

    for (var mechanic in data) {
        addMarker(data[mechanic].Longitude, data[mechanic].Latitude, map, 'Mechanic', 'a');
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
    if (icon1 != null) {
        marker.setIcon(document.getElementById('ico').getAttribute('src'));
    }
    mechanic_markers.push(marker);
}






function next_view() {
    document.getElementById("problem").style.visibility = "hidden";
    document.getElementById("bill").style.visibility = "hidden";
    document.getElementById("map_div").style.height = "800px";
    document.getElementById("loader").style.visibility = "visible";

    $('html, body').animate({ scrollTop: 0 }, '300');
    $("#loader").fadeIn('slow').delay(5000).fadeOut('slow');
    setTimeout(display, 6000);

    mechanicHub.server.getMechanics(my_position);

}

function display() {
    document.getElementById("info").style.visibility = "visible";
    $("#info").fadeIn('slow');
}




/****This is to add problem***/
$(document).ready(function () {
    $("input[type=checkbox]").change(function () {
        var checked_value = $(this).parent().parent().next().next().text();
        checked_value = parseInt(checked_value.substring(4, checked_value.length));

        var est_bill = $("#estimated_bill").text();
        est_bill = parseInt(est_bill.substring(4, est_bill.length));

        var net_bill = $("#net_bill").text();
        net_bill = parseInt(net_bill.substring(4, net_bill.length));

        if (this.checked)
        {
            problem_id_list.push(parseInt($(this).parent().parent().next().next().next().text()));

            $("#estimated_bill").text("RS/- " + (est_bill + checked_value));
            $("#net_bill").text("RS/- " + (net_bill + checked_value));
        }
        else {
            var index = problem_id_list.indexOf(parseInt($(this).parent().parent().next().next().next().text()));

            problem_id_list.splice(index, 1);

            $("#estimated_bill").text("RS/- " + (est_bill - checked_value));
            $("#net_bill").text("RS/- " + (net_bill - checked_value));

        }
        //alert(problem_id_list);
    });

});
