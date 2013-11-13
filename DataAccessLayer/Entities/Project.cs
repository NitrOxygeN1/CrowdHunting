using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proxies;

namespace DataAccessLayer.Entities
{
    class Project : IProject
    {
        public Guid ProjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date_start { get; set; }
        public DateTime Date_end { get; set; }
        public string Status { get; set; }
        public string GitHub_url { get; set; }
        public Guid UserID { get; set; }
    }
}
