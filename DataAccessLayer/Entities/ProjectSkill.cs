using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proxies;

namespace DataAccessLayer.Entities
{
    public class ProjectSkill : IProjectSkill
    {
        public Guid ProjectSkillID { get; set; }
        public Guid SkillID { get; set; }
        public Guid ProjectID { get; set; }
        public int Level { get; set; }
    }
}
