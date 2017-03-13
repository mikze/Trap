(function () {

    "use strict";
    
    angular.module("app-traps")
    .controller("trapEditorController",trapEditorController);

    function trapEditorController($http, $routeParams, $location) {

        var vm = this;

        vm.trapid = $routeParams.trapid;

        vm.Trap = {};

        vm.Trap.sendTrapId = vm.trapid;

        vm.errorMessage = "";

        vm.editTrap = function()
        {
            vm.write("Try to modify");

            $http.patch("/api/traps", vm.Trap)
            .then(function (response) {
                vm.write("Done!");

                vm.Trap = {};
                $location.path('/');
            },
            function (error) {
                vm.errorMessage = "Filed to save new trap" + error;
                vm.write(vm.errorMessage);
                $location.path('/');
            });
        }

        vm.write = function (log) {
            console.log(log);
        }
    }

})();