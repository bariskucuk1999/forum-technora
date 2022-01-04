using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NewsManager
    {
        GenericRepository<News> news = new GenericRepository<News>();
        public List<News> GetNews() => news.List();

        public List<News> NewsFilter(string p)
        {
            return news.List(a => a.NewsTitle.Contains(p) || a.NewsText.Contains(p));
        }
        public News GetNewsID(int id)
        {
            return news.Get(r => r.NewsID == id);
        }
        public void CreateNews(News n)
        {
            news.Insert(n);
        }
        public void DeleteNews(News n)
        {
            news.Delete(n);
        }
    }
}
