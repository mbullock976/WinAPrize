[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WinAPrize.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WinAPrize.App_Start.NinjectWebCommon), "Stop")]

namespace WinAPrize.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Modules;
    using Ninject.Web.Common;

    using WinAPrize.Platform.DependencyResolver.Implementation;
    using WinAPrize.Platform.DependencyResolver.Modules;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            //Share IOC Container with both MVC and WEB API            
            NinjectModule registrations = new PublicPlatformNinjectModule();
            var kernel = new StandardKernel(registrations);

            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            //MVC
            System.Web.Mvc.IDependencyResolver ninjectResolver = new PublicDependencyResolver(kernel);
            System.Web.Mvc.DependencyResolver.SetResolver(ninjectResolver); // MVC

            //WEB API
            GlobalConfiguration.Configuration.DependencyResolver = (System.Web.Http.Dependencies.IDependencyResolver)ninjectResolver;

            return kernel;
        }
    }
}
