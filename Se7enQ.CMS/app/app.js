var app = angular.module('sevenqCms', ['ui.router', 'ngAnimate', 'ngSanitize', 'ngFileUpload', 'textAngular', 'ui.bootstrap', 'toaster']);


app.config(function ($stateProvider, $urlRouterProvider, $httpProvider, $locationProvider) {
    $urlRouterProvider.otherwise(function ($injector) {
        var $state = $injector.get('$state');
        $state.go('layout.dashboard');
    });

    $stateProvider
        .state('layout', {
            controller: 'LayoutController',
            templateUrl: '/views/layout.html'
        })
            .state('layout.login', {
                controller: 'LoginController',
                url: '/login',  
                templateUrl: '/views/login.html',
                pageName: 'Login',
                requireLogin: false
            })
            .state('layout.dashboard', {
                controller: 'DashboardController',
                url: '/dashboard',
                templateUrl: '/views/dashboard.html',
                pageName: 'Dashboard',
                requireLogin: true
            })
            .state('layout.calculations', {
                controller: 'QuestionsController',
                url: '/calculations',
                templateUrl: '/views/questions.html',
                pageName: 'Calculations',
                requireLogin: true,
                resolve: {
                    method: function (questionsService) {
                        return questionsService.getCalculations;
                    }
                }
            })
            .state('layout.knowledge', {
                controller: 'QuestionsController',
                url: '/knowledge',
                templateUrl: '/views/questions.html',
                pageName: 'General Knowledge',
                requireLogin: true,
                resolve: {
                    method: function (questionsService) {
                        return questionsService.getKnowledge;
                    }
                }
            })
    



    $locationProvider.html5Mode(true);

    $httpProvider.interceptors.push(function ($injector, $q) {
        return {
            request: function (requestConfig) {
                var userService = $injector.get('userService');
                var token = userService.getToken();
                if (token && requestConfig.url.indexOf(config.baseAddress) > -1) {
                    requestConfig.headers.Authorization = token;
                }

                return requestConfig;
            },
            responseError: function (response) {
                if (response.status == 400) {
                    return $q.reject(response);
                }
                if (response.status == 401) {
                    var userService = $injector.get('userService');
                    userService.logout();
                }
                if (response.state == 403) {
                    var userService = $injector.get('userService');
                    userService.logout();
                }
                return response;
            }
        };
    });
});

app.run(function ($rootScope, $state, userService) {
    $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
        var requireLogin = toState.requireLogin;
        var currentUser = userService.getCurrentUser();
        if (requireLogin && !currentUser) {
            event.preventDefault();

            $state.go('layout.login');
        }
        else if (currentUser && currentUser.routeState && toState.name != currentUser.routeState) {
            event.preventDefault();
            $state.go(currentUser.routeState);
        }

        if (toState.pageName) {
            document.title = 'Se7enQ CMS | ' + toState.pageName;
        }

        $rootScope.state = toState.name;
    });
});