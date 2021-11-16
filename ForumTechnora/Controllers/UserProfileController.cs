using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumTechnora.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        [Authorize]
        public ActionResult UserProfile()
        {
            return View();
        }
    }
}