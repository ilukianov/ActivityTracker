(function (app) {
    var ListController = function ($scope, activityService) {
        activityService.getAll("/api/activity")
            .success(function (data) {
                $scope.activities = data;
            });

        $scope.delete = function (movie) {
            activityService.delete(movie)
                .success(function () {
                    removeMovieById(movie.Id);
                });
        };

        $scope.create = function () {
            $scope.edit = {
                movie: {
                    Title: "",
                    Runtime: 0,
                    ReleaseYear: new Date().getFullYear()
                }
            };
        };

        var removeMovieById = function (id) {
            for (var i = 0; i < $scope.movies.length; i++) {
                if ($scope.movies[i].Id == id) {
                    $scope.movies.splice(i, 1);
                    break;
                }
            }
        };
    }

    app.controller("ListController", ListController);

}(angular.module("activityTrackerApp")));