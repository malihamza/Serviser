<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of c6bbca6... a
﻿//var bookingApp = angular.module("MechanicBookingApp", ['ngAnimate']);

//bookingApp.controller("OptionsSelectionController", function ($scope) {
//    var me = this;
//    me.maxSteps = 4;
//    $scope.currentStep = 1;

//    $scope.optionsData = [];
//    $scope.selectedVehicleTypeIndex = null;
//    $scope.selectedProblemsIndices = [];
//    $scope.descriptionOfProblem = '';
//    $scope.currentPos = { lat: 0, lng: 0 };
//    $scope.map = null;
//    $scope.mapMarker = null;
//    $scope.currentAddress = 'Map API quota is out probably';

//    me.pos = new google.maps.LatLng();

//    $scope.step1Click = function (index) {
//        $scope.selectedVehicleTypeIndex = index;
//        $scope.selectedProblemsIndices = new Array($scope.optionsData[index].Problems.length);
//        $scope.nextStep();
//    }

//    $scope.step2ItemClick = function (index) {
//        $scope.selectedProblemsIndices[index] = !$scope.selectedProblemsIndices[index];
//    }


//    $scope.pinCurrentLocation = function () {
//        if (navigator.geolocation) {
//            navigator.geolocation.getCurrentPosition(function (position) {
//                $scope.currentPos.lat = position.coords.latitude;
//                $scope.currentPos.lng = position.coords.longitude;
//                $scope.mapMarker.setPosition($scope.currentPos);
//                $scope.map.panTo($scope.currentPos);
//            },
//                function (posErr) {
//                    alert(posErr.message);
//                });
//        }
//        else {
//            alert("Your Browser Doesn't Support GeoLocation");
//        }
//    }


//    $scope.nextStep = function () {
//        if ($scope.currentStep < me.maxSteps)
//            $scope.currentStep++;
//    }
//    $scope.previousStep = function () {
//        if ($scope.currentStep > 1)
//            $scope.currentStep--;
//    }

//    me.getCurrentPosition = function () {
//        if (navigator.geolocation) {
//            navigator.geolocation.getCurrentPosition(function (position) {
//                    $scope.currentPos.lat = position.coords.latitude;
//                    $scope.currentPos.lng = position.coords.longitude;
//            });
//        }
//    }

//    me.initMapWithLocation = function (position) {
//        $scope.currentPos.lat = position.coords.latitude;
//        $scope.currentPos.lng = position.coords.longitude;

//        $scope.map = new google.maps.Map(document.getElementById('map'), {
//            zoom: 4,
//            center: $scope.currentPos
//        });

//        $scope.mapMarker = new google.maps.Marker({
//            position: $scope.currentPos,
//            map: $scope.map,
//            draggable: true,
//            animation: google.maps.Animation.DROP
//        });

//        google.maps.event.addListener($scope.mapMarker, 'mouseup', function (event) {
//            $scope.currentPos = {
//                lat: $scope.mapMarker.getPosition().lat(),
//                lng: $scope.mapMarker.getPosition().lng()
//            };

//            $.getJSON(`https://maps.googleapis.com/maps/api/geocode/json?latlng=${$scope.currentPos.lat},${$scope.currentPos.lng}&key=AIzaSyDg-T5ErBSP7PrxppZiO9OPBA3HW4TXleo`, function (data, status) {
//                if (status === 'success') {
//                    $scope.currentAddress = data.results[0].formatted_address;
//                }
//            });
//        });
//    }

//    me.initMap = function () {
//        if (navigator.geolocation) {
//            navigator.geolocation.getCurrentPosition(me.initMapWithLocation, me.initMapWithLocation({ coords: {latitude: 0, longitude: 0}}));
//        }
//        else {
//            me.initMapWithLocation({ coords: { latitude: 0, longitude: 0 } });
//        }
//    }

//    $(function () { me.initMap(); });

//    dummyDataInstantiate($scope);
//});

//function dummyDataInstantiate(scope) {
//    scope.optionsData = [
//        {
//            Id: 1, Name: 'Bike', ImageUrl: '/Assets/Images/bike.png', Problems:
//            [{ Id: 1, Title: 'Problem 1' }, { Id: 2, Title: 'Problem 2' }, { Id: 3, Title: 'Problem 3' }, { Id: 4, Title: 'Problem 4' }]
//        },
//        {
//            Id: 2, Name: 'Car', ImageUrl: '/Assets/Images/car.png', Problems:
//            [{ Id: 5, Title: 'Problem 5' }, { Id: 6, Title: 'Problem 6' }, { Id: 7, Title: 'Problem 7' }, { Id: 8, Title: 'Problem 8' }]
//        },
//        {
//            Id: 3, Name: 'Truck', ImageUrl: '/Assets/Images/truck.png', Problems:
//            [{ Id: 5, Title: 'Problem 5' }, { Id: 6, Title: 'Problem 6' }, { Id: 7, Title: 'Problem 7' }, { Id: 8, Title: 'Problem 8' }]
//        },
//        {
//            Id: 4, Name: 'Van', ImageUrl: '/Assets/Images/van.png', Problems:
//            [{ Id: 1, Title: 'Problem 1' }, { Id: 2, Title: 'Problem 2' }, { Id: 3, Title: 'Problem 3' }, { Id: 4, Title: 'Problem 4' }]
//        },
//        {
//            Id: 1, Name: 'Bike', ImageUrl: '/Assets/Images/bike.png', Problems:
//            [{ Id: 1, Title: 'Problem 1' }, { Id: 2, Title: 'Problem 2' }, { Id: 3, Title: 'Problem 3' }, { Id: 4, Title: 'Problem 4' }]
//        },
//        {
//            Id: 2, Name: 'Car', ImageUrl: '/Assets/Images/car.png', Problems:
//            [{ Id: 5, Title: 'Problem 5' }, { Id: 6, Title: 'Problem 6' }, { Id: 7, Title: 'Problem 7' }, { Id: 8, Title: 'Problem 8' }]
//        },
//        {
//            Id: 3, Name: 'Truck', ImageUrl: '/Assets/Images/truck.png', Problems:
//            [{ Id: 5, Title: 'Problem 5' }, { Id: 6, Title: 'Problem 6' }, { Id: 7, Title: 'Problem 7' }, { Id: 8, Title: 'Problem 8' }]
//        },
//        {
//            Id: 4, Name: 'Van', ImageUrl: '/Assets/Images/van.png', Problems:
//            [{ Id: 1, Title: 'Problem 1' }, { Id: 2, Title: 'Problem 2' }, { Id: 3, Title: 'Problem 3' }, { Id: 4, Title: 'Problem 4' }]
//        }
//    ];


//}











if (navigator.geolocation)
{
    var pos = {lati : 20,longi:20};
    nav = navigator.geolocation;
    nav.getCurrentPosition(success, failure);
    var map;
    function success(position) {
        var lati = position.coords.latitude;
        var longi = position.coords.longitude;
        pos.lati = lati;
        pos.longi = longi;
        map = new google.maps.Map(document.getElementById('map_div'), {
            center: { lat: lati, lng: longi },
            zoom: 17,
            zoomControl: false,
             gestureHandling: 'none',
            scaleControl: false

        });
        addMarker(longi, lati,'Your Current Location');
    }
    function addMarker(longi, lati,title,icon1) {
        
        if (icon1 != null) {
            var marker = new google.maps.Marker({
                position: { lat: lati, lng: longi },
                title: title,
                map: map,
                animation: google.maps.Animation.DROP,
                icon: document.getElementById('ico').getAttribute('src')
            });
        }
        else
        {
            var marker = new google.maps.Marker({
                position: { lat: lati, lng: longi },
                title: title,
                animation: google.maps.Animation.DROP,
                map: map
            });
        }
        //var info = new google.maps.InfoWindow({
        //    content: document.getElementById('info')
        //});
        marker.addListener('click', function () {
            //info.open(map, marker);
            document.getElementById('info').style.visibility = "visible";
        });
    }
    function failure() {
        alert("failed");
    }

}
<<<<<<< HEAD
=======
    $scope.previousStep = function () {
        if ($scope.currentStep > 1)
            $scope.currentStep--;
    }
>>>>>>> parent of f019f0c... Merge branch 'master' of https://github.com/malihamza/Serviser
=======
﻿var bookingApp = angular.module("MechanicBookingApp", ['ngAnimate']);

bookingApp.controller("OptionsSelectionController", function ($scope) {
    var me = this;
    me.maxSteps = 4;
    $scope.currentStep = 1;

    $scope.optionsData = [];
    $scope.selectedVehicleTypeIndex = null;
    $scope.selectedProblemsIndices = [];
    $scope.descriptionOfProblem = '';
    $scope.currentPos = { lat: 0, lng: 0 };
    $scope.map = null;
    $scope.mapMarker = null;
    $scope.currentAddress = 'Map API quota is out probably';

    me.pos = new google.maps.LatLng();

    $scope.step1Click = function (index) {
        $scope.selectedVehicleTypeIndex = index;
        $scope.selectedProblemsIndices = new Array($scope.optionsData[index].Problems.length);
        $scope.nextStep();
    }

    $scope.step2ItemClick = function (index) {
        $scope.selectedProblemsIndices[index] = !$scope.selectedProblemsIndices[index];
    }


    $scope.pinCurrentLocation = function () {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                $scope.currentPos.lat = position.coords.latitude;
                $scope.currentPos.lng = position.coords.longitude;
                $scope.mapMarker.setPosition($scope.currentPos);
                $scope.map.panTo($scope.currentPos);
            },
                function (posErr) {
                    alert(posErr.message);
                });
        }
        else {
            alert("Your Browser Doesn't Support GeoLocation");
        }
    }


    $scope.nextStep = function () {
        if ($scope.currentStep < me.maxSteps)
            $scope.currentStep++;
    }
    $scope.previousStep = function () {
        if ($scope.currentStep > 1)
            $scope.currentStep--;
    }
>>>>>>> parent of f019f0c... Merge branch 'master' of https://github.com/malihamza/Serviser

=======
﻿var bookingApp = angular.module("MechanicBookingApp", ['ngAnimate']);

bookingApp.controller("OptionsSelectionController", function ($scope) {
    var me = this;
    me.maxSteps = 4;
    $scope.currentStep = 1;

    $scope.optionsData = [];
    $scope.selectedVehicleTypeIndex = null;
    $scope.selectedProblemsIndices = [];
    $scope.descriptionOfProblem = '';
    $scope.currentPos = { lat: 0, lng: 0 };
    $scope.map = null;
    $scope.mapMarker = null;
    $scope.currentAddress = 'Map API quota is out probably';

    me.pos = new google.maps.LatLng();

    $scope.step1Click = function (index) {
        $scope.selectedVehicleTypeIndex = index;
        $scope.selectedProblemsIndices = new Array($scope.optionsData[index].Problems.length);
        $scope.nextStep();
    }

    $scope.step2ItemClick = function (index) {
        $scope.selectedProblemsIndices[index] = !$scope.selectedProblemsIndices[index];
    }


    $scope.pinCurrentLocation = function () {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                $scope.currentPos.lat = position.coords.latitude;
                $scope.currentPos.lng = position.coords.longitude;
                $scope.mapMarker.setPosition($scope.currentPos);
                $scope.map.panTo($scope.currentPos);
            },
                function (posErr) {
                    alert(posErr.message);
                });
        }
        else {
            alert("Your Browser Doesn't Support GeoLocation");
        }
    }


    $scope.nextStep = function () {
        if ($scope.currentStep < me.maxSteps)
            $scope.currentStep++;
    }
    $scope.previousStep = function () {
        if ($scope.currentStep > 1)
            $scope.currentStep--;
    }

>>>>>>> parent of f019f0c... Merge branch 'master' of https://github.com/malihamza/Serviser
    me.getCurrentPosition = function () {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                    $scope.currentPos.lat = position.coords.latitude;
                    $scope.currentPos.lng = position.coords.longitude;
            });
        }
    }

    me.initMapWithLocation = function (position) {
        $scope.currentPos.lat = position.coords.latitude;
        $scope.currentPos.lng = position.coords.longitude;
=======
>>>>>>> parent of c6bbca6... a


<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of c6bbca6... a
function next_view() {
    document.getElementById("problem").style.visibility = "hidden";
    document.getElementById("bill").style.visibility = "hidden";
    document.getElementById("map_div").style.height = "100%";
    document.getElementById("loader").style.visibility = "visible";

    $('html, body').animate({ scrollTop: 0 }, '300');
//    $("#loader").fadeIn('slow').delay(5000).fadeOut('slow');

    
    $.ajax({
        url: "/Services/getMechanics",
        method: "POST",
        data: { Latitude: pos.lati, Longitude: pos.longi },
        success: function (data) {
            for (var mechanic in data) {
                addMarker(data[mechanic].Longitude, data[mechanic].Latitude, 'Mechanic', 'a');
            }
        },
        failure: function (err) {
            console.log(err);
        }
    });
    //setTimeout(display, 6000);
    display();
    document.getElementById("loader").style.visibility = "hidden";
   

<<<<<<< HEAD
=======
        $scope.mapMarker = new google.maps.Marker({
            position: $scope.currentPos,
            map: $scope.map,
            draggable: true,
            animation: google.maps.Animation.DROP
        });

        google.maps.event.addListener($scope.mapMarker, 'mouseup', function (event) {
            $scope.currentPos = {
                lat: $scope.mapMarker.getPosition().lat(),
                lng: $scope.mapMarker.getPosition().lng()
            };

=======
        $scope.mapMarker = new google.maps.Marker({
            position: $scope.currentPos,
            map: $scope.map,
            draggable: true,
            animation: google.maps.Animation.DROP
        });

        google.maps.event.addListener($scope.mapMarker, 'mouseup', function (event) {
            $scope.currentPos = {
                lat: $scope.mapMarker.getPosition().lat(),
                lng: $scope.mapMarker.getPosition().lng()
            };

>>>>>>> parent of f019f0c... Merge branch 'master' of https://github.com/malihamza/Serviser
=======
        $scope.mapMarker = new google.maps.Marker({
            position: $scope.currentPos,
            map: $scope.map,
            draggable: true,
            animation: google.maps.Animation.DROP
        });

        google.maps.event.addListener($scope.mapMarker, 'mouseup', function (event) {
            $scope.currentPos = {
                lat: $scope.mapMarker.getPosition().lat(),
                lng: $scope.mapMarker.getPosition().lng()
            };

>>>>>>> parent of f019f0c... Merge branch 'master' of https://github.com/malihamza/Serviser
            $.getJSON(`https://maps.googleapis.com/maps/api/geocode/json?latlng=${$scope.currentPos.lat},${$scope.currentPos.lng}&key=AIzaSyDg-T5ErBSP7PrxppZiO9OPBA3HW4TXleo`, function (data, status) {
                if (status === 'success') {
                    $scope.currentAddress = data.results[0].formatted_address;
                }
            });
        });
    }

    me.initMap = function () {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(me.initMapWithLocation, me.initMapWithLocation({ coords: {latitude: 0, longitude: 0}}));
        }
        else {
            me.initMapWithLocation({ coords: { latitude: 0, longitude: 0 } });
        }
    }

    $(function () { me.initMap(); });

    dummyDataInstantiate($scope);
});

function dummyDataInstantiate(scope) {
    scope.optionsData = [
        {
            Id: 1, Name: 'Bike', ImageUrl: '/Assets/Images/bike.png', Problems:
            [{ Id: 1, Title: 'Problem 1' }, { Id: 2, Title: 'Problem 2' }, { Id: 3, Title: 'Problem 3' }, { Id: 4, Title: 'Problem 4' }]
        },
        {
            Id: 2, Name: 'Car', ImageUrl: '/Assets/Images/car.png', Problems:
            [{ Id: 5, Title: 'Problem 5' }, { Id: 6, Title: 'Problem 6' }, { Id: 7, Title: 'Problem 7' }, { Id: 8, Title: 'Problem 8' }]
        },
        {
            Id: 3, Name: 'Truck', ImageUrl: '/Assets/Images/truck.png', Problems:
            [{ Id: 5, Title: 'Problem 5' }, { Id: 6, Title: 'Problem 6' }, { Id: 7, Title: 'Problem 7' }, { Id: 8, Title: 'Problem 8' }]
        },
        {
            Id: 4, Name: 'Van', ImageUrl: '/Assets/Images/van.png', Problems:
            [{ Id: 1, Title: 'Problem 1' }, { Id: 2, Title: 'Problem 2' }, { Id: 3, Title: 'Problem 3' }, { Id: 4, Title: 'Problem 4' }]
        },
<<<<<<< HEAD
<<<<<<< HEAD
        {
            Id: 1, Name: 'Bike', ImageUrl: '/Assets/Images/bike.png', Problems:
            [{ Id: 1, Title: 'Problem 1' }, { Id: 2, Title: 'Problem 2' }, { Id: 3, Title: 'Problem 3' }, { Id: 4, Title: 'Problem 4' }]
        },
        {
            Id: 2, Name: 'Car', ImageUrl: '/Assets/Images/car.png', Problems:
            [{ Id: 5, Title: 'Problem 5' }, { Id: 6, Title: 'Problem 6' }, { Id: 7, Title: 'Problem 7' }, { Id: 8, Title: 'Problem 8' }]
        },
        {
            Id: 3, Name: 'Truck', ImageUrl: '/Assets/Images/truck.png', Problems:
            [{ Id: 5, Title: 'Problem 5' }, { Id: 6, Title: 'Problem 6' }, { Id: 7, Title: 'Problem 7' }, { Id: 8, Title: 'Problem 8' }]
        },
        {
            Id: 4, Name: 'Van', ImageUrl: '/Assets/Images/van.png', Problems:
            [{ Id: 1, Title: 'Problem 1' }, { Id: 2, Title: 'Problem 2' }, { Id: 3, Title: 'Problem 3' }, { Id: 4, Title: 'Problem 4' }]
        }
    ];
>>>>>>> parent of f019f0c... Merge branch 'master' of https://github.com/malihamza/Serviser
=======
>>>>>>> parent of c6bbca6... a

}
function display() {
    document.getElementById("info").style.visibility = "visible";
    $("#info").fadeIn('slow');
}




async function makeAjaxRequest()
{
    await $.ajax({
        url: "/Services/getMechanics",
        method: "POST",
        data: { Latitude: pos.lati, Longitude: pos.longi },
        success: function (data)
        {
            for (var mechanic in data)
            {
                addMarker(data[mechanic].Longitude, data[mechanic].Latitude, 'Mechanic', 'a');
            }
=======
        {
            Id: 1, Name: 'Bike', ImageUrl: '/Assets/Images/bike.png', Problems:
            [{ Id: 1, Title: 'Problem 1' }, { Id: 2, Title: 'Problem 2' }, { Id: 3, Title: 'Problem 3' }, { Id: 4, Title: 'Problem 4' }]
>>>>>>> parent of f019f0c... Merge branch 'master' of https://github.com/malihamza/Serviser
=======
        {
            Id: 1, Name: 'Bike', ImageUrl: '/Assets/Images/bike.png', Problems:
            [{ Id: 1, Title: 'Problem 1' }, { Id: 2, Title: 'Problem 2' }, { Id: 3, Title: 'Problem 3' }, { Id: 4, Title: 'Problem 4' }]
>>>>>>> parent of f019f0c... Merge branch 'master' of https://github.com/malihamza/Serviser
        },
        {
            Id: 2, Name: 'Car', ImageUrl: '/Assets/Images/car.png', Problems:
            [{ Id: 5, Title: 'Problem 5' }, { Id: 6, Title: 'Problem 6' }, { Id: 7, Title: 'Problem 7' }, { Id: 8, Title: 'Problem 8' }]
        },
        {
            Id: 3, Name: 'Truck', ImageUrl: '/Assets/Images/truck.png', Problems:
            [{ Id: 5, Title: 'Problem 5' }, { Id: 6, Title: 'Problem 6' }, { Id: 7, Title: 'Problem 7' }, { Id: 8, Title: 'Problem 8' }]
        },
        {
            Id: 4, Name: 'Van', ImageUrl: '/Assets/Images/van.png', Problems:
            [{ Id: 1, Title: 'Problem 1' }, { Id: 2, Title: 'Problem 2' }, { Id: 3, Title: 'Problem 3' }, { Id: 4, Title: 'Problem 4' }]
        }
<<<<<<< HEAD
<<<<<<< HEAD
    });

<<<<<<< HEAD
=======
>>>>>>> parent of f019f0c... Merge branch 'master' of https://github.com/malihamza/Serviser
=======
    ];


>>>>>>> parent of f019f0c... Merge branch 'master' of https://github.com/malihamza/Serviser
=======
    ];


>>>>>>> parent of f019f0c... Merge branch 'master' of https://github.com/malihamza/Serviser
=======
>>>>>>> parent of c6bbca6... a
}