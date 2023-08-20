using MediatR;

namespace IssueTrackingSystem.Application.Commands.IssuePriorities.UpdateIssuePriority;

public class UpdateIssuePriorityCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}