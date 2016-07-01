'use strict';
/**
 * @ngdoc overview
 * @name sbAdminApp
 * @description
 * # sbAdminApp
 *
 * Main module of the application.
 */
angular
  .module('sbAdminApp', [
    'oc.lazyLoad',
    'ui.router',
    'ui.bootstrap',
    'angular-loading-bar',
  ])
  .config(['$stateProvider', '$urlRouterProvider', '$ocLazyLoadProvider', function ($stateProvider, $urlRouterProvider, $ocLazyLoadProvider) {

      $ocLazyLoadProvider.config({
          debug: false,
          events: true,
      });

      $urlRouterProvider.otherwise('/dashboard/home');

      $stateProvider
        .state('dashboard', {
            url: '/dashboard',
            templateUrl: 'Views/dashboard/main.html',
            resolve: {
                loadMyDirectives: function ($ocLazyLoad) {
                    return $ocLazyLoad.load(
                    {
                        name: 'sbAdminApp',
                        files: [
                        'Script/App/directives/header/header.js',
                        'Script/App/directives/header/header-notification/header-notification.js',
                        'Script/App/directives/sidebar/sidebar.js',
                        'Script/App/directives/sidebar/sidebar-search/sidebar-search.js'
                        ]
                    }),
                    $ocLazyLoad.load(
                    {
                        name: 'toggle-switch',
                        files: ["Script/Vendor/angular-toggle-switch/angular-toggle-switch.min.js",
                               "Script/Vendor/angular-toggle-switch/angular-toggle-switch.css"
                        ]
                    }),
                    $ocLazyLoad.load(
                    {
                        name: 'ngAnimate',
                        files: ['Script/Vendor/angular-animate/angular-animate.js']
                    })
                    $ocLazyLoad.load(
                    {
                        name: 'ngCookies',
                        files: ['Script/Vendor/angular-cookies/angular-cookies.min.js']
                    })
                    $ocLazyLoad.load(
                    {
                        name: 'ngResource',
                        files: ['Script/Vendor/angular-resource/angular-resource.min.js']
                    })
                    $ocLazyLoad.load(
                    {
                        name: 'ngSanitize',
                        files: ['Script/Vendor/angular-sanitize/angular-sanitize.min.js']
                    })
                    $ocLazyLoad.load(
                    {
                        name: 'ngTouch',
                        files: ['Script/Vendor/angular-touch/angular-touch.min.js']
                    })
                }
            }
        })
        .state('dashboard.home', {
            url: '/home',
            controller: 'MainCtrl',
            templateUrl: 'Views/dashboard/home.html',
            resolve: {
                loadMyFiles: function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: 'sbAdminApp',
                        files: [
                        'Script/App/controllers/main.js',
                        'Script/App/directives/timeline/timeline.js',
                        'Script/App/directives/notifications/notifications.js',
                        'Script/App/directives/chat/chat.js',
                        'Script/App/directives/dashboard/stats/stats.js'
                        ]
                    })
                }
            }
        })
        .state('dashboard.form', {
            templateUrl: 'Views/form.html',
            url: '/form'
        })
        .state('dashboard.blank', {
            templateUrl: 'Views/pages/blank.html',
            url: '/blank'
        })
        .state('login', {
            templateUrl: 'Views/pages/login.html',
            url: '/login',
            resolve: {
                loadMyDirectives: function ($ocLazyLoad) {
                    return $ocLazyLoad.load(
                    {
                        name: 'sbAdminApp',
                        files: [
                        'Script/App/Services/Account/authInterceptorService.js',
                        'Script/App/Services/Account/authService.js',
                        'Script/App/Services/Account/tokensManagerService.js',
                        //'Script/Vendor/authComplete.js',
                        'Script/App/controllers/Account/loginController.js'
                        ]
                    })
                }
            }
        })
        .state('signup', {
            templateUrl: 'Views/pages/signup.html',
            url: '/signup',
            resolve: {
                loadMyDirectives: function ($ocLazyLoad) {
                    return $ocLazyLoad.load(
                    {
                        name: 'sbAdminApp',
                        files: [
                        'Script/App/Services/Account/authInterceptorService.js',
                        'Script/App/Services/Account/authService.js',
                        'Script/App/Services/Account/tokensManagerService.js',
                        'Script/App/controllers/Account/signupController.js'
                        ]
                    })
                }
            }
        })
        .state('dashboard.chart', {
            templateUrl: 'Views/chart.html',
            url: '/chart',
            controller: 'ChartCtrl',
            resolve: {
                loadMyFile: function ($ocLazyLoad) {
                    return $ocLazyLoad.load({
                        name: 'chart.js',
                        files: [
                          'Script/Vendor/angular-chart.js/dist/angular-chart.min.js',
                          'Script/Vendor/angular-chart.js/dist/angular-chart.css'
                        ]
                    }),
                    $ocLazyLoad.load({
                        name: 'sbAdminApp',
                        files: ['Script/App/controllers/chartContoller.js']
                    })
                }
            }
        })
        .state('dashboard.table', {
            templateUrl: 'Views/table.html',
            url: '/table'
        })
        .state('dashboard.panels-wells', {
            templateUrl: 'Views/ui-elements/panels-wells.html',
            url: '/panels-wells'
        })
        .state('dashboard.buttons', {
            templateUrl: 'Views/ui-elements/buttons.html',
            url: '/buttons'
        })
        .state('dashboard.notifications', {
            templateUrl: 'Views/ui-elements/notifications.html',
            url: '/notifications'
        })
        .state('dashboard.typography', {
            templateUrl: 'Views/ui-elements/typography.html',
            url: '/typography'
        })
        .state('dashboard.icons', {
            templateUrl: 'Views/ui-elements/icons.html',
            url: '/icons'
        })
        .state('dashboard.grid', {
            templateUrl: 'Views/ui-elements/grid.html',
            url: '/grid'
        })
  }]);

var serviceBase = 'http://localhost:50001/';
//var serviceBase = 'http://ngauthenticationapi.azurewebsites.net/';
angular
  .module('sbAdminApp').constant('ngAuthSettings', {
      apiServiceBaseUri: serviceBase,
      clientId: 'ngAuthApp'
  });

angular.module('sbAdminApp').run(['authService', '$rootScope', '$location', function (authService, $rootScope, $location) {
    var auth = authService.fillAuthData();

    var allowAnonymousUser = ['/signup'];

    $rootScope.$on('$routeChangeStart', function (event, next, current) {
        var keepGoing = true;
        angular.forEach(allowAnonymousUser, function (path, key) {
            if (keepGoing) {
                if (next.originalPath != path) {
                    if (!authService.authentication.isAuth) {
                        event.preventDefault();
                        $location.path('/login');
                    }
                    else {
                    }
                    keepGoing = false;
                }
            }
        });
    });
}]);



