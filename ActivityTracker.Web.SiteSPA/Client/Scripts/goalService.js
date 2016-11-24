(function (app) {

    var goalService = function ($http, apiUrl) {

        var getAll = function () {
            return $http.get(apiUrl);
        };

        var create = function (goal) {
            return $http.post(apiUrl, goal);
        };

        /*
        var getById = function (id) {
            return $http.get(apiUrl + id);
        };

        var update = function (activity) {
            return $http.put(apiUrl + activity.Id, activity);
        };

        var create = function (activity) {
            return $http.post(apiUrl, activity);
        };

        var changeStatus = function (activity) {
            return $http.put(apiUrl + "changestatus/", activity);
        };

        var destroy = function (activity) {
            return $http.delete(apiUrl + activity.Id);
        };*/

        return {
            getAll: getAll,
            create: create
            /*getById: getById,
            update: update,
            create: create,
            delete: destroy,
            changeStatus: changeStatus*/
        };
    };

    goalService.$inject = ["$http", "goalApiUrl"];

    app.factory("goalService", goalService);

}(angular.module("activityTrackerApp")));