using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxies
{
    public enum CallResult
    {
        Ok = 0,
        NotAuthenticated,
        NotAuthorized,
        ExceptionOccured,
        NotFound
    }
}
