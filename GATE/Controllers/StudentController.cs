using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using GATE.DAL;
using GATE.Models;

namespace GATE.Controllers {
    public class StudentController : DefaultController {
        private readonly Random _random;

        public StudentController() {
            _random = new Random();
        }

        // GET: Student/Create
        public ActionResult Create() => View();

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student model) {
            model.StudentNumber = _random.Next(1000, 1000000);
            // Bug: Find a better way to set StudentNumber or just use Id Key of Student Model
            if (!ModelState.IsValid)
                return View(model);
            GateContext.Students.Add(model);

            return RedirectToAction("Create", "User", new {studentId = model.Id});
        }

    }
}