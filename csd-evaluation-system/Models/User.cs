using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csd_evaluation_system.Models
{
    public class User : BaseModel
    {

        protected override string[] columns { get{
            return new string[] {
                "id", "username", "password", "fullname"
            };
        }}

        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }

        public User() { }
        public User(DbObject data)
        {
            this.id = (int) data["id"];
            this.username = (string) data["username"];
            this.fullname = (string) data["fullname"];
            this.password = (string) data["password"];
        }

        public static User Find(string username)
        {
            var query = "SELECT * FROM users WHERE username = @username";
            var param = new DbObject().Push("username", username);
            var user = new User().First(query, param);
            return new User(user);
        }

        public static User Find(int id)
        {
            var query = "SELECT * FROM users WHERE id = @id";
            var param = new DbObject().Push("id", id);
            var user = new User().First(query, param);
            return new User(user);
        }

        public static List<User> All()
        {
            var users = new User().Get("SELECT * FROM users", null);
            var result = new List<User>();
            foreach (var user in users)
                result.Add(new User(user));
            return result;
        }

        public static User Login(string username, string password)
        {
            return null;
        }
    }
}
