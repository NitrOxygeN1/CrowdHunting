using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proxies;

namespace DataAccessLayer.Entities
{
    public class Role : IRole
    {
        public Guid RoleID { get; set; }
        public string Title { get; set; }
    }
}
