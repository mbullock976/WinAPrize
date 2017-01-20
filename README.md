# WinAPrize
Customer Loyalty Prize Giveaway

Solution Composition:

(* Please refer to WinAPrize_Architecture.png image found on the root of this repository *)

- ASP.NET
- RestFul Web APIs
- Code-First Entity Framework to SQL DB
- DB --> 3 DB Entities {Customer, Coupon, MarketingStats}
- Repository and Unit Of work design patterns for CRUD operations.
- Thin Web Client --> WebAPIs call down to Business Logic implemenation contained in separate WinAPrize.Platform assembly
- Resuable business logic via WinAPrize.API assembly
- Ninject and Ninject MVC used for Dependency Injection to resolve API interfaces into Restful WebAPIs
- Reusable Ninject Dependency Resolver used to create a TestClass base for future intergation testing
- NSubsitute mocking framwork used for WinAPrize.API unit testing
- JasmineJS used for client side scripting testing
- AngularJS used for data binding, custom data retrieval service to webAPi HTTPGET & HTTPPOSTS, $http service for ajax queries returning promises.
- Ui-Router routing to views.

Website Usage Instructions:
- MainPage - enter coupon
- Server side async operation to check for prime number condition
- if true then switch to customer entry page
- else throws up retry message
- customer page submit writes customer and associated codes to DB
- Marketing link in the nav bar presents user with Pass Key (this is 1234). This will take marketing staff to a page that they can change total winning limit
- HttpPosts check if customer already exists in DB.


Useful Locations:
- WinAPrize\angularJs contain js scripts - modules, config, services, controllers, views.
- WinAPrize\Views\Shared\_Layout.cshtml - data-ng-app initialised, and nav bar that links to Marketing pages, and angularjs scripts
- WinAPrize\Views\Home\Index.cshtml - contains the refs the \angularJs\ scripts
- WinAPrize\WebConfig.cs - EF DB connection string setting.
- WinAPrize\Controllers\WebApi - Restful Web Api controllers
- WinAPrize.Platform\Implementation\DataLayer - section for EF DBContext
- WinAPrize.Platform\Migartions - section for EF Code first Migrations
- WinAPrize.Platform\Models - section for business models 
- WinAPrizeAPI.UnitTests - server side unit tests
- WinAPrize.Tests - client side unit test
