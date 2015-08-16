(function () {
    'use strict';
    var app = angular.module("app");

    app.controller("studentController", ['$stateParams', 'studentRepository', studentController]);

    function studentController($stateParams, studentRepository) {
        var vm = this;
        var branchId = $stateParams.Id;
        vm.searchText = "";

        vm.students = studentRepository.GetAllStudensByBranchId(branchId);

        return vm;
    }
})();