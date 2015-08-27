(function () {
    'use strict';

    // Define the common module 
    // Contains services:
    //  - common
    //  - logger
    //  - spinner
    var commonModule = angular.module('common', []);

    commonModule.factory('common',['logger', common]);

    function common(logger) {
        var throttles = {};

        var service = {
            logger: logger, // for accessibility
        };

        return service;
    }
})();