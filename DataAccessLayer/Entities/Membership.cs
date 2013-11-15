using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proxies;

namespace DataAccessLayer.Entities
{
    public class Membership : IMembership
    {
        public Guid MemberID { get; set; }
        public Guid UserID { get; set; }
        public Guid ProjectID { get; set; }
        public Guid RoleID { get; set; }
        public int Active { get; set; }
    }
}
