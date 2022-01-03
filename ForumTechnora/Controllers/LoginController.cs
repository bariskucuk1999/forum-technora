using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using BusinessLayer.Concrete;
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
        UserManager um = new UserManager();
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
            p.Password = um.EncodePasswordToBase64(p.Password); //Veri tabanında sorgulamadan önce şifreleme
            var userinfo = c.Users.FirstOrDefault(x => x.Email == p.Email && x.Password == p.Password);
            if (userinfo != null)
            {
                //yönlendirme işlemi
                FormsAuthentication.SetAuthCookie(userinfo.Email, false);
                Session["UserID"] = userinfo.UserID;
                Session["UserName"] = userinfo.UserName;
                Session["UserLastName"] = userinfo.UserLastName;
                Session["NickName"] = userinfo.NickName; 
                Session["UserBirthday"] = userinfo.UserBirthday;
                Session["CreationDate"] = userinfo.CreationDate;

                DateTime now = DateTime.Now;
                var cdate=DateTime.Parse(userinfo.CreationDate);
                TimeSpan diff = now.Date - cdate.Date;
                int days = (int)diff.TotalDays;
                Session["DayMember"] = days;

                return RedirectToAction("Posts","Home");
            }
            else
            {
                //hatalı giriş
                Session["Error"] = true;
                return RedirectToAction("Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}