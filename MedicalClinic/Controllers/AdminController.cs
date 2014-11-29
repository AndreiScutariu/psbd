using MedicalClinic.Models.User;
using MedicalClinic.Utils.ModelDtoMapper;
using MedicalClinicHandler.Handlers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MedicalClinic.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserHandler _userHandler;
        private readonly IRoleHandler _roleHandler;

        public AdminController(IUserHandler userHandler, IRoleHandler roleHandler)
        {
            _userHandler = userHandler;
            _roleHandler = roleHandler;
        }

        public ActionResult Index()
        {
            var modelList = new List<UserModel>();
            var currentIdx = 0;
            foreach (var model in _userHandler.GetAllUsers().Select(UserMapper.GetModel))
            {
                model.CurrentIndex = ++currentIdx;
                modelList.Add(model);
            }
            return View(modelList);
        }

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

            _userHandler.SaveUser(UserMapper.GetDto(userModel));
            return RedirectToAction("Index");
        }

        public ActionResult EditUser(int userId)
        {
            var userDto = _userHandler.GetById(userId);
            var userModel = UserMapper.GetModel(userDto);
            return View("AddUser", userModel);
        }

        public ActionResult Delete(int userId)
        {
            _userHandler.DeleteById(userId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetAllRoles()
        {
            var allItems = _roleHandler.GetAllRoles();
            return Json(new { Items = allItems.Select(r => r.RoleName) });
        }
    }
}
