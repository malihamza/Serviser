var bookingApp = angular.module("MechanicBookingApp", ['ngAnimate']);

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

        $scope.map = new google.maps.Map(document.getElementById('map'), {
            zoom: 4,
            center: $scope.currentPos
        });

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


}