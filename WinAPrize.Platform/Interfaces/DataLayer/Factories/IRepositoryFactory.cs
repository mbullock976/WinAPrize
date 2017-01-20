namespace WinAPrize.Platform.Interfaces.DataLayer.Factories
{
    using System.Data.Entity;

    using WinAPrize.Platform.Interfaces.DataLayer.Repositories;

    public interface IRepositoryFactory
    {
        IGenericRepository<T> Create<T>(DbContext context) where T : class;
    }
}