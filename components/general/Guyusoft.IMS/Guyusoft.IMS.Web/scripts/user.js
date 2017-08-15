var app = angular.module('IMS');

app.controller('userController', ['$scope', 'ngDialog', '$http', function ($scope, ngDialog, $http) {
    $scope.columnDefinition = ["登录名", "通讯地址", "Email",'操作'];

    $scope.Items = JSON.parse($('#dataModel').val());

    $scope.item = {};

    $scope.delete = function (item) {
        $scope.item = item;

        ngDialog.open({
            template: '<p>确定删除该用户？</p> \
                <div><button type="button" class="btn btn-sm btn-default" ng-click="remove()">确定</button> \
                <button type="button" class="btn btn-sm btn-default" ng-click="cancel()">取消</button></div>',
            plain: true,
            scope: $scope
        });
    }

    $scope.remove = function () {
        $http.post('/User/Delete', $scope.item).then(function (res) {
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
        window.location.href = "/User/Edit?id=" + item.Id;
    };

    $scope.add = function (item) {
        window.location.href = "/User/Edit?id=0";
    };

}]);