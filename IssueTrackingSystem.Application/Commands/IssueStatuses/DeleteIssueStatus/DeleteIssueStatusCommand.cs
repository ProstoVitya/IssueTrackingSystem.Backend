using MediatR;

namespace IssueTrackingSystem.Application.Commands.IssueStatuses.DeleteIssueStatus;

public class DeleteIssueStatusCommand : IRequest
{
    public int Id { get; set; }
}