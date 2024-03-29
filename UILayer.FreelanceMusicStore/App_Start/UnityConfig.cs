using BLL.FreelanceMusicStore.Interfaces;
using BLL.FreelanceMusicStore.Services;
using DAL.FreelanceMusicStore;
using DAL.FreelanceMusicStore.Interfaces;
using System;
using System.Web.Mvc;
using TestProject.Mapper;
using Unity;

namespace TestProject {
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() => {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container) {
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterInstance(AutoMapperConfiguration.mapper);
            container.RegisterType<IApplicationUserService, ApplicationUserService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IMusicInstrumentService, MusicInstrumentService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IClientService, ClientService>();
            container.RegisterType<IMusicianService, MusicianService>();
            container.RegisterType<IFileStorageService, FileStorageService>();
            container.RegisterType<ICommentService, CommentService>();
            DependencyResolver.SetResolver(new Unity.AspNet.Mvc.UnityDependencyResolver(container));
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
        }
    }
}