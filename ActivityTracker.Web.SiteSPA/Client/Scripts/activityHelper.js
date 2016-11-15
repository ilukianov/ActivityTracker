function ActivityConfigurator() {
};

ActivityConfigurator.configure = function(activity, key) {
    activity.CanStart = function() {
        return this.Status === 0 || this.Status === 2;
    };
    activity.CanStop = function() {
        return this.Status === 1;
    };
    activity.CanComplete = function() {
        return this.Status !== 3;
    };
    activity.CanResume = function() {
        return this.Status === 2;
    };

    activity.StartTime = new Date(activity.StartTime);

    return activity;
};