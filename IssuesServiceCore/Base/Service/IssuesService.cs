using IssuesServiceCore.Abstract;
using IssuesServiceCore.Abstract.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesServiceCore.Base.Service
{
    public class IssuesService : IIssuesService
    {
        IIssuesRepository repository;

        public IssuesService()
        {
            repository = ServiceManager.container.Resolve<IIssuesRepository>();
        }

        public string GetIssueById(string id)
        {
            return JsonConvert.SerializeObject(repository.GetIssueById(id));
        }

        public string GetIssueByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
