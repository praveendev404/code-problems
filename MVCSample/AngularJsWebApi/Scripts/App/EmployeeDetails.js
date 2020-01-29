//alert("c0");
//var sampleApp=angular
//    .module('sampleApp', []);
////    .controller('AddOrderController', [
////        '$scope', function ($scope) {
////            alert("child");

////        }
////    ]);

sampleApp.controller('ShowEmployeeListController', function ($scope, EmployeeService) {
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
        CountryId: '',
        GenderId: '',
        StateId: '',
        StatusTypeId: '',
        lstGenders: '',
        lstCountrys: '',
        lstStates: '',
        file: '',
        LstCourses: '',
    }


    //$scope.Edit = function (emp) {

    //    $scope.emp.EmployeeId = emp.EmployeeId;
    //    $scope.emp.FirstName = "aswgdfb";
    //    $scope.emp.LastName = emp.LastName;
    //    $scope.emp.Email = emp.Email;
    //    $scope.emp.MobileNo = emp.MobileNo;
    //    $scope.emp.Address = emp.Address;
    //    $scope.emp.ZipCode = emp.ZipCode;
    //    $scope.emp.CountryId = emp.CountryId;
    //    $scope.emp.StateId = emp.StateId;
    //    $scope.emp.GenderId = emp.GenderId;
    //    //  window.location = "/Angular/AddEmployee";
    //}
    $scope.Delete = function (employeeId) {

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '/Angular/DeleteEmployee?id=' + employeeId,
            success: function (data, status) {
                alert("Record delete successfully");
                window.location = "#/ShoeEmployeeList";
            },
            error: function (status) { }
        });
    }

})


sampleApp.controller('AddEmployeeController', function ($scope, $http) {
    $scope.emp = {
        EmployeeId: '',
        FirstName: '',
        LastName: '',
        Email: '',
        MobileNo: '',
        Address: '',
        ZipCode: '',
        CountryId: '',
        GenderId: '',
        StateId: '',
        StatusTypeId: '',
        lstGenders: '',
        LstCountrys: '',
        LstStates: '',
        file: '',
        LstCourses: '',
    }

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '/Angular/GetCountries',
        async: false,
        success: function (data, status) {
            var emp = data;
            $scope.emp.LstCountrys = data;
        },
        error: function (status) {
            alert("error");
        }
    });

    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '/Angular/GetCourses',
        async: false,
        success: function (data, status) {
            var emp = data;
            $scope.emp.LstCourses = data;
        },
        error: function (status) {
            alert("error");
        }
    });
    $scope.update = function (id) {
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '/Angular/GetStates?id=' + id,
            async: false,
            success: function (data, status) {
                var emp = data;
                $scope.emp.LstStates = data;
            },
            error: function (status) {
                alert("error");
            }
        });
    }

    //$http.get('http://localhost:3614/api/ApiAngularJs/GetCountries').success(function (data) {
    //    debugger
    //    $scope.lstCountrys = data;
    //})
    // .error(function () {

    // });
  
    $scope.clear = function () {

        $scope.emp.EmployeeId = '';
        $scope.emp.FirstName = '';
        $scope.emp.LastName = '';
        $scope.emp.Email = '';
        $scope.emp.MobileNo = '';
        $scope.emp.Address = '';
        $scope.emp.ZipCode = '';
    }


    $scope.Save = function () {

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify($scope.emp),
            url: '/Angular/saveEmployee',
            success: function (data, status) {
                window.location = "#/ShoeEmployeeList";
            },
            error: function (status) { }
        });
    }

    $scope.emp.SelectedCourses = []; 
    $scope.toggleSelection = function toggleSelection(id) {
        debugger
        var idx = $scope.emp.SelectedCourses.indexOf(id);
        if (idx > -1) {
            $scope.emp.SelectedCourses.splice(idx, 1);
        }          
        else {
            $scope.emp.SelectedCourses.push(id);
        }
    };
});


sampleApp.controller('EditEmployeeController', function ($scope, $routeParams, EmployeeService) {
    $scope.emp = {
        //EmployeeId: '',
        //FirstName: '',
        //LastName: '',
        //Email: '',
        //MobileNo: '',
        //Address: '',
        //ZipCode: '',
        //CountryId: '',
        //GenderId: '',
        //StateId: '',
        //StatusTypeId: '',
        //lstGenders: '',
        // lstCountrys: '',
        //lstStates: '',
        //file: '',
        //LstCourses: '',
        //country: ''
    }
    
    var employeeId = $routeParams.employeeId;
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '/Angular/GetCountries',
        async: false,
        success: function (data, status) {

            var emp = data;
            $scope.emp.lstCountrys = data;
        },
        error: function (status) {
            alert("error");
        }
    });

    //$.ajax({
    //    type: 'POST',
    //    contentType: 'application/json; charset=utf-8',
    //    url: '/Angular/GetCourses',
    //    async: false,
    //    success: function (data, status) {
    //        debugger
    //        var emp = data;
    //        $scope.emp.LstCourses = data;
    //    },
    //    error: function (status) {
    //        alert("error");
    //    }
    //});
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '/Angular/GetEmployeeById?id=' + employeeId,
        async: false,
        success: function (data, status) {
            debugger
            $scope.emp = data;
            $scope.emp.SelectedCourses = [];
            for (var i = 0; i < data.SelectedEmpCourses.length; i++) {
              
            }
          
           
            //$scope.emp.EmployeeId = emp1.EmployeeId;
            //$scope.emp.FirstName = emp1.FirstName;
            //$scope.emp.LastName = emp1.LastName;
            //$scope.emp.Email = emp1.Email;
            //$scope.emp.MobileNo = emp1.MobileNo;
            //$scope.emp.Address = emp1.Address;
            //$scope.emp.ZipCode = emp1.ZipCode;
            //$scope.emp.EmployeeId = emp1.EmployeeId;
            //$scope.emp.CountryId = emp1.CountryId;
            //$scope.emp.StateId = emp1.StateId;
            //$scope.emp.GenderId = emp1.GenderId;
            //$scope.emp.country = emp1.country;
            //$.ajax({
            //    type: 'POST',
            //    contentType: 'application/json; charset=utf-8',
            //    url: '/Angular/GetStates?id=' + data.CountryId,
            //    async: false,
            //    success: function (data1, status) {
            //        $scope.emp.lstStates = data1;
            //    },
            //    error: function (status) {
            //        alert("error");
            //    }
            //});
        },
        error: function (status) {
            alert("error");
        }
    });

    $scope.update = function (id) {
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            url: '/Angular/GetStates?id=' + id,
            async: false,
            success: function (data, status) {


                $scope.emp.lstStates = data;
            },
            error: function (status) {
                alert("error");
            }
        });
    }

    $scope.Save = function () {

        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify($scope.emp),
            url: '/Angular/saveEmployee',
            success: function (data, status) {


                window.location = "#/ShoeEmployeeList";
            },
            error: function (status) { }
        });
    }

});

sampleApp.factory('EmployeeService', ['$http', function ($http) {
    var empService = {};
    empService.getEmployess = function () {
        return $http.get('/Angular/GetEmployee');
    };
    return empService;
}]);


sampleApp.directive('fileModel', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {

            var model = $parse(attrs.fileModel);
            var modelSetter = model.assign;

            element.bind('change', function () {

                scope.$apply(function () {
                    modelSetter(scope, element[0].files[0]);
                });
            });
        }
    };
}]);

sampleApp.service('fileUpload', ['$http', function ($http) {

    this.uploadFileToUrl = function (file, uploadUrl) {

        var fd = new FormData();
        fd.append('file', file);
        $.ajax({
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: fd,
            url: '/Angular/saveFile',
            success: function (data, status) {
            },
            error: function (status) { }
        });
        //$http.post(uploadUrl, fd, {
        //    transformRequest: angular.identity,
        //    headers: { 'Content-Type': undefined }
        //})
        //.success(function () {
        //})
        //.error(function () {
        //});
    }
}]);

sampleApp.controller('myCtrl', ['$scope', 'fileUpload', function ($scope, fileUpload) {
    $scope.uploadFile = function () {

        var file = $scope.myFile;
        console.log('file is ');
        console.dir(file);
        var uploadUrl = "/fileUpload";
        fileUpload.uploadFileToUrl(file, uploadUrl);
    };

}]);