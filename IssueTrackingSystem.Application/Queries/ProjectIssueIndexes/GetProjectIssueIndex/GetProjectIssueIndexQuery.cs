using IssueTrackingSystem.Domain.Issues;
using MediatR;

namespace IssueTrackingSystem.Application.Queries.ProjectIssueIndexes.GetProjectIssueIndex;

public class GetProjectIssueIndexQuery : IRequest<ProjectIssueIndex>
{
    public int ProjectId { get; set; }
}