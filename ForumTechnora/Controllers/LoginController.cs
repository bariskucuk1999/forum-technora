using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ForumTechnora.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User p)
        {
            Context c = new Context();
            var userinfo = c.Users.FirstOrDefault(x => x.Email == p.Email && x.Password == p.Password);
            if (userinfo != null)
            {
                //yönlendirme işlemi
                FormsAuthentication.SetAuthCookie(userinfo.Email, false);
                Session["UserName"] = userinfo.NickName; //UserProfile HTML sayfasında kullandık
                return RedirectToAction("UserProfile","UserProfile");
            }
            else
            {
                //hatalı giriş
                return RedirectToAction("Login");
            }
        }
    }
}