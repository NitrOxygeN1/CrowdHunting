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
        public ServiceAnswer<string> Login(string login, string password)
        {
            var res = new ServiceAnswer<string>();
            try
            {
                var token = UserContext.Login(login, password);
                res.Data = token;
                res.CallResult = CallResult.Ok;

            }
            catch (Exception ex)
            {
                res.ErrorText = ex.Message;
                res.ErrorType = ex.GetType().FullName;
                res.CallResult = CallResult.ExceptionOccured;
            }
            return res;
        }

        public ServiceAnswer<bool> Authorize(string token, string entityID)
        {
            var res = new ServiceAnswer<bool>();
            try
            {
                Guid calleeID = Guid.Parse(token);
                Guid objectID = Guid.Parse(entityID);
                res.Data = UserContext.Authorize(calleeID, objectID);
                res.CallResult = CallResult.Ok;

            }
            catch (Exception ex)
            {
                res.ErrorText = ex.Message;
                res.ErrorType = ex.GetType().FullName;
                res.CallResult = CallResult.ExceptionOccured;
            }
            return res;
        }


        public IUser Get(Guid user_id)
        {
            return UserContext.Get(user_id);
        }
    }
}
