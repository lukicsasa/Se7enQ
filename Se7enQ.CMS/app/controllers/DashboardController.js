app.controller('DashboardController', function ($scope, $state, dashboardService, toastService, method) {

    $scope.loader = true;
    $scope.search = '';

    function getUsers() {
        method().then(function (response) {
            $scope.users = response.users;
            $scope.loader = false;
        });
    }

    getUsers();
    
});