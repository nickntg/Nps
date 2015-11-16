using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ETravel.Nps.Service.Controllers;

namespace ETravel.Nps.Service
{
    /// <summary>
    /// Registers all controllers for DI.
    /// </summary>
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .Where(type => type == typeof(NpsController))
                .WithService.DefaultInterfaces()
                .LifestyleTransient()
                );
        }
    }
}