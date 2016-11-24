(function (app) {
    var GoalController = function ($scope, goalService) {

        goalService.getAll("/api/goals")
            .success(function (data) {
                $scope.goals = data;
                /*angular.forEach($scope.activities, function (activity, key) {
                    ActivityConfigurator.configure(activity);

                    if (activity.Status === 1) {
                        $scope.activityRunning = activity;
                    }
                });*/
            });

    };

    app.controller("GoalController", GoalController);
}(angular.module("activityTrackerApp")))