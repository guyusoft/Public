var app = angular.module('IMS', ['ngDialog', 'datatables']);

app.run(["$rootScope", function ($rootScope) {
    $rootScope.leftNavigation = [];

    $rootScope.leftNavigation.push({
        heading: true,
        displayName: "基础信息配置",
        subItems: [
            {
                text: "导航菜单",
                href: "Home/Index"
            },
            {
                text: "用户管理",
                href: "User/Index"
            },
            {
                text: "新闻类别",
                href: "News/Index"
            },
            {
                text: "产品类别",
                href: "Product/Index"
            }
        ]
    });

    $rootScope.pageOptions = [1, 2, 5, 10, 20, 50, 100];
}]);

app.controller('sidebarController', ['$scope', '$http', function ($scope, $http) {

    var collapseList = [];

    var isActive = function (item) {

        if (!item) return;

        if (!item.sref || item.sref == '#') {
            var foundActive = false;
            angular.forEach(item.submenu, function (value, key) {
                if (isActive(value)) foundActive = true;
            });
            return foundActive;
        }
    };

    $scope.getMenuItemPropClasses = function (item) {
        return (item.heading ? 'nav-heading' : '') +
               (isActive(item) ? ' active' : '');
    };

    $scope.loadSidebarMenu = function () {

        var menuJson = '/configuration/menu.json',
            menuURL = menuJson + '?v=' + (new Date().getTime()); // jumps cache

        $http.get(menuURL).then(function (items) {
              $scope.menuItems = items;
          });
    };

    $scope.loadSidebarMenu();

    $scope.addCollapse = function ($index, item) {
        collapseList[$index] = !isActive(item);
    };

    $scope.isCollapse = function ($index) {
        return (collapseList[$index]);
    };

    $scope.toggleCollapse = function ($index, isParentItem) {
        if (angular.isDefined(collapseList[$index])) {
            if (!$scope.lastEventFromChild) {
                collapseList[$index] = !collapseList[$index];
                closeAllBut($index);
            }
        }
        else if (isParentItem) {
            closeAllBut(-1);
        }

        $scope.lastEventFromChild = isChild($index);

        return true;

    };

    function closeAllBut(index) {
        index += '';
        for (var i in collapseList) {
            if (index < 0 || index.indexOf(i) < 0)
                collapseList[i] = true;
        }
    }

    function isChild($index) {
        return (typeof $index === 'string') && !($index.indexOf('-') < 0);
    }

}]);