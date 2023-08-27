using MediatR;

namespace IssueTrackingSystem.Application.Commands.ProjectIssueIndexes.CreateProjectIssueIndex;

public class CreateProjectIssueIndexCommand : IRequest
{
    public int ProjectId { get; set; }
}