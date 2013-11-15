using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proxies;

namespace DataAccessLayer.Entities
{
    public class Task : ITask
    {
        public Guid TaskID { get; set; }
        public string Task_title { get; set; }
        public string Task_description { get; set; }
        public int GitHub_id { get; set; }
        public int Karma { get; set; }
    }
}
