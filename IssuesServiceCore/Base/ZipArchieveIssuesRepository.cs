using Ionic.Zip;
using IssuesServiceCore.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesServiceCore.Base
{
    public class ZipArchieveIssuesRepository : IssuesFilesRepository
    {
        string password = "";
        public ZipArchieveIssuesRepository(string pathToRepo = "repository.zip", string password = "")
            : base(pathToRepo)
        {
            this.PathToRepo = pathToRepo;
            if (!String.IsNullOrEmpty(password)) this.password = password;
            ParseIssues();
        }

        protected override void ParseIssues()
        {
            List<Issue> result = new List<Issue>();

            using (ZipFile zip = ZipFile.Read(PathToRepo))
            {
                foreach (var entry in zip.Entries)
                {
                    //entry.Password = this.password;
                    using (var stream = entry.OpenReader(this.password))
                    {
                        StreamReader reader = new StreamReader(stream);
                        string content = reader.ReadToEnd();

                        IssueFormatAdapter adapter = JsonConvert.DeserializeObject<IssueFormatAdapter>(content);
                        if (adapter != null)
                        {
                            Issue issue = adapter.issue;
                            if (issue != null)
                                result.Add(issue);
                        }
                    }
                }
            }
            issuesCache = result;
        }
    }
}
