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

namespace GATE.Controllers {
    public class DefaultController : Controller {
        protected static ApplicationDbContext ApplicationDbContext;

        private static UserStore<CustomIdentityUser> Store;

        protected static UserManager<CustomIdentityUser> UserManager;

        protected SignInManager<CustomIdentityUser, string> SignInManager;


        public DefaultController() {
            ApplicationDbContext = new ApplicationDbContext();
            Store =
                new UserStore<CustomIdentityUser>(ApplicationDbContext);
            UserManager = new UserManager<CustomIdentityUser>(Store);
            //SignInManager =
                //new SignInManager<CustomIdentityUser, string>(UserManager, HttpContext.GetOwinContext().Authentication);
        }
    }
}