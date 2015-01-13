using System.Web.Mvc;
using MedicalClinic.Models.Medic;
using MedicalClinic.Utils;

namespace MedicalClinic.Controllers
{
    public class BaseController : Controller
    {
        protected int UserId;
        protected string FullName;
        protected UserModel UserModel;
        private readonly UserModelBuilder _userModelBuilder;

        public BaseController(UserModelBuilder userModelBuilder)
        {
            _userModelBuilder = userModelBuilder;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userIdFromSession = Session[SessionKeys.UserId];
            if (userIdFromSession == null)
            {
                RedirectToAction("Login", "Home");
            }
            else
            {
                UserId = (int)userIdFromSession;
                UserModel = _userModelBuilder.GetUserById(UserId);
                FullName = UserModel.FullName;
                ViewBag.FullName = FullName;
            }
        }
    }
}