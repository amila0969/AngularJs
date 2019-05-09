var url = "http://localhost/webapiwithangularjs/api/employees";
var myApp = angular.module("testModule", []);

var EmployeeController = function ($scope, $http) {
    //debugger;
    var onSuccess = function (response) {
        console.log(response.data);
        $scope.employees = response.data;;
    };

    var onFailure = function (reason) {
        $scope.error = reason;
    };


    var getAllEmployees = function () {
        $http.get(url).then(onSuccess, onFailure)


    
    };

    getAllEmployees();

    //debugger;

     $scope.AddData = function () {
         debugger;
        var emp = {
            Name: $scope.Name,
            Email : $scope.Email
         };
         console.log(emp);
         $http.Post(url, emp)

    };
};

myApp.controller("EmployeeController", EmployeeController);