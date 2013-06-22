'use strict';

/* App Module */

angular.module('issues', ['issuesServices']);

app.filter('startFrom', function() {
    return function(input, start) {
        start = +start; //parse to int
        return input.slice(start);
    }
});