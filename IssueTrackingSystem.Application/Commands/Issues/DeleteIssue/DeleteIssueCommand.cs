using IssueTrackingSystem.Domain;
using MediatR;

namespace IssueTrackingSystem.Application.Commands.Issues.DeleteIssue;

public class DeleteIssueCommand : IRequest
{
    public int ProjectId { get; set; }
    public int IssueIndex { get; set; }
}