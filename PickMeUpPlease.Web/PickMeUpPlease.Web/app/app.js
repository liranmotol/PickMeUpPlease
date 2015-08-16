angular.module('app', ['ionic'])
    .config(function ($stateProvider, $urlRouterProvider) {

        // Ionic uses AngularUI Router which uses the concept of states
        // Learn more here: https://github.com/angular-ui/ui-router
        // Set up the various states which the app can be in.
        // Each state's controller can be found in controllers.js
        $stateProvider

            .state('home', {
                abstract: true,
                url: "/home",
                templateUrl: "app/home/home.html"
            })

            .state('home.branches', {
                url: "/branches",
                views: {
                    "tab-branches": {
                        templateUrl: "app/branch/branches.html"
                    }
                }
            })

            .state('home.branche-details', {
                url: "/branch-details/:Id",
                views: {
                    "tab-branches": {
                        templateUrl: "app/branch/branchDetails.html"
                    }
                }
            })

            .state('home.students', {
                url: "/students/:branchId",
                views: {
                    "tab-branches": {
                        templateUrl: "app/student/student.html"
                    }
                }
            })

            .state('home.student-details', {
                url: "/student-details/:studentId",
                views: {
                    "tab-branches": {
                        templateUrl: "app/student/studentDetails.html"
                    }
                }
            })


        //// if none of the above states are matched, use this as the fallback

        $urlRouterProvider.otherwise('/home/branches');

    });

