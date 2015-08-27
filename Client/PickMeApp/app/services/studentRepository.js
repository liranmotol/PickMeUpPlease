(function () {
    'use strict';

    angular.module('app').factory('studentRepository', studentRepository);


    function studentRepository() {
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
            return [{
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
            }, {
                "StudentID": "1",
                "Img": "",
                "FirstName": "Aiden\t  ",
                "LastName": "Madison\t  ",
                "Grade": "GAN",
                "SClass": "1",
                "PickUpFrom": "nada",
                "HealthIssues": ["GLUTEN"],
                "HealthIssuesString": "GLUTEN",
                "CheckedIn": { "ByWhom": null, "When": null },
                "PickUp": { "ByWhom": null, "When": null },
                "PickUpOptions": ["Aiden\t  ", "Madison\t  "],
                "IsPickedUp": false,
                "Parent1Name": "Aiden\t  ",
                "Parent1Num": "052-1234567",
                "Parent1Email": "liran@gmail.com",
                "Parent2Name": "Madison\t  ",
                "Parent2Num": "052-7654321",
                "HomeNum": "03-5555555",
                "Gender": "Female",
                "BirthDay": "2015-07-30T20:17:31.156387+00:00",
                "BirthDayString": "7/30/2015",
                "LastUpdateTime": "2015-07-30T20:17:31.156387+00:00"
            }, {
                "StudentID": "2",
                "Img": "",
                "FirstName": "Isaac\t  ",
                "LastName": "Mila\t      ",
                "Grade": "C",
                "SClass": "4",
                "PickUpFrom": "nada",
                "HealthIssues": ["GLUTEN", "SUGAR"],
                "HealthIssuesString": "GLUTEN,SUGAR",
                "CheckedIn": { "ByWhom": null, "When": null },
                "PickUp": { "ByWhom": null, "When": null },
                "PickUpOptions": ["Isaac\t  ", "Mila\t      "],
                "IsPickedUp": false,
                "Parent1Name": "Isaac\t  ",
                "Parent1Num": "052-1234567",
                "Parent1Email": "liran@gmail.com",
                "Parent2Name": "Mila\t      ",
                "Parent2Num": "052-7654321",
                "HomeNum": "03-5555555",
                "Gender": "Male",
                "BirthDay": "2015-07-30T20:17:31.156387+00:00",
                "BirthDayString": "7/30/2015",
                "LastUpdateTime": "2015-07-30T20:17:31.156387+00:00"
            },
            ]


        }

        return {
            GetAllStudensByBranchId: getAllStudensByBranchId,
            getStudentById: getStudentById
        }
    }
})();