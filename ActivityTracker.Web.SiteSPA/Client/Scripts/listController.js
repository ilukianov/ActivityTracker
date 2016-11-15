/*
        None = 0,
        InProgress = 1,
        Stopped = 2,
        Completed = 3
*/

(function (app) {
    var ListController = function ($scope, $interval, activityService) {

        function ActivityTimer() {
            var self = this,
                timerId;

            self.CurrentTime = new Date();

            self.GetActivityDuration = function() {
                if ($scope.activityRunning === null || $scope.activityRunning === undefined) {
                    return null;
                }

                return getTimeSpanForActivity();//new Date(self.CurrentTime - $scope.activity.StartTime); //timeSpan;
            };

            function getTimeSpanForActivity() {
                var diff = self.CurrentTime.getTime() - $scope.activityRunning.StartTime.getTime();
                var days = Math.floor(diff / (1000 * 60 * 60 * 24));
                diff -= days * (1000 * 60 * 60 * 24);

                var hours = Math.floor(diff / (1000 * 60 * 60));
                diff -= hours * (1000 * 60 * 60);

                var mins = Math.floor(diff / (1000 * 60));
                diff -= mins * (1000 * 60);

                var seconds = Math.floor(diff / (1000));
                diff -= seconds * (1000);

                var timeSpan = "";
                if (days > 0) {
                    timeSpan = days + ":" + hours + ":" + mins + ":" + seconds;
                }
                else if (hours > 0) {
                    timeSpan = hours + ":" + mins + ":" + seconds;
                }
                else {
                    timeSpan = mins + ":" + seconds;
                }

                // todo move the code above into separate class and file
                return timeSpan;
            }
            
            self.timerId = $interval(timeIntervalCallback, 1000);
            
/*            function startTimer() {
                
            };*/

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

        $scope.start = function(activity) {
            var startActivity,
                stopActivity,
                activitiesForStatusChange;

            if (activity === $scope.activityRunning) {
                return;
            }

            startActivity = angular.copy(activity);
            startActivity.StartTime = new Date();
            startActivity.Status = 1;

            if ($scope.activityRunning) {
                stopActivity = angular.copy($scope.activityRunning);
                stopActivity.Status = 2;

                activitiesForStatusChange = [stopActivity, startActivity];
            } else {
                activitiesForStatusChange = [startActivity];
            }

            activityService.changeStatus(activitiesForStatusChange)
                .success(function () {
                    //stop previous
                    if ($scope.activityRunning) {
                        angular.extend($scope.activityRunning, stopActivity);
                    }

                    //start next
                    angular.extend(activity, startActivity);
                    $scope.activityRunning = activity;
                });
        };

        $scope.stop = function(activity) {
            var obj = angular.copy(activity);
            obj.Status = 2;

            activityService.changeStatus([obj])
                .success(function () {
                    $scope.activityRunning = null;
                    angular.extend(activity, obj);
                });
        };

        $scope.done = function (activity) {
            var obj = angular.copy(activity);
            obj.Status = 3;

            activityService.changeStatus([obj])
                .success(function () {
                    if ($scope.activityRunning === activity) {
                        $scope.activityRunning = null;
                    }

                    angular.extend(activity, obj);
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