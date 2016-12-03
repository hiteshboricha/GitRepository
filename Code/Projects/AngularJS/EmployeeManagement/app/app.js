

var mainApp = angular.module('mainApp', ['ngRoute']);

//configure routes
mainApp.config(function ($routeProvider, $locationProvider) {
    $routeProvider

    //route for home page
    .when('/home', {
        templateUrl: 'app/employees/pages/home.html',
        controller: 'employeeController'
    })

    .when('/', {
        templateUrl: '/app/common/pages/mainpage.html',
        controller:  'mainController'
    });

    // use the HTML5 History API
    $locationProvider.html5Mode(true);
});

mainApp.constant('urlflag', 'home');
//mainApp.constant('urlflag', 'work');