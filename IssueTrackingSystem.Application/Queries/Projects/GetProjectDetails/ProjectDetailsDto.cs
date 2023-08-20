using AutoMapper;
using IssueTrackingSystem.Application.Common.Mappings;
using IssueTrackingSystem.Domain;
using IssueTrackingSystem.Domain.Issues;
using IssueTrackingSystem.Domain.Users;

namespace IssueTrackingSystem.Application.Queries.Projects.GetProjectDetails;

public class ProjectDetailsDto : IMapWith<Project>
{
    public string Name { get; }
    public string Description { get; }
    public IEnumerable<User> Collaborators { get; }
    public IEnumerable<Issue> Issues { get; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Project, ProjectDetailsDto>();
    }
}