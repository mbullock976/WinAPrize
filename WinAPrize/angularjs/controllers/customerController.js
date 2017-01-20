var customerController =
    function ($scope,
        $q,
        $window,
        $state,
        $stateParams,
        dataService) {

        $scope.title = "Customer Page!";
        $scope.dataService = dataService;
        $scope.countryList = ["United Kingdom", "United States"];
        $scope.townOrCityList = ["Luton", "London"];
        
        var init_newCustomerModel = function () {
            $scope.newCustomerModel = {
                couponCode: $stateParams.couponCode
            };
        }

        init_newCustomerModel();

        $scope.save = function () {

            var couponModel = {
                code: $scope.newCustomerModel.couponCode
            }

            //TODO Save to the database
            dataService.saveWinningCoupon($scope.newCustomerModel, couponModel)
                .then(function() {

                        $state.go('submitted', {}, { reload: true });
                    },
                    function() {
                        console.log("error occured saving customer to the database");
                    });

            
        };

    }

app.controller("customerController", ["$scope", "$q", "$window",
    "$state", "$stateParams", "dataService", customerController]);

