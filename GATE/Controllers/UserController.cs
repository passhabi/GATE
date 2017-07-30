using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GATE.DAL;
using GATE.Models;

namespace GATE.Controllers
{
    public class UserController : DefaultController
    {
        private int _studentId;

        // GET: User/Create
        [HttpGet]
        public ViewResult Create(int studentId)
        {
            _studentId = studentId;
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User model)
        {
            // TODO: Store _studentId to User Model, UserTypeId
            model.Confirmed = false;
            model.UserType = UserTypes.Student;
            model.CreationTime = DateTime.Now;
            model.LastUpdate = null;

            if (!ModelState.IsValid)
                return View(model);
            GateContext.Users.Add(model);
            // Send an email to the user
            return RedirectToAction("", "");
        }
    }
}