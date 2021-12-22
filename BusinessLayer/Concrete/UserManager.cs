using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager
    {
        GenericRepository<User> user = new GenericRepository<User>();
        GenericRepository<Post> post = new GenericRepository<Post>();
        GenericRepository<News> news = new GenericRepository<News>();
        public List<User> GetData() => user.List();
        public List<Post> GetPost() => post.List();

        public List<News> GetNews() => news.List();

        public Post GetPostID(int id)
        {
            return post.Get(r => r.PostID == id);
        }
        public News GetNewsID(int id)
        {
            return news.Get(r => r.NewsID == id);
        }
        public void AddUser(User p)
        {
            if (p.Password == "")
            {
                //Hata mesajı
            }
            else
            {
                //p.Password = EncodePasswordToBase64(p.Password);
                user.Insert(p);
            }
        }
        public void CreatePost(Post p)
        {
            post.Insert(p);
        }
        public void DeletePost(Post p)
        {
            post.Delete(p);
        }
        public void CreateNews(News n)
        {
            news.Insert(n);
        }
        public void DeleteNews(News n)
        {
            news.Delete(n);
        }
        //public static string EncodePasswordToBase64(string password)
        //{
        //    byte[] bytes = Encoding.Unicode.GetBytes(password);
        //    byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
        //    return Convert.ToBase64String(inArray);
        //}
    }
}
