using IssueTrackingSystem.Domain.Issues;
using MediatR;

namespace IssueTrackingSystem.Application.Queries.Issues.GetIssueDetails;

public class GetIssueDetailsQuery : IRequest<Issue>
{
    public int IssueIndex { get; set; }
    public int ProjectId { get; set; }
}