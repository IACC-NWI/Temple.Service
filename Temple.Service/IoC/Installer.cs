using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Temple.Service.Database;

namespace Temple.Service.IoC
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ITempleDbContext>().ImplementedBy<TempleDbContext>().LifestyleTransient(),
                Classes.FromThisAssembly().BasedOn<ApiController>().LifestyleTransient());
        }
    }
}
