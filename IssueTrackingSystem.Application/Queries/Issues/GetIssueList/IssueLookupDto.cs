using AutoMapper;
using IssueTrackingSystem.Application.Common.Mappings;
using IssueTrackingSystem.Domain;
using IssueTrackingSystem.Domain.Issues;
using IssueTrackingSystem.Domain.Users;

namespace IssueTrackingSystem.Application.Queries.Issues.GetIssueList;

public class IssueLookupDto : IMapWith<Issue>
{
    public int Index { get; set; }
    public Project Project { get; set; }
    public int StoryPoints { get; set; }
    public User Assignee { get; set; }
    public IssueType Type { get; set; }
    public IssuePriority Priority { get; set; }
    public IssueStatus Status { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Issue, IssueLookupDto>();
    }
}