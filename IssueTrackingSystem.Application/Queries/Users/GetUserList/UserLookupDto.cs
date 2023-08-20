using AutoMapper;
using IssueTrackingSystem.Application.Common.Mappings;
using IssueTrackingSystem.Domain;
using IssueTrackingSystem.Domain.Users;

namespace IssueTrackingSystem.Application.Queries.Users.GetUserList;

public class UserLookupDto : IMapWith<User>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Role Role { get; set; }
    public IEnumerable<Project> RelatedProjects { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserLookupDto>();
    }
}