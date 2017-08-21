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

namespace GATE.Controllers {
    public class LevelsController : BaseController {
        // GET: Levels
        public ActionResult Index() => View(DbContext.Levels.ToList());
        // GET: Levels/Create
        public ActionResult Create() => View();
       

        // POST: Levels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Level level) {
            if (ModelState.IsValid) {
                level.CreationTime = DateTime.Now;
                level.LastUpdate = null;
                DbContext.Levels.Add(level);
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(level);
        }

        // GET: Levels/Edit/5
        public ActionResult Edit(int id) {
            Level level = DbContext.Levels.Find(id);
            if (level == null) {
                return HttpNotFound();
            }
            return View(level);
        }

        // POST: Levels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Level level) {
            if (ModelState.IsValid) {
                var levelInDb = DbContext.Levels.SingleOrDefault(m => m.Id == level.Id);
                if (levelInDb == null)
                    return HttpNotFound();

                TryUpdateModel(levelInDb, "", new string[] {"Code", "Title", "" ,"LastUpdate" });
                levelInDb.LastUpdate = DateTime.Now;
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(level);
        }

        // GET: Levels/Delete/5
        public ActionResult Delete(int id) {
            Level level = DbContext.Levels.Find(id);

            if (level == null) {
                return HttpNotFound();
            }

            DbContext.Levels.Remove(level);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}