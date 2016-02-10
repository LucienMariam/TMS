using System.Data.Entity;
using Ninject.Web.Common;
using Ninject;
using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using ORM;

namespace CustomNinjectDependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            Database.SetInitializer<EntityModel>(new InitializeEntityModel());
            kernel.Bind<DbContext>().To<EntityModel>().InRequestScope();

            kernel.Bind<IKeyRepository<TaskDAL>>().To<KeyRepository<Task, TaskDAL, TaskMapperDAL>>();
            kernel.Bind<IKeyRepository<UserDAL>>().To<KeyRepository<User, UserDAL, UserMapperDAL>>();
            kernel.Bind<IKeyRepository<RoleDAL>>().To<KeyRepository<Role, RoleDAL, RoleMapperDAL>>();
            kernel.Bind<ITaskUserRepository>().To<TaskUserRepository>();
            kernel.Bind<IRoleUserRepository>().To<RoleUserRepository>();

            kernel.Bind<IKeyService<TaskEntity>>().To<KeyService<TaskDAL, TaskEntity, IKeyRepository<TaskDAL>, TaskMapper>>();
            kernel.Bind<IKeyService<UserEntity>>().To<KeyService<UserDAL, UserEntity, IKeyRepository<UserDAL>, UserMapper>>();
            kernel.Bind<IKeyService<RoleEntity>>().To<KeyService<RoleDAL, RoleEntity, IKeyRepository<RoleDAL>, RoleMapper>>();
            kernel.Bind<ITaskUserService>().To<TaskUserService>();
            kernel.Bind<IRoleUserService>().To<RoleUserService>();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }

        public static void Reconfiguration(this IKernel kernel)
        {
            ((EntityModel)kernel.GetService(typeof(DbContext))).Dispose();            
        }
    }

}
