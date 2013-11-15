using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxies
{
    public interface ISkill
    {
        Guid SkillID { get; set; }
        string Title { get; set; }
    }
}
