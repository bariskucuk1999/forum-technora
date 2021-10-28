using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Login
    {
        [Key]
        public int LoginID { get; set; }
        public string Email { get; set; }
        [StringLength(16)]
        public string Password { get; set; }

    }
}
