using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager
    {
        GenericRepository<Comment> comment = new GenericRepository<Comment>();
        public List<Comment> GetComment() => comment.List();

        public Comment GetCommentID(int id)
        {
            return comment.Get(r => r.CommentID == id);
        }
        public void CreateComment(Comment c)
        {
            if (c.CommentText == null)
            {
                //İşlem yok
            }
            else
            {
                comment.Insert(c);
            }
        }
        public void DeleteComment(Comment c)
        {
            comment.Delete(c);
        }
    }
}
