(function () {
    'use strict';

    angular.module('app').controller('CategoryController', CategoryController);

    function CategoryController($http) {

        var vm = this;
        var dataService = $http;
    }
})();