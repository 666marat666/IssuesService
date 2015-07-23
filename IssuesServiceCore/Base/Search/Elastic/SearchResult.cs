using IssuesServiceCore.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesServiceCore.Base.Search.Elastic
{
    public class SearchResult
    {
        public Hits hits { get; set; }
    }

    public class Hits
    {
        public int total { get; set; }
        public List<Hit> hits { get; set; } 
    }

    //{"_index":"issuestracker","_type":"tickets","_id":"450888","_version":5,"found":true,"_source":{"ID":"450888","Name":"hello","Description":"hello world!"}}
    public class Hit
    {
        public string _index { get; set; }
        public string _type { get; set; }
        public string _id { get; set; }
        public float _score { get; set; }
        public Issue _source { get; set; }
    }
}
