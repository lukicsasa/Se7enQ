app.factory('userService', function ($http, $state, $q, $rootScope, toastService) {

    var factory = {};

    factory.login = function (user) {
        return $http({
            url: config.baseAddress + 'admin/login',
            method: 'POST',
            data: user
        }).then(function (response) {
            if (response.data.user) {
                var user = response.data.user;
                factory.setCurrentUser(user);
                localStorage.token = response.data.token;
            } else {
                var message = 'userService.login: Failure';
                if (response.data && response.data.message) {
                    message = response.data.message;
                }
                toastService.error(message);
            }
        },
        function (response) {
            var message = 'userService.login: Failure';
            if (response.data && response.data.message) {
                message = response.data.message;
            }
            toastService.error(message);
        });
    };

    factory.logout = function () {
        localStorage.clear();
        factory.setCurrentUser(null);
        $state.go('layout.login');
    };

    factory.getCurrentUser = function () {
        if (localStorage.currentUser) {
            var user = JSON.parse(localStorage.currentUser);
            return user;
        }
        return null;
    };

    factory.setCurrentUser = function (user) {
        if (user) {
            localStorage.currentUser = JSON.stringify(user);
        } else {
            localStorage.currentUser = null;
        }
        $rootScope.$emit('currentUserChanged', user);
    };

    factory.getToken = function () {
        return localStorage.token;
    };

    return factory;
});