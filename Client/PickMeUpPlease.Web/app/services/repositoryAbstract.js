(function () {
    'use strict';

    angular.module('app').factory('repositoryAbstract', ['$http', 'common', 'ngAuthSettings', repositoryAbstract]);


    function repositoryAbstract($http, common, ngAuthSettings) {
        var service = this;
        service.data = null;
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logErr = getLogFn(controllerId,'Error');


        function getData(userToken) {
            if (data == null) {
                $http.post(ngAuthSettings.apiServiceBaseUri + '/GetBranchInfo', getServerToken()).
                  then(
                  onSuccess(response),
                  onFailure(response)
                  );
            }

            return service.data;
        }

        function onSuccess(){
            log('getting all data from server')
            service.data = response;
        }

        function onFailure(){
            logErr(response)
        }


        function getServerToken() {

            var LastSyncTime = 0;// new Date(2000, 1);
            var Request =
                {
                    LastSyncTime: LastSyncTime,
                    Token: token,
                };
            return JSON.stringify(Request);
        }

        return {
            getData: getData,
        }
    }
})();