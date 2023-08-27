using MediatR;

namespace IssueTrackingSystem.Application.Commands.ProjectIssueIndexes.DeleteProjectIssueIndex;

public class DeleteProjectIssueIndexCommand : IRequest
{
    public int ProjectId { get; set; }
}