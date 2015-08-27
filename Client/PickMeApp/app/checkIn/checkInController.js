(function () {
    'use strict';
    var controllerId = "checkInController";

    var app = angular.module("app");

    app.controller(controllerId, ['common', checkInController]);

    function checkInController(common) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;


        return vm;
    }
})();