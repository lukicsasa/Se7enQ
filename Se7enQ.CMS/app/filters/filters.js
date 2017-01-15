app.filter("correctedDateTime", function () {
    return function (date) {
        if (date) {
            return moment.utc(date).local().format("DD/MM/YYYY hh:mm A");
        }
    };
});

app.filter("correctedDate", function () {
    return function (date) {
        if (date) {
            return moment.utc(date).local().format("DD/MM/YYYY");
        }
    };
});

app.filter("removeId", function () {
    return function (fields) {
        if (fields.length) {
            return fields.splice(0, 1);
        }
    };
});

app.filter('range', function () {
    return function (input, start, end) {
        start = parseInt(start);
        end = parseInt(end);
        if (start < end)
            for (var i = start; i <= end; i++) { input.push(i); }
        else
            for (var i = start; i >= end; i--) { input.push(i); }
        return input;
    };
});

app.filter('boolToYesNo', function () {
    return function (value) {
        if (value !== null) {
            return value ? "Yes" : "No";
        }
        return "No";
    };
});

app.filter('boolToOnOff', function () {
    return function (value) {
        if (value !== null) {
            return value ? "On" : "Off";
        }
        return "Off";
    };
});

app.filter('boolToActivateDeactivate', function () {
    return function (value) {
        if (value !== null) {
            return value ? "Deactivate" : "Activate";
        }
        return "Activate";
    };
});