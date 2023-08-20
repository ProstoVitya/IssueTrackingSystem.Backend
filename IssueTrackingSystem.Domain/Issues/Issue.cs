using IssueTrackingSystem.Domain.Users;

namespace IssueTrackingSystem.Domain.Issues;

public class Issue
{
    public int Id { get; set; }
    public int ProjectKey { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int StoryPoints { get; set; }
    
    public string? DevelopCommit { get; set; }
    public string? ReleaseCommit { get; set; }
    
    public DateTime Created { get; set; }
    public DateTime LastModified { get; set; }
    public DateTime Started { get; set; }
    public DateTime? Finished { get; set; }
    public DateTime? FixBefore { get; set; }
    
    public User Assignee { get; set; }
    
    public IssueType Type { get; set; }
    public IssuePriority Priority { get; set; }
    public IssueStatus Status { get; set; }

    public Project Project { get; set; }
    public User Author { get; set; }
}