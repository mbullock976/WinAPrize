using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAPrize.Platform.DependencyResolver.Modules
{
    using System.Security;

    using Ninject.Modules;
    using Ninject.Web.Common;

    using WinAPrize.API.Interfaces;
    using WinAPrize.Platform.Implementation;
    using WinAPrize.Platform.Implementation.DataLayer;
    using WinAPrize.Platform.Implementation.DataLayer.Factories;
    using WinAPrize.Platform.Implementation.Managers;
    using WinAPrize.Platform.Interfaces.DataLayer;
    using WinAPrize.Platform.Interfaces.DataLayer.Factories;

    public class PublicPlatformNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepositoryFactory>().To<RepositoryFactory>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IMarketingManager>().To<MarketingManager>().InRequestScope();
            Bind<ICustomerManager>().To<CustomerManager>().InRequestScope();            
            Bind<IApplicationManager>().To<ApplicationManager>().InRequestScope();
        }
    }
}
