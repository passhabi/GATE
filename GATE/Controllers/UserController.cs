using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GATE.DAL;
using GATE.Models;

namespace GATE.Controllers
{
    public class UserController : Controller
    {
        private readonly GateContext _gateContext;

        public UserController()
        {
            _gateContext = new GateContext();
        }

        // GET: User
        public ActionResult Index() => View();

        // GET: User/Create
        [HttpGet]
        public ViewResult Create() => View();

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User model)
        {
            model.Confirmed = false;
            model.UserType = UserTypes.Student;
            model.CreationTime = DateTime.Now;
            model.LastUpdate = null;

            if (!ModelState.IsValid)
                return View(model);
            _gateContext.Users.Add(model);
            // Send an email to the user
            return RedirectToAction("", "");
        }
    }
}