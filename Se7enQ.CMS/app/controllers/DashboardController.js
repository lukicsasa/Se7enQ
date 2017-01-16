app.controller('DashboardController', function ($scope, $state, dashboardService, toastService, method) {

    $scope.loader = true;
    $scope.search = '';

    function getUsers() {
        dashboardService.getUsers().then(function (response) {
            $scope.users = response;
            $scope.loader = false;
        });
    }

    $scope.deleteUser = function (id) {
        dashboardService.deleteUser(id).then(function (response) {
            getUsers();
        })
    }

    getUsers();
    
});