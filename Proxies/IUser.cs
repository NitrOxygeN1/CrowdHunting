using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxies
{
    public interface IUser
    {
        Guid UserID { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string GitHub_login { get; set; }
        string Password { get; set; }
        int Disabled { get; set; }
    }
}
