using System;
using MedicalClinic.App_Start;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MedicalClinicExceptions;
using MedicalClinicHandler.Handlers;
using Ninject;

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

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();

            HandleDbExceptions(ex.InnerException as McDatabaseBaseException);
            HandleHttpExceptions(ex);
            HandleProgramExceptions(ex.InnerException as McProgramException);

            Response.Redirect("/Error/Error");
        }

        private void HandleDbExceptions(McBaseException mcExcption)
        {
            if (mcExcption == null) return;
            
            switch (mcExcption.ExceptionType)
            {
                case ExceptionType.MinorError:
                    Response.Redirect("/Error/MinorDbError");
                    break;
                case ExceptionType.CriticalError:
                    Response.Redirect("/Error/CriticalDbError");
                    break;
            }
        }

        private void HandleHttpExceptions(Exception ex)
        {
            var httpException = ex as HttpException;
            if (httpException == null) return;

            if (httpException.GetHttpCode() == 404)
            {
                Response.Redirect("/Error/NotFound");
            }
        }

        private void HandleProgramExceptions(McBaseException ex)
        {
            if (ex == null) return;
            Response.Redirect("/Error/Error");
        }

        private void RegisterDependencyResolver()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IUserHandler>().To<UserHandler>();
            kernel.Bind<IRoleHandler>().To<RoleHadler>();
            kernel.Bind<IPatientHandler>().To<PatientHandler>();
            kernel.Bind<IAppointmentHandler>().To<AppointmentHandler>();
            kernel.Bind<ISpecializationHadler>().To<SpecializationHadler>();
            kernel.Bind<IDiagnosticHadler>().To<DiagnosticHadler>();
            kernel.Bind<IMedicalResultHandler>().To<MedicalResultHandler>();

            DependencyResolver.SetResolver(new MedicalClinicDependencyResolver(kernel));
        }
    }
}