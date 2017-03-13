(function () {
    "use strict";

    angular
        .module("app-traps")
        .controller("trapsController", trapsController);


    function trapsController($http, $location, $routeParams) {
        /* jshint validthis:true */
        var vm = this;

        vm.traps = [];

        vm.newTrap = {};

        //vm.path = '';

        vm.trapid = $routeParams.trapid;

        vm.errorMessage = "";

        $http.get("/api/traps")
        .then(function (response) {
            console.log("Wczytano jsony http.get");
            angular.copy(response.data, vm.traps)
        },
        function (error) {
            vm.errorMessage = "Filed to load data" + error;
        });

        vm.addTrap = function () {

            $http.post("/api/traps", vm.newTrap)
        .then(function (response) {
            
            vm.traps.push(response.data);
            vm.newTrap = {};
        },
        function (error) {
            vm.errorMessage = "Filed to save new trap" + error;
        });
            
        };


        vm.removeTrap = function (toRemove) {

            console.log("Staram sie usunac");

            $http.put("/api/traps", toRemove)
           .then(function (response) {
               console.log(response.data);
        },
        function (error) {
            vm.errorMessage = "Filed to remove new trap" + error;
            console.log(vm.errorMessage);
        });

        };

        /*vm.getPath = function ()
        {
            var url = $location.path();
            vm.path = url.split('/').pop();
        }*/

        vm.write = function(log)
        {
            console.log(log);
        }
    }
})();
