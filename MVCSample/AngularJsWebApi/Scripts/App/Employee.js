var employeeApp = angular.module('EmployeeApp', []);
employeeApp.controller('EmployeeController', function ($scope, EmployeeService) {
    EmployeeService.getEmployess().success(function (emps) {
        
        $scope.employees = emps;
    }).error(function (error) {
        $scope.status = 'Unable to load customer data: ' + error.message;
    });
    $scope.emp = {
        EmployeeId: '',
        FirstName: '',
        LastName: '',
        Email: '',
        MobileNo: '',
        Address: '',
        ZipCode: '',
        StatusTypeId:''
    }
    $scope.clear = function () {
        
        $scope.emp.EmployeeId = '';
        $scope.emp.FirstName = '';
        $scope.emp.LastName = '';
        $scope.emp.Email = '';
        $scope.emp.MobileNo = '';
        $scope.emp.Address = '';
        $scope.emp.ZipCode = '';

    }

    $scope.Edit = function (emp) {
        alert(JSON.stringify(emp));
        debugger
        $scope.emp.FirstName = emp.FirstName;
        window.location = "/Angular/AddEmployee";
    }

    $scope.Save = function () {
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify($scope.emp),
            url: '/Angular/saveEmployee',
            success: function (data, status) {
                
                $scope.clear();             
            },
            error: function (status) { }
        });
    }
})

employeeApp.factory('EmployeeService', ['$http', function ($http) {
    
    var empService = {};   
    empService.getEmployess = function () {
        return $http.get('/Angular/GetEmployee');
    };
    return empService;
}]);