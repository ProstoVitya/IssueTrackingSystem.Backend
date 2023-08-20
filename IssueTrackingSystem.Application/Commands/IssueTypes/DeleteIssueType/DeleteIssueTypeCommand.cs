using MediatR;

namespace IssueTrackingSystem.Application.Commands.IssueTypes.DeleteIssueType;

public class DeleteIssueTypeCommand : IRequest
{
    public int Id { get; set; }
}

