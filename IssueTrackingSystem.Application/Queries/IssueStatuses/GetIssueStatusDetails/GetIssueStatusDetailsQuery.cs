using IssueTrackingSystem.Domain.Issues;
using MediatR;

namespace IssueTrackingSystem.Application.Queries.IssueStatuses.GetIssueStatusDetails;

public class GetIssueStatusDetailsQuery : IRequest<IssueStatus>
{
    public int IssueStatusId { get; set; }
}