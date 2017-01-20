namespace WinAPrize.Platform.Implementation.DataLayer
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using WinAPrize.Models;

    public class WinAPrizeDBContext : DbContext
    {
        public WinAPrizeDBContext()
             : base("WinAPrizeDBContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<MarketingStats> MarketingStats { get; set; }        
    }
}
