using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager
    {
        GenericRepository<User> user = new GenericRepository<User>();
        public List<User> GetData() => user.List();
        
        public void AddUser(User p)
        {
            if (p.Password == "")
            {
                //Hata mesajı
            }
            else
            {
                p.Password = EncodePasswordToBase64(p.Password);
                user.Insert(p);
            }
        }             
        public string EncodePasswordToBase64(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }       
    }
}
