using MediatR;

namespace IssueTrackingSystem.Application.Commands.Issues.DeleteAllProjectIssues;

public class DeleteAllProjectIssuesCommand : IRequest
{
    public int ProjectId { get; set; }
}

