var app = angular.module('IMS');

app.controller('navigationMenuController', ['$scope', 'ngDialog', function ($scope, ngDialog) {

    $scope.columnDefinition = ["链接标题", "链接地址", "操作"];

    $scope.menuItems = JSON.parse($('#dataModel').val());

    $scope.delete = function (id) {
        ngDialog.open({
            template: '<p>确定删除该链接？</p> \
                <div><button type="button" class="btn btn-sm btn-default">确定</button> \
                <button type="button" class="btn btn-sm btn-default">取消</button></div>',
            plain: true
        });
    }

    $scope.edit = function (item) {
        ngDialog.open({
            template: 'navigationMenuAddAndEdit',
            className: 'ngdialog-theme-default',
            data: item
        });
    };

    $scope.add = function (item) {
        ngDialog.open({
            template:'navigationMenuAddAndEdit',
            className: 'ngdialog-theme-default',
            data: item
        });
    };

}]);