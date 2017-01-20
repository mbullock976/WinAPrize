app.config(['$stateProvider', '$urlRouterProvider', '$locationProvider',
    function ($stateProvider, $urlRouterProvider, $locationProvider) {

        $urlRouterProvider.otherwise('/');

        $stateProvider
            .state('/',
            {
                url: '/',
                templateUrl: "/angularjs/views/mainView.html",
                controller: "mainController"
            })
            .state('home',
            {
                url: '/',
                templateUrl: "/angularjs/views/mainView.html",
                controller: "mainController"
            })
            .state('customer',
            {
                url: "couponCode/:couponCode",
                templateUrl: "/angularjs/views/customerView.html",
                controller: "customerController",
                parent: "home"


            })
            .state('submitted',
            {
                templateUrl: "/angularjs/views/submittedView.html"
            })
            .state('login',
            {
                url: "/login",
                templateUrl: "/angularjs/views/loginView.html",
                controller: "loginController"
            })
            .state('marketing',
            {
                url: "/marketing",
                templateUrl: "/angularjs/views/marketingView.html",
                controller: "marketingController"
    });

    }]);