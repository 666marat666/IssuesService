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

namespace IssuesServiceCore.Base
{
    public class IssuesFilesRepository : IssuesServiceCore.Abstract.IIssuesRepository
    {
        public string PathToRepo { get; set; }
        List<Issue> issuesCache = null;

        public IssuesFilesRepository(string pathToRepo = "repo")//TODO
        {
            this.PathToRepo = pathToRepo;
            Init();
        }

        void Init()
        {
            List<Issue> result = new List<Issue>();

            foreach (var item in Directory.GetFiles(PathToRepo, "*.json", SearchOption.AllDirectories))
            {
                string content = File.ReadAllText(item);

                var issue = JsonConvert.DeserializeObject<Issue>(content);
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
