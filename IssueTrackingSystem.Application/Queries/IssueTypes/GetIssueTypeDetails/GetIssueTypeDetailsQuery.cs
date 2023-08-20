using IssueTrackingSystem.Domain.Issues;
using MediatR;

namespace IssueTrackingSystem.Application.Queries.IssueTypes.GetIssueTypeDetails;

public class GetIssueTypeDetailsQuery : IRequest<IssueType>
{
    public int IssueTypeId { get; set; }
}