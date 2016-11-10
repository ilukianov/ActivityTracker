(function (app) {
    var ListController = function ($scope, activityService) {
        activityService.getAll("/api/activity")
            .success(function (data) {
                $scope.activities = data;
            });

        $scope.delete = function (activity) {
            activityService.delete(activity)
                .success(function () {
                    removeMovieById(activity.Id);
                });
        };

        $scope.start = function (activity) {
            //var obj = { "Id": activity.Id, "Status": 2 };
            activityService.start({ "Id": activity.Id, "Status": 2 })
                .success(function () {
                    //removeMovieById(activity.Id);
                });
        };

        $scope.stop = function (activity) {
            //var obj = { "Id": activity.Id, "Title": "Some text" };
            activityService.stop({ "Id": activity.Id, "Title": "Some text" })
                .success(function () {
                    //removeMovieById(activity.Id);
                });
        };

        $scope.create = function () {
            $scope.edit = {
                activity: {
                    Title: "",
                    Runtime: 0,
                    ReleaseYear: new Date().getFullYear()
                }
            };
        };

        var removeMovieById = function (id) {
            for (var i = 0; i < $scope.activities.length; i++) {
                if ($scope.activities[i].Id === id) {
                    $scope.activities.splice(i, 1);
                    break;
                }
            }
        };
    }

    app.controller("ListController", ListController);

}(angular.module("activityTrackerApp")));