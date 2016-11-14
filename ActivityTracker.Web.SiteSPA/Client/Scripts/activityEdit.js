(function(app) {
    var EditController = function ($scope, activityService) {

        $scope.isEditable = function () {
            return $scope.edit && $scope.edit.activity;
        };

        $scope.create = function () {
            $scope.edit = {
                activity: {
                    Title: "",
                    Description: ""
                }
            };
        };

        $scope.cancel = function() {
            $scope.edit = null;
        };

        $scope.save = function() {
            if ($scope.edit.activity.Id) {
                updateActivity();
            } else {
                createActivity();
            }
        };

        var updateActivity = function () {
            activityService.update($scope.edit.activity)
                .success(function () {
                    //angular.extend($scope.activity, $scope.edit.activity);
                    $scope.edit.activity = null;
                });
        };

        var createActivity = function () {
            activityService.create($scope.edit.activity)
                .success(function (activity) {
                    $scope.activities.push(ActivityConfigutator.configure(activity));
                    $scope.edit.activity = null;
                });
        };

    };

    app.controller("EditController", EditController);
}(angular.module("activityTrackerApp")))