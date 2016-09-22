mainApp.controller('employeeController', function ($scope, $http, urlflag) {

    $scope.callwebapi = function () {
        $http.get(config_data_development.Production_Settings.employeeService).success(function (response) {
            $scope.employees = response;

            $scope.serviceresponse = "Web API called...";
        })
    }
});