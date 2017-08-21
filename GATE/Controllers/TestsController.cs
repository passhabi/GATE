using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GATE.DAL;
using GATE.Models;

namespace GATE.Controllers {
    [Authorize]
    public class TestsController : BaseController {
        // GET: Tests
        public ActionResult Index() {
            var tests = DbContext.Tests.Include(t => t.Course);
            return View(tests.ToList());
        }

        // GET: Tests/Create
        public ActionResult Create() {
            ViewBag.CourseId = new SelectList(DbContext.Courses, "Id", "Title");
            return View();
        }

        // POST: Tests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestViewModel model) {
            var test = new Test() {
                Title = model.Title,
                Fee = model.Fee,
                CourseId = model.CourseId,
                Course = model.Course,
                CreationTime = DateTime.Now,
                LastUpdate = null,
            };
            if (ModelState.IsValid) {
                DbContext.Tests.Add(test);
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(DbContext.Courses, "Id", "Title", test.CourseId);
            return View(model);
        }

        // GET: Tests/Edit/5
        public ActionResult Edit(int id) {
            var test = DbContext.Tests.Find(id);
            if (test == null) {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(DbContext.Courses, "Id", "Title", test.CourseId);
            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Test model) {
            var test = DbContext.Tests.SingleOrDefault(t => t.Id == model.Id);
            if (ModelState.IsValid) {
                test.Course = model.Course;
                test.CourseId = model.CourseId;
                test.Fee = model.Fee;
                test.LastUpdate = DateTime.Now;
                test.Title = model.Title;
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(DbContext.Courses, "Id", "Title", test.CourseId);
            return View(test);
        }

        // POST: Tests/Delete/5
        public ActionResult Delete(int id) {
            var test = DbContext.Tests.Find(id);
            if (test == null)
                return HttpNotFound();
            DbContext.Tests.Remove(test);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}