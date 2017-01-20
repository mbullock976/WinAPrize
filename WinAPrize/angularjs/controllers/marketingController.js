var marketingController =
    function ($scope,
        $q,
        $window,
        $state,
        dataService) {

        $scope.title = "Marketing Page!";
        $scope.dataService = dataService;
        $scope.lastSavedDateTime = "";
        $scope.errorMessage = "";

        var init_Model = function () {
            $scope.model = {
                totalWinnersLimit: 0
            }

        }

        init_Model();

        //Save reset current winners count && set total winners Limit
        dataService.getTotalWinnersLimit()
            .then(function (result) {
                    $scope.model.totalWinnersLimit = result.data;
                },
                function () {
                    console.log("error occured getting total winner limit");
                });


        $scope.save = function () {
            //if (angular.isNumber($scope.model.totalWinnersLimit)) {

                //Save reset current winners count && set total winners Limit
                dataService.setTotalWinnersLimit($scope.model.totalWinnersLimit)
                    .then(function () {
                        $scope.errorMessage = "";
                        $scope.lastSavedDateTime = "Last Updated: " + new Date().toUTCString() + $scope.model.totalWinnersLimit;
                        },
                        function() {
                            console.log("error occured setting total winner limit");
                        });
            //} else {
            //    $scope.errorMessage = "Total Winners Limit must be a number";
            //}
        }
    }

app.controller("marketingController", ["$scope", "$q", "$window",
    "$state", "dataService", marketingController]);
