(function () {
    'use strict';
    var controllerId = "menuController";


    var app = angular.module("app");

    app.controller(controllerId, ['$state', 'authService', 'common', menuController]);

    function menuController($state, authService, common) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;

        vm.logOut = function () {
            log("user logging out")
            authService.logOut();
            $state.go('app.login');
        }

        return vm;
    }
})();