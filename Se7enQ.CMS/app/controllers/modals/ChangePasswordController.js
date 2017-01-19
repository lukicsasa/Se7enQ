app.controller('ChangePasswordController', function ($scope, $state, $timeout, $uibModalInstance, $uibModal, toastService, dashboardService, id) {
    $scope.id = id;

    $scope.changePassword = function () {
        console.log($scope.id, $scope.pass);
        dashboardService.changePassword($scope.id, $scope.pass).then(function (response) {
            $uibModalInstance.close();
        }, function (error) {
            toastService.error(error);
        });
    }

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

});
