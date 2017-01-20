namespace WinAPrize.Platform.DependencyResolver.Interfaces
{
    using Ninject.Modules;

    public interface IDependencyResolver
    {
        INinjectModule[] GetModules();
    }
}
