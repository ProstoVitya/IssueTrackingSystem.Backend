using IssueTrackingSystem.Domain;
using MediatR;

namespace IssueTrackingSystem.Application.Queries.Issues.GetIssueList;

public class GetIssueListQuery : IRequest<IssueListVm>
{
    public Guid AssigneeId { get; set; }
    public Project Project { get; }
}