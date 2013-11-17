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
    }
}
