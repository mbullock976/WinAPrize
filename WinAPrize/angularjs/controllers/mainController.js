var mainController =
    function($scope,
        $q,
        $window,
        $state,
        dataService) {

        $scope.title = "Main Page!";
        $scope.dataService = dataService;
        $scope.couponCodePattern = "^[A-F0-6]{6}$";
        $scope.pleaseWaitMsg = "";

        var init_newEntryModel = function () {
            $scope.newEntryModel = {
                couponCode: ""
            };
        }

        init_newEntryModel();


        var retry = function () {
            $scope.pleaseWaitMsg = "";
            $scope.retryMessage =
                        "Unfortunately you were unsuccessful this time, but do come back and try again when you receive your new loyalty coupon..";

            //reinitialise new entry model for resubmission
            init_newEntryModel();
        }

        // save function - regex Validation for coupon code - True go to customer details page, False show retry message
        $scope.save = function () {
            $scope
                .retryMessage = "";           
            //alert("hey");
                var match = $scope.newEntryModel.couponCode.match($scope.couponCodePattern);
                if (match) {

                    $scope.pleaseWaitMsg = "Please wait...";
                    dataService.isWinnerCoupon($scope.newEntryModel.couponCode)
                        .then(function (result) {
                            
                            var isPrime = result.data;
                            if (isPrime) {
                                    $state.go('customer', { couponCode: $scope.newEntryModel.couponCode }, { reload: false });
                                } else {
                                    retry();
                                }

                        }, function () {
                            alert("error occured");
                        });

                } else {

                    retry();
                }            
        };

    }

app.controller("mainController", ["$scope", "$q", "$window",
    "$state", "dataService", mainController]);

