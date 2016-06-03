(function () {
    'use strict';
    angular
        .module('myQuotesApp')
        .controller('quotesController', quotesController)
        .controller('quotesAddController', quotesAddController)
        .controller('quotesEditController', quotesEditController)

    quotesController.$inject = ['$scope', '$filter', '$location', 'Quotes'];
    function quotesController($scope, $filter, $location, Quotes) {
        $scope.listQuotes = Quotes.query();

        $scope.sortBy = function (keyName) {
            $scope.sortKey = keyName;
            $scope.reverse = !$scope.reverse;
        }

        $scope.showConfirm = function (quote) {
            $scope.quote = quote;
            $("#confirmModal").modal('show');
        }

        $scope.deleteQuote = function () {
            var quote = $scope.quote;
            $scope.quote = Quotes.get({ id: quote.Id });
            $scope.deleteQuote = function () {
                $scope.quote.$remove({ id: $scope.quote.Id }, function () {
                    $("#confirmModal").modal('hide');
                    $location.path('/');
                },
                function (error) {
                    _showValidationErrors($scope, error);
                });
            };
        }
    };

    quotesAddController.$inject = ['$scope', '$location', 'Quotes'];
    function quotesAddController($scope, $location, Quotes) {
        $scope.quote = new Quotes();
        $scope.addQuote = function () {
            $scope.quote.$save(
                function () {
                    $location.path('/');
                },
                function (error) {
                    _showValidationErrors($scope, error);
                }
            );
        };

    }

    quotesEditController.$inject = ['$scope', '$routeParams', '$location', 'Quotes'];
    function quotesEditController($scope, $routeParams, $location, Quotes) {
        $scope.quote = Quotes.get({ id: $routeParams.id });
        $scope.editQuote = function () {
            $scope.quote.$save(
                function () {
                    $location.path('/');
                },
                function (error) {
                    _showValidationErrors($scope, error);
                }
            );
        };
    }

    /* Utility Functions */
    function _showValidationErrors($scope, error) {
        $scope.validationErrors = [];
        if (error.data && angular.isObject(error.data)) {
            for (var key in error.data) {
                $scope.validationErrors.push(error.data[key][0]);
            }
        } else {
            $scope.validationErrors.push('Could not add Quote.');
        };
    }
})();
