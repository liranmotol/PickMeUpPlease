(function () {
    'use strict';
    var controllerId = "homeController";

    var app = angular.module("app");

    app.controller(controllerId, ['$state', 'authService', 'common', homeController]);

    function homeController($state, authService, common) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;

        return vm;
    }
})();