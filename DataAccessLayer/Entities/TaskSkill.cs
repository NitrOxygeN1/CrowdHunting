using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proxies;

namespace DataAccessLayer.Entities
{
    public class TaskSkill : ITaskSkill
    {
        public Guid TaskSkillID { get; set; }
        public Guid SkillID { get; set; }
        public Guid TaskID { get; set; }
        public int Level { get; set; }
    }
}
