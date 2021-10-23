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
        public string Email { get; set; }
        [StringLength(16)]
        public string Username { get; set; }
        [StringLength(20)]
        public string Password { get; set; }
    }
}
