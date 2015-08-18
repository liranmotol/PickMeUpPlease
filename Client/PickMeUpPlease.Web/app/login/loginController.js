(function () {
    'use strict';
    var controllerId = "loginController";


    var app = angular.module("app");

    app.controller(controllerId, ['$scope', '$state', 'authService', 'ngAuthSettings', 'common', loginController]);

    function loginController($scope, $state, authService, ngAuthSettings, common) {

        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);


        $scope.loginData = {
            userName: "",
            password: "",
        };

        if (authService.authentication.isAuth) {
            log("user already authenticated, redirect to menu page");
            $state.go('home.menu');
        }


        $scope.message = "";

        $scope.login = function (loginType) {
            
            log($scope.loginData.userName + " " + $scope.loginData.password);

            authService.login($scope.loginData).then(function (response) {

                $state.go('home.menu');

            },
         function (err) {
             $scope.message = err.error_description;
         });
        }

        $scope.register = function () {

            authService.saveRegistration().then(function (response) {

                $state.go('home.menu');

            },
         function (err) {
             $scope.message = err.error_description;
         });
        }

        $scope.authExternalProvider = function (provider) {
            alert($scope.loginData.userName + " " + $scope.loginData.password);

            var redirectUri = location.protocol + '//' + location.host + '/authcomplete.html';

            var externalProviderUrl = ngAuthSettings.apiServiceBaseUri + "api/Account/ExternalLogin?provider=" + provider
                                                                        + "&response_type=token&client_id=" + ngAuthSettings.clientId
                                                                        + "&redirect_uri=" + redirectUri;
            window.$windowScope = $scope;

            var oauthWindow = window.open(externalProviderUrl, "Authenticate Account", "location=0,status=0,width=600,height=750");
        };

        $scope.authCompletedCB = function (fragment) {

            $scope.$apply(function () {

                if (fragment.haslocalaccount == 'False') {

                    authService.logOut();

                    authService.externalAuthData = {
                        provider: fragment.provider,
                        userName: fragment.external_user_name,
                        externalAccessToken: fragment.external_access_token
                    };
                    $state.go('home.menu');
                }
                else {
                    //Obtain access token and redirect to orders
                    var externalData = { provider: fragment.provider, externalAccessToken: fragment.external_access_token };
                    authService.obtainAccessToken(externalData).then(function (response) {
                        $state.go('home.menu');
                    },
                 function (err) {
                     $scope.message = err.error_description;
                 });
                }

            });
        }
    }




})();