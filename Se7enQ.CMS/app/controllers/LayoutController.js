app.controller('LayoutController', function ($scope, $state, $rootScope, userService) {
    $scope.currentUser = userService.getCurrentUser();

    $rootScope.$on('currentUserChanged', function (event, user) {
        $scope.currentUser = userService.getCurrentUser();
    });

    $scope.logout = function () {
        userService.logout();
    };
});