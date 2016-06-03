(function () {
    'use strict';

    angular.module('quotesService', ['ngResource', 'angular-loading-bar']).factory('Quotes', Quotes);

    Quotes.$inject = ['$resource'];
    function Quotes($resource) {
        return $resource('/api/quotes/:id');
    }
})();