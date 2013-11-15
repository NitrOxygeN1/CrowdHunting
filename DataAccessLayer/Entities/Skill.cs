using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proxies;

namespace DataAccessLayer.Entities
{
    class Skill : ISkill
    {
        public Guid SkillID { get; set; }
        public string Title { get; set; }
    }
}
