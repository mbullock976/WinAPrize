/// <reference path="../scripts/jasmine.js" />
/// <reference path="../../winaprize/scripts/angular.js" />
/// <reference path="../../winaprize/scripts/angular-route.js" />
/// <reference path="../../winaprize/scripts/ui-router.js" />
/// <reference path="../../winaprize/scripts/angular-mocks.js" />
/// <reference path="../../winaprize/angularjs/modules/app.js" />
/// <reference path="../../winaprize/angularjs/services/dataservice.js" />


describe("main-module Tests->",
    function() {

        beforeEach(function () {
            module("mainModule");
        });

        //mock the backend server for http request tests
        var $httpBackendServer;

        //before each test
        beforeEach(inject(function ($injector) {

            //mock object
            // this is angular mock object that mocks back end server, $injector resolves the angular "httpBackend" js object
            $httpBackendServer = $injector.get("$httpBackend"); 
        }));

        //after each test e.g mock or cleanup
        afterEach(function () {

            //mock object
            $httpBackendServer.verifyNoOutstandingExpectation(); //cleans up http requests and expects
            $httpBackendServer.verifyNoOutstandingRequest();
        });

        //test class for dataService !!!!!!!!!
        describe("dataService->",
            function() {

                //test method
                it("can check coupon is winner", inject(function ($q, dataService) {

                    //ARRANGE
                    //expect(dataService.coupon).toEqual([]);                    

                    $httpBackendServer.expectGET("api/couponsApi/?couponCode=9825EB")
                        .respond(true);

                    //ACT
                    var result = dataService.isWinnerCoupon("9825EB");

                    //waits for all backend calls have been made successfully
                    $httpBackendServer.flush();

                    //TODO MB need to sort out the handling of promises here

                    //ASSERT
                    expect(result).toEqual(true);
                }));



            });
    });