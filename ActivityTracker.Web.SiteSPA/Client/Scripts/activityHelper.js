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
    activity.IsNotInProgress = function () {
        return this.Status !== 1;
    };

    activity.GetDuration = function() {
        return TimeHelper.getTimeFromMilliseconds(activity.Duration);
    };

    activity.TimeStamp = TimeHelper.getUTCDateTimeFromMilliseconds(activity.TimeStamp);

    return activity;
};

function TimeHelper() {
};

TimeHelper.getUTCDateTimeFromMilliseconds = function(milliseconds) {
    var date = new Date(milliseconds);
    //date.setUTCMilliseconds(milliseconds);
    return date;
}

TimeHelper.getTimeFromMilliseconds = function (milliseconds) {
    // timestamp on http://stackoverflow.com/questions/9575790/how-to-get-time-in-milliseconds-since-the-unix-epoch-in-javascript
    // var milliseconds = (new Date).getTime();

    var days = Math.floor(milliseconds / (1000 * 60 * 60 * 24));
    milliseconds -= days * (1000 * 60 * 60 * 24);

    var hours = Math.floor(milliseconds / (1000 * 60 * 60));
    milliseconds -= hours * (1000 * 60 * 60);

    var mins = Math.floor(milliseconds / (1000 * 60));
    milliseconds -= mins * (1000 * 60);

    var seconds = Math.floor(milliseconds / (1000));

    var timeSpan = "";
    if (days > 0) {
        timeSpan = days + " d " + hours + " h";
        //timeSpan = days + ":" + hours + ":" + mins + ":" + seconds;
    }
    else if (hours > 0) {
        timeSpan = hours + ":" + mins + ":" + seconds;
    }
    else {
        timeSpan = mins + ":" + seconds;
    }

    return timeSpan;
};