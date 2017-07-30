using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GATE.DAL;

namespace GATE.Controllers
{
    public class DefaultController : Controller
    {
        protected static readonly GateContext GateContext = new GateContext();

    }
}