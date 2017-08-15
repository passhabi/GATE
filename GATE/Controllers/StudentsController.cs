using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GATE.DAL;
using GATE.Models;
using Microsoft.AspNet.Identity;

namespace GATE.Controllers {
    [Authorize]
    public class StudentsController : BaseController {
        // GET: Students
//        public ActionResult Index() => View(DbContext.Students.ToList());

/*        // GET: Students/Details/5
        public ActionResult Details(int id) {

            Student student = DbContext.Students.Find(id);
            if (student == null) {
                return HttpNotFound();
            }
            return View(student);
        }*/

        // GET: Students/Get
        public ActionResult Create() => View();

        // POST: Students/Get
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
/*        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student) {
            if (ModelState.IsValid) {
                DbContext.Students.Add(student);
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }*/

        // GET: Students/Edit/5
        public ActionResult Edit(int id) {
            Student student = DbContext.Students.Find(id);
            if (student == null) {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student) {
            if (ModelState.IsValid) {
                DbContext.Entry(student).State = EntityState.Modified;
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            var student = DbContext.Students.Find(id);
            var user = UserManager.Users.FirstOrDefault(model => model.UserTypeId == student.Id);
            if (user != null && student != null) {
                // Delete Student from Users login table.
                UserManager.Delete(user);
                // Delete Student form Students table.
                DbContext.Students.Remove(student);
                DbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                DbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}