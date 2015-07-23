using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesServiceCore.Abstract
{
    public class Issue
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Issue() { }

        public Issue(string id = "0", string description = "", string name = "_empty_")
        {
            this.ID = id;
            this.Description = description;
            this.Name = name;
        }
    }
}
