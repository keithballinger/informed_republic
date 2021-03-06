function IssuesListCtrl($scope, $http) {
  $http({method: 'GET', url: 'http://hack2013.azurewebsites.net/api/users/GetIssuesForUser?user=Bob', headers: {'Accept': 'application/json'}}).
      success(function(data, status) {
        $.each(data, function() {
          if (this.Hotness > 70) {
            this.ProgressStyle = "progress-danger";
          } else if (this.Hotness > 30){
            this.ProgressStyle = "progress-warning";
          } else {
            this.ProgressStyle = "progress-success";
          }
        });
        $scope.issues = data;
        console.log($scope.issues);
      }).
      error(function(data, status) {
        console.log("Request failed");
  });
}
/*
[
  {
    "UrlImage":"http://ts1.mm.bing.net/th?id=H.4872010103062804&pid=1.7&w=221&h=164&c=7&rs=1",
    "Link":"http://news.cnet.com/8301-1009_3-57588253-83/what-is-the-nsas-prism-program-faq/",
    "Text":"Learn about PRISM"
  },
  {
    "UrlImage":"http://ts1.mm.bing.net/th?id=H.4679732980810272&pid=1.7&w=229&h=164&c=7&rs=1",
    "Link":"http://www.bbc.co.uk/news/magazine-22853432",
    "Text":"BBC on Prism"
  }
]
*/
function AlertsListCtrl($scope, $http) {
  $http({method: 'GET', url: ' http://hack2013.azurewebsites.net/api/users/GetAlerts?user=Bob', headers: {'Accept': 'application/json'}}).
      success(function(data, status) {
        $scope.alerts = data;
      }).
      error(function(data, status) {
        console.log("Request failed");
  });
}

// [
// {
// "UrlImage":"http://ts1.mm.bing.net/th?id=HB.210774609816&pid=1.7&w=242&h=164&c=7&rs=1",
// "Link":null,
// "Text":"Sign petition to save Snowden"
// }]
function ActionsListCtrl($scope, $http) {

  $http({method: 'GET', url: 'http://hack2013.azurewebsites.net/api/users/GetAction?user=Bob', headers: {'Accept': 'application/json'}}).
      success(function(data, status) {
        $scope.actions = data;
        $scope.action = data[0];
        $scope.currentPage = 0;
        $scope.pageSize = 1;
        $scope.numberOfPages=function(){
          return Math.ceil($scope.actions.length/$scope.pageSize);                
        }
      }).
      error(function(data, status) {
        console.log("Request failed");
  });
}

function PlayersListCtrl($scope, $http) {
  $http({method: 'GET', url: 'http://hack2013.azurewebsites.net/api/users/GetPlayers?user=Bob', headers: {'Accept': 'application/json'}}).
      success(function(data, status) {
        $scope.players = data;
      }).
      error(function(data, status) {
        console.log("Request failed");
  });
}