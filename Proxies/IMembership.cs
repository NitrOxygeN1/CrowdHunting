using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxies
{
    public interface IMembership
    {
        Guid MemberID { get; set; }
        Guid UserID { get; set; }
        Guid ProjectID { get; set; }
        Guid RoleID { get; set; }
        int Active { get; set; }
    }
}
