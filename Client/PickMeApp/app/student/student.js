(function () {
    'use strict';

    var controllerId = "studentController";

    var app = angular.module("app");

    app.controller(controllerId, ['$stateParams', 'common', 'studentRepository', studentController]);

    function studentController($stateParams, common, studentRepository) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        var branchId = $stateParams.Id;
        vm.searchText = "";

        vm.students = studentRepository.GetAllStudensByBranchId(branchId);
                                
        console.log(vm.students);


        return vm;
    }
})();