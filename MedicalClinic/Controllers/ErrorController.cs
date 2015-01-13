using System.Web.Mvc;

namespace MedicalClinic.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult MinorDbError()
        {
            return View();
        }

        public ActionResult CriticalDbError()
        {
            return View();
        }
    }
}
