/*
        None = 0,
        InProgress = 1,
        Stopped = 2,
        Completed = 3
*/

(function (app) {
    var ListController = function ($scope, $interval, activityService) {

        function ActivityTimer() {
            var self = this;

            self.CurrentTime = new Date();

            self.GetActivityDuration = function() {
                if ($scope.activityRunning === null || $scope.activityRunning === undefined) {
                    return null;
                }

                return getTimeSpanForActivity();
            };

            function getTimeSpanForActivity() {
                var diff = self.CurrentTime.getTime() - $scope.activityRunning.TimeStamp.getTime() + $scope.activityRunning.Duration;

                return TimeHelper.getTimeFromMilliseconds(diff);
            }
            
            self.timerId = $interval(timeIntervalCallback, 1000);

            function timeIntervalCallback() {
                self.CurrentTime = new Date();
            };
        };

        $scope.timer = new ActivityTimer();

        activityService.getAll("/api/activity")
            .success(function(data) {
                $scope.activities = data;
                angular.forEach($scope.activities, function (activity, key) {
                    ActivityConfigurator.configure(activity);

                    if (activity.Status === 1) {
                        $scope.activityRunning = activity;
                    }
                });
            });

        $scope.delete = function(activity) {
            activityService.delete(activity)
                .success(function() {
                    //removeMovieById(activity.Id);
                });
        };

        $scope.start = function(activityToStart) {
            var startActivity,
                stopActivity,
                activitiesForStatusChange = [],
                updatedActivities;

            //skip start if it is running activity
            if (activityToStart === $scope.activityRunning) {
                return;
            }

            //add activity to stop
            if ($scope.activityRunning) {
                stopActivity = angular.copy($scope.activityRunning);
                stopActivity.TimeStamp = new Date();
                stopActivity.Status = 2;

                activitiesForStatusChange.push(stopActivity);
            }

            // get activity to start
            startActivity = angular.copy(activityToStart);
            startActivity.TimeStamp = new Date();
            console.log(startActivity.TimeStamp);
            console.log(startActivity.TimeStamp.getTime());
            startActivity.Status = 1;
            activitiesForStatusChange.push(startActivity);

            //here should be something like a queue or broker
            activityService.changeStatus(activitiesForStatusChange)
                .success(function (updatedActivities) {
                    angular.forEach(updatedActivities, function (activity, key) {

                        //ActivityConfigurator.configure(activity);

                        if ($scope.activityRunning) {
                            if (activity.Id === $scope.activityRunning.Id) {
                                ActivityConfigurator.configure(activity);
                                angular.extend($scope.activityRunning, activity);
                            }
                        }

                        if (activityToStart) {
                            if (activity.Id === activityToStart.Id) {
                                ActivityConfigurator.configure(activity);
                                angular.extend(activityToStart, activity);
                            }
                        }
                    });

                    //stop previous
                    /*if ($scope.activityRunning) {
                        angular.extend($scope.activityRunning, stopActivity);
                    }*/

                    //start next
                    //angular.extend(activity, startActivity);
                    $scope.activityRunning = activityToStart;
                });
        };

        $scope.stop = function(activityToStop) {
            var obj = angular.copy(activityToStop),
                updatedActivities;
            obj.TimeStamp = new Date();
            console.log(obj.TimeStamp);
            obj.Status = 2;

            activityService.changeStatus([obj])
                .success(function (updatedActivities) {

                    angular.forEach(updatedActivities, function(activity, key) {
                        if (activityToStop) {
                            if (activity.Id === activityToStop.Id) {
                                ActivityConfigurator.configure(activity);
                                angular.extend(activityToStop, activity);
                            }
                        }
                    });

                    $scope.activityRunning = null;
                    //angular.extend(activityToStop, obj);
                });
        };

        $scope.done = function (activityToDone) {
            var obj = angular.copy(activityToDone),
                updatedActivities;
            obj.Status = 3;

            activityService.changeStatus([obj])
                .success(function (updatedActivities) {
                    angular.forEach(updatedActivities, function (activity, key) {
                        if (activityToDone) {
                            if (activity.Id === activityToDone.Id) {
                                ActivityConfigurator.configure(activity);
                                angular.extend(activityToDone, activity);
                            }
                        }
                    });

                    if ($scope.activityRunning === activityToDone) {
                        $scope.activityRunning = null;
                    }

                    //angular.extend(activity, obj);
                });
        };

        var removeMovieById = function(id) {
            for (var i = 0; i < $scope.activities.length; i++) {
                if ($scope.activities[i].Id === id) {
                    $scope.activities.splice(i, 1);
                    break;
                }
            }
        };
    };

    app.controller("ListController", ListController);

}(angular.module("activityTrackerApp")));