using Ninject.Modules;
using V.Blog.Data;
using System.Data.Entity;
using Ninject.Web.Common;
using V.Blog.Services.Implementations;
using V.Blog.Data.POCO;


namespace V.Blog.Test.Framework
{
    public class MVCModule:NinjectModule
    {
        public override void Load()
        {

            Bind<V.Blog.Core.Data.Interfaces.IUnitOfWork>().To<V.Blog.Core.Data.Implementation.POCOUnitOfWork>();
            Bind(typeof(V.Blog.Core.Data.Interfaces.IRepository<>)).To(typeof(V.Blog.Core.Data.Implementation.POCORepository<>));

            Bind<DbContext>().ToConstructor(T => new BlogEntities()).InRequestScope();

            Bind<V.Blog.Service.Interfaces.IUserService>().To<V.Blog.Service.Implementations.UserService>();
                    
        }
    }
}
