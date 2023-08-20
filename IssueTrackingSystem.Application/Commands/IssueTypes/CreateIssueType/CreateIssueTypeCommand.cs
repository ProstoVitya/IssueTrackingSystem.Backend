using MediatR;

namespace IssueTrackingSystem.Application.Commands.IssueTypes.CreateIssueType;

public class CreateIssueTypeCommand : IRequest
{
    public string Name { get; set; }
}