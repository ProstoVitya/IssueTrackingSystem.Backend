using IssueTrackingSystem.Domain.Issues;
using MediatR;

namespace IssueTrackingSystem.Application.Queries.IssuePriorities.GetIssuePriorityDetails;

public class GetIssuePriorityDetailsQuery : IRequest<IssuePriority>
{
    public int IssuePriorityId { get; set; }
}