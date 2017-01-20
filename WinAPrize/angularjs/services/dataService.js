app.factory("dataService",
[
    "$http", "$q",
    function($http, $q) {


        var _isWinningCoupon = function(code) {

            //TODO work out id the code is a prime number
            /*
            a). convert code into hexidecimal number
            b). divide it by 65,353.00
            c). if result = prime number = then this is winning number.
            */

            var _deferred = $q.defer();

            $http.get(
                'api/couponsApi/?couponCode=' + code)
                .then(function(result) {
                        _deferred.resolve(result);
                    },
                    function() {
                        _deferred.reject();
                    });
            

            return _deferred.promise;
        };

        var _saveWinningCoupon = function (customerModel, couponModel) {

            var _deferred = $q.defer();

            //save customer
            $http.post(
                    'api/customersApi/',
                    JSON.stringify(customerModel),
                    {
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }
                ).then(function (result) {

                    couponModel.customerId = result.data;

                    //save coupon
                    $http.post(
                        'api/couponsApi/',
                        JSON.stringify(couponModel),
                        {
                            headers: {
                                'Content-Type': 'application/json'
                            }
                        })
                        .then(function(result) {
                            _deferred.resolve(result);
                        }, function () {
                            _deferred.reject();
                        });


                _deferred.resolve(result);
            }, function () {
                _deferred.reject();
            });

            return _deferred.promise;
        };

        var _setTotalWinnersLimit = function(totalLimit) {

            var _deferred = $q.defer();

            //save customer
            $http.post(
                    'api/marketingApi/?totalLimit=' + totalLimit
                    
                )
                .then(function (result) {
                    _deferred.resolve(result);
                }, function () {
                    _deferred.reject();
                });

            return _deferred.promise;
        };


        var _getTotalWinnersLimit = function () {

            var _deferred = $q.defer();

            $http.get(
                    'api/marketingApi/')
                .then(function (result) {
                    _deferred.resolve(result);
                }, function () {
                    _deferred.reject();
                });

            return _deferred.promise;
        };

        return {
            saveWinningCoupon: _saveWinningCoupon,
            isWinnerCoupon: _isWinningCoupon,
            setTotalWinnersLimit: _setTotalWinnersLimit,
            getTotalWinnersLimit: _getTotalWinnersLimit
    };
    }
]);