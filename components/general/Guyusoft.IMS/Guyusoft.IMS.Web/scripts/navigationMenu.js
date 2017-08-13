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

    $scope.edit = function (id) {
        ngDialog.open({
            template:
              '<div class="panel panel-default dialog"> \
                 <div class="panel-heading">新增链接</div> \
                 <div class="panel-body"> \
                    <form class="form-horizontal ng-pristine ng-valid"> \
                       <div class="form-group"> \
                          <label class="col-lg-4 control-label">链接标题</label> \
                          <div class="col-lg-8"> \
                             <input type="text" placeholder="链接标题" class="form-control"> \
                          </div> \
                       </div> \
                       <div class="form-group"> \
                          <label class="col-lg-4 control-label">链接地址</label> \
                          <div class="col-lg-8"> \
                             <input type="text" placeholder="链接地址" class="form-control"> \
                          </div> \
                       </div> \
                       <div class="form-group"> \
                          <div class="col-lg-offset-4 col-lg-8"> \
                             <button type="button" class="btn btn-sm btn-default">确定</button> \
                             <button type="button" class="btn btn-sm btn-default">取消</button> \
                          </div> \
                       </div> \
                    </form> \
                 </div> \
            </div>',
            plain: true
        });
    };

    $scope.add = function (id) {
        ngDialog.open({
            template:
              '<div class="panel panel-default dialog"> \
                 <div class="panel-heading">新增链接</div> \
                 <div class="panel-body"> \
                    <form class="form-horizontal ng-pristine ng-valid"> \
                       <div class="form-group"> \
                          <label class="col-lg-4 control-label">链接标题</label> \
                          <div class="col-lg-8"> \
                             <input type="text" placeholder="链接标题" class="form-control"> \
                          </div> \
                       </div> \
                       <div class="form-group"> \
                          <label class="col-lg-4 control-label">链接地址</label> \
                          <div class="col-lg-8"> \
                             <input type="text" placeholder="链接地址" class="form-control"> \
                          </div> \
                       </div> \
                       <div class="form-group"> \
                          <div class="col-lg-offset-4 col-lg-8"> \
                             <button type="button" class="btn btn-sm btn-default">确定</button> \
                             <button type="button" class="btn btn-sm btn-default">取消</button> \
                          </div> \
                       </div> \
                    </form> \
                 </div> \
            </div>',
            plain: true
        });
    };

}]);