using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxies
{
    public interface IRole
    {
        Guid RoleID { get; set; }
        string Title { get; set; }
    }
}
