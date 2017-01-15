app.controller('QuestionsController', function ($scope, $state, $uibModal, questionsService, toastService, method) {

    $scope.loader = true;
    $scope.title = $state.current.pageName;

    $scope.search = '';

    function getQuestions() {
        method().then(function (response) {
            $scope.questions = response.questions;
            $scope.headers = response.headers;
            $scope.loader = false;
        });
    }

    $scope.deleteQuestion = function (id) {
        questionsService.deleteQuestion(id, $scope.title).then(function (response) {
            getQuestions();
        })
    }


    $scope.addModal = function (type, item) {
        var modalInstance = $uibModal.open({
            animation: true,
            size: 'lg',
            templateUrl: '../../views/modals/addQuestion.html',
            controller: 'AddQuestionController',
            resolve: {
                fields: function () { return $scope.headers.splice(1) },
                category: function () { return $scope.title }
            }
        });

        modalInstance.result.then(function (data) {
            getQuestions()
        })
    };

    getQuestions();
});