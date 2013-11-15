using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxies
{
    public interface IProjectSkill
    {
        Guid ProjectSkillID { get; set; }
        Guid SkillID { get; set; }
        Guid ProjectID { get; set; }
        int Level { get; set; }
    }
}
