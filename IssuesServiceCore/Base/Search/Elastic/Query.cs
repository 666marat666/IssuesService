using IssuesServiceCore.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesServiceCore.Base.Search.Elastic
{
    public class Query
    {
        public Issue Term { get; set; }

        public Query(Issue term)
        {
            Term = term;
        }

    }
}
