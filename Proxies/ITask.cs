using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proxies
{
    public interface ITask
    {
        Guid TaskID { get; set; }
        string Task_title { get; set; }
        string Task_description { get; set; }
        int GitHub_id { get; set; }
        int Karma { get; set; }
    }
}
