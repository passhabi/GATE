using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using GATE.DAL;
using GATE.Models;

namespace GATE.Controllers
{
    public class StudentController : Controller
    {
        private readonly GateContext _gateContext;

        public StudentController()
        {
            _gateContext = new GateContext();
        }

        // GET: Student
        public ActionResult Index()
        {
            var students = _gateContext.Students;
            return View(students);
        }
       
    }
}