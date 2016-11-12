(function (app) {
    var ListController = function ($scope, $interval, activityService) {

        function ActivityTimer() {
            var self = this,
                timerId;

            self.CurrentTime = new Date();

            self.GetActivityDuration = function() {
                if ($scope.activity === null || $scope.activity === undefined) {
                    return null;
                }

                return getTimeSpanForActivity();//new Date(self.CurrentTime - $scope.activity.StartTime); //timeSpan;
            };

            function getTimeSpanForActivity() {
                var diff = self.CurrentTime.getTime() - $scope.activity.StartTime.getTime();
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
                else if (mins > 0) {
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
                angular.forEach($scope.activities, function(activity, key) {
                    activity.CanStart = function() {
                        return this.Status === 0;
                    };
                    activity.CanStop = function() {
                        return this.Status === 1;
                    };
                    activity.CanComplete = function() {
                        return this.Status !== 3;
                    };
                    activity.CanResume = function () {
                        return this.Status === 2;
                    };

                    activity.StartTime = new Date(activity.StartTime);

                    if (activity.Status === 1) {
                        $scope.activity = activity;
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
            var obj = { "Id": activity.Id, "Status": 1 };
            activityService.start(obj)
                .success(function () {
                    $scope.activity = activity;
                    angular.extend($scope.activity, obj);
                });
        };

        $scope.stop = function(activity) {
            var obj = { "Id": activity.Id, "Title": "Some text" };
            activityService.stop(obj)
                .success(function () {
                    $scope.activity = null;
                    angular.extend(activity, obj);
                });
        };

        $scope.create = function() {
            $scope.edit = {
                activity: {
                    Title: "",
                    Runtime: 0,
                    ReleaseYear: new Date().getFullYear()
                }
            };
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