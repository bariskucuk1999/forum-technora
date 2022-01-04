using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PostManager
    {
        GenericRepository<Post> post = new GenericRepository<Post>();
        public List<Post> GetPost() => post.List();
        public List<Post> CategoryFilter(int p)
        {
            return post.List(a => a.CategoryID.Equals(p));
        }
        public List<Post> PostFilter(string p)
        {
            return post.List(a => a.PostTitle.Contains(p) || a.PostText.Contains(p));
        }
        public Post GetPostID(int id)
        {
            return post.Get(r => r.PostID == id);
        }
        public void CreatePost(Post p)
        {
            if (p.PostTitle == null || p.PostText == null)
            {
                //İşlem yok
            }
            else
            {
                post.Insert(p);
            }
        }
        public void DeletePost(Post p)
        {
            post.Delete(p);
        }
    }
}
