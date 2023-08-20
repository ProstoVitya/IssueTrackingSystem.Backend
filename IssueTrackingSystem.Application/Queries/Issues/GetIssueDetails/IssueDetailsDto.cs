using AutoMapper;
using IssueTrackingSystem.Application.Common.Mappings;
using IssueTrackingSystem.Domain;
using IssueTrackingSystem.Domain.Issues;
using IssueTrackingSystem.Domain.Users;

namespace IssueTrackingSystem.Application.Queries.Issues.GetIssueDetails;

public class IssueDetailsDto : IMapWith<Issue>
{
    public int Index { get; }
    public string Name { get; }
    public string? Description { get; }
    public int StoryPoints { get; }
    
    public string? DevelopCommit { get; }
    public string? ReleaseCommit { get; set; }
    
    public DateTime Created { get; }
    public DateTime LastModified { get; }
    public DateOnly Started { get; }
    public DateOnly? Finished { get; }
    public DateOnly? FixBefore { get; }
    
    public User Assignee { get; }
    
    public IssueType Type { get; }
    public IssuePriority Priority { get; }
    public IssueStatus Status { get; }

    public Project Project { get; }
    public User Author { get; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Issue, IssueDetailsDto>();
    }
}