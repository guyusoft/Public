var app = angular.module('IMS');

app.controller('productCategoryController', ['$scope', 'ngDialog', '$http', function ($scope, ngDialog, $http) {

    $scope.columnDefinition = ["Id", "名称", "操作"];

    $scope.items = JSON.parse($('#dataModel').val());

    $scope.item = {};

    $scope.delete = function (item) {
        $scope.item = item;

        ngDialog.open({
            template: '<p>确定删除该类别？</p> \
                <div><button type="button" class="btn btn-sm btn-default" ng-click="remove()">确定</button> \
                <button type="button" class="btn btn-sm btn-default" ng-click="cancel()">取消</button></div>',
            plain: true,
            scope: $scope
        });
    }

    $scope.edit = function (item) {
        $scope.item = item;

        ngDialog.open({
            template: 'newsCategoryAddAndEdit',
            className: 'ngdialog-theme-default',
            scope: $scope
        });
    };

    $scope.add = function () {
        $scope.item = initializeMenu();

        ngDialog.open({
            template: 'newsCategoryAddAndEdit',
            className: 'ngdialog-theme-default',
            scope: $scope
        });
    };

    $scope.save = function () {
        $http.post('/ProductCategory/Edit', $scope.item).then(function (res) {
            if (res.data && res.data.Id > 0 && $.inArray($scope.item, $scope.items) < 0) {
                $scope.item.Id = res.data.Id;
                $scope.items.push($scope.item);
            }
        });

        this.closeThisDialog(0);
    }

    $scope.remove = function () {
        $http.post('/ProductCategory/Delete', $scope.item).then(function (res) {
            if (res.data) {
                $scope.items.splice($.inArray($scope.item, $scope.items), 1);
            }
        });

        this.closeThisDialog(0);
    }

    $scope.cancel = function () {
        this.closeThisDialog(0);
    }

    var initializeMenu = function () {
        var item = {};
        item.Id = 0;
        item.CategoryName = "";

        return item;
    }
}]);