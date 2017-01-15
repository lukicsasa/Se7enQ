app.factory('questionsService', function ($http, $state, $q, $rootScope, toastService) {

    var factory = {};

    factory.getCalculations = function () {
        return $http({
            url: config.baseAddress + 'admin/getCalculations',
            method: 'GET'
        }).then(function (response) {
            return response.data;
        },
        function (error) {
            return $q.reject(error.data.message);
        });
    };

    factory.getKnowledge = function () {
        return $http({
            url: config.baseAddress + 'admin/getKnowledge',
            method: 'GET'
        }).then(function (response) {
            return response.data;
        }, function (error) {
            return $q.reject(error.data.message);
        });
    };

    factory.deleteQuestion = function (id, category) {
        return $http({
            url: config.baseAddress + 'admin/deleteQuestion',
            method: 'POST',
            params: {
                id: id,
                category: category
            }
        }).then(function (response) {
            toastService.success('Question deleted.');
        }, function (error) {
            return $q.reject(error.data.message);
        });
    };

    factory.addQuestion = function (question) {
        return $http({
            url: config.baseAddress + 'admin/addQuestion',
            method: 'POST',
            data: question
        }).then(function (response) {
            toastService.success('Question added');
        }, function (error) {
            return $q.reject(error.data.message);
        });
    }

    return factory;
});