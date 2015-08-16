(function () {
    'use strict';
    var app = angular.module("app");

    app.controller("brancDetailshController", ['$scope','$stateParams', 'branchRepository', brancDetailshController]);

    function brancDetailshController($scope, $stateParams, branchRepository) {
        var vm = this;
        var branchId = $stateParams.Id;

        vm.selectedBranch = branchRepository.getById(1);


        return vm;
    }
})();