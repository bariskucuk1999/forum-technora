using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager
    {
        GenericRepository<User> user = new GenericRepository<User>();
        GenericRepository<Post> post = new GenericRepository<Post>();
        public List<User> GetData() => user.List();
        public List<Post> GetPost() => post.List();
        public void AddUser(User p)
        {
            if (p.Password == "")
            {
                //Hata mesajı
            }
            else
            {
                user.Insert(p);
            }
        }
        public void CreatePost(Post p)
        {
            post.Insert(p);
        }
    }
}
