using IssuesServiceCore.Abstract;
using IssuesServiceCore.Abstract.Search;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IssuesServiceCore.Base.Search.Elastic
{
    public class ElasticSearchProvider : IIndexesRepository
    {
        string serviceAddress;
        string indexName;
        string type;
        RestClient client = null;
        public ElasticSearchProvider(string serviceAddress = "http://localhost:9200", string indexName = "issuestracker", string type = "tickets")
        {
            this.serviceAddress = serviceAddress;
            this.indexName = indexName;
            this.type = type;
            client = new RestClient(
                serviceAddress
                );
            
        }

        public HttpStatusCode AddIssueToIndex(Abstract.Issue issue)
        {
            var request = new RestRequest("{indexName}/{type}/{id}", Method.PUT);

            request.AddUrlSegment("indexName", indexName); // replaces matching token in request.Resource
            request.AddUrlSegment("type", type);
            request.AddUrlSegment("id", issue.ID);
            request.RequestFormat = DataFormat.Json;
            //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
            request.AddBody(issue);
            // easily add HTTP Headers
            //request.AddHeader("header", "value");

            // add files to upload (works with compatible verbs)
            //request.AddFile(path);

            // execute the request
            IRestResponse response = client.Execute(request);
            return response.StatusCode;
        }

        public void AddIssuesToIndex(List<Abstract.Issue> issues)
        {
            foreach (var issue in issues)
            {
                var request = new RestRequest("{indexName}/{type}/{id}", Method.PUT);

                request.AddUrlSegment("indexName", indexName); // replaces matching token in request.Resource
                request.AddUrlSegment("type", type);
                request.AddUrlSegment("id", issue.ID);
                request.RequestFormat = DataFormat.Json;
                //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
                request.AddBody(issue);
                // easily add HTTP Headers
                //request.AddHeader("header", "value");

                // add files to upload (works with compatible verbs)
                //request.AddFile(path);

                // execute the request
                client.Execute(request);
            }
        }
        
        public Issue SearchIssueWithId(string id)
        {
            var request = new RestRequest("{indexName}/{type}/{id}", Method.GET);

            request.AddUrlSegment("indexName", indexName); // replaces matching token in request.Resource
            request.AddUrlSegment("type", type);
            request.AddUrlSegment("id", id);
            request.RequestFormat = DataFormat.Json;
            //request.AddParameter("q","id:"+id);

            // execute the request
            IRestResponse<Hit> response = client.Execute<Hit>(request);
            return response.Data._source;
        }

        public List<Hit> SearchIssues(Query query)
        {
            var request = new RestRequest("{indexName}/{type}/_search", Method.GET);

            request.AddUrlSegment("indexName", indexName); // replaces matching token in request.Resource
            request.AddUrlSegment("type", type);
            request.AddJsonBody(query);
            request.RequestFormat = DataFormat.Json;
            //request.AddParameter("q","id:"+id);

            // execute the request
            IRestResponse<SearchResult> response = client.Execute<SearchResult>(request);
            return response.Data.hits.hits;
        }
    }
}
