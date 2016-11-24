(function(app) {

    var activityService = function($http, activityApiUrl) {

        var getAll = function() {
            return $http.get(activityApiUrl);
        };

        var getById = function(id) {
            return $http.get(activityApiUrl + id);
        };

        var update = function(activity) {
            return $http.put(activityApiUrl + activity.Id, activity);
        };

        var create = function(activity) {
            return $http.post(activityApiUrl, activity);
        };

        var changeStatus = function(activity) {
            return $http.put(activityApiUrl + "changestatus/", activity);
        };

        var destroy = function(activity) {
            return $http.delete(activityApiUrl + activity.Id);
        };

        return {
            getAll: getAll,
            getById: getById,
            update: update,
            create: create,
            delete: destroy,
            changeStatus: changeStatus
        };
    };

    activityService.$inject = ["$http", "activityApiUrl"];

    app.factory("activityService", activityService);

}(angular.module("activityTrackerApp")));