using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Vote
    {
        [Key]
        public int VoteID { get; set; }
        public DateTime VoteDate { get; set; }
        public int? UserID { get; set; }
        public virtual User User { get; set; }
        public int PostID { get; set; }
        public virtual Post Post { get; set; }
    }
}
