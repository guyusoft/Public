var app = angular.module('IMS',['textAngular']);

app.controller('newsEditController', ['$scope', '$http', function ($scope, $http) {
    if ($('#dataModel').val() != '') {
        $scope.item = JSON.parse($('#dataModel').val());
    }
    else {
        $scope.item = {};
        $scope.item.Id = 0;
        $scope.item.Title = 'Title';
        $scope.item.NewsCategoryId = 1;
        $scope.item.UserId = 1;
        $scope.item.Content = '<h2>Content</h2>';
    }

    $scope.save = function () {
        $http.post('/News/Edit', $scope.item).then(function (res) {
            if (res.data && res.data.Id > 0) {
                window.location.href = "/News/Index";
            }
        });
    }

    $scope.cancel = function () {
        window.location.href = "/News/Index";
    }
}]);

