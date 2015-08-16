(function () {
    'use strict';

    var controllerId = "studentDetailsController";

    var app = angular.module("app");

    app.controller(controllerId, ['$stateParams', 'common', 'studentRepository', studentDetailsController]);


    function studentDetailsController($stateParams, common, studentRepository) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.studentId = $stateParams.studentId;

        vm.selectedStudent = studentRepository.getStudentById(vm.studentId);


        return vm;
    }
})();