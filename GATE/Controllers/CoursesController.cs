using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GATE.DAL;
using GATE.Models;

namespace GATE.Controllers
{
    [Authorize]
    public class CoursesController : BaseController
    {

        // GET: Courses
        public ActionResult Index()
        {
            var courses = DbContext.Courses.Include(c => c.Level).ToList();
            return View(courses);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.LevelId = new SelectList(DbContext.Levels, "Id", "Title");
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (Course course)
        {
            course.CreationTime = DateTime.Now;
            course.LastUpdate = null;
            if (ModelState.IsValid)
            {
                DbContext.Courses.Add(course);
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LevelId = new SelectList(DbContext.Levels, "Id", "Title", course.LevelId);
            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int id)
        {
            var course = DbContext.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }

            ViewBag.LevelId = new SelectList(DbContext.Levels, "Id", "Title", course.LevelId);
            return View(course);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid) {
                var courseInDb = DbContext.Courses.Find(course.Id);
                if (courseInDb == null) return HttpNotFound();
                TryUpdateModel(courseInDb, "", new string [] {"Code","Title", "Fee", "LevelId" });
                courseInDb.LastUpdate = DateTime.Now;
                //DbContext.Entry(course).State = EntityState.Modified;
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LevelId = new SelectList(DbContext.Levels, "Id", "Title", course.LevelId);
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int id)
        {
            var course = DbContext.Courses.Find(id);
            if (course == null) return HttpNotFound();
            DbContext.Courses.Remove(course);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
