using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IdentityManager;
using IdentityManager.Configuration;
using IdMgrAspnetIdentity.IdentityConfig;
using Owin;

namespace IdMgrAspnetIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AppStart();
            ConfigureAuth(app);
            app.Map("/idm", idm =>
            {
                var factory = new IdentityManagerServiceFactory();
                factory.IdentityManagerService = 
                new Registration<IIdentityManagerService, 
                ApplicationIdentityManagerService>();

                factory.Register(new Registration<ApplicationUserManager>());
                factory.Register(new Registration<ApplicationUserStore>());
                factory.Register(new Registration<ApplicationRoleManager>());
                factory.Register(new Registration<ApplicationRoleStore>());
                //factory.Register(new Registration<ApplicationDbContext>(resolver => new ApplicationDbContext("foo")));
                factory.Register(new Registration<ApplicationDbContext>());

                idm.UseIdentityManager(new IdentityManagerOptions
                {
                    Factory = factory
                });
            });
        }

        private void AppStart()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}