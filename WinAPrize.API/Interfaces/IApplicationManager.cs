namespace WinAPrize.API.Interfaces
{
    using System;
    using System.Threading.Tasks;

    public interface IApplicationManager : IDisposable
    {     
        ICustomerManager CustomerManager { get; set; }

        IMarketingManager MarketingManager { get; set; }        

        Task<bool> IsCouponPrimeNumberAsync(string couponCode);
    }
}