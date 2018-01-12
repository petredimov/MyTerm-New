(function () {
    'use strict';

    angular.module('app').controller('UserController', UserController);

    function UserController($http) {

        var vm = this;
        var dataService = $http;

        vm.LogoName = "MyTerm";
        vm.login = login;
        vm.register = register;

        vm.user = {
            Id:'',
            Username: '',
            PasswordHash: '',
            Email: '',
            EmailConfirmed: true,
            PhoneNumber: '',
            FirstName: '',
            LastName: '',
            ConfirmPassword: '',
        };

        function login() {           
            dataService.post("/api/accounts/login", vm.user)
            .then(function (result) {
                vm.user = result.data;                
            }, function (error) {               
                handleException(error);
            });
        }

        function register() {            
            dataService.post("/api/accounts/create", vm.user)
            .then(function (result) {
                console.log(result.data);
                alert('User is registered.');
                initUser();
            }, function (error) {
                handleException(error);
            });
        }

        function handleException(error) {
            alert(error.data.ExceptionMessage);
        }
        

        function initUser() {
            vm.user.Id = '';
            vm.user.Username = '';
            vm.user.Email = '';
            vm.user.EmailConfirmed = true;
            vm.user.FirstName = '';
            vm.user.LastName = '';
            vm.user.PasswordHash = '';
            vm.user.PhoneNumber = '';
            vm.user.ConfirmPassword = '';
        }
    }
})();