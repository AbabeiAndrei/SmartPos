using System.Reflection;
using System.Web.Http;

using Autofac;
using Autofac.Integration.WebApi;

using SmartPos.DomainModel;
using SmartPos.DomainModel.Interfaces;

namespace Smartpos.Api
{
    public static class DependencyResolver
    {
        public static void Config(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(configuration);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            MapResolver(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void MapResolver(ContainerBuilder builder)
        {
            builder.Register(context => new DbContext())
                   .As<IDbContext>();
        }
    }
}