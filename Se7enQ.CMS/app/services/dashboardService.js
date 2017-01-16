app.factory('dashboardService', function ($http, $state, $q, $rootScope, toastService) {
    var factory = {};

    factory.getUsers = function () {
        return $http({
            url: config.baseAddress + 'admin/getUsers',
            method: 'GET'
        }).then(function (response) {
            return response.data;
        }, function (error) {
            return $q.reject(error.data.message);
        });
    };

    return factory;
});
