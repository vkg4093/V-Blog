todoapp.controller('customerCtrl', function ($scope, customersService) {

    init();

    function init() {
        $scope.customers = customersService.getCustomers();
    }

});

