(function () {
    'use strict';

    angular.module('myQuotesApp', [
        "ngRoute",
        "quotesService",
        'angularUtils.directives.dirPagination'
    ]);

    angular.module('myQuotesApp').config(['$routeProvider', '$locationProvider',
        function ($routeProvider, $locationProvider) {

            $routeProvider
                .when('/', {
                    templateUrl: 'views/quotes/list.html',
                    controller: 'quotesController'
                })
                .when('/quotes/add', {
                    templateUrl: 'views/quotes/add.html',
                    controller: 'quotesAddController'
                })
                .when('/quotes/edit/:id', {
                    templateUrl: 'views/quotes/edit.html',
                    controller: 'quotesEditController'
                })
                .otherwise({ redirectTo: '/' });

            $locationProvider.html5Mode(true);
        }]);
})();