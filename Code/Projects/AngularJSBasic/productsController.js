mainApp.controller('productsController', function ($scope, $http) {
    $scope.callwebapi = function () {
        //var url = "http://INMUMWRK000086/WebAPI/api/Products/";
        var url = "http://h-pc/WebAPI/api/Products/";

        $http.get(url).success( function (response) { 
            $scope.products = response;

            $scope.serviceresponse = "Web API called...";
        })
    }
});