using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxies
{
    public interface IProject
    {
        Guid ProjectID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        DateTime Date_start { get; set; }
        DateTime Date_end { get; set; }
        string Status { get; set; }
        string GitHub_url { get; set; }
        Guid UserID { get; set; }
    }
}
