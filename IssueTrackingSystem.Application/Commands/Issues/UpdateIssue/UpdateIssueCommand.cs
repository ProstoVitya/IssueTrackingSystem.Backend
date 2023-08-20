using MediatR;

namespace IssueTrackingSystem.Application.Commands.Issues.UpdateIssue;

public class UpdateIssueCommand : IRequest
{
    public int IssueIndex { get; set; }
    public int ProjectId { get; set; }
    
    public string Name { get; set; }
    public string? Description { get; set; }
    public int StoryPoints { get; set; }
    public string? DevelopCommit { get; set; }
    public string? ReleaseCommit { get; set; }
    public DateTime Started { get; set; }
    public DateTime? Finished { get; set; }
    public DateTime? FixBefore { get; set; }
    public Guid AssigneeId { get; set; }
    public int IssueTypeId { get; set; }
    public int PriorityId { get; set; }
    public int StatusId { get; set; }
}