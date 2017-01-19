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

    factory.deleteUser = function (id) {
        return $http({
            url: config.baseAddress + 'admin/deleteUser',
            method: 'POST',
            params: {
                id: id
            }
        }).then(function (response) {
            toastService.success('User deleted.');
        }, function (error) {
            return $q.reject(error.data.message);
        });
    };

    factory.editUser = function (user) {
        return $http({
            url: config.baseAddress + 'admin/editUser',
            method: 'POST',
            data: user
        }).then(function (response) {
            toastService.success('User has been modified.');
        }, function (error) {
            return $q.reject(error.data.message);
        });
    }

    factory.changePassword = function (id, newPassword) {
        return $http({
            url: config.baseAddress + 'admin/changePassword',
            method: 'POST',
            params: {
                id: id,
                newPassword: newPassword
            }
        }).then(function (response) {
            toastService.success('Password changed!');
        }, function (error) {
            return $q.reject(error.data.message);
        });
    }

    return factory;
});
