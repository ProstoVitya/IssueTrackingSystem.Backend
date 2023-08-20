using MediatR;

namespace IssueTrackingSystem.Application.Commands.IssueStatuses.UpdateIssueStatus;

public class UpdateIssueStatusCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}