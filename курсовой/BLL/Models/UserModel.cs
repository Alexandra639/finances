using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Models
{
   public class UserModel
    {
       
        public int user_code_ID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public UserModel() { }
        public UserModel(USER u)
        {
            user_code_ID = u.id;
            name = u.name;
            surname = u.surname;
            login = u.login;
            password = u.password;
        }
    }
}
