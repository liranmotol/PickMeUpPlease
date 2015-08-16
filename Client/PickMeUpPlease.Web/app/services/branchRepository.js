(function () {
    'use strict';

    var serviceId = 'branchRepository';


    angular.module('app').factory(serviceId, ['common', branchRepository]);


    function branchRepository(common) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(serviceId);

        var self = this;

        function getAll() {
            log("Get all")
            return [
                {
                    "BranchId": 1,
                    "BranchName": "First",
                    "StudentsList": [],
                    "OptionalGrades": ["B", "GAN", "C", "A"],
                    "OptionalClasses": ["3", "1", "4", "2"],
                    "OptionalHealthIssues": ["GLUTEN", "SUGAR"],
                    "PrincipalName": "eran",
                    "PrincipalNUmber": "0523245505"
                }, {
                    "BranchId": 2,
                    "BranchName": "Second",
                    "StudentsList": [],
                    "OptionalGrades": ["B", "GAN", "C", "A"],
                    "OptionalClasses": ["3", "1", "4", "2"],
                    "OptionalHealthIssues": ["GLUTEN", "SUGAR"],
                    "PrincipalName": null,
                    "PrincipalNUmber": null
                }
            ]
        }

        function getBranchById(Id) {
            log("Get branch by id: " + Id);

            return {
                "BranchId": 1,
                "BranchName": "First",
                "StudentsList": [],
                "OptionalGrades": ["B", "GAN", "C", "A"],
                "OptionalClasses": ["3", "1", "4", "2"],
                "OptionalHealthIssues": ["GLUTEN", "SUGAR"],
                "PrincipalName": "eran",
                "PrincipalNUmber": "0523245505"
            };
        }

        return {
            get: getAll,
            getById: getBranchById
        }
    }
})();