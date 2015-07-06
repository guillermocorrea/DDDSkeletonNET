using DDDSkeleton.Portal.Domain.Customer;
using DDDSkeletonNET.Infrastructure.Common.Domain;
using DDDSkeletonNET.Infrastructure.Common.UnitOfWork;
using DDDSkeletonNET.Portal.ApplicationServices.Interfaces;
using DDDSkeletonNET.Portal.Repository.Memory;
using DDDSkeletonNET.Portal.Repository.Memory.Database;
using DDDSkeletonNET.Portal.Repository.Memory.Repositories;
using DDDSkeletonNET.Portal.WebService.App_Start;
using DDDSkeletonNET.Portal.WebService.DependencyResolution;
using Microsoft.Owin;
using Owin;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(DDDSkeletonNET.Portal.WebService.Startup))]
namespace DDDSkeletonNET.Portal.WebService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            var container = SetupStructureMap();

            // sets up the mvc dependency resolver
            config.DependencyResolver = new StructureMapDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

        }

        private static IContainer SetupStructureMap()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    //        scan.TheCallingAssembly();
                    scan.AssemblyContainingType<ICustomerRepository>();
                    scan.AssemblyContainingType<CustomerRepository>();
                    scan.AssemblyContainingType<ICustomerService>();
                    scan.AssemblyContainingType<BusinessRule>();
                    scan.WithDefaultConventions();
                });
                x.For<IUnitOfWork>().Use<InMemoryUnitOfWork>();
                x.For<IObjectContextFactory>().Use<LazySingletonObjectContextFactory>();
                })
            ;
            //ObjectFactory.AssertConfigurationIsValid();
            return ObjectFactory.Container;
        }
    }
}
