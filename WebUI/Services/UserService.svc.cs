using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Proxies;
using BusinessLayer;

namespace WebUI.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    public class UserService : IUserService
    {
        public IUser Get(string login, string password)
        {
            return null;
        }

        public IUser Get(Guid user_id)
        {
            return UserContext.Get(user_id);
        }
    }
}
