﻿(function () {
    'use strict';

    angular.module('common').factory('logger', ['$log', logger]);

    function logger($log) {
        var service = {
            getLogFn: getLogFn,
            log: log,
            logError: logError,
            logSuccess: logSuccess,
            logWarning: logWarning
        };

        return service;

        function getLogFn(moduleId, fnName) {
            fnName = fnName || 'log';
            switch (fnName.toLowerCase()) { // convert aliases
                case 'success':
                    fnName = 'logSuccess'; break;
                case 'error':
                    fnName = 'logError'; break;
                case 'warn':
                    fnName = 'logWarning'; break;
                case 'warning':
                    fnName = 'logWarning'; break;
            }

            var logFn = service[fnName] || service.log;
            return function (msg, data) {
                logFn(msg, data, moduleId);
            };
        }

        function log(message, data, source, showToast) {
            logIt(message, data, source,'info');
        }

        function logWarning(message, data, source, showToast) {
            logIt(message, data, source,'warning');
        }

        function logSuccess(message, data, source, showToast) {
            logIt(message, data, source,'success');
        }

        function logError(message, data, source, showToast) {
            logIt(message, data, source, 'error');
        }

        function logIt(message, data, source, toastType) {
            var write = (toastType === 'error') ? $log.error : $log.log;
            source = source ? '[' + source + '] ' : '';
            write(source, message, data);
        }
    }
})();