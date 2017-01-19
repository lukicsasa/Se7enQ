app.controller('EditUserController', function ($scope, $state, $timeout, $uibModalInstance, $uibModal, toastService, dashboardService, user) {
    $scope.user = user;

    $scope.editUser = function () {
        
            dashboardService.editUser($scope.user).then(function (response) {
                $uibModalInstance.close();
            }, function (error) {
                toastService.error(error);
            });
        }

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $scope.changePasswordEdit = function (id) {
        var modalInstance = $uibModal.open({
            animation: true,
            size: 'lg',
            templateUrl: '../../views/modals/changePassword.html',
            controller: 'ChangePasswordController',
            resolve: {
                id: function () { return user.id; }
            }
        });

        
    };


});