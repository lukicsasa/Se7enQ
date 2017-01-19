app.controller('DashboardController', function ($scope, $state, $uibModal, dashboardService, toastService) {

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

    $scope.modalUser = function (user) {
        var modalInstance = $uibModal.open({
            animation: true,
            size: 'lg',
            templateUrl: '../../views/modals/editUser.html',
            controller: 'EditUserController',
            resolve: {
                user: function () { return user;}
            }
        });

        modalInstance.result.then(function (data) {
            getUsers()
        })
    };

    getUsers();
    
});