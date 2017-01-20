namespace WinAPrize.API.UnitTests.Managers
{
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using NSubstitute;

    using WinAPrize.API.Interfaces;
    using WinAPrize.Platform.Implementation.Managers;

    [TestClass]
    public class ApplicationManagerShould : TestClassBase
    {
        private const string LOSING_COUPON = "AA01FD";
        private const string WINNING_COUPON = "9825EB";

        private IApplicationManager applicationManager;        

        [TestInitialize]
        public void Setup()
        {           
            var customerManager = Substitute.For<ICustomerManager>();
            var marketingManager = Substitute.For<IMarketingManager>();

            this.applicationManager = new ApplicationManager(customerManager, marketingManager);
        }       

        [TestMethod]
        public async Task Return_True_If_Coupon_Is_PrimeNumber_Async()
        {
            //Act
            var result = await this.applicationManager.IsCouponPrimeNumberAsync(WINNING_COUPON);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task Return_False_If_Coupon_Is_Not_PrimeNumber_Async()
        {
            var result = await this.applicationManager.IsCouponPrimeNumberAsync(LOSING_COUPON);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task Increment_Winning_Counter_If_Coupon_Is_Prime_Number_Async()
        {
            await this.applicationManager.IsCouponPrimeNumberAsync(WINNING_COUPON);

            this.applicationManager
                .MarketingManager
                .Received(1).IncrementCurrentWinningCount();
        }

        [TestMethod]
        public async Task Not_Increment_Winning_Counter_If_Coupon_Is_Not_Prime_Number_Async()
        {
            await this.applicationManager.IsCouponPrimeNumberAsync(LOSING_COUPON);

            this.applicationManager
                .MarketingManager
                .DidNotReceive().IncrementCurrentWinningCount();
        }


        [TestCleanup]
        public void Cleanup()
        {
            this.applicationManager.Dispose();   
        }
    }
}
