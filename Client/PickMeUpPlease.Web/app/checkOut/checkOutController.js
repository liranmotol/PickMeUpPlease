(function () {
    'use strict';
    var controllerId = "checkOutController";

    var app = angular.module("app");

    app.controller(controllerId, ['common', checkOutController]);

    function checkOutController(common) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;


        return vm;
    }
})();