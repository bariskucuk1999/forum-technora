using DataAccessLayer.Abstract;
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
        GenericRepository<Comment> comment = new GenericRepository<Comment>();
        public List<User> GetData() => user.List();
        public List<Post> GetPost() => post.List();
        public List<News> GetNews() => news.List();
        public List<Comment> GetComment() => comment.List();
        public List<Post> CategoryFilter(int p)
        {
            return post.List(a => a.CategoryID.Equals(p));
        }
        public List<News> NewsFilter(string p)
        {
            return news.List(a => a.NewsTitle.Contains(p));
        }
        public List<Post> PostFilter(string p)
        {
            return post.List(a => a.PostTitle.Contains(p));
        }
        public Post GetPostID(int id)
        {
            return post.Get(r => r.PostID == id);
        }
        public News GetNewsID(int id)
        {
            return news.Get(r => r.NewsID == id);
        }
        public Comment GetCommentID(int id)
        {
            return comment.Get(r => r.CommentID == id);
        }
        public void AddUser(User p)
        {
            if (p.Password == "")
            {
                //Hata mesajı
            }
            else
            {
                p.Password = EncodePasswordToBase64(p.Password);
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
        public void CreateComment(Comment c)
        {
            comment.Insert(c);
        }
        public void DeleteComment(Comment c)
        {
            comment.Delete(c);
        }
        public string EncodePasswordToBase64(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }
    }
}
