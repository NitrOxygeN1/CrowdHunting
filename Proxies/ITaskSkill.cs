using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxies
{
    public interface ITaskSkill
    {
        Guid TaskSkillID { get; set; }
        Guid SkillID { get; set; }
        Guid TaskID { get; set; }
        int Level { get; set; }
    }
}
