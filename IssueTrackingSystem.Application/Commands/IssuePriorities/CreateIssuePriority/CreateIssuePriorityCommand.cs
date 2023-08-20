using MediatR;

namespace IssueTrackingSystem.Application.Commands.IssuePriorities.CreateIssuePriority;

public class CreateIssuePriorityCommand : IRequest
{
    public string Name { get; set; }
}