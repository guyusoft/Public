var app = angular.module('IMS');

app.controller('newsController', ['$scope', 'ngDialog', function ($scope, ngDialog) {

    $scope.columnDefinition = ["标题", "新闻", "操作"];

    $scope.menuItems = JSON.parse($('#dataModel').val());

    $scope.delete = function (id) {
        ngDialog.open({
            template: '<p>确定删除该新闻？</p> \
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
        window.location.href = "";
    };

}]);