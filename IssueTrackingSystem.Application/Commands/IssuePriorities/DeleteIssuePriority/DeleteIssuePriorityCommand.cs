using MediatR;

namespace IssueTrackingSystem.Application.Commands.IssuePriorities.DeleteIssuePriority;

public class DeleteIssuePriorityCommand : IRequest
{
    public int Id { get; set; }
}