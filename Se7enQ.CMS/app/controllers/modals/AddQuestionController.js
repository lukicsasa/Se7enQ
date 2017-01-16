app.controller('AddQuestionController', function ($scope, $state, $timeout, $uibModalInstance, $uibModal, toastService, questionsService, fields, category) {
    $scope.fields = fields;
    $scope.category = category;

    if (category == 'Synonyms or Antonyms') {
        $scope.question = [
        correctAnswer1 = null,
        correctAnswer2 = null,
        wrongAnswer1 = null,
        wrongAnswer2 = null
        ];
    }else {
        $scope.question = [
        question = null,
        correctAnswer = null,
        wrongAnswer1 = null,
        wrongAnswer2 = null,
        wrongAnswer3 = null
        ];
    }

    var model = {
        question: null,
        correctAnswer: null,
        wrongAnswer1: null,
        wrongAnswer2: null,
        wrongAnswer3: null
    };

    var modelSynonym = {
        correctAnswer1: null,
        correctAnswer2: null,
        wrongAnswer1: null,
        wrongAnswer2: null
    };

    function convertToObj(model) {

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
        if (category == 'Synonyms or Antonyms') {
            questionsService.addQuestionSynonym(convertToObj(modelSynonym)).then(function (response) {
                $uibModalInstance.close();
            }, function (error) {
                toastService.error(error);
            });
        } else {
            questionsService.addQuestion(convertToObj(model)).then(function (response) {
                $uibModalInstance.close();
            }, function (error) {
                toastService.error(error);
            });
        }
        
    }

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };


});