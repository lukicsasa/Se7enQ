app.factory('toastService', function ($http, $state, toaster) {
    var factory = {};

    factory.success = function (message) {
        toaster.pop({ type: 'success', body: message, timeout: 3000 });
    };

    factory.error = function (message) {
        toaster.pop({ type: 'error', body: message, timeout: 3000 });
    };

    return factory;
});