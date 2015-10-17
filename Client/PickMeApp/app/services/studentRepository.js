(function () {
    'use strict';

    var serviceId = 'studentRepository';


    angular.module('app').factory(serviceId, ['$q', 'common', 'repositoryAbstract', studentRepository]);


    function studentRepository() {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(serviceId);

        var self = this;

        function getStudentById(id) {
            return {
                "StudentID": "0",
                "Img": "",
                "FirstName": "Jayden\t\t",
                "LastName": "Scarlett     ",
                "Grade": "B",
                "SClass": "3",
                "PickUpFrom": "nada",
                "HealthIssues": ["GLUTEN", "SUGAR"],
                "HealthIssuesString": "GLUTEN,SUGAR",
                "CheckedIn": { "ByWhom": null, "When": null },
                "PickUp": { "ByWhom": null, "When": null },
                "PickUpOptions": ["Jayden\t\t", "Scarlett     ", "Ryan\t  ", "Nora\t      "], "IsPickedUp": false, "Parent1Name": "Jayden\t\t",
                "Parent1Num": "052-1234567",
                "Parent1Email": "liran@gmail.com",
                "Parent2Name": "Scarlett     ",
                "Parent2Num": "052-7654321",
                "HomeNum": "03-5555555",
                "Gender": "Male",
                "BirthDay": "2015-07-30T20:17:31.156387+00:00",
                "BirthDayString": "7/30/2015",
                "LastUpdateTime": "2015-07-30T20:17:31.156387+00:00"
            }
        }

        function getAllStudensByBranchId(branchId) {
            var deferred = $q.defer();

            repositoryAbstract.getData().then(function (data) {
                var students = null;
                $.each(data, function (index, item) {
                    console.log(item);
                    students.push(item);
                })

                deferred.resolve(students)
            });

            return deferred.promise;

        }

        function getAllStudens() {
            var deferred = $q.defer();

            repositoryAbstract.getData().then(function (data) {
                var students = null;
                $.each(data, function (index, item) {
                    console.log(item);
                    students.push(item);
                })

                deferred.resolve(students)
            });

            return deferred.promise;

        }

        return {
            GetAllStudensByBranchId: getAllStudensByBranchId,
            getStudentById: getStudentById,
            get:getAllStudens
        }
    }
})();