var routingApp = angular.module('routingApp', ['ngRoute']);

//configure routes
routingApp.config(function ($routeProvider, $locationProvider) {
    $routeProvider

    //route for home page
    .when('/', {
        templateUrl: 'pages/home.html',
        controller: 'mainController'
    })

    .when('/about', {
        templateUrl: 'pages/about.html',
        controller: 'aboutController'
    })

    .when('/contact', {
        templateUrl: 'pages/contact.html',
        controller: 'contactController'
    })
    .otherwise({
        redirectTo: '/'
    });

    // use the HTML5 History API
    $locationProvider.html5Mode(true);
});

//Create the controller and inject angular's scope
routingApp.controller('mainController', function ($scope) {

    //create a message to display in our view
    $scope.message = "This is the 'home' page coming via $routeProvider";
});

routingApp.controller('aboutController', function ($scope) {

    //create a message to display in our view
    $scope.message = "This is the 'about' page coming via $routeProvider";
});

routingApp.controller('contactController', function ($scope) {

    //create a message to display in our view
    $scope.message = "This is the 'contact' page coming via $routeProvider";
});