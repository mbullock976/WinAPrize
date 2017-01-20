namespace WinAPrize.Platform.Implementation.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using WinAPrize.API.Interfaces;
    using WinAPrize.Models;

    public class ApplicationManager : IApplicationManager
    {
        private bool isDisposed = false;

        private int currentWinnersCount;

        private readonly object syncLock = new object();        

        private const int DIVIDER = 63353;

        private int totalWinnersLimit = 10;         

        public ApplicationManager(
            ICustomerManager customerManager,
            IMarketingManager marketingManager)
        {
            this.MarketingManager = marketingManager;
            this.CustomerManager = customerManager;
            this.currentWinnersCount = 0;
            this.totalWinnersLimit = 10;
        }

        public ICustomerManager CustomerManager { get; set; }

        public IMarketingManager MarketingManager { get; set; }

        public async Task<bool> IsCouponPrimeNumberAsync(string couponCode)
        {
            return await Task.Run(
                () =>
                    {
                        //convert to hex           
                        int decValue = int.Parse(couponCode, System.Globalization.NumberStyles.HexNumber);
                        var result = decValue / DIVIDER;
                        

                        var isPrime = CheckIsPrime(result);
                        if (isPrime)
                        {
                            this.currentWinnersCount = this.MarketingManager.IncrementCurrentWinningCount();
                            this.totalWinnersLimit = this.MarketingManager.GetTotalWinnersLimit();

                            if (this.currentWinnersCount > this.totalWinnersLimit)
                            {
                                return false;
                            }
                        }

                        return isPrime;
                    });            
        }        

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool isDisposing)
        {
            if (!this.isDisposed)
            {
                if (isDisposing)
                {
                    //TODO dispose
                }

                this.isDisposed = true;
            }
        }

        private static bool CheckIsPrime(int candidate)
        {
            // Test whether the parameter is a prime number.
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
           
            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }
            return candidate != 1;
        }       
    }
}