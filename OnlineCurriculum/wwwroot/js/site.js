// Write your Javascript code.
angular
	.module('MainApp', ['ngMaterial'])
	.controller('AppCtrl', ["$scope", "$timeout", "$mdSidenav", function ($scope, $timeout, $mdSidenav) {
		$scope.toggleSidenav = buildToggler('sidenav');
		$scope.toggleRightnav = buildToggler('sidenav-info');
		function buildToggler(componentId) {
			return function () {
				$mdSidenav(componentId).toggle();
			}
		}
	}]);