'use strict';

/**
 * @ngdoc directive
 * @name izzyposWebApp.directive:adminPosHeader
 * @description
 * # adminPosHeader
 */
angular.module('sbAdminApp')
	.directive('headerNotification', ['$compile', 'authService', function ($compile, authService) {
	    return {
	        templateUrl: 'Script/App/directives/header/header-notification/header-notification.html',
	        restrict: 'E',
	        replace: true,
	        link: function (scope, element, attrs) {
	            scope.userName = authService.authentication.userName;

	            scope.logout = function () {
	                authService.logOut();
	            };
	        }
	    }
	}]);


