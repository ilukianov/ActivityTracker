(function (app) {
    var GoalEditController = function ($scope, goalService) {

        $scope.isEditable = function() {
            return $scope.edit && $scope.edit.goal;
        };

        $scope.turnOnControlMode = function() {
            $scope.isControlMode = true;
        };

        $scope.turnOffControlMode = function() {
            $scope.isControlMode = false;
        };

        $scope.create = function () {
            $scope.edit = {
                goal: {
                    Title: "",
                    Description: "",
                    Active: true
                }
            };
        };

        $scope.cancel = function () {
            $scope.edit = null;
        };

        $scope.save = function () {
            if ($scope.edit.goal.Id) {
                updateGoal();
            } else {
                createGoal();
            }
        };

        var updateGoal = function () {
            goalService.update($scope.edit.goal)
                .success(function () {
                    //angular.extend($scope.activity, $scope.edit.activity);
                    $scope.edit.goal = null;
                });
        };

        var createGoal = function () {
            goalService.create($scope.edit.goal)
                .success(function (goal) {
                    // Can use angular.extend ?
                    //$scope.goals.push(ActivityConfigurator.configure(activity));
                    $scope.goals.push(goal);
                    $scope.edit.goal = null;
                });
        };

    };

    app.controller("GoalEditController", GoalEditController);
}(angular.module("activityTrackerApp")))