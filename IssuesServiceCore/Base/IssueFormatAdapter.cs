using IssuesServiceCore.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesServiceCore.Base
{
    //root data object
    public class IssueFormatAdapter
    {
        [JsonProperty("data")]
        public Issue issue { get; set; }
    }
}
