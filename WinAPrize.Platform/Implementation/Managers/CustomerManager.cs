namespace WinAPrize.Platform.Implementation.Managers
{
    using WinAPrize.API.Interfaces;
    using WinAPrize.Platform.Interfaces.DataLayer;

    public class CustomerManager : DataManager, ICustomerManager
    {
        public CustomerManager(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}