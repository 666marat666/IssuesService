using IssuesServiceCore.Abstract;
using IssuesServiceCore.Base;
using IssuesServiceCore.Base.Search.Elastic;
using IssuesServiceCore.Base.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesService
{
    class Program
    {
        static void Main(string[] args)
        {
            //ServiceManager.Initialize("localhost", 8080);
            //ServiceManager.host.Open();


            IIssuesRepository repo = new ZipArchieveIssuesRepository("repository.zip", "marat007");


            Console.WriteLine(repo.GetAllIssues().FirstOrDefault().Name);
            //ElasticSearchProvider searchProvider = new ElasticSearchProvider();
            //searchProvider.AddIssuesToIndex(repo.GetAllIssues());
            //Console.WriteLine(
            //    searchProvider.SearchIssues(
            //    new Query(
            //        new IssuesServiceCore.Abstract.Issue(null, "*2*", null)
            //        )
            //    )[0]._source.Description
            //);

            Console.ReadLine();

            //ServiceManager.host.Close();
            
        }
    }
}
