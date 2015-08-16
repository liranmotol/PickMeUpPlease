(function () {
    'use strict';

    var controllerId = "brancDetailshController";

    var app = angular.module("app");

    app.controller(controllerId, ['$scope', '$stateParams', 'common', 'branchRepository', brancDetailshController]);

    function brancDetailshController($scope, $stateParams, common, branchRepository) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        var branchId = $stateParams.Id;

        vm.selectedBranch = branchRepository.getById(branchId);

        return vm;
    }
})();