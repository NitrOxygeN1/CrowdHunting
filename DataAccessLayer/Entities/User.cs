using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proxies;

namespace DataAccessLayer.Entities
{
    public class User : IUser
    {
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string GitHub_login { get; set; }
        public string Password { get; set; }
        public int Disabled { get; set; }
    }
}
