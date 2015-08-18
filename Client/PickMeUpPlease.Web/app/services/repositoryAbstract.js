(function () {
    'use strict';

    var serviceId = 'repositoryAbstract';

    angular.module('app').factory(serviceId, ['$q', '$http', 'localStorageService', 'common', 'ngAuthSettings', repositoryAbstract]);


    function repositoryAbstract($q, $http, localStorageService, common, ngAuthSettings) {
        var service = this;
        service.data = null;
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(serviceId);
        var logErr = getLogFn(serviceId, 'Error');

        function _getData(userToken) {
            var deferred = $q.defer();

            if (service.data == null) {
                $http.post(ngAuthSettings.apiServiceBaseUri + '/Branches/Get', _getServerToken()).
                  success(function (response) {
                      log('getting all data from server')
                      //service.data = response;

                      service.data = [
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
                      ];

                      deferred.resolve(service.data)
                  }).error(function (response) {
                      logErr(response)
                      deferred.reject(err);
                  });
            } else {
                deferred.resolve(service.data)
            }

            return deferred.promise;
        }


        function _getServerToken() {
            var LastSyncTime = (new Date()).toISOString()
            var Request =
                {
                    LastSyncTime: LastSyncTime,
                    Token: localStorageService.get('authorizationData').token,
                };
            return JSON.stringify(Request);
        }

        return {
            getData: _getData,
        }
    }
})();