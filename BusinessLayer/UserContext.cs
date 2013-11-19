using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proxies;
using DataAccessLayer;

namespace BusinessLayer
{
    public static class UserContext
    {
        static Dictionary<Guid, IUser> _loggedInUsersByGuid = new Dictionary<Guid, IUser>();

        public static IUser Get(Guid user_id)
        {
            IUser user = null;
            using (Context context = new Context(""))
            {
                if (user_id != null)
                {
                    user = UserUtility.Get(context, user_id);
                }
            }
            return user;
        }

        public static string Login(string login, string password)
        {
            var token = (from u in _loggedInUsersByGuid where u.Value.Name.Equals(login) select u.Key).FirstOrDefault();
            if (token != null)
                return token.ToString();

            IUser user = null;
            using (Context context = new Context(""))
            {
                user = UserUtility.GetByLogin(context, login);
            }
            
            token = Guid.NewGuid();

            _loggedInUsersByGuid.Add(token, user);

            return token.ToString();
            
        }

        public static bool Authorize(Guid callerID, Guid objectID)
        {
            if (!_loggedInUsersByGuid.ContainsKey(callerID))
                return false;         
            return UserUtility.AuthorizedByRole(callerID, objectID) ||
                UserUtility.AuthorizedByInheritanceChain(callerID, objectID);
        }
    }
}
