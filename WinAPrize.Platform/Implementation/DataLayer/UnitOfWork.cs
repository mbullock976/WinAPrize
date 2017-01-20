namespace WinAPrize.Platform.Implementation.DataLayer
{
    using System;

    using WinAPrize.Models;
    using WinAPrize.Platform.Interfaces.DataLayer;
    using WinAPrize.Platform.Interfaces.DataLayer.Factories;
    using WinAPrize.Platform.Interfaces.DataLayer.Repositories;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepositoryFactory repositoryFactory;

        private readonly WinAPrizeDBContext context = new WinAPrizeDBContext();

        private bool isDisposed = false;

        private IGenericRepository<Customer> customerRepository;

        private IGenericRepository<Coupon> couponRepository;

        private IGenericRepository<MarketingStats> marketingStatsRepository;

        public UnitOfWork(IRepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;

            this.Initialise();
        }

        public IGenericRepository<T> GetRepository<T>()
            where T : class
        {
            if (typeof(Customer) == typeof(T))
            {
                return this.customerRepository as IGenericRepository<T>;
            }

            if (typeof(Coupon) == typeof(T))
            {
                return this.couponRepository as IGenericRepository<T>;
            }

            if (typeof(MarketingStats) == typeof(T))
            {
                return this.marketingStatsRepository as IGenericRepository<T>;
            }

            return null;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!this.isDisposed)
            {
                if (isDisposing)
                {
                    this.context.Dispose();
                }
            }

            this.isDisposed = true;
        }

        private void Initialise()
        {
            this.CreateRepositories();
        }

        private void CreateRepositories()
        {
            this.customerRepository = this.repositoryFactory.Create<Customer>(this.context);
            this.couponRepository = this.repositoryFactory.Create<Coupon>(this.context);
            this.marketingStatsRepository = this.repositoryFactory.Create<MarketingStats>(this.context);
        }
       
    }
}