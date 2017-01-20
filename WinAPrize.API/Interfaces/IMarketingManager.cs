namespace WinAPrize.API.Interfaces
{
    using System;

    public interface IMarketingManager : IManager, IDisposable
    {
        int GetTotalWinnersLimit();

        void SetTotalWinnersLimit(int newTotalWinnersLimit);

        int IncrementCurrentWinningCount();
    }
}