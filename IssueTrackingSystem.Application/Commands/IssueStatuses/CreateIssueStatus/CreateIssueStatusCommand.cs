using MediatR;

namespace IssueTrackingSystem.Application.Commands.IssueStatuses.CreateIssueStatus;

public class CreateIssueStatusCommand : IRequest
{
    public string Name { get; set; }
}