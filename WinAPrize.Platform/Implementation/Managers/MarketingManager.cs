namespace WinAPrize.Platform.Implementation.Managers
{
    using System.Linq;

    using WinAPrize.API.Interfaces;
    using WinAPrize.Models;
    using WinAPrize.Platform.Interfaces.DataLayer;

    public class MarketingManager : DataManager, IMarketingManager
    {
        private int totalWinnersLimit;

        public MarketingManager(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public int GetTotalWinnersLimit()
        {
            var statistics = this.Get<MarketingStats>().FirstOrDefault();
            if (statistics == null)
            {
                this.totalWinnersLimit = 10;
            }

            this.totalWinnersLimit = statistics.TotalWinningLimitCount;

            return this.totalWinnersLimit;
        }

        public void SetTotalWinnersLimit(int newTotalWinnersLimit)
        {
            var statistics = this.Get<MarketingStats>().FirstOrDefault();
            if (statistics == null)
            {
                this.Add(new MarketingStats
                {
                    CurrentWinnersCount = 0,
                    TotalWinningLimitCount = newTotalWinnersLimit
                });
                this.Save();
                return;
            }

            statistics.CurrentWinnersCount = 0; //reset everytime we change limit
            statistics.TotalWinningLimitCount = newTotalWinnersLimit;
            this.Save();
        }

        public int IncrementCurrentWinningCount()
        {
            var statistics = this.Get<MarketingStats>().FirstOrDefault();
            if (statistics == null)
            {
                this.Add(new MarketingStats
                {
                    CurrentWinnersCount = 1,
                    TotalWinningLimitCount = 10
                });
                this.Save();
                return 1;
            }

            statistics.CurrentWinnersCount = statistics.CurrentWinnersCount++;
            this.Save();

            return statistics.CurrentWinnersCount;
        }
    }
}