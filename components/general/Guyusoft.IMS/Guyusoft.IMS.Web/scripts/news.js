var app = angular.module('IMS');

app.controller('newsController', ['$scope', 'ngDialog', '$http', function ($scope, ngDialog, $http) {
    $scope.columnDefinition = ["标题", "新闻", "操作"];

    $scope.newsItems = JSON.parse($('#dataModel').val());

    $scope.item = {};

    $scope.delete = function (item) {
        $scope.item = item;

        ngDialog.open({
            template: '<p>确定删除该新闻？</p> \
                <div><button type="button" class="btn btn-sm btn-default" ng-click="remove()">确定</button> \
                <button type="button" class="btn btn-sm btn-default" ng-click="cancel()">取消</button></div>',
            plain: true,
            scope: $scope
        });
    }

    $scope.remove = function () {
        $http.post('/News/Delete', $scope.item).then(function (res) {
            if (res.data) {
                $scope.newsItems.splice($.inArray($scope.item, $scope.newsItems), 1);
            }
        });

        this.closeThisDialog(0);
    }

    $scope.cancel = function () {
        this.closeThisDialog(0);
    }

    $scope.edit = function (item) {
        window.location.href = "/News/Edit?id=" +item.Id;
    };

    $scope.add = function (item) {
        window.location.href = "/News/Edit?id=0";
    };

}]);