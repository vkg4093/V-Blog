using System.Data.Entity;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(V.Blog.Test.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(V.Blog.Test.App_Start.NinjectWebCommon), "Stop")]

namespace V.Blog.Test.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using V.Blog.Data;

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
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                //kernel.Bind<DbContext>().ToConstructor(T => new BlogEntities()).InRequestScope(); 

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DbContext>().ToConstructor(T => new BlogEntities()).InRequestScope();
            kernel.Bind<V.Blog.Core.Data.Interfaces.IUnitOfWork>().To<V.Blog.Core.Data.Implementation.POCOUnitOfWork>();
            kernel.Bind(typeof(V.Blog.Core.Data.Interfaces.IRepository<>)).To(typeof(V.Blog.Core.Data.Implementation.POCORepository<>));
            kernel.Bind<V.Blog.Service.IUserService>().To<V.Blog.Service.UserService>();
        }        
    }
}
