using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csd_evaluation_system.Models
{
    class User
    {

        public string username { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }

        public static User Login(string username, string password)
        {
            return null;
        }
    }
}
