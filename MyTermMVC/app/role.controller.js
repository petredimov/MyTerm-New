(function () {
    'use strict';

    angular
        .module('app')
        .controller('role', role);

    role.$inject = ['$location']; 

    function role($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'role';

        activate();

        function activate() { }
    }
})();
