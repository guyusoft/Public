var app = angular.module('IMS',['textAngular']);

app.controller('productEditController', ['$scope', '$http', function ($scope, $http) {
    if ($('#dataModel').val() != '') {
        $scope.item = JSON.parse($('#dataModel').val());
    }
    else {
        $scope.item = {};
        $scope.item.Id = 0;
        $scope.item.ProductName = '产品名称';
        $scope.item.ProductDesc = '产品描述';
        $scope.item.ProductCategoryId = 1;
    }

    $http.get('/ProductCategory/GetAll').then(function (res) {
        $scope.categories = res.data;
    });

    $scope.save = function () {
        $http.post('/Product/Edit', $scope.item).then(function (res) {
            if (res.data && res.data.Id > 0) {
                window.location.href = "/Product/Index";
            }
        });
    }

    $scope.cancel = function () {
        window.location.href = "/Product/Index";
    }
}]);

