using AutoMapper;
using IssueTrackingSystem.Application.Commands.Issues.CreateIssue;
using IssueTrackingSystem.Application.Common.Mappings;

namespace IssueTrackingSystem.WebApi.Models;

public class CreateIssueDto : IMapWith<CreateIssueCommand>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public int StoryPoints { get; set; }
    public DateOnly Started { get; set; }
    public DateOnly? FixBefore { get; }
    public Guid AssigneeId { get; set; }
    public int TypeId { get; set; }
    public int PriorityId { get; set; }
    public int StatusId { get; set; }
    public int ProjectId { get; set; }
    
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateIssueDto, CreateIssueCommand>();
    }
}