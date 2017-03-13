(function () {
    "use strict";

    angular
        .module("app-traps")
        .controller("trapRemoveController", trapRemoveController);


    function trapRemoveController($http) {
        /* jshint validthis:true */
        var vm = this;

        vm.guwno = "jajco";

        vm.traps = [];

        vm.newTrap = {};

        vm.errorMessage = "";

        vm.addTrap = function () {

            $http.post("/remov/traps", vm.newTrap)
            .then(function (response) {

            vm.traps.push(response.data);
            vm.newTrap = {};
        },
        function (error) {
            vm.errorMessage = "Filed to save new trap" + error;
        });

        };
    }
})();
