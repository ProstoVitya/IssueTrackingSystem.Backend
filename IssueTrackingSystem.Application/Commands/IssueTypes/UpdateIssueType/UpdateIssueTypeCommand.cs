using MediatR;

namespace IssueTrackingSystem.Application.Commands.IssueTypes.UpdateIssueType;

public class UpdateIssueTypeCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}