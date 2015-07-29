using IssuesServiceCore.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesServiceTools
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Add Issues To Mongo
            string connString = ConfigurationManager.ConnectionStrings["mongodb"].ConnectionString;
            MongoDB.Driver.MongoClient client = new MongoDB.Driver.MongoClient(connString);

            var db = client.GetDatabase("issues_db");
            var issuesCollection = db.GetCollection<Issue>("issues");
            List<Task> tasks = new List<Task>();
            //issuesCollection.InsertOneAsync(new Issue("111111", "description", "name"));

            IIssuesRepository repo = new IssuesServiceCore.Base.IssuesFilesRepository("repository");
            Console.WriteLine("Items get:" + repo.GetAllIssues().Count);
            issuesCollection.InsertManyAsync(repo.GetAllIssues()).Wait();

            Console.WriteLine("Migration complete.");
            
            Console.ReadLine();
            
            #endregion
        }
    }
}
