(function() {
    var app = angular.module("activityTrackerApp", ["ngRoute"]);

    var config = function ($routeProvider) {
        $routeProvider
            .when("/list",
                { templateUrl: "/client/views/list.html" })
            .when("/details/:id",
                { templateUrl: "/client/views/details.html" })
            .when("/goals",
                { templateUrl: "/client/views/goals.html" })
            .otherwise(
                { redirectTo: "/list" });
    };
    app.config(config);    app.constant("activityApiUrl", "/api/activity/");
    app.constant("goalApiUrl", "/api/goal/");
}());