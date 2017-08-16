var app = angular.module('IMS');

app.controller('userEditController', ['$scope', '$http', function ($scope, $http) {
    if ($('#dataModel').val() != '') {
        $scope.item = JSON.parse($('#dataModel').val());
    }
    else {
        $scope.item = {};
        $scope.item.Id = 0;
        $scope.item.LoginName = 'LoginName';
        $scope.item.LoginPwd = 'LoginPwd';
        $scope.item.FirstName = 'FirstName';
        $scope.item.LastName = 'LastName';
        $scope.item.EmailAddress = 'EmailAddress';
        $scope.item.PostAddress = 'PostAddress';
    }

    $scope.validateInput = function (name, type) {
        var input = $scope.userInfoEditor[name];
        return (input.$dirty || $scope.submitted) && input.$error[type];
    };

    $scope.save = function () {
        if (!$scope.userInfoEditor.$valid) {
            return false;
        }
        $http.post('/User/Edit', $scope.item).then(function (res) {
            if (res.data && res.data.Id > 0) {
                window.location.href = "/User/Index";
            }
        });
    }

    $scope.cancel = function () {
        window.location.href = "/User/Index";
    }
}]);

