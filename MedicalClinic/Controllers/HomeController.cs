using System.Web.Security;
using MedicalClinic.Models.Medic;
using MedicalClinic.Utils;
using System.Web.Mvc;

namespace MedicalClinic.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserModelBuilder _userModelBuilder;

        public HomeController(UserModelBuilder userModelBuilder)
        {
            Roles.ApplicationName = "Medical Clinic";
            _userModelBuilder = userModelBuilder;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(UserLoginModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userModelBuilder.GetByEmailAndPassword(userModel.Email, userModel.Password);
                if (user == null)
                {
                    ModelState.AddModelError("Eroare la logare", "Adresa de email sau parola incorecte.");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(userModel.Email, userModel.RememberMe);
                    Session[SessionKeys.UserId] = user.Id;
                    return GoToDefaultPage();
                }
            }

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public void Logout()
        {
            Session[SessionKeys.UserId] = null;
            Roles.DeleteCookie();
            FormsAuthentication.RedirectToLoginPage();
        }

        public ActionResult GoToDefaultPage()
        {
            var myRoles = Roles.GetRolesForUser();
            var userRole = myRoles.Length > 0 ? myRoles[0] : "";

            switch (userRole)
            {
                case "Administrator":
                    return RedirectToAction("Home", "Admin");

                case "Medic":
                    return RedirectToAction("Home", "User");

                case "Asistent":
                    return RedirectToAction("Home", "User");

                default:
                    return RedirectToAction("Login", "Home");
            }
        }
    }
}
