(function(app) {

    var activityService = function($http, activityApiUrl) {

        var getAll = function() {
            return $http.get(activityApiUrl);
        };

        var getById = function(id) {
            return $http.get(activityApiUrl + id);
        };

        var update = function(activity) {
            return $http.put(activityApiUrl + activity.id, activity);
        };

        var create = function(activity) {
            return $http.post(activityApiUrl, activity);
        };

        var start = function(activity) {
            return $http.put(activityApiUrl + "changestatus/" + activity.Id, activity);
        };

        var stop = function(activity) {
            return $http.put(activityApiUrl + "changetitle/" + activity.Id, activity);
        };

        var destroy = function(activity) {
            return $http.delete(activityApiUrl + activity.id);
        };

        return {
            getAll: getAll,
            getById: getById,
            update: update,
            create: create,
            delete: destroy,
            start: start,
            stop: stop
        };
    };

    activityService.$inject = ["$http", "activityApiUrl"];

    app.factory("activityService", activityService);

}(angular.module("activityTrackerApp")));