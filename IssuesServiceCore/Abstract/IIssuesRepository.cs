using System;
namespace IssuesServiceCore.Abstract
{
    public interface IIssuesRepository
    {
        System.Collections.Generic.List<IssuesServiceCore.Abstract.Issue> GetAllIssues();
        IssuesServiceCore.Abstract.Issue GetIssueById(string id);
        IssuesServiceCore.Abstract.Issue GetIssueByName(string name);

    }
}

