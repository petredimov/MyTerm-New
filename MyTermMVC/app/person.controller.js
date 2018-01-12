(function () {
    'use strict';

    angular.module('app').controller('PersonController', PersonController);

    function PersonController($http) {

        var vm = this;
        var dataService = $http;
        vm.insertPerson = insertPerson;

        vm.person = {
            Town: '',
            Minicipality: '',
            AreaCode: '',
            PhoneNumber: '',
            Country: '',
            Address: '',
            FirstName: '',
            LastName: '',
        };

        function getPerson(id)
        {
            dataService.get("/api/Person", id)
            .then(function (result) {
                vm.person = result.data;
            }, function (error) {
                handleException(error);
            });
        }

        function insertPerson() {
            dataService.post("/api/Person", vm.person)
            .then(function (result) {
                console.log(result.data);
                alert('Person created.');
                initPerson();
            }, function (error) {
                handleException(error);
            });
        }

        function handleException(error) {
            alert(error.data.ExceptionMessage);
        }

        function updatePerson() {

        }

        function initPerson() {
            vm.person.Town = '';
            vm.person.Minicipality = '';
            vm.person.AreaCode = '';
            vm.person.PhoneNumber = '';
            vm.person.Country = '';
            vm.person.Address = '';
            vm.person.FirstName = '';
            vm.person.LastName = '';
        }
    }
})();
