var todoapp = angular.module('myModule', []);

todoapp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider
      .when('/todo', {
          templateUrl: 'views/todoPage.htm',
          controller: 'ToDoCtrl'
      })
      .when('/customer', {
          templateUrl: 'views/customers.htm',
          controller: 'customerCtrl'
         
      });
  } ]);




