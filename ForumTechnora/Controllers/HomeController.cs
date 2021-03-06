using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumTechnora.Controllers
{
    public class HomeController : Controller
    {
        UserManager um = new UserManager();
        CommentManager cm = new CommentManager();
        NewsManager nm = new NewsManager();
        PostManager pm = new PostManager();
        VoteManager vm = new VoteManager();

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
            string TodayInHistoryScrapper()
            {
                HtmlAgilityPack.HtmlDocument doc1 = web.Load("https://tr.wikipedia.org/wiki/Anasayfa");
                int count = 0;
                string temp = "";
                string info = "";
                foreach (var item in doc1.DocumentNode.SelectNodes("//td[@id='mp-itn']/ul"))
                {
                    if (count == 0)
                    {
                        temp = temp + item.InnerText;
                        count++;
                        continue;
                    }
                    info = info + item.InnerText;

                }
                return info;
            }
            Session["Bist100"] = Bist100Scrapper();
            Session["UsdTry"] = UsdTryScrapper();
            Session["EurTry"] = EurTryScrapper();
            Session["Weather"] = WeatherScrapper();
            Session["TodayInHistory"] = TodayInHistoryScrapper();
            return View();
        }
        [HttpGet]
        public ActionResult Posts()
        {
            dynamic myModel = new ExpandoObject(); //Birden fazla modelin tek cshtml dosyasında kullanımı
            myModel.postItems = pm.GetPost().OrderByDescending(c => c.PostID).ToList(); ;
            myModel.commentItems = cm.GetComment().OrderByDescending(d => d.CommentID).ToList();
            myModel.voteItems = vm.GetVote();
            return View(myModel);
        }
        [HttpPost]
        public ActionResult Posts(Post p, Comment c, Vote v)
        {
            pm.CreatePost(p);
            cm.CreateComment(c);
            vm.CreateVote(v);
            return Redirect("/Home/Posts");
        }
        public ActionResult DeletePost(int id)
        {
            var PostIdValue = pm.GetPostID(id);
            pm.DeletePost(PostIdValue);
            return Redirect("/Home/Posts");
        }
        public ActionResult DeleteComment(int id)
        {
            var CommentIdValue = cm.GetCommentID(id);
            cm.DeleteComment(CommentIdValue);
            return Redirect("/Home/Posts");
        }
        [HttpGet]
        public ActionResult News()
        {
            var newsItems = nm.GetNews();
            return View(newsItems.OrderByDescending(c => c.NewsID).ToList());
        }
        [HttpPost]
        public ActionResult News(News n)
        {
            nm.CreateNews(n);
            return Redirect("/Home/News");
        }
        public ActionResult DeleteNews(int id)
        {
            var NewsIdValue = nm.GetNewsID(id);
            nm.DeleteNews(NewsIdValue);
            return Redirect("/Home/News");
        }
        public ActionResult DeleteVote(int id)
        {
            var VoteIdValue = vm.GetVoteID(id);
            vm.DeleteVote(VoteIdValue);
            return Redirect("/Home/Posts");
        }
        public ActionResult Search()
        {
            dynamic myModel1 = new ExpandoObject();
            string param = Request.QueryString["p"];
            myModel1.postFilter = pm.PostFilter(param).OrderByDescending(c => c.PostID);
            myModel1.commentFilter = cm.GetComment().OrderByDescending(d => d.CommentID).ToList();
            myModel1.newsFilter = nm.NewsFilter(param).OrderByDescending(e => e.NewsID);
            myModel1.voteFilter = vm.GetVote();
            return View(myModel1);
        }
        public ActionResult CategoryFilter()
        {
            int category = Convert.ToInt32(Request.QueryString["filter"]);
            dynamic myModel = new ExpandoObject(); //Birden fazla modelin tek cshtml dosyasında kullanımı
            myModel.postItems1 = pm.CategoryFilter(category).OrderByDescending(c => c.PostID); //Category ID'ye göre post return etme
            myModel.commentItems1 = cm.GetComment().OrderByDescending(d => d.CommentID).ToList();
            myModel.voteItems1 = vm.GetVote();
            return View(myModel);
        }
        [HttpPost]
        public ActionResult CategoryFilter(Post p, Comment c, Vote v)
        {
            pm.CreatePost(p);
            cm.CreateComment(c);
            vm.CreateVote(v);
            return Redirect("/Home/Posts");
        }
    }
}