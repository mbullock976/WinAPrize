var loginController =
    function ($scope,
        $q,
        $window,
        $state,
        dataService) {

        $scope.title = "login Page!";
        $scope.dataService = dataService;

        $scope.accessDenied = "";
        $scope.passkey = "1234";

        var init_Model = function () {
            $scope.model = {
                enteredPasskey: ""
            }

        }

        init_Model();

        $scope.save = function () {
            $scope.accessDenied = "";
            if ($scope.passkey === $scope.model.enteredPasskey && $scope.model.enteredPasskey.length > 0) {

                $state.go('marketing', {}, { reload: false });
            } else {
                $scope.accessDenied = "Access Denied";
            }
        }

    }

app.controller("loginController", ["$scope", "$q", "$window",
    "$state", "dataService", loginController]);



