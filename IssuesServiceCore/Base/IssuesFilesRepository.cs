using IssuesServiceCore.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using IssuesServiceCore.Abstract.Search;
using IssuesServiceCore.Base.Service;
using Newtonsoft.Json.Linq;

namespace IssuesServiceCore.Base
{
    public class IssuesFilesRepository : IssuesServiceCore.Abstract.IIssuesRepository
    {
        public string PathToRepo { get; set; }
        protected List<Issue> issuesCache = null;

        public IssuesFilesRepository(string pathToRepo = "repo")//TODO
        {
            this.PathToRepo = pathToRepo;
            ParseIssues();
        }

        protected virtual void ParseIssues()
        {
            List<Issue> result = new List<Issue>();

            foreach (var item in Directory.GetFiles(PathToRepo, "*.json", SearchOption.AllDirectories))
            {
                string content = File.ReadAllText(item);
                IssueFormatAdapter adapter = JsonConvert.DeserializeObject<IssueFormatAdapter>(content);
                Issue issue = adapter.issue;
                if (issue != null)
                    result.Add(issue);
            }
            issuesCache = result;
        }

        public List<Issue> GetAllIssues()
        {
            return issuesCache;
        }

        public Issue GetIssueById(string id)
        {
            return issuesCache.Where(x => x.ID == id).FirstOrDefault();
        }

        public Issue GetIssueByName(string name)
        {
            return issuesCache.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
