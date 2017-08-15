using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GATE.DAL;
using GATE.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Provider;

namespace GATE.Controllers {
    public abstract class BaseController : Controller {

        public ApplicationDbContext DbContext => HttpContext.GetOwinContext().Get<ApplicationDbContext>();

        public ApplicationUserManager UserManager {
            get { return HttpContext.GetOwinContext().Get<ApplicationUserManager>(); }
        }
        public ApplicationSignInManager SignInManager {
            get { return HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
        }
    }
}