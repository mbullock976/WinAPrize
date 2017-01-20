namespace WinAPrize.Platform.Implementation.DataLayer.Factories
{
    using System.Data.Entity;

    using WinAPrize.Models;
    using WinAPrize.Platform.Implementation.DataLayer.Repositories;
    using WinAPrize.Platform.Interfaces.DataLayer.Factories;
    using WinAPrize.Platform.Interfaces.DataLayer.Repositories;

    public class RepositoryFactory : IRepositoryFactory
    {
        public IGenericRepository<T> Create<T>(DbContext context) where T : class
        {
            if (typeof(Customer) == typeof(T))
            {
                return new GenericRepository<T>(context);
            }

            if (typeof(Coupon) == typeof(T))
            {
                return new GenericRepository<T>(context);
            }

            if (typeof(MarketingStats) == typeof(T))
            {
                return new GenericRepository<T>(context);
            }

            return null;
        }
    }
}