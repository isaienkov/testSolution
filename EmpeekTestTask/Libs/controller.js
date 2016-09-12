var app = angular.module("fileSystemApp", []);
app.controller("FileSystemAppCtrl", function ($scope, $http) {

    $scope.GetPath = function (path, dir) {
        $http.get("api/path?path=" + path + "&dir=" + dir).success(function (response) {
            $scope.path = response;
        })
    }

    $scope.ChangeStatus = function (status) {
        $http.get("api/showdisc?status=" + status).success(function (response) {
            $scope.showdisc = response;
        })
    }

    $scope.GetNewData = function (path) {
        $http.get("api/document?path=" + path).success(function (response) {
            $scope.document = response;
        });
    }


    $http.get("api/disc").success(function (response) {
        $scope.disc = response;
    })

});