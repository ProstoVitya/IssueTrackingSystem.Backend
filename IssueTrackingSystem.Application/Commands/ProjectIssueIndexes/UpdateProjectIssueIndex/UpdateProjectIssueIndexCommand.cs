using MediatR;

namespace IssueTrackingSystem.Application.Commands.ProjectIssueIndexes.UpdateProjectIssueIndex;

public class UpdateProjectIssueIndexCommand : IRequest
{
    public int ProjectId { get; set; }
}