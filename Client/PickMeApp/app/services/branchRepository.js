(function () {
    'use strict';

    var serviceId = 'branchRepository';


    angular.module('app').factory(serviceId, ['$q', 'common', 'repositoryAbstract', branchRepository]);


    function branchRepository($q, common, repositoryAbstract) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(serviceId);

        var self = this;

        function getAll() {
            log("Get all")

            var deferred = $q.defer();

            repositoryAbstract.getData().then(function (data) {
                deferred.resolve(data)
            });

            return deferred.promise;

        }

        function getBranchById(Id) {
            log("Get branch by id: " + Id);

            var deferred = $q.defer();

            repositoryAbstract.getData().then(function (data) {
                var branch = null;
                $.each(data, function (index, item) {
                    if (item.BranchId == Id) {
                        branch = item;
                    }
                })

                deferred.resolve(branch)
            });

            return deferred.promise;
        }

        return {
            get: getAll,
            getById: getBranchById
        }
    }
})();