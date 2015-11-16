using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace ETravel.Nps.Service
{
    /// <summary>
    /// Registers all repositories for DI.
    /// </summary>
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed("ETravel.Nps.DataAccess")
                .Where(type => type.Name.EndsWith("Repository"))
                .WithService.DefaultInterfaces()
                .LifestyleTransient()
                );
        }
    }
}