'use strict';

/* Services */

angular.module('issuesServices', ['ngResource']).
  factory('Issues', function($resource){
    return $resource('http://hack2013.azurewebsites.net/api/users/GetIssuesForUser?user=Bob', {}, {
    query: {method:'GET', isArray:true}
  });
});
