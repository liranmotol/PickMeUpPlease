(function () {
    'use strict';
    var app = angular.module("app");

    app.controller("branchController", ['branchRepository', branchController]);

    function branchController(branchRepository, selectedBranch) {
        var vm = this;
        vm.branches = branchRepository.get();

        vm.selectBranch = function (item) {
        }

        return vm;
    }
})();