app.controller('LoginController', function ($scope, $state, userService, toastService) {

    $scope.login = function () {
        userService.login($scope.user).then(function (response) {
            $state.go('layout.dashboard');
        })
    };

    if (userService.getCurrentUser()) {
        $state.go('layout.dashboard');
    }
});