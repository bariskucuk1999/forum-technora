using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumTechnora.Controllers
{
    public class SignUpController : Controller
    {
        UserManager um = new UserManager();
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        // GET: SignUp
        [HttpPost]
        public ActionResult SignUp(User p)
        {
            um.AddUser(p);
            return Redirect("/Home/Index");
        }
        
    }
}