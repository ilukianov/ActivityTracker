(function (app) {

    var activityService = function ($http, activityApiUrl) {

        var getAll = function () {
            return $http.get(activityApiUrl);
        };

        var getById = function (id) {
            return $http.get(activityApiUrl + id);
        };

        var update = function (movie) {
            return $http.put(activityApiUrl + movie.id, movie);
        };

        var create = function (movie) {
            return $http.post(activityApiUrl, movie);
        };

        var destroy = function (movie) {
            return $http.delete(movieApiUrl + movie.id);
        };

        return {
            getAll: getAll,
            getById: getById,
            update: update,
            create: create,
            delete: destroy
        };
    };

    activityService.$inject = ["$http", "activityApiUrl"];

    app.factory("activityService", activityService);

}(angular.module("activityTrackerApp")))