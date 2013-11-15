using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxies
{
    public interface IUserSkill
    {
        Guid UserSkillID { get; set; }
        Guid SkillID { get; set; }
        Guid UserID { get; set; }
        int Level { get; set; }
    }
}
