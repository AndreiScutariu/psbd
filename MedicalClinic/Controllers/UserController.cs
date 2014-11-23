using System.Web.Mvc;

namespace MedicalClinic.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Login()
        {
            return View();
        }

        public void Logout()
        {
        }
    }
}
