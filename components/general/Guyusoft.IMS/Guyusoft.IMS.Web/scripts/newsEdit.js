angular.module("textAngularditor", ['textAngular'])
    .controller('wysiwygeditor', ['$scope', 'textAngularManager', function wysiwygeditor($scope, textAngularManager) {
        $scope.version = textAngularManager.getVersion();
        $scope.versionNumber = $scope.version.substring(1);
        $scope.orightml = '<h2>请输入新闻内容</h2>';
        $scope.htmlcontent = $scope.orightml;
        $scope.disabled = false;
    }]);

var app = angular.module('IMS');

app.controller('newsEditController', ['$scope', 'ngDialog', function ($scope, ngDialog) {
    $scope.columnDefinition = ["标题", "新闻", "操作"];

    $scope.newsItems = JSON.parse($('#dataModel').val());

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
        window.location.href = "/News/Edit";
    };

}]);