

var sampleApp = angular.module('sampleApp', ['ngSanitize']);//, 'ui.select'
sampleApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/AddEmployeer', {
            templateUrl: '/Angular/AddEmployee1',
            controller: 'AddEmployeeController'
        }).
        when('/ShoeEmployeeList', {
            templateUrl: '/Angular/EmployeeList1',
            controller: 'ShowEmployeeListController'
        }).
        when('/EditEmployee/:employeeId', {
            templateUrl: '/Angular/AddEmployee1',
            controller: 'EditEmployeeController'
        })//.
      //otherwise({
      //    redirectTo: '/addOrder'
      //});
  }]);

