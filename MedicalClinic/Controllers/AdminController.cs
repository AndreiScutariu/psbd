﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MedicalClinic.Models.User;
using MedicalClinic.Utils.ModelDtoMapper;
using MedicalClinicHandler.Handlers;

namespace MedicalClinic.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserHandler _userHandler;

        public AdminController()
        {
            _userHandler = new UserHandler();
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

        public bool CanUseThisUsername(string email)
        {
            return email != "andrei_s4u@yahoo.com";
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
    }
}
