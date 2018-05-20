using Autofac;
using McFly.Server2.Controllers;

namespace McFly.Server2
{
    public class ControllerAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProjectController>()
                .PropertiesAutowired();
        }
    }
}