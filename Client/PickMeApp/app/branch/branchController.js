(function () {
    'use strict';
    var controllerId = "branchController";

    var app = angular.module("app");

    app.controller(controllerId, ['common', 'branchRepository',  branchController]);

    function branchController(common, branchRepository) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        branchRepository.get().then(function (response) {
            vm.branches = response;
        });
 

        return vm;
    }
})();