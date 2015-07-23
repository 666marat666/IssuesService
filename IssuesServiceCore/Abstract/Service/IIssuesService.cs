using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace IssuesServiceCore.Abstract.Service
{
    [ServiceContract]
    public interface IIssuesService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "getissuebyid/{id}")]
        string GetIssueById(string id);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "getissuebyname/{name}")]
        string GetIssueByName(string name);
    }
}
