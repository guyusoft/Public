var app = angular.module('IMS');

app.controller('navigationMenuController', ['$scope', 'ngDialog', '$http', function ($scope, ngDialog, $http) {

    $scope.columnDefinition = ["链接标题", "链接地址", "操作"];

    $scope.menuItems = JSON.parse($('#dataModel').val());

    $scope.menuItem = {};

    $scope.delete = function (item) {
        $scope.menuItem = item;

        ngDialog.open({
            template: '<p>确定删除该链接？</p> \
                <div><button type="button" class="btn btn-sm btn-default" ng-click="remove()">确定</button> \
                <button type="button" class="btn btn-sm btn-default" ng-click="cancel()">取消</button></div>',
            plain: true,
            scope: $scope
        });
    }

    $scope.edit = function (item) {
        $scope.menuItem = item;

        ngDialog.open({
            template: 'navigationMenuAddAndEdit',
            className: 'ngdialog-theme-default',
            scope: $scope
        });
    };

    $scope.add = function () {
        $scope.menuItem = initializeMenu();

        ngDialog.open({
            template: 'navigationMenuAddAndEdit',
            className: 'ngdialog-theme-default',
            scope: $scope
        });
    };

    $scope.save = function () {
        $http.post('/Home/Edit', $scope.menuItem).then(function (res) {
            if (res.data && res.data.Id > 0 && $.inArray($scope.menuItem, $scope.menuItems) < 0) {
                $scope.menuItem.Id = res.data.Id;
                $scope.menuItems.push($scope.menuItem);
            }
        });

        this.closeThisDialog(0);
    }

    $scope.remove = function () {
        $http.post('/Home/Delete', $scope.menuItem).then(function (res) {
            if (res.data) {
                $scope.menuItems.splice($.inArray($scope.menuItem, $scope.menuItems), 1);
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
        item.Text = "Text";
        item.Href = "Href";

        return item;
    }
}]);