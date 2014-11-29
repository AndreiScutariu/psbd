using MedicalClinic.App_Start;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MedicalClinicHandler.Handlers;
using Ninject;
using DependencyResolver = MedicalClinic.App_Start.DependencyResolver;

namespace MedicalClinic
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            RegisterDependencyResolver();
        }

        private void RegisterDependencyResolver()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IUserHandler>().To<UserHandler>();
            kernel.Bind<IRoleHandler>().To<RoleHadler>();
            System.Web.Mvc.DependencyResolver.SetResolver(new DependencyResolver(kernel));
        }
    }
}