(function () {
    'use strict';
    var controllerId = "menuController";


    var app = angular.module("app");

    app.controller(controllerId, ['$state', 'common', menuController]);

    function menuController($state, common) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;


        return vm;
    }
})();