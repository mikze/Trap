//module
(function () {

    "use strict";

    angular.module("app-traps", ["ngRoute"])
    .config(function ($routeProvider) {
        $routeProvider.when("/", {
            controller: "trapsController",
            controllerAs: "vm",
            templateUrl: "/views/trapsView.html"

        });

        $routeProvider.when("/remove/:trapid", {
            controller: "trapsController",
            controllerAs: "vm",
            templateUrl: "/views/trapRemoveView.html"

        });

        $routeProvider.when("/editor/:trapid", {
            controller: "trapEditorController",
            controllerAs: "vm",
            templateUrl: "/views/trapEditorView.html"

        });

       

        $routeProvider.otherwise({redirectTo: "/"});
    });

})();
