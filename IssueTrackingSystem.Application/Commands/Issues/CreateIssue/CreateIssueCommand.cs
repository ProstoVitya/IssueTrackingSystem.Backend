using MediatR;

namespace IssueTrackingSystem.Application.Commands.Issues.CreateIssue;

public class CreateIssueCommand : IRequest
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public int StoryPoints { get; set; }
    public DateTime Started { get; set; }
    public DateTime? FixBefore { get; }
    public Guid AssigneeId { get; set; }
    public int IssueTypeId { get; set; }
    public int PriorityId { get; set; }
    public int StatusId { get; set; }
    public int ProjectId { get; set; }
    public Guid AuthorId { get; set; }
}