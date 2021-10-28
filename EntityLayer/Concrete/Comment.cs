using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        [StringLength(500)]
        public string CommentText { get; set; }
        public DateTime CommentCreationDate { get; set; }
        public int? UserID { get; set; }
        public virtual User User { get; set; }

        public int PostID { get; set; }
        public virtual Post Post { get; set; }
    }
}
