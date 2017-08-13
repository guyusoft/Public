var app = angular.module('IMS', ['ngDialog']);

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