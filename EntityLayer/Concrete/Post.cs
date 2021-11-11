using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        [StringLength(64)]
        public string PostTitle { get; set; }
        [StringLength(5000)]
        public string PostText { get; set; }
        public string PostCreationDate { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Vote> Votes { get; set; }
    }
}
