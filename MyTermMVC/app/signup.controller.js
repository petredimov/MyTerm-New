'use strict';
app.controller('signup', ['$scope', '$location', '$timeout', 'authService', function ($scope, $location, $timeout, authService) {

    var vm = this;

    vm.savedSuccessfully = false;

    vm.registration = {
        userName: "",
        password: "",
        confirmPassword: ""
    };

    vm.signUp = function () {

        authService.saveRegistration($scope.registration).then(function (response) {

            $scope.savedSuccessfully = true;            
        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to register user due to:" + errors.join(' ');
         });
    };

}]);