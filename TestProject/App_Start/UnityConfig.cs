using System;
using DAL.FreelanceMusicStore;
using DAL.FreelanceMusicStore.Interfaces;
using Unity.AspNet;
using Unity;
using System.Web.Mvc;
using Unity.Lifetime;
using Domain.FreelanceMusicStore.Entities;
using DAL.FreelanceMusicStore.Repositories;
using Microsoft.AspNet.Identity;
using DAL.FreelanceMusicStore.Identity;
using Domain.FreelanceMusicStore.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Unity.Injection;
using BLL.FreelanceMusicStore.Interfaces;
using BLL.FreelanceMusicStore.Services;

namespace TestProject
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
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
        public static void RegisterTypes(IUnityContainer container)
        {
/*            container.RegisterType<EF6DBContext>(new PerThreadLifetimeManager());
            container.RegisterType<IRepository<Client>, ClientRepository>();
            container.RegisterType<IRepository<Musician>, MusicianRepository>();
            container.RegisterType<IRepository<MusicInstrument>, MusicInstrumentRepository>();
            container.RegisterType<IRepository<Order>, OrderRepository>();*/
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IApplicationUserService, ApplicationUserService>();
/*            container.RegisterType<CustomUserClaim>();
            container.RegisterType<CustomUserLogin>();
            container.RegisterType<CustomUserRole>();*/
/*            container.RegisterType<IdentityUser<Guid, CustomUserLogin, CustomUserRole, CustomUserClaim>>();
            container.RegisterType<ApplicationUser>();*/
/*            container.RegisterType<IUserStore<ApplicationUser, Guid>, UserStore<ApplicationUser, CustomRole, Guid, CustomUserLogin, CustomUserRole, CustomUserClaim>>();
            container.RegisterType<ApplicationUserManager>();*/

            DependencyResolver.SetResolver(new Unity.AspNet.Mvc.UnityDependencyResolver(container));
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
        }
    }
}