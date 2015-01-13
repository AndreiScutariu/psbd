using MedicalClinic.Models.Admin;
using MedicalClinic.Models.Medic;
using MedicalClinic.Utils;
using System.Linq;
using System.Web.Mvc;

namespace MedicalClinic.Controllers
{

    public class AdminController : BaseController
    {
        private readonly AdminModelBuilder _adminModelBuilder;

        public AdminController(AdminModelBuilder adminModelBuilder, UserModelBuilder userModelBuilder)
            : base(userModelBuilder)
        {
            _adminModelBuilder = adminModelBuilder;
        }

        public ActionResult Home()
        {
            var userId = Session[SessionKeys.UserId];
            if (userId == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.Notification = UserModel.Notification;
            return View(_adminModelBuilder.GetAllUsers());
        }

        public ActionResult Notification()
        {
            var userId = Session[SessionKeys.UserId];
            if (userId == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View(_adminModelBuilder.GetAllUsersWithNotifications());
        }

        #region CrudOperatios On Users
        public ActionResult AddUser()
        {
            return View("AddUser");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddUser", userModel);
            }

            _adminModelBuilder.SaveUser(userModel);
            return RedirectToAction("Home");
        }

        public ActionResult EditUser(int userId)
        {
            var userModel = _adminModelBuilder.GetUserById(userId);
            return View("AddUser", userModel);
        }

        public ActionResult Delete(int userId)
        {
            _adminModelBuilder.DeleteById(userId);
            return RedirectToAction("Home");
        }
        #endregion
        
        [HttpPost]
        public JsonResult GetAllRoles()
        {
            var allItems = _adminModelBuilder.GetAllRoles();
            return Json(new { Items = allItems.Select(r => r.RoleName) });
        }

        public JsonResult AddNewSpecializationForUser(int userId, int specializationId)
        {
            _adminModelBuilder.ConfirmSpecializationForUser(userId, specializationId);
            return Json("S-a confirmat.", JsonRequestBehavior.AllowGet);
        }

        public FileResult DownloadHelpFile()
        {
            var sDocument = Server.MapPath("/Content/admin-help.chm");
            return File(sDocument, "application/vnd.ms-htmlhelp", "MedicalClinicHelp.chm");
        }
    }
}