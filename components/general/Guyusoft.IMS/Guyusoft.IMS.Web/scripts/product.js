var app = angular.module('IMS');

app.controller('poductController', ['$scope', 'ngDialog', '$http', function ($scope, ngDialog, $http) {
    $scope.columnDefinition = ["产品名称", "类别", "操作"];

    $scope.Items = JSON.parse($('#dataModel').val());

    $scope.item = {};

    $scope.delete = function (item) {
        $scope.item = item;

        ngDialog.open({
            template: '<p>确定删除该产品？</p> \
                <div><button type="button" class="btn btn-sm btn-default" ng-click="remove()">确定</button> \
                <button type="button" class="btn btn-sm btn-default" ng-click="cancel()">取消</button></div>',
            plain: true,
            scope: $scope
        });
    }

    $scope.remove = function () {
        $http.post('/Product/Delete', $scope.item).then(function (res) {
            if (res.data) {
                $scope.Items.splice($.inArray($scope.item, $scope.Items), 1);
            }
        });

        this.closeThisDialog(0);
    }

    $scope.cancel = function () {
        this.closeThisDialog(0);
    }

    $scope.edit = function (item) {
        window.location.href = "/Product/Edit?id=" + item.Id;
    };

    $scope.add = function (item) {
        window.location.href = "/Product/Edit?id=0";
    };

}]);