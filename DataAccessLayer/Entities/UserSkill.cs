using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proxies;

namespace DataAccessLayer.Entities
{
    public class UserSkill : IUserSkill
    {
        public Guid UserSkillID { get; set; }
        public Guid SkillID { get; set; }
        public Guid UserID { get; set; }
        public int Level { get; set; }
    }
}
