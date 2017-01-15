app.controller('AddQuestionController', function ($scope, $state, $timeout, $uibModalInstance, $uibModal, toastService, questionsService, fields, category) {
    $scope.fields = fields;
    $scope.category = category;

    $scope.question = [
        question = null,
        correctAnswer = null,
        wrongAnswer1 = null,
        wrongAnswer2 = null,
        wrongAnswer3 = null
    ];

    function convertToObj() {
        var model = {
            question: null,
            correctAnswer: null,
            wrongAnswer1: null,
            wrongAnswer2: null,
            wrongAnswer3: null
        };

        for (var i = 0; i < $scope.question.length; i++) {
            for (var property in model) {
                if (model.hasOwnProperty(property) && model[property] == null) {
                    model[property] = $scope.question[i];
                    break;
                }
            }
        }
        model.category = $scope.category;
        return model;
    }

    $scope.addQuestion = function () {
        questionsService.addQuestion(convertToObj()).then(function (response) {
            $uibModalInstance.close();
        }, function (error) {
            toastService.error(error);
        });
    }

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };


});