(function (app) {
    var AllActivitiesController = function ($scope, activityService) {

        activityService.getAll("/api/activity")
            .success(function (data) {
                $scope.activities = data;
                angular.forEach($scope.activities, function (activity, key) {
                    ActivityConfigurator.configure(activity);

                    if (activity.Status === 1) {
                        $scope.activityRunning = activity;
                    }
                });
            });

    };

    app.controller("AllActivitiesController", AllActivitiesController);
}(angular.module("activityTrackerApp")))