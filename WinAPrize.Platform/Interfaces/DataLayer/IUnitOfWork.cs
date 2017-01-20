namespace WinAPrize.Platform.Interfaces.DataLayer
{
    using System;

    using WinAPrize.Platform.Interfaces.DataLayer.Repositories;

    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class;

        void Save();        
    }
}