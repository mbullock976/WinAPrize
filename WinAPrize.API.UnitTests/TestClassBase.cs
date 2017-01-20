namespace WinAPrize.API.UnitTests
{
    using System.Web.Mvc;

    using Ninject;
    using Ninject.Modules;

    using WinAPrize.Platform.DependencyResolver.Implementation;
    using WinAPrize.Platform.DependencyResolver.Modules;

    public class TestClassBase
    {
        private readonly StandardKernel kernel;

        public TestClassBase()
        {
            NinjectModule registrations = new PublicPlatformNinjectModule();
            this.kernel = new StandardKernel(registrations);
            IDependencyResolver ninjectResolver = new PublicDependencyResolver(this.kernel);

            System.Web.Mvc.DependencyResolver.SetResolver(ninjectResolver); // MVC
            //GlobalConfiguration.Configuration.DependencyResolver = (System.Web.Http.Dependencies.IDependencyResolver)ninjectResolver; // Web API           
        }

        // Only use this when you want a real instance from IOC container
        // use this for integration testing
        public T ResolveInstance<T>()
        {
            return this.kernel.Get<T>();
        }
    }
}