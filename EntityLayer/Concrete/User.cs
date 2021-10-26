﻿using System;
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
        [StringLength(100)]
        public string UserImage { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [StringLength(20)]
        public string UserLastName { get; set; }
        [StringLength(16)]
        public string NickName { get; set; }
        public DateTime UserBirthday { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
