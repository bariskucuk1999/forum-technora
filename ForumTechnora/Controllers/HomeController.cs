using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumTechnora.Controllers
{
    public class HomeController : Controller
    {
        UserManager um = new UserManager();

        public ActionResult Index()
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.bloomberght.com/piyasalar");
            string Bist100Scrapper()
            {
                string bist100 = "";
                foreach (var item in doc.DocumentNode.SelectNodes("//span[@data-secid='XU100 Index']"))
                {
                    bist100 = bist100 + item.InnerText;
                }
                return bist100;
            }
            string UsdTryScrapper()
            {
                string usdtry = "";
                foreach (var item in doc.DocumentNode.SelectNodes("//span[@data-secid='USDTRY Curncy']"))
                {
                    usdtry = usdtry + item.InnerText;
                }
                return usdtry;
            }
            string EurTryScrapper()
            {
                string eurtry = "";
                foreach (var item in doc.DocumentNode.SelectNodes("//span[@data-secid='EURTRY Curncy']"))
                {
                    eurtry = eurtry + item.InnerText;
                }
                return eurtry;
            }
            string WeatherScrapper()
            {
                HtmlAgilityPack.HtmlDocument doc1 = web.Load("https://weather.com/tr-TR/weather/today/l/33d1e415eb66f3e1ab35c3add45fccf4512715d329edbd91c806a6957e123b49");
                string weather = doc1.DocumentNode.SelectNodes("//div[@class='CurrentConditions--primary--2SVPh']").FirstOrDefault().InnerText;
                return weather;
            }
            Session["Bist100"] = Bist100Scrapper();
            Session["UsdTry"] = UsdTryScrapper();
            Session["EurTry"] = EurTryScrapper();
            Session["Weather"] = WeatherScrapper();
            return View();
        }
        [HttpGet]
        public ActionResult Posts()
        {
            var postItems = um.GetPost();
            return View(postItems);
        }
        [HttpPost]
        public ActionResult Posts(Post p)
        {
            um.CreatePost(p);
            return Redirect("/Home/Posts");
        }
        
        public ActionResult News()
        {
            return View();
        }
    }
}