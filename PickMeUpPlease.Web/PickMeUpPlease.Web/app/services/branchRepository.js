(function () {
    'use strict';

    angular.module('app').factory('branchRepository', branchRepository);


    function branchRepository() {
        var self = this;

        function getAll() {
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

        function getBranchById() {
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