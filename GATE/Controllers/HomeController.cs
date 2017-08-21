using GATE.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GATE.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GATE.Controllers {
    public class HomeController : BaseController {
        public ActionResult Index() {
            var roleManager = ApplicationRoleManager.GetObj(HttpContext.GetOwinContext());
            // If one of the role doesn't exist then others don't too.
            if (roleManager.RoleExists(UserTypes.Student.ToString())) return View();
            roleManager.Create(new IdentityRole(UserTypes.Student.ToString()));
            roleManager.Create(new IdentityRole(UserTypes.Admin.ToString()));
            //roleManager.Create(new IdentityRole(UserTypes.Teacher.ToString()));
            roleManager.Create(new IdentityRole(UserTypes.Staff.ToString()));
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page";
            return View();
        }
    }
}