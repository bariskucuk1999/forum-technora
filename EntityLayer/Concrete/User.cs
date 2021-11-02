using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [StringLength(20)]
        public string UserLastName { get; set; }
        public string Email { get; set; }
        [StringLength(16)]
        public string Password { get; set; }
        [StringLength(16)]
        public string NickName { get; set; }
        public string UserBirthday { get; set; }
        public string CreationDate { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Vote> Votes { get; set; }
    }
}
