todoapp.controller('ToDoCtrl', function ($scope) {
    $scope.todotext = "";
    $scope.todo = model;
    $scope.message = 'This is Add new order screen';

    $scope.incompleteCount = function () {
        var count = 0;
        angular.forEach($scope.todo.items, function (item) {
            if (!item.done) { count++ }
        });
        return count;
    }

    $scope.warningLevel = function () {
        return $scope.incompleteCount() < 3 ? "label-success" : "label-warning";
    }

    $scope.addTodo = function (todotext) {
        if ($scope.todotext != "") {
            $scope.todo.items.push({ action: todotext, done: false });
        }

    }
    $scope.resetInput = function () {
        $scope.todotext = "";
    }

});

var model = {
    user: "Vikram",
    items: [{ action: "Buy Flowers", done: false },
            { action: "Get Shoes", done: false },
            { action: "Collect Tickets", done: true },
            { action: "Call Joe", done: false}]
};