using System;
using System.Threading;
using System.Web;
using System.Web.Http;
using Assistance.APIs;
using BL.BussinessMangers.Classes;
using BL.BussinessMangers.Interfaces;
using DAL.DBContext;
using DAL.Repository.Classes;
using DAL.UnitOfWork;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.WebApi;
using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof (NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof (NinjectWebCommon), "Stop")]

namespace Assistance.APIs
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        ///     Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof (OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof (NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
            // for all Lazy's
  
        }

        /// <summary>
        ///     Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        ///     Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        ///     Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
     
            kernel.Bind<IDbContext>().To<DbGooContext>().InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork<DbGooContext>>().InRequestScope();
            kernel.Bind<IDriverDeviceBussinessManger>().To<DriverDeviceBussinessManger<DriverDeviceRepository>>();
            kernel.Bind<IPassengerDeviceBussinessManger>().To<PassengerDeviceBussinessManger<PassengerDeviceRepository>>();
        }
    }
}
