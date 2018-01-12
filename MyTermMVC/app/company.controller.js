(function () {
    'use strict';

    angular.module('app').controller('CompanyController', CompanyController);

    function CompanyController($http) {

        var vm = this;
        var dataService = $http;

        vm.insertCompany = insertCompany;
        vm.countries = [];
        vm.company = {
            Town: '',
            Minicipality: '',
            AreaCode: '',
            PhoneNumber: '',
            Country:
                {
                    Name: '',
                    Description: '',
                    Id: 0,
                    Prefix: ''
                },
            Address: '',
            FirstName: '',
            LastName: '',
            EDB: '',
            FaxNumber: '',
            Name: '',
        };

        getCountriesList();

        function getCompany(id) {
            dataService.get("/api/Company", id)
            .then(function (result) {
                vm.company = result.data;
            }, function (error) {
                handleException(error);
            });
        }

        function getCountriesList() {
            dataService.get("/api/Country").then(function (result) {
                vm.countries = result;
            }, function (error) {
                handleException(error);
            });
        }

        function insertCompany() {
            dataService.post("/api/Company", vm.company)
            .then(function (result) {
                console.log(result.data);
                alert('Company created.');
                initCompany();
            }, function (error) {
                handleException(error);
            });
        }

        function handleException(error) {
            alert(error.data.ExceptionMessage);
        }

        function updateCompany() {

        }

        function initCompany() {
            vm.company.Town = '';
            vm.company.Minicipality = '';
            vm.company.AreaCode = '';
            vm.company.PhoneNumber = '';
            vm.company.Country.Id = 0;
            vm.company.Country.Description = '';
            vm.company.Country.Name = '';
            vm.company.Country.Prefix = '';
            vm.company.Address = '';
            vm.company.FirstName = '';
            vm.company.LastName = '';
            vm.company.EDB = '';
            vm.company.FaxNumber = '';
            vm.company.Name = '';
        }
    }
})();