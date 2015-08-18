
var app = angular.module('app', ['ionic', 'LocalStorageModule', 'common']);

app.config(function ($stateProvider, $urlRouterProvider) {

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

        .state('home.menu', {
            url: "/menu",
            views: {
                "mainContent": {
                    templateUrl: "app/menu/menu.html"
                }
            }
        })

        .state('home.branches', {
            url: "/branches",
            views: {
                "mainContent": {
                    templateUrl: "app/branch/branches.html"
                }
            }
        })

        .state('home.branche-details', {
            url: "/branch-details/:Id",
            views: {
                "mainContent": {
                    templateUrl: "app/branch/branchDetails.html"
                }
            }
        })

        .state('home.students', {
            url: "/students/:branchId",
            views: {
                "mainContent": {
                    templateUrl: "app/student/student.html"
                }
            }
        })

        .state('home.student-details', {
            url: "/student-details/:studentId",
            views: {
                "mainContent": {
                    templateUrl: "app/student/studentDetails.html"
                }
            }
        })

        .state('home.checkIn', {
            url: "/checkIn",
            views: {
                "mainContent": {
                    templateUrl: "app/checkIn/checkIn.html"
                }
            }
        })

        .state('home.checkOut', {
            url: "/checkOut",
            views: {
                "mainContent": {
                    templateUrl: "app/checkOut/checkOut.html"
                }
            }
        })

        .state('home.meals', {
            url: "/meals",
            views: {
                "mainContent": {
                    templateUrl: "app/meals/meals.html"
                }
            }
        })

        .state('app', {
            abstract: true,
            url: "/app",
            templateUrl: "app/home/layout.html"
        })

        .state('app.login', {
            url: "/login",
            views: {
                "loginContent": {
                    templateUrl: "app/login/login.html"
                }
            }
        })

    //// if none of the above states are matched, use this as the fallback

    $urlRouterProvider.otherwise('/app/login');

});

var serviceBase = "http://pickmeplease.azurewebsites.net/"
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

