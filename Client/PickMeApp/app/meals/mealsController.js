(function () {
    'use strict';
    var controllerId = "mealsController";

    var app = angular.module("app");

    app.controller(controllerId, ['common', mealsController]);

    function mealsController(common) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;


        return vm;
    }
})();