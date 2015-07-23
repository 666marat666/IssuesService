using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IssuesServiceCore.Abstract.Search
{
    public interface IIndexesRepository
    {
        HttpStatusCode AddIssueToIndex(Issue issue);
        Issue SearchIssueWithId(string id);
    }
}
