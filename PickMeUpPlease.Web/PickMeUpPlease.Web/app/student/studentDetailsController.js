(function () {
    'use strict';
    var app = angular.module("app");

    app.controller("studentDetailsController", ['$stateParams', 'studentRepository', studentDetailsController]);


    function studentDetailsController($stateParams, studentRepository) {
        var vm = this;
        vm.studentId = $stateParams.studentId;

        vm.selectedStudent = studentRepository.getStudentById(vm.studentId);


        return vm;
    }
})();